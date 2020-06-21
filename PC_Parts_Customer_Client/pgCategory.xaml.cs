using System;
using System.Collections.Generic;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

// Author: Daniel McCracken
// Date: 18/06/2020
namespace PC_Parts_Customer_Client
{
    public sealed partial class pgCategory : Page
    {
        private clsCategory _Category;

        public pgCategory()
        {
            InitializeComponent();
        }

        // Runs when this page is navigated to along with placing any parameter passed into a local variable.
        // Sends request to get all category products which matches the category name passed into the variable if the variable is not null, i.e. no parameter passed.
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string lcCategoryName = e.Parameter.ToString();  
            
            try
            {
                if(!string.IsNullOrEmpty(lcCategoryName))
                    SetDetails(await ServiceClient.GetCategoryProductsAsync(lcCategoryName));
            }
            catch (Exception ex)
            {
                MessageDialog errorDialog = new MessageDialog(ex.ToString());
                await errorDialog.ShowAsync();
            }
        }

        // Takes the passed object and places it into the object instance declared at the top. 
        // Uses the object data to populate the UI text blocks befor calling a display update.
        private void SetDetails(clsCategory prCategory)
        {
            _Category = prCategory;
            tbTitle.Text = _Category.CategoryName;
            tbDescription.Text = _Category.CategoryDescription;

            UpdateDisplay();
        }

        // When called populates or re-populates the list view from previously retrieved object's product list.
        private async void UpdateDisplay()
        {
            lvProductList.ItemsSource = null;
            try
            {                    
                List<string> lcProductDetailsList = new List<string>();
                    foreach (clsProduct item in _Category.ProductList)
                    {
                        lcProductDetailsList.Add("\n" + "Product ID:         " + "#" +
                            item.ProductID + "\n" + "Product Name:   " + 
                            item.ProductName + "\n" + "Qty Available:     " + 
                            item.Quantity.ToString() + "\n" + "Product Price:     " + "$" +
                            item.Price.ToString() + "\n");
                    }
                if (lcProductDetailsList.Count > 0)
                {
                    lvProductList.ItemsSource = lcProductDetailsList;
                }
                else
                {
                    lvProductList.Items.Add("Sorry, there are no products available in this category.");
                }
            }
            catch (Exception ex)
            {
                MessageDialog errorDialog = new MessageDialog(ex.ToString());
                await errorDialog.ShowAsync();
            }

        }

        private void lvProductList_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            viewProduct();
        }

        private void btnViewProduct_Click(object sender, RoutedEventArgs e)
        {
            viewProduct();
        }

        // Called by button click or double click, this method checks that an item in the list is selected before
        // navigating to the next page and passing the selected item's id as a parameter.
        // Displays message if no item is selected.
        private async void viewProduct() 
        {
            try
            {
                int lcProductKey = _Category.ProductList[lvProductList.SelectedIndex].ProductID; ;

                if (lcProductKey != 0)
                {
                    try
                    {
                        Frame.Navigate(typeof(pgProduct), lcProductKey);
                    }
                    catch (Exception ex)
                    {
                        MessageDialog errorDialog = new MessageDialog(ex.ToString());
                        await errorDialog.ShowAsync();
                    }
                }
            }
            catch
            {
                // Custom made message box for no selection error.
                ContentDialog lcErrorDialog = new ContentDialog
                {
                    Title = "No Product Selected",
                    Content = "Please select a product.",
                    CloseButtonText = "Ok"
                };
                await lcErrorDialog.ShowAsync();
            }
        }

        // On button click navigates back to the home page.
        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(pgMain));
        }
    }
}
