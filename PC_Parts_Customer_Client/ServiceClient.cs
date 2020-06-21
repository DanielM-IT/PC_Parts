using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

// Author: Daniel McCracken
// Date: 18/06/2020
namespace PC_Parts_Customer_Client
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
        internal async static Task<string> UpdateProductAsync(clsProduct prProduct)
        {
            return await InsertOrUpdateAsync(prProduct, "http://localhost:60064/api/pcparts/updateproduct", "PUT");
        }

        internal async static Task<string> UpdateProductQuantityAsync(clsProduct prProduct)
        {
            return await InsertOrUpdateAsync(prProduct, "http://localhost:60064/api/pcparts/updateproductquantity", "PUT");
        }

        internal async static Task<string> InsertOrderAsync(clsCustomerOrder prOrder)
        {
            return await InsertOrUpdateAsync(prOrder, "http://localhost:60064/api/pcparts/postorder", "POST");
        }
    }
}
