using PC_Parts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;

// Author: Daniel McCracken
// Date: 18/06/2020
namespace PC_Parts_Selfhost
{
    public class PcPartsController : ApiController
    {
        // Gets all category names from the database and passes them into a list of strings.
        public List<string> GetCategoryNames()
        {
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT CategoryName FROM Category ORDER BY CategoryName", null);
            List<string> lcNames = new List<string>();
            foreach (DataRow dr in lcResult.Rows)
                lcNames.Add((string)dr[0]);
            return lcNames;
        }

        // Gets a single category name and description them calls a new method to retrieve all products for the category. 
        // Passes the category data and string of products into a data object class.
        public clsCategory GetProductList(string CategoryName)
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>(1);
            dictionary.Add("CategoryName", CategoryName);
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT * FROM Category WHERE CategoryName = @CategoryName", dictionary);

            if (lcResult.Rows.Count == 1)
                return new clsCategory()
                {
                    CategoryName = (string)lcResult.Rows[0]["CategoryName"],
                    CategoryDescription = (string)lcResult.Rows[0]["CategoryDescription"],

                    ProductList = getProductList(CategoryName)
                };
            else
                return null;
        }

        // Retrieves all products fromt he database which belong to the specified category name then passes each set of results 
        // into a data object and each data object into a list.
        private List<clsProduct> getProductList(string CategoryName)
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>(1); 
            dictionary.Add("CategoryName", CategoryName);
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT * FROM Product WHERE CategoryName = @CategoryName ORDER BY ProductName", dictionary);
            List<clsProduct> lcProducts = new List<clsProduct>();
            foreach (DataRow dr in lcResult.Rows)
                lcProducts.Add(getProductRow(dr));
            return lcProducts;
        }

        // Passes each field of a data row into a corresponding field in a data object.
        private clsProduct getProductRow(DataRow prDataRow)
        {
            return new clsProduct()
            {
                ProductID = Convert.ToInt32(prDataRow["ProductID"]),
                ProductName = Convert.ToString(prDataRow["ProductName"]),
                ProductDescription = Convert.ToString(prDataRow["ProductDescription"]),
                Price = Convert.ToDecimal(prDataRow["Price"]),
                DateModified = Convert.ToDateTime(prDataRow["DateModified"]),
                Quantity = Convert.ToInt16(prDataRow["Quantity"]),
                Condition = prDataRow["Condition"] is DBNull ? null : Convert.ToString(prDataRow["Condition"]),
                Manufacturer = prDataRow["Manufacturer"] is DBNull ? null : Convert.ToString(prDataRow["Manufacturer"]),
                ProductType = Convert.ToChar(prDataRow["ProductType"]),
                ProductImageUrl = prDataRow["ProductImage"] is DBNull ? null : Convert.ToString(prDataRow["ProductImage"]), 
                CategoryName = Convert.ToString(prDataRow["CategoryName"])
            };
        }

        // Retrieves a single product using the provided id and passes it into a data object.
        public clsProduct GetProduct(string ProductID)
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>(1);
            dictionary.Add("ProductID", ProductID);
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT * FROM Product WHERE ProductID = @ProductID", dictionary);

            if (lcResult.Rows.Count == 1)
                return new clsProduct()
                {
                    ProductID = (int)lcResult.Rows[0]["ProductID"],
                    ProductName = (string)lcResult.Rows[0]["ProductName"],
                    ProductDescription = (string)lcResult.Rows[0]["ProductDescription"],
                    Price = (decimal)lcResult.Rows[0]["Price"],
                    DateModified = (DateTime)lcResult.Rows[0]["DateModified"],
                    Quantity = (int)lcResult.Rows[0]["Quantity"],
                    Condition = lcResult.Rows[0]["Condition"] is DBNull ? null : (string)lcResult.Rows[0]["Condition"],
                    Manufacturer = lcResult.Rows[0]["Manufacturer"] is DBNull ? null : (string)lcResult.Rows[0]["Manufacturer"],
                    ProductType = Convert.ToChar(lcResult.Rows[0]["ProductType"]),
                    ProductImageUrl = lcResult.Rows[0]["ProductImage"] is DBNull ? null : (string)lcResult.Rows[0]["ProductImage"],
                    CategoryName = (string)lcResult.Rows[0]["CategoryName"]                
                };
            else
                return null;
        }

        // Inserts a new product into the database using a data object previously destructured into a dictionary.
        public string PostProduct(clsProduct prProduct)
        {
            try
            {
                int lcCount = clsDbConnection.Execute("INSERT INTO Product " +
                    "(ProductName, ProductDescription, Price, DateModified, Quantity, Condition, Manufacturer, " +
                    "ProductType, ProductImage, CategoryName)" +
                    "VALUES (@ProductName, @ProductDescription, @Price, @DateModified, @Quantity, @Condition, " +
                    "@Manufacturer, @ProductType, @ProductImage, @CategoryName)",
                    prepareProductParameters(prProduct));
                if (lcCount == 1)
                {
                    return "Your product has been successfully added.";
                }
                else return "There has been an attempt to insert an unexpected number of products of: " + lcCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        // Updates an existing product in the database using a data object previously destructured into a dictionary. Uses the httpput 
        // method since the word put was not used in the method name. It was changed to increase the code readability.
        [HttpPut]
        public string UpdateProduct(clsProduct prProduct)
        {
            try
            {
                int lcCount = clsDbConnection.Execute("UPDATE Product " +
                    "SET ProductName = @ProductName, ProductDescription = @ProductDescription, Price = @Price, " +
                    "DateModified = @DateModified, Quantity = @Quantity, Condition = @Condition, " +
                    "Manufacturer = @Manufacturer, ProductType = @ProductType, ProductImage = @ProductImage, CategoryName = @CategoryName " +
                    "WHERE ProductID = @ProductID",
                    prepareProductParameters(prProduct));
                if (lcCount == 1)
                {
                    return "Your product has been successfully updated.";
                }
                else 
                    return "There has been an attempt to update an unexpected number of products of: " + lcCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        // Destructures the provided data object into its individual values and adding these into a dictionary ready for adding to the database.
        private Dictionary<string, object> prepareProductParameters(clsProduct prProduct)
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>(11);
            dictionary.Add("ProductID", prProduct.ProductID);
            dictionary.Add("ProductName", prProduct.ProductName);
            dictionary.Add("ProductDescription", prProduct.ProductDescription);
            dictionary.Add("Price", prProduct.Price);
            dictionary.Add("DateModified", prProduct.DateModified);
            dictionary.Add("Quantity", prProduct.Quantity);
            dictionary.Add("Condition", prProduct.Condition);
            dictionary.Add("Manufacturer", prProduct.Manufacturer);
            dictionary.Add("ProductType", prProduct.ProductType);
            dictionary.Add("ProductImage", prProduct.ProductImageUrl);
            dictionary.Add("CategoryName", prProduct.CategoryName);

            return dictionary;
        }

        // Updates an existing products quantity in the database using a data object previously destructured into a dictionary. Uses the httpput 
        // method since the word put was not used in the method name. It was changed to increase the code readability.
        [HttpPut]
        public string UpdateProductQuantity(clsProduct prProduct)
        {
            try
            {
                int lcCount = clsDbConnection.Execute("UPDATE Product " +
                    "SET Quantity = @Quantity WHERE ProductID = @ProductID",
                    prepareQuantityParameters(prProduct));
                if (lcCount == 1)
                {
                    return "Your product has been successfully updated.";
                }
                else
                    return "There has been an attempt to update an unexpected number of products of: " + lcCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        // Destructures the provided data object into its individual values and adding these into a dictionary ready for adding to the database.
        private Dictionary<string, object> prepareQuantityParameters(clsProduct prProduct)
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>(2);
            dictionary.Add("Quantity", prProduct.Quantity);
            dictionary.Add("ProductID", prProduct.ProductID);

            return dictionary;
        }

        // Finds a product that matches the passed id and deletes it.
        public string DeleteProduct(int ProductID)
        {
            try
            {
                int lcCount = clsDbConnection.Execute(
                    "DELETE FROM Product WHERE ProductID = @ProductID",
                    new Dictionary<string, object>(1) { { "ProductID", ProductID } });
                if (lcCount == 1)
                    return "Your product has been successfully deleted.";
                else
                    return "There has been an attempt to delete an unexpected number of products of: " + lcCount;
            }
            catch (Exception ex)
            {
                return  ex.GetBaseException().Message;
            }
        }

        // Gets all orders from the database which have a the specified status and passes them into a list of strings.
        public List<int> GetOrders(string Status)
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>(1);
            dictionary.Add("Status", Status);
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT OrderID FROM CustomerOrder WHERE Status = @Status Order By OrderID", dictionary);
            List<int> lcNames = new List<int>();
            foreach (DataRow dr in lcResult.Rows)
                lcNames.Add((int)dr[0]);
            return lcNames;
        }

        // Retrieves a single order using the provided id and passes it into a data object.
        public clsCustomerOrder GetOrderDetails(string OrderID)
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>(1);
            dictionary.Add("OrderID", OrderID);
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT OrderID, PriceAtTimeOfOrder, QuantityTotal, OrderDate, Status, " +
                "CustomerName, CustomerEmail, Product.ProductID, ProductName, ProductDescription " +
                "FROM CustomerOrder JOIN Product ON Product.ProductID = CustomerOrder.ProductID WHERE OrderID = @OrderID", dictionary);

            if (lcResult.Rows.Count == 1)
                return new clsCustomerOrder()
                {
                    OrderID = (int)lcResult.Rows[0]["OrderID"],
                    PriceAtTimeOfOrder = (decimal)lcResult.Rows[0]["PriceAtTimeOfOrder"],
                    QuantityTotal = (int)lcResult.Rows[0]["QuantityTotal"],
                    OrderDate = (DateTime)lcResult.Rows[0]["OrderDate"],
                    Status = (string)lcResult.Rows[0]["Status"],
                    CustomerName = (string)lcResult.Rows[0]["CustomerName"],
                    CustomerEmail = (string)lcResult.Rows[0]["CustomerEmail"],
                    ProductID = (int)lcResult.Rows[0]["ProductID"],
                    ProductName = (string)lcResult.Rows[0]["ProductName"],
                    ProductDescription = (string)lcResult.Rows[0]["ProductDescription"]
                };
            else
                return null;
        }

        // Inserts a new order into the database using a data object previously destructured into a dictionary.
        public string PostOrder(clsCustomerOrder prOrder)
        {
            try
            {
                int lcCount = clsDbConnection.Execute("INSERT INTO CustomerOrder " +
                    "(PriceAtTimeOfOrder, QuantityTotal, OrderDate, Status, CustomerName, CustomerEmail, ProductID)" +
                    "VALUES (@PriceAtTimeOfOrder, @QuantityTotal, @OrderDate, @Status, @CustomerName, @CustomerEmail, @ProductID)",
                    prepareOrderParameters(prOrder));
                if (lcCount == 1)
                {
                    return "Your order has been successfully added.";
                }
                else return "There has been an attempt to insert an unexpected number of orders of: " + lcCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        // Destructures the provided data object into its individual values and adding these into a dictionary ready for adding to the database.
        private Dictionary<string, object> prepareOrderParameters(clsCustomerOrder prOrder)
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>(7);
            dictionary.Add("PriceAtTimeOfOrder", prOrder.PriceAtTimeOfOrder);
            dictionary.Add("QuantityTotal", prOrder.QuantityTotal);
            dictionary.Add("OrderDate", prOrder.OrderDate);
            dictionary.Add("Status", prOrder.Status);
            dictionary.Add("CustomerName", prOrder.CustomerName);
            dictionary.Add("CustomerEmail", prOrder.CustomerEmail);
            dictionary.Add("ProductID", prOrder.ProductID);

            return dictionary;
        }

        // Gets the product from two fields for each record containing the specified status and then aggregates them all. Passing this aggregate total into 
        // a data object.
        public clsCustomerOrder GetCurrentOrdersValue(string Status)
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>(1);
            dictionary.Add("Status", Status);
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT SUM(PriceAtTimeOfOrder * QuantityTotal) AS PriceAtTimeOfOrder FROM CustomerOrder WHERE Status = @Status GROUP BY Status", dictionary);

            if (lcResult.Rows.Count == 1)
                return new clsCustomerOrder()
                {
                    TotalValueOfCurrentOrders = (decimal)lcResult.Rows[0]["PriceAtTimeOfOrder"],
                };
            else
                return null;
        }

        // Finds a product that matches the passed id and deletes it.
        public string DeleteOrder(int OrderID)
        {
            try
            {
                int lcCount = clsDbConnection.Execute(
                    "DELETE FROM  CustomerOrder WHERE OrderID = @OrderID",
                    new Dictionary<string, object>(1) { { "OrderID", OrderID } });
                if (lcCount == 1)
                    return "Your order has been successfully deleted.";
                else
                    return "There has been an attempt to delete an unexpected number of orders of: " + lcCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }
    }
}

