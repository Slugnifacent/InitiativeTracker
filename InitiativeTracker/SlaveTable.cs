using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Table {
    class SlaveTable
    {
            ListView panel;

            public SlaveTable(params string[] Column)
            {
                panel = new ListView();
                panel.Dock = DockStyle.Fill;
                panel.GridLines = true;
                panel.View = View.Details;
                panel.Activation = ItemActivation.OneClick;
                panel.AutoSize = true;
                panel.ItemSelectionChanged += yourListView_ItemSelectionChanged;
                if (Column != null)
                {
                    foreach (string column in Column)
                    {
                        AddColumn(column);
                    }
                }
                
        }
        

        private void yourListView_ItemSelectionChanged(
            object sender,
            ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
                e.Item.Selected = false;
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
                panel.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

            public void DeleteRow(int Row)
            {
             panel.Items.Remove(panel.Items[Row]);
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
        }
    }

