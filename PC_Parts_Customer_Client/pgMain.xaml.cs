using System;
using System.Collections.Generic;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// Author: Daniel McCracken
// Date: 18/06/2020
namespace PC_Parts_Customer_Client
{
    public sealed partial class pgMain : Page
    {
        public pgMain()
        {
            InitializeComponent();
        }

        // Populates the list view control on form load. If an error occures it will display the exception.
        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                List<string> CategoryList = await ServiceClient.GetCategoryNamesAsync();

                foreach (string item in CategoryList)
                {
                    lvCategoryList.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageDialog errorDialog = new MessageDialog(ex.ToString());
                await errorDialog.ShowAsync();
            }
        }

        private void btnViewCategory_Click(object sender, RoutedEventArgs e)
        {
            viewCategoryProducts();
        }

        private void lvCategoryList_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            viewCategoryProducts();
        }

        // Called by button click or double click, this method checks that an item in the list is selected before
        // navigating to the next page and passing the selected item as a parameter.
        // Displays message if no item is selected.
        private async void viewCategoryProducts()
        {
            try
            {
                string lcKey = (string)lvCategoryList.SelectedItems[0]; ;

                if (lcKey != null)
                {
                    try
                    {
                        Frame.Navigate(typeof(pgCategory), lcKey);
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
                    Title = "No Category Selected",
                    Content = "Please select a category.",
                    CloseButtonText = "Ok"
                };
                await lcErrorDialog.ShowAsync();
            }
        }

        // Exits the entire application
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }
    }
}
