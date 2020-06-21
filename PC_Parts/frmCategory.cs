using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

// Author: Daniel McCracken
// Date: 18/06/2020
namespace PC_Parts
{
    public partial class frmCategory : Form
    {
        private clsCategory _Category;

        private ColumnHeader _SortingColumn = null;

        private static Dictionary<string, frmCategory> _CategoryFormList = new Dictionary<string, frmCategory>();

        private frmCategory()
        {
            InitializeComponent();
            cboProductTypeSelection.SelectedIndex = 0;
        }

        // On form run checks if it is opening a new or existing form and does so according to the checks.
        public static void Run(string prCategoryName)
        {
            frmCategory lcCategoryForm;
            if (!_CategoryFormList.TryGetValue(prCategoryName, out lcCategoryForm))
            {
                lcCategoryForm = new frmCategory();
                if (!string.IsNullOrEmpty(prCategoryName))
                {
                    _CategoryFormList.Add(prCategoryName, lcCategoryForm);
                    _ = lcCategoryForm.refreshFormFromDB(prCategoryName);
                }
                else
                {
                    MessageBox.Show("Please select a category.");
                }
            }
            else
            {
                lcCategoryForm.Show();
                lcCategoryForm.Activate();
            }
        }

        // Get all products belonging to the passed category as an object whihc contains a list of objects.
        private async Task refreshFormFromDB(string prCategoryName)
        {
            SetDetails(await ServiceClient.GetCategoryProductsAsync(prCategoryName));
        }

        // Populate the labels.
        private void SetDetails(clsCategory prCategory)
        {
            _Category = prCategory;
            lblCategoryName.Text = _Category.CategoryName;
            lblCategoryDescription.Text = _Category.CategoryDescription;

            UpdateDisplay();
            Show();
        }

        // Populates the list view and set the default selected item to be the first in the index.
        private void UpdateDisplay()
        {
            lvCategoryProducts.Items.Clear();

            foreach (clsProduct p in _Category.ProductList)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(p.ProductID));
                item.SubItems.Add(p.ProductName);
                item.SubItems.Add("$" + Convert.ToString(p.Price));
                item.SubItems.Add(Convert.ToString(p.Quantity));
                item.SubItems.Add(Convert.ToString(p.DateModified));
                lvCategoryProducts.Items.Add(item);
            }

            lvCategoryProducts.Items[0].Selected = true;
        }

        // On button click gets the selected product type and calls create new product form method. 
        // After checking that a product was created will repopulate the product list view.
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                clsProduct lcProduct = clsProduct.NewProduct(cboProductTypeSelection.Text);
                if (lcProduct != null)
                {
                    lcProduct.CategoryName = _Category.CategoryName;
                    frmProduct.CreateProductForm(lcProduct);
                    if (!string.IsNullOrEmpty(lcProduct.ProductName))
                    {
                        _ = refreshFormFromDB(_Category.CategoryName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry, there was an error adding a new product.", ex.Message);
            }
        }

        private void btnEditItem_Click(object sender, EventArgs e)
        {
            viewProduct();
        }

        private void lvCategoryProducts_DoubleClick(object sender, EventArgs e)
        {
            viewProduct();
        }

        // Opens a new product form passing the current selected items id as a parameter.
        private void viewProduct()
        {
            try
            {
                int lcKey = Convert.ToInt32(lvCategoryProducts.SelectedItems[0].SubItems[0].Text);

                clsProduct lcProduct = _Category.ProductList.Find(x => x.ProductID == lcKey);
                frmProduct.CreateProductForm(lcProduct);
                UpdateDisplay();
            }
            catch
            {
                MessageBox.Show("Please select a product.", "No Product Selected");
            }
        }

        // Deletes the current selected item using its id.
        private async void btnDeleteItem_Click(object sender, EventArgs e)
        {
            try
            {
                int lcKey;

                lcKey = Convert.ToInt32(lvCategoryProducts.SelectedItems[0].SubItems[0].Text);
                if (MessageBox.Show("Are you sure you want to delete this product?", "Delete Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        MessageBox.Show(await ServiceClient.DeleteProductAsync(lcKey));
                        _ = refreshFormFromDB(_Category.CategoryName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error with deleting the selected product.");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please select a product.", "No product Selected");
            }
        }

        // Returns to the main form.
        private void btnReturn_Click(object sender, EventArgs e)
        {
            frmMain.Instance.Show();
            Hide();

        }

        // Column sorter for the list view. Sorting ascending and descending by column header click.
        private void lvCategoryProducts_ColumnClick(object o, ColumnClickEventArgs e)
        {
            // Get the new sorting column.
            ColumnHeader lcNewSortingColumn = lvCategoryProducts.Columns[e.Column];

            // Figure out the new sorting order.
            SortOrder lcSortOrder;

            if (_SortingColumn == null)
            {
                // New column and sort ascending.
                lcSortOrder = SortOrder.Ascending;
            }
            else
            {
                // See if this is the same column.
                if (lcNewSortingColumn == _SortingColumn)
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
                }
                else
                {
                    // New column and sort ascending.
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
            lvCategoryProducts.ListViewItemSorter =
                new clsListItemComparer(e.Column, lcSortOrder);

            // Sort.
            lvCategoryProducts.Sort();
        }
    }
}
