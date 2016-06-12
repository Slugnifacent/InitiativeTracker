using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InitiativeTracker.WindowUI
{
    class ListLayout
    {
        protected ListView panel;
        protected List<Entry> entries;
        public ListLayout()
        {
            entries = new List<Entry>();
            // Create Panel
            CreatePanel();
        }

        // Initialization Helper
        private void CreatePanel()
        {
            panel = new ListView();
            panel.View = View.Details;
            panel.GridLines = true;
            panel.FullRowSelect = true;

            //Add column header
            panel.Columns.Add("ProductName", 100);
            panel.Columns.Add("Price", 70);
            panel.Columns.Add("Quantity", 70);

            //Add items in the listview
            string[] arr = new string[4];
            ListViewItem itm;

            //Add first item
            arr[0] = "product_1";
            arr[1] = "100";
            arr[2] = "10";
            itm = new ListViewItem(arr);
            panel.Items.Add(itm);

            //Add second item
            arr[0] = "product_2";
            arr[1] = "200";
            arr[2] = "20";
            itm = new ListViewItem(arr);
            panel.Items.Add(new ListViewItem(arr));
        }

        // User Interface for creating an Entry. 
        public void CreateRow(Entry entry, bool AddButton = true)
        {

        }

        private void BuildTable()
        {
  
        }
        
        public void DeleteEntry(Entry entry)
        {
            // it is assumed there is a first entry
            // and that the panel and entries match
        }

        public void DeleteRow(int Row)
        {
            // it is assumed there is a first entry
            // and that the panel and entries match
            panel.Items.RemoveAt(Row);
        }

        public void Sort()
        {
        }

        // Updates panel to show current entries
        // This serves to match the entries with the panel 
        // This must be called after any modifications to the panel or entries
        public void RefreshPanel()
        {
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

            return new List<string>(); ;
        }
    }
}
