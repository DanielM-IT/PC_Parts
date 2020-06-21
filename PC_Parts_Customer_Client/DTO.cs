using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Media.Imaging;

// Author: Daniel McCracken
// Date: 18/06/2020
namespace PC_Parts_Customer_Client
{
    // Classes containing properties which are used as data objects to store and pass data or in some cases a list of data objects.
    public class clsCategory
    {
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

        public List<clsProduct> ProductList { get; set; }
    }

    public class clsProduct
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public DateTime DateModified { get; set; }
        public int Quantity { get; set; }
        public string Condition { get; set; }
        public string Manufacturer { get; set; }
        public char ProductType { get; set; }
        public string ProductImageUrl { get; set; }
        public string CategoryName { get; set; }

        // Retrieves image using provided url, converts to Bitmap format and places into a property.
        private BitmapSource _UriImage { get; set; }

        public BitmapSource UriImage
        {
            get
            {
                if (checkUrlValid(ProductImageUrl))
                {
                    if (_UriImage == null)
                        _UriImage = new BitmapImage(new Uri(ProductImageUrl, UriKind.Absolute));
                }
                return _UriImage;
            }
        }

        // Additional layer of Url validation to check that the url is valid before attempting to use it.
        private static bool checkUrlValid(string strUrl)
        {
            Uri uriResult;
            return Uri.TryCreate(strUrl, UriKind.Absolute, out uriResult) &&
                (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }

    public class clsCustomerOrder
    {
        public int OrderID { get; set; }
        public decimal PriceAtTimeOfOrder { get; set; }
        public int QuantityTotal { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }

        public decimal TotalValueOfCurrentOrders { get; set; }
    }
}
