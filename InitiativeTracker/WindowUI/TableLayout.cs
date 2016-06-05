using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InitiativeTracker.WindowUI
{
    class TableLayout
    {
        protected List<Entry> entries;
        protected TableLayoutPanel panel;

        public TableLayout()
        {
            entries = new List<Entry>();

            // Create Panel
            CreatePanel();
        }

        // Initialization Helper
        private void CreatePanel()
        {
            panel = new TableLayoutPanel();
            panel.RowCount = 1;
            panel.ColumnCount = 1;
            panel.Name = "ActorWindow";
            panel.Location = new System.Drawing.Point(0, 0);
            panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            panel.AutoSize = true;
            panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        // User Interface for creating an Entry. 
        public void CreateRow(Entry entry, bool AddButton = true)
        {
            entries.Add(entry);

            int column = 0;
            foreach (EntryComponent component in entry.Components)
            {
                // Dynamically Increase the Column count of the panel to match entries
                AddControlToTable(component.Control, column, panel.RowCount-1);
                column++;
                panel.ColumnCount = Math.Max(column, panel.ColumnCount);
            }
            panel.RowCount++;

            
        }
        
        private void BuildTable()
        {
            panel.Controls.Clear();
            panel.RowCount = 1;
            panel.ColumnCount = 1;

            foreach (Entry entry in entries)
            {
                int column = 0;
                foreach (EntryComponent component in entry.Components)
                {
                    // Dynamically Increase the Column count of the panel to match entries
                    AddControlToTable(component.Control, column, panel.RowCount - 1);
                    column++;
                    panel.ColumnCount = Math.Max(column, panel.ColumnCount);
                }
                panel.RowCount++;
            }
        }

        // Adds control to panel helper
        private void AddControlToTable(Control control, int Column, int Row)
        {
            panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            panel.Controls.Add(control, Column, Row);
            panel.TabIndex = 0;
        }

        public void DeleteEntry(Entry entry)
        {
            // it is assumed there is a first entry
            // and that the panel and entries match
            entries.Remove(entry);
        }

        public void DeleteRow(int Row)
        {
            // it is assumed there is a first entry
            // and that the panel and entries match
           if(Row < entries.Count) entries.RemoveAt(Row);
        }

        public void Sort()
        {
            entries.Sort();
        }

        // Updates panel to show current entries
        // This serves to match the entries with the panel 
        // This must be called after any modifications to the panel or entries
        public void RefreshPanel()
        {
            panel.Visible = false;
            BuildTable();
            panel.Refresh();
            panel.Visible = true;
        }
        
        public void Clear()
        {
            entries.Clear();
            RefreshPanel();
        }

        public Control Panel
        {
            get { return panel; }
        }

        public List<Entry> GetEntries()
        {
            return entries;
        }

        public List<string> GetRowAsStrings(int Row)
        {
            // Iterates Through Panel
            int column = 0;
            List<string> result = new List<string>();
            while (column < panel.ColumnCount)
            {
                Control control = panel.GetControlFromPosition(column, Row);
                if (control != null)
                {
                    result.Add(control.Text);
                }
                column++;
            }
            return result;
        }
        
    }
}
