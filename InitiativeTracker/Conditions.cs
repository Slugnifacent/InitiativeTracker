using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Table
{
    class Conditions : IWindow
    {
        // Fields
        protected Form window;
        CheckedListBox status;
        ListViewItem itm;
        Combatant fighter;

        public Conditions(string Condition, ListViewItem Itm)
        {
            status = new CheckedListBox();
            string[] conditions = Condition.Split(',');
            foreach (string val in conditions)
            {
                status.Items.Add(string.Format("{0}", val.Trim()));
            }
            status.Dock = DockStyle.Fill;
            window = new Form();
            window.Controls.Add(status);
            itm = Itm;
            fighter = Itm.Tag as Combatant;
            window.Text = fighter.CharacterName;
            CreateContextMenu();
        }

        ContextMenuStrip mnu;
        private void CreateContextMenu()
        {
            mnu = new ContextMenuStrip();
            ToolStripMenuItem Add = new ToolStripMenuItem("Add");
            ToolStripMenuItem Remove = new ToolStripMenuItem("Remove Selected");
            //Assign event handlers
            Add.Click += Add_Click;
            Remove.Click += Remove_Click;
            //Add to main context menu
            mnu.Items.AddRange(new ToolStripItem[] { Add, Remove });
            window.ContextMenuStrip = mnu;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            List<string>[] results = WindowManager.Instance().Request(null, "New Condition", true);
            if (results != null)
            {
                foreach (List<String> row in results)
                {
                    if (row[0].CompareTo(" ") != 0) { 
                        fighter.Condition += string.Format(",{0}", row[0].Trim());
                        int indexOfConditions = itm.SubItems.Count - 1;
                        status.Items.Add(string.Format("{0}", row[0].Trim()));
                    }
                }
            }
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            CheckedListBox.CheckedItemCollection selected =  status.CheckedItems;
            // Update Window
            for(int index = 0; selected.Count != 0; index++)
            {
                object item = selected[0];
                status.Items.Remove(item);
            }

            // Update Combatant
            fighter.Condition = "";
            foreach (object row in status.Items)
            {
                string value = row as string;
                fighter.Condition += string.Format("{0},", value.Trim());
            }
        }

        // Called when we enter the window
        public virtual void Enter()
        {
            window.Show();
        }

        // Called when we exit the window
        public virtual void Exit()
        {
            window.Close();
        }
    }
}
