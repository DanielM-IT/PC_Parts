using System;
using System.Collections.Generic;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// Author: Daniel McCracken
// Date: 18/06/2020
namespace PC_Parts_Customer_Client
{
    public sealed partial class pgProduct : Page
    {
        private clsProduct _Product;

        public delegate void LoadProductControlDelegate(clsProduct prProduct);
        private Dictionary<char, Delegate> _ProductControl;

        // Dynamically invokes the correct delagate form the dictionary using the products product type.
        private void GetProductTypeControl(clsProduct prProduct)
        {
            _ProductControl[prProduct.ProductType].DynamicInvoke(prProduct);
        }

        public pgProduct()
        {
            InitializeComponent();

            // Dictionary of available delegates.
            _ProductControl = new Dictionary<char, Delegate>
            {
                { 'N', new LoadProductControlDelegate(RunNewProduct)},
                { 'U', new LoadProductControlDelegate(RunUsedProduct)}
            };
        }

        // These create new instances of each user control. A sort of form of inheritance within UWP's.
        private void RunNewProduct(clsProduct prProduct)
        {
            ctcProductSpecs.Content = new ucNewProduct();
        }

        private void RunUsedProduct(clsProduct prProduct)
        {
            ctcProductSpecs.Content = new ucUsedProduct();
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
        // Uses the object data to populate the UI text blocks including those which are provided using a user control.
        private void SetDetails(clsProduct prProduct)
        {
            _Product = prProduct;
            tbTitle.Text = _Product.ProductName;
            tbDescription.Text = _Product.ProductDescription;
            tbDisplayedProductId.Text = "#" + Convert.ToString(_Product.ProductID);
            tbDisplayedPrice.Text = "$" + Convert.ToString(_Product.Price);
            tbDisplayedQuantity.Text = Convert.ToString(_Product.Quantity);

            GetProductTypeControl(_Product as clsProduct);
            (ctcProductSpecs.Content as IProductControl).UpdateControl(_Product);

            // After checking that there is a url available gets the image in Bitmap format and passes it into the xaml image source. 
            if (_Product.ProductImageUrl != null)
            {
                if (_Product.UriImage != null)
                    iProduct.Source = _Product.UriImage;
            }
        }

        // Navigates to the order page on button click passing the current product objects id.
        private void btnOrderProduct_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(pgOrder), _Product.ProductID);
        }

        // Navigates to the category page on button click passing the category name of the current product object.
        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(pgCategory), _Product.CategoryName);
        }
    }
}
