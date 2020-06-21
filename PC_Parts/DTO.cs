using System;
using System.Collections.Generic;

// Author: Daniel McCracken
// Date: 18/06/2020
namespace PC_Parts
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

        // Returns the product type as a single character char converted to uppercase.
        public static clsProduct NewProduct(string prSelection)
        {
            return new clsProduct() { ProductType = Convert.ToChar(prSelection.ToUpper().Substring(0, 1)) };
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
