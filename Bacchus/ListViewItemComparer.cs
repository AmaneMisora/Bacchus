using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bacchus
{
    // Implements the manual sorting of items by columns.
    class ListViewItemComparer : IComparer
    {
        private int Col;
        private SortOrder SortingOrder;

        public ListViewItemComparer()
        {
            Col = 0;
        }

        public ListViewItemComparer(int Column)
        {
            Col = Column;
        }
        public ListViewItemComparer(int Column, SortOrder SortingOrder)
        {
            Col = Column;
            this.SortingOrder = SortingOrder;
        }

        public int Compare(object x, object y)
        {
            int Order;
            if (SortingOrder == SortOrder.Ascending)
            {
                Order = String.Compare(((ListViewItem)x).SubItems[Col].Text, ((ListViewItem)y).SubItems[Col].Text);
            }
            else
            {
                Order = -String.Compare(((ListViewItem)x).SubItems[Col].Text, ((ListViewItem)y).SubItems[Col].Text);
            }
            return Order;
        }
    }
}
