using System;
using System.Collections.Generic;
using System.Windows.Forms;

// Author: Daniel McCracken
// Date: 18/06/2020
namespace PC_Parts
{
    // Creating the class as a singleton.
    public sealed partial class frmMain : Form
    {
        private static readonly frmMain _Instance = new frmMain();

        private ColumnHeader _SortingColumn = null;

        private frmMain()
        {
            InitializeComponent();
        }

        public static frmMain Instance
        {
            get { return frmMain._Instance; }
        }

        // Update the UI display with data on form load.
        private void frmMain_Load(object sender, EventArgs e)
        {
            _ = UpdateDisplayAsync();
        }

        // Retrieves all categories as a list and displays within a listview.
        // Ensures the first item is selected by default on form load.
        public async System.Threading.Tasks.Task UpdateDisplayAsync()
        {
            try
            {
                lvCategoryList.Items.Clear();

                List<string> CategoryList = await ServiceClient.GetCategoryNamesAsync();

                foreach (string item in CategoryList)
                {
                    lvCategoryList.Items.Add(item);
                }

                lvCategoryList.Items[0].Selected = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void lvCategoryList_DoubleClick(object sender, EventArgs e)
        {
            viewCategoryProducts();
        }

        private void btnViewCategory_Click(object sender, EventArgs e)
        {
            viewCategoryProducts();
        }

        // Takes the current selected item and runs the next form to display passing the selected item as the parameter.
        private void viewCategoryProducts()
        {
            try
            {
                string lcKey = lvCategoryList.SelectedItems[0].SubItems[0].Text;

                if (lcKey != null)
                {
                    try
                    {
                        frmCategory.Run(lcKey);
                        Visible = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch
            { 
                MessageBox.Show("Please select a category.", "No Category Selected");
            }
        }

        // Opens the orders form.
        private void btnManageOrders_Click(object sender, EventArgs e)
        {
            try
            {
                frmOrder.Run();
                Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Exits the application.
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Column sorter for the list view. Sorting ascending and descending by column header click.
        private void lvCategoryList_ColumnClick(object o, ColumnClickEventArgs e)
        {
            // Get the new sorting column.
            ColumnHeader lcNewSortingColumn = lvCategoryList.Columns[e.Column];

            // Figure out the new sorting order.
            SortOrder lcSortOrder;

            if (_SortingColumn == null)
            {
                // New column to sort ascending.
                lcSortOrder = SortOrder.Ascending;
            }
            else
            {
                // Same column and switch the sort order.
                if (_SortingColumn.Text.StartsWith("> "))
                {
                    lcSortOrder = SortOrder.Descending;
                }
                else
                {
                    lcSortOrder = SortOrder.Ascending;
                }

                // Remove the old sort indicator.
                _SortingColumn.Text = _SortingColumn.Text.Substring(2);
            }

            // Display the new sort order.
            _SortingColumn = lcNewSortingColumn;
            if (lcSortOrder == SortOrder.Ascending)
            {
                _SortingColumn.Text = "> " + _SortingColumn.Text;
            }
            else
            {
                _SortingColumn.Text = "< " + _SortingColumn.Text;
            }

            // Create a comparer.
            lvCategoryList.ListViewItemSorter = new clsListItemComparer(e.Column, lcSortOrder);

            // Sort.
            lvCategoryList.Sort();
        }
    }
}
