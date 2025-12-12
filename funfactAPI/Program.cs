using funfactAPI.Services;
using funfactAPI.Modelas;

namespace funfactAPI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // create service objects using their interfaces
            IFactService factService = new FactService();
            IJokeService jokeService = new JokeService();

            // services
            Fact fact = factService.GetRandomFact();
            Joke joke = jokeService.GetRandomJoke();

            // display results
            Console.WriteLine("=== Random  FACT ===\n");
            Console.WriteLine(fact.Text + "\n");


            Console.WriteLine("=== A JOKE ===");
            Console.WriteLine(joke.Setup);
            Console.WriteLine(joke.Punchline);

            Console.WriteLine("\nPress any key to exit");
            Console.ReadKey();
        }
    }
}
