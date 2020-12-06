using Clients;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookApiConsumer
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            var httpClient = new HttpClient();
            var client = new BookApiClient(httpClient, false)
            {
                BaseUri = new Uri("http://localhost:5000")
            };

            var authors = await client.Authors.GetAllAuthorsAsync();

            foreach (var author in authors)
            {
                Console.WriteLine($"Name: {author.Name}");
            }

            return 0;
        }
    }
}
