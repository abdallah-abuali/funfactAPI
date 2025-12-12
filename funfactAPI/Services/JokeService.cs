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
    // Implements IJokeService
    public class JokeService : IJokeService
    {
        public Joke GetRandomJoke()
        {
            using var client = new HttpClient();

            // Call the joke API
            string json = client
                .GetStringAsync("https://official-joke-api.appspot.com/random_joke")
                .Result;

            // Parse the JSON response
            using var doc = JsonDocument.Parse(json);

            // Create and return a Joke object
            return new Joke
            {
                Setup = doc.RootElement.GetProperty("setup").GetString(),
                Punchline = doc.RootElement.GetProperty("punchline").GetString()
            };
        }
    }
}
