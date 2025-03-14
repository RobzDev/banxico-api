using System;
using System.Net.Http;
using System.Threading.Tasks;

public class Program
{
   public  static async Task Api()
    {
        string token = "1c189f03f7bce05946b878a418c095e2f6d7dd7bf233fef28f626fae359bd9e9";
        string url = "https://www.banxico.org.mx/SieAPIRest/service/v1/token";

        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("Bmx-Token", token);

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Access Token Response:");
                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }
}
