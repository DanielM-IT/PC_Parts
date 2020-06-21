using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

// Author: Daniel McCracken
// Date: 18/06/2020
namespace PC_Parts
{
    public partial class frmOrder : Form
    {
        private clsCustomerOrder _Order;

        private ColumnHeader _SortingColumn = null;

        private static Dictionary<string, frmOrder> _OrderFormList = new Dictionary<string, frmOrder>();

        public frmOrder()
        {
            InitializeComponent();
        }

        // Sets a variable for pending orders as well as instantiates a new order form. 
        // Passes the status to called methods.
        public static void Run()
        {
            frmOrder lcOrderForm;
            string lcStatus = "Pending";
            if (!_OrderFormList.TryGetValue(lcStatus, out lcOrderForm))
            {
                lcOrderForm = new frmOrder();
                _OrderFormList.Add(lcStatus, lcOrderForm);
                lcOrderForm.setTotalOrderPrice(lcStatus);
                lcOrderForm.updateDisplay(lcStatus);
                lcOrderForm.Show();
            }
            else
            {
                lcOrderForm.Show();
                lcOrderForm.Activate();
            }
        }

        // Gets all pending orders and places them in a list. Uses the list of orders to populate the list view.
        private async void updateDisplay(string prStatus)
        {
            lvOrderList.Items.Clear();
;
            List<int> OrderList = await ServiceClient.GetOrdersAsync(prStatus);

            foreach (int item in OrderList)
            {
                lvOrderList.Items.Add(Convert.ToString(item));
            }

            lvOrderList.Items[0].Selected = true;
            getSelectedItemKey();
        }

        // Retrieves and displays details of the selected order item.
        private void lvOrderList_Click(object sender, EventArgs e)
        {
            getSelectedItemKey();
        }

        // Retrieve the order id of the current selected item.
        private void getSelectedItemKey()
        {
            string lcKey;

            lcKey = lvOrderList.SelectedItems[0].SubItems[0].Text;
            _ = refreshFormFromDB(lcKey);
        }

        // Takes retrieved order id and retrieves all its order details as a data object.
        private async Task refreshFormFromDB(string prOrderID)
        {
            SetDetails(await ServiceClient.GetOrderListAsync(prOrderID));
        }

        // Gets total value of all pending orders as a string.
        private async void setTotalOrderPrice(string prStatus)
        {
            SetDetails(await ServiceClient.GetCurrentOrdersValueAsync(prStatus));
        }

        // Takes the order object retrieved and uses it to populate all labels.
        private void SetDetails(clsCustomerOrder prOrder)
        {
            _Order = prOrder;

            // Populates the total value label.
            if (_Order.Status == null)
            {
                lblTotalOrderValue.Text = "$" + Convert.ToString(_Order.TotalValueOfCurrentOrders);
            }
            // Populates all other labels.
            else
            {
                lblOrderID.Text = Convert.ToString(_Order.OrderID);
                lblDate.Text = (_Order.OrderDate).ToString("dd/MM/yyyy");
                lblQuantity.Text = Convert.ToString(_Order.QuantityTotal);
                lblCustomerName.Text = _Order.CustomerName;
                lblCustomerEmail.Text = _Order.CustomerEmail;
                lblProductName.Text = _Order.ProductName;
                lblProductDescription.Text = _Order.ProductDescription;
                lblPriceAtTimeOfOrder.Text = "$" + Convert.ToString(_Order.PriceAtTimeOfOrder);
                lblSelectedOrderValue.Text = "$" + Convert.ToString(_Order.PriceAtTimeOfOrder * _Order.QuantityTotal);
            }
        }

        // On button click confirms if the deletion was wanted then on confirmation retrieves the current selected orders id and passes it into a variabl.
        // Takes the id variable and sends it off with a delete request.
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int lcKey;

                lcKey = Convert.ToInt32(lvOrderList.SelectedItems[0].SubItems[0].Text);
                if (MessageBox.Show("Are you sure you want to delete this order?", "Delete order", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        MessageBox.Show(await ServiceClient.DeleteOrderAsync(lcKey));
                        updateDisplay("Pending");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error with deleting the selected order.");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please select an order.", "No order Selected");
            }
        }

        // Hides this form and displays the main form.
        private void btnReturn_Click(object sender, EventArgs e)
        {
            frmMain.Instance.Show();
            Hide();
        }

        // Column sorter for the list view. Sorting ascending and descending by column header click.
        private void lvOrderList_ColumnClick(object o, ColumnClickEventArgs e)
        {
            // Get the new sorting column.
            ColumnHeader lcNewSortingColumn = lvOrderList.Columns[e.Column];

            // Figure out the new sorting order.
            SortOrder lcSortOrder;

            if (_SortingColumn == null)
            {
                // New column and sort ascending.
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
            lvOrderList.ListViewItemSorter = new clsListItemComparer(e.Column, lcSortOrder);

            // Sort.
            lvOrderList.Sort();
        }
    }
}
