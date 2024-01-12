using System;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    public class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();

            var kanyeAPi = "https://api.kanye.rest";

            var ronSwanApi = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";

            for (int i = 0; i <= 5; i++)
            {
                var ronResponse = client.GetStringAsync(ronSwanApi).Result;
                var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Replace('"', ' ').Replace('"', ' ').Trim();

                Console.WriteLine($"Ron: {ronQuote}");
                Console.WriteLine();

                var KanyeResponse = client.GetStringAsync(kanyeAPi).Result;
                var KanyeQuote = JObject.Parse(KanyeResponse).GetValue("quote").ToString();

                Console.WriteLine($"Kanye: {KanyeQuote}");
                Console.WriteLine();
            }
        }
    }
}
