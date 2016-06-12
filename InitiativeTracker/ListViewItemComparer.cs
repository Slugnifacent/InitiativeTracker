﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Table
{
    class ListViewItemComparer : IComparer
    {
        private int col;
        public ListViewItemComparer()
        {
            col = 0;
        }
        public ListViewItemComparer(int column)
        {
            col = column;
        }
        public int Compare(object x, object y)
        {
            int left = int.Parse( ((ListViewItem)x).SubItems[col].Text);
            int right = int.Parse(((ListViewItem)y).SubItems[col].Text);

            return left.CompareTo(right);
        }
    }
}
