using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using funfactAPI.Modelas;

namespace funfactAPI.Services
{

    public class FactService : IFactService
    {
        public Fact GetRandomFact()
        {
            // used HttpClient to make a HTTP requests
            using var client = new HttpClient();

            // Call the random fact API (GET request)
            string json = client
                .GetStringAsync("https://uselessfacts.jsph.pl/random.json?language=en")
                .Result;

            using var doc = JsonDocument.Parse(json);

            // Extract the "text" field from the JSON
            string text = doc.RootElement.GetProperty("text").GetString();

            // Return a Fact object with the data
            return new Fact
            { 
                Text = text
            };
        }
    }
}