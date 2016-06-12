using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Table
{
    class Table
    {
        ListView panel;
        SlaveTable slave;

        public Table(string[] Column, SlaveTable SlaveTab = null)
        {
            panel = new ListView();
            panel.Dock = DockStyle.Fill;
            panel.GridLines = true;
            panel.View = View.Details;
            panel.Activation = ItemActivation.OneClick;
            panel.FullRowSelect = true;
            panel.MouseClick += MouseClick;
            panel.LabelWrap = true;
            
            
            CreateContextMenu();
            if (Column != null)
            {
                foreach (string column in Column)
                {
                    AddColumn(column);
                }
            }

           
            slave = SlaveTab;
        }

        ContextMenuStrip mnu;
        private void CreateContextMenu()
        {
            mnu = new ContextMenuStrip();
            ToolStripMenuItem Add = new ToolStripMenuItem("Add");
            ToolStripMenuItem Remove = new ToolStripMenuItem("Remove");
            ToolStripMenuItem Condition = new ToolStripMenuItem("Condition");
            ToolStripMenuItem MoreInfo = new ToolStripMenuItem("More Info");
            //Assign event handlers
            Add.Click += Add_Click;
            Remove.Click += Remove_Click;
            Condition.Click += Condition_Click;
            MoreInfo.Click += MoreInfo_Click;
            //Add to main context menu
            mnu.Items.AddRange(new ToolStripItem[] { Add, Remove, Condition, MoreInfo });
            panel.ContextMenuStrip = mnu;
        }

        private void MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (panel.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    mnu.Show(Cursor.Position);
                }
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            List<string> headers = new List<string>();
            foreach (ColumnHeader head in panel.Columns)
            {
                headers.Add(head.Text);
            }
            headers.Add("More Info");
            headers.Add("Conditions");
            List<string>[] results = WindowManager.Instance().Request(headers.ToArray(),"Add Combatant");
            if (results != null)
            { 
                foreach (List<string> row in results)
                {
                    // TODO Check if this works on empty lists properly
                    if (row != null)
                    {
                        AddRow(row.ToArray());
                    }
                }
                if (panel.Items.Count > 0) panel.ContextMenuStrip = null;
            }
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            // Try to cast the sender to a ToolStripItem
            ListViewItem itm = panel.FocusedItem;
            if (slave != null) slave.DeleteRow(panel.FocusedItem.Index);
            panel.Items.Remove(itm);
            if (panel.Items.Count == 0) panel.ContextMenuStrip = mnu;
        }

        private void Condition_Click(object sender, EventArgs e)
        {
            ListViewItem itm = panel.FocusedItem;
            Combatant combatant = itm.Tag as Combatant;
            WindowManager.Instance().Conditions(combatant.Condition,itm);
        }

        private void MoreInfo_Click(object sender, EventArgs e)
        {
            ListViewItem itm = panel.FocusedItem;
            Combatant combatant = itm.Tag as Combatant;
            WindowManager.Instance().MoreInfo(combatant.CharacterName,combatant.ToArray());
        }

        public void AddColumn(string text)
        {
            panel.Columns.Add(text);
        }

        public void AddRow(params string[] Information)
        {
            AddRow(new Combatant(Information));
        }

        public void AddRow(Combatant fighter)
        {
            if (fighter == null) return;
            string[] elements = fighter.ToArray();
            ListViewItem itm = new ListViewItem(elements);
            itm.Tag = fighter;
            panel.Items.Add(itm);
            if(slave != null) slave.AddRow(elements);
            panel.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        public void Sort()
        {
            panel.ListViewItemSorter = new ListViewItemComparer(0);
            panel.Sorting = SortOrder.Ascending;
            panel.Sort();
            panel.Sorting = SortOrder.None;
            panel.ListViewItemSorter = null;
        }

        public ListView.ListViewItemCollection GetRows()
        {
            return panel.Items;
        }
        
        public Control CONTROL
        {
            get { return panel; }
        }

        public Control SLAVECONTROL
        {
            get { return slave.CONTROL; }
        }
    }
}
