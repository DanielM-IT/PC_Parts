using System;
using System.Linq;
using System.Net.Mail;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// Author: Daniel McCracken
// Date: 18/06/2020
namespace PC_Parts_Customer_Client
{
    public sealed partial class pgOrder : Page
    {
        // New instance of each class created.
        private clsProduct _Product;
        private clsCustomerOrder _Order;

        public pgOrder()
        {
            InitializeComponent();
        }

        // Runs when this page is navigated to along with placing any parameter passed into a local variable.
        // Sends request to get a product which matches the product Id passed into the variable as long as the variable is not null, i.e. no parameter passed.
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string lcProductId = e.Parameter.ToString();

            try
            {
                if (!string.IsNullOrEmpty(lcProductId))
                    SetDetails(await ServiceClient.GetProductAsync(lcProductId));
            }
            catch (Exception ex)
            {
                MessageDialog errorDialog = new MessageDialog(ex.ToString());
                await errorDialog.ShowAsync();
            }
        }

        // Takes the passed object and places it into the object instance declared at the top. 
        // Uses the object data to populate the UI text blocks.
        private void SetDetails(clsProduct prProduct)
        {
            _Product = prProduct;
            tbDisplayedProductName.Text = _Product.ProductName;
            tbDisplayedProductId.Text = "#" + Convert.ToString(_Product.ProductID);
            tbDisplayedPrice.Text = "$" + Convert.ToString(_Product.Price);
            tbDisplayedQuantity.Text = Convert.ToString(_Product.Quantity);
        }        

