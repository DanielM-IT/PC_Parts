using System;
using System.Collections;
using System.Windows.Forms;

// Author: Daniel McCracken
// Date: 18/06/2020
namespace PC_Parts
{
    public class clsListItemComparer : IComparer
    {
        private int _Column;
        private SortOrder _SortOrder;

        // Create variables for the column and sort order.
        public clsListItemComparer(int column, SortOrder sortOrder)
        {
            _Column = column;
            _SortOrder = sortOrder;
        }

        // Take two items and compare them. Rearranging will be done if their current position is not 
        // correct according to the sort order specified by the user.
        public int Compare(object object_x, object object_y)
        {
            ListViewItem item_x = object_x as ListViewItem;
            ListViewItem item_y = object_y as ListViewItem;

            string string_x;
            if (item_x.SubItems.Count <= _Column)
            {
                string_x = "";
            }
            else
            {
                string_x = item_x.SubItems[_Column].Text;
            }

            string string_y;
            if (item_y.SubItems.Count <= _Column)
            {
                string_y = "";
            }
            else
            {
                string_y = item_y.SubItems[_Column].Text;
            }

            // Compare the items.
            int result;
            double double_x, double_y;
            // Checks if they are a number and if so compares them as such.
            if (double.TryParse(string_x, out double_x) &&
                double.TryParse(string_y, out double_y))
            {
                result = double_x.CompareTo(double_y);
            }
            else
            {
                // Checks if they are a date and if so compares them as such.
                DateTime date_x, date_y;
                if (DateTime.TryParse(string_x, out date_x) &&
                    DateTime.TryParse(string_y, out date_y))
                {
                    // Treat as a date.
                    result = date_x.CompareTo(date_y);
                }
                // Defaults to treating them as a string for comparison.
                else
                {
                    // Treat as a string.
                    result = string_x.CompareTo(string_y);
                }
            }

            // Return the correct result depending on whether sorting ascending or descending.
            if (_SortOrder == SortOrder.Ascending)
            {
                return result;
            }
            else
            {
                return -result;
            }
        }
    }
}
