using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

// Author: Daniel McCracken
// Date: 18/06/2020
namespace PC_Parts
{
    public static class ServiceClient
    {
        // Gets all categories as a list of strings.
        internal async static Task<List<string>> GetCategoryNamesAsync()
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<string>>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/pcparts/getcategorynames"));
        }

        // Get all products from a specified category which are returned as a data object.
        internal async static Task<clsCategory> GetCategoryProductsAsync(string prCategoryName)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<clsCategory>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/pcparts/getproductlist?categoryname=" + prCategoryName));
        }

        // Get a single product using a product id. Returns it as a data object.
        internal async static Task<clsProduct> GetProductAsync(string prProductID)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<clsProduct>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/pcparts/getproduct?productid=" + prProductID));
        }

        //  Takes update or post request responses and converts them to Json.
        private async static Task<string> InsertOrUpdateAsync<TItem>(TItem prItem, string prUrl, string prRequest)
        {
            using (HttpRequestMessage lcReqMessage = new HttpRequestMessage(new HttpMethod(prRequest), prUrl))
            using (lcReqMessage.Content = new StringContent(JsonConvert.SerializeObject(prItem), Encoding.UTF8, "application/json"))
            using (HttpClient lcHttpClient = new HttpClient())
            {
                HttpResponseMessage lcRespMessage = await lcHttpClient.SendAsync(lcReqMessage);
                return await lcRespMessage.Content.ReadAsStringAsync();
            }
        }

        // These send a request to the controller using the parameter, url and request type. The response data is then passed through the above method.
        internal async static Task<string> InsertProductAsync(clsProduct prProduct)
        {
            return await InsertOrUpdateAsync(prProduct, "http://localhost:60064/api/pcparts/postproduct", "POST");
        }

        internal async static Task<string> UpdateProductAsync(clsProduct prProduct)
        {
            return await InsertOrUpdateAsync(prProduct, "http://localhost:60064/api/pcparts/updateproduct", "PUT");
        }

        // Delete a single product which has the passed id.
        internal async static Task<string> DeleteProductAsync(int prProductID)
        {
            using (HttpClient lcHttpClient = new HttpClient())
            {
                HttpResponseMessage lcResponseMessage = await lcHttpClient.DeleteAsync
                    ($"http://localhost:60064/api/pcparts/deleteproduct?productid={prProductID}");
                return await lcResponseMessage.Content.ReadAsStringAsync();
            }
        }

        // Get all orders with the given status type. Returns them as a list of integers.
        internal async static Task<List<int>> GetOrdersAsync(string prStatus)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<int>>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/pcparts/getorders?status=" + prStatus));
        }

        // Get all details of a single order using the passed id.
        internal async static Task<clsCustomerOrder> GetOrderListAsync(string prOrderID)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<clsCustomerOrder>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/pcparts/getorderdetails?orderid=" + prOrderID));
        }

        // Retrieves the aggregated value of all orders which contain the status whihc is passed.
        internal async static Task<clsCustomerOrder> GetCurrentOrdersValueAsync(string prStatus)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<clsCustomerOrder>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/pcparts/getcurrentordersvalue?status=" + prStatus));
        }

        // Delete a single order which has the passed id.
        internal async static Task<string> DeleteOrderAsync(int prOrderID)
        {
            using (HttpClient lcHttpClient = new HttpClient())
            {
                HttpResponseMessage lcResponseMessage = await lcHttpClient.DeleteAsync
                    ($"http://localhost:60064/api/pcparts/deleteorder?orderid={prOrderID}");
                return await lcResponseMessage.Content.ReadAsStringAsync();
            }
        }
    }
}