        // Text changed event which updates the order total text block based on the product of the quantity and price. 
        // If there is no text in the field it will default to 0.
        private void txtQuantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtQuantity.Text))
                tbDisplayedOrderTotal.Text = Convert.ToString(Convert.ToInt32(txtQuantity.Text) * Convert.ToDecimal(tbDisplayedPrice.Text.TrimStart('$')));
            else
                txtQuantity.Text = Convert.ToString(0);
        }

        // Calls field validation on button click. If passes then continues with order submission.
        private void btnPlaceOrder_Click(object sender, RoutedEventArgs e)
        {
            if(validateFields())
            {
                orderSubmission();
            }
        }

        // Event allowing user to only insert digits into the text field.
        private void txtQuantity_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !char.IsDigit(c));
        }

        // Validates all fields checking that they have input then double checking that quantity field only has 
        // digits and that a valid email has been provided.
        private bool validateFields()
        {
            if (!string.IsNullOrWhiteSpace(txtQuantity.Text) 
                && !string.IsNullOrWhiteSpace(txtCustomerName.Text)
                && !string.IsNullOrWhiteSpace(txtCustomerEmail.Text))
            {
                if(txtQuantity.Text.All(char.IsDigit))
                {
                    if(Convert.ToInt32(txtQuantity.Text) <= Convert.ToInt32(tbDisplayedQuantity.Text))
                    {
                        try
                        {
                            MailAddress lcMailAddress = new MailAddress(txtCustomerEmail.Text);
                            return true;
                        }
                        catch (FormatException)
                        {
                            inputMessages("Invalid Email");
                            return false;
                        }
                    }
                    else
                    {
                        inputMessages("Invalid Quantity");
                        return false;
                    }
                }
                else
                {
                    inputMessages("Invalid Input");
                    return false;
                }
            }
            else
            {
                inputMessages("Empty");
                return false;
            }
        }

        // Messages shown for failed validation.
        private async void inputMessages(string prWrongType)
        {
            if (prWrongType == "Invalid Input")
            {
                ContentDialog lcInvalidInput = new ContentDialog
                {
                    Title = "Invalid Input ",
                    Content = "You have entered invalid input.",
                    CloseButtonText = "Ok"
                };
                await lcInvalidInput.ShowAsync();
            }
            else if(prWrongType == "Empty")
            {
                ContentDialog lcEmptyFields = new ContentDialog
                {
                    Title = "Empty Fields",
                    Content = "Please fill in all fields.",
                    CloseButtonText = "Ok"
                };
                await lcEmptyFields.ShowAsync();
            }
            else if (prWrongType == "Invalid Email")
            {
                ContentDialog lcInvalidInput = new ContentDialog
                {
                    Title = "Invalid Email ",
                    Content = "Please enter a valid email address.",
                    CloseButtonText = "Ok"
                };
                await lcInvalidInput.ShowAsync();
            }
            else if (prWrongType == "Invalid Quantity")
            {
                ContentDialog lcInvalidQuantity = new ContentDialog
                {
                    Title = "Invalid Quantity ",
                    Content = "The quantity requested is greater than what is available. Please re-enter your quantity.",
                    CloseButtonText = "Ok"
                };
                await lcInvalidQuantity.ShowAsync();
            }
        }

        // Called if validation passes. Displays user with a confirmation window before pushing the data.
        private async void orderSubmission()
        {
            try
            {
                ContentDialog lcConfirmtion = new ContentDialog
                {
                    Title = "Order Confirmation",
                    Content = "Please confirm your order.",
                    PrimaryButtonText = "Place Order",
                    CloseButtonText = "Cancel"
                };
                var lcResult = await lcConfirmtion.ShowAsync();

                if(lcResult == ContentDialogResult.Primary)
                {
                    string lcCategory = _Product.CategoryName;
                    _Product = await ServiceClient.GetProductAsync(tbDisplayedProductId.Text.TrimStart('#'));

                    if (_Product != null)
                    {
                        pushData();
                        createNewOrder();
                    }
                    else
                    {
                        ContentDialog lcProductUnavailable = new ContentDialog
                        {
                            Title = "Product Unavailable",
                            Content = "Sorry, this product is no longer available.",
                            SecondaryButtonText = "Return to Products"
                        };
                        var lcNoProductResult = await lcProductUnavailable.ShowAsync();

                        if (lcNoProductResult == ContentDialogResult.Secondary)
                        {
                            Frame.Navigate(typeof(pgCategory), lcCategory);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDialog errorDialog = new MessageDialog(ex.ToString());
                await errorDialog.ShowAsync();
            }
        }

        // Sends data provided into an object.
        private void pushData()
        {
            clsCustomerOrder lcOrder = new clsCustomerOrder();

            lcOrder.PriceAtTimeOfOrder = Convert.ToDecimal(tbDisplayedPrice.Text.TrimStart('$'));
            lcOrder.OrderDate = DateTime.Now;
            lcOrder.Status = "Pending";
            lcOrder.CustomerName = txtCustomerName.Text;
            lcOrder.CustomerEmail = txtCustomerEmail.Text;
            lcOrder.ProductID = _Product.ProductID;
            lcOrder.QuantityTotal = Convert.ToInt32(txtQuantity.Text);

            _Order = lcOrder;
        }

        // Takes the object previously created and populated.
        // Gets the current quantity of the product and checks it aginst the quantity provided by the user .
        // If quantity is available then updates the product in the database subtracting the quantity orderes. If unavailable then displays error message to user.
        // New order request sent to the database.
        // If there is an error in any of the processes display an error message.
        private async void createNewOrder()
        {
            try
            {
                if (_Product != null)
                {
                    if (Convert.ToInt32(txtQuantity.Text) <= _Product.Quantity)
                    {
                        _Product.Quantity -= Convert.ToInt32(txtQuantity.Text);

                        await ServiceClient.UpdateProductQuantityAsync(_Product);
                        await ServiceClient.InsertOrderAsync(_Order);

                        Frame.Navigate(typeof(pgOrderConfirmation));
                    }
                    else
                    {
                        SetDetails(_Product);

                        ContentDialog lcNotEnoughStock = new ContentDialog
                        {
                            Title = "Stock Unavailable",
                            Content = "Sorry, there has been a change in the quantity of this item and the number requested is no longer available. " +
                            "Please return to your order to see updated stock levels.",
                            CloseButtonText = "Return to Order",
                        };
                        await lcNotEnoughStock.ShowAsync();
                    }
                }
            }
            catch (Exception)
            {
                ContentDialog lcErrorDialog = new ContentDialog
                {
                    Title = "Order Error",
                    Content = "Sorry, there has been an error placing your order.",
                    CloseButtonText = "Return to Order",
                    SecondaryButtonText = "Return Home"
                };
                var lcResult = await lcErrorDialog.ShowAsync();

                if (lcResult == ContentDialogResult.Secondary)
                {
                    Frame.Navigate(typeof(pgMain));
                }
            }
        }

        // On button click navigates back to the product page passing the product id as a parameter.
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(pgProduct), _Product.ProductID);
        }
    }
}
