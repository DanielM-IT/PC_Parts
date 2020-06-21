using System;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.SelfHost;

// Author: Daniel McCracken
// Date: 18/06/2020
namespace PC_Parts_Selfhost
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set up server configuration and provide the base url address.
            Uri _baseAddress = new Uri("http://localhost:60064/");
            HttpSelfHostConfiguration config = new HttpSelfHostConfiguration(_baseAddress);
            config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{action}/{id}",
            defaults: new { id = RouteParameter.Optional }
            );

            // Return JSON as the default format
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(
            new MediaTypeHeaderValue("text/html"));

            // Create server
            HttpSelfHostServer server = new HttpSelfHostServer(config);

            // Start listening on the base url address.
            server.OpenAsync().Wait();
            Console.WriteLine("PC Parts Web-API Self hosted on " + _baseAddress);
            Console.WriteLine("Hit ENTER to exit...");
            Console.ReadLine();
            server.CloseAsync().Wait();
        }
    }
}
