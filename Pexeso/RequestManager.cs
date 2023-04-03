using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Pexeso
{
    internal class RequestManager
    {
        private static RequestManager _instance = new();

        internal static RequestManager Instance { get => _instance; }

        private RequestManager()
        {
        }
        
        public List<Cat> GetCats(int howMuch)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.thecatapi.com/v1/images/search?limit="+ howMuch + "&api_key=live_UmVSOfZVhBiyX2rfiU3xgJ4EKZKcY7lQgZ9IgMLvAU5sXj14HPDFs8Zjl32HGlKr");

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress);

            var result = client.GetAsync(client.BaseAddress).Result.Content.ReadAsStringAsync().Result;
            List<Cat> cats = JsonConvert.DeserializeObject<List<Cat>>(result);

            foreach (var cat in cats)
            {
                Console.WriteLine(cat.url);
            }
            return cats;
            
        }
    }
}
