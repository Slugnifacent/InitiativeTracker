using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Table
{
    class EditableTable
    {
        DataGridView panel;
        Action<EditableTable> OnSubmit;
        List<string>[] table;

        public EditableTable(Action<EditableTable> Submit_Action, params string[] Column)
        {
            panel = new DataGridView();
            panel.Dock = DockStyle.Fill;
            panel.AutoSize = true;
            CreateContextMenu();
            OnSubmit = Submit_Action;
            if (Column != null)
            { 
                foreach (string column in Column)
                {
                    AddColumn(column);
                }
            }
        }

        ContextMenuStrip mnu;
        private void CreateContextMenu()
        {
            mnu = new ContextMenuStrip();
            ToolStripMenuItem Submit = new ToolStripMenuItem("Submit");
            //Assign event handlers
            Submit.Click += Submit_Click;
            //Add to main context menu
            mnu.Items.AddRange(new ToolStripItem[] { Submit });
            panel.ContextMenuStrip = mnu;
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            if(OnSubmit != null)
            OnSubmit(this);
        }

        public void AddColumn(string text)
        {
            DataGridViewColumn column = new DataGridViewColumn();
            panel.Columns.Add(text, text);
        }

        public void AddRow()
        {
            DataGridViewColumn column = new DataGridViewColumn();
            panel.Rows.Add(1);
        }

        public void DisableAutoRow(bool TrueFalse)
        {
            panel.AllowUserToAddRows = !TrueFalse;
        }

        public List<string>[] GetRows()
        {
            table = new List<string>[panel.Rows.Count];
            List<string> values = new List<string>();
             
            for(int index = 0; index < panel.Rows.Count; index++)
            {
                DataGridViewRow Row = panel.Rows[index];
                values.Clear();
                for (int endex = 0; endex < Row.Cells.Count; endex++)
                {
                    DataGridViewCell cell = Row.Cells[endex];
                    string str = " ";
                    if (cell.IsInEditMode == true)
                    {
                        str = (cell.EditedFormattedValue == null) ? " " : cell.EditedFormattedValue.ToString();
                    }
                    else {
                        str = (cell.Value == null) ? " " : cell.Value.ToString();
                    }
                   
                    values.Add(str);
                }
                table[index] = new List<string>(values);
            }
            return table;
        }


        public List<string> GetRow(int Row)
        {
            List<string> value = new List<string>();
            if (Row < panel.Rows.Count)
            {
                foreach (DataGridViewCell cell in panel.Rows[Row].Cells)
                {
                    if (cell.Value != null) { 
                        value.Add(cell.Value.ToString());
                    }
                }
            }
            return value;
        }

        public Control CONTROL
        {
            get { return panel; }
        }
    }
}
