using Clients;
using IdentityModel.Client;
using Microsoft.Rest;
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
            var disco = await httpClient.GetDiscoveryDocumentAsync("http://localhost:5000");
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return 1;
            }

            // request token
            // client credentials would be used in service-to-service authentication and the
            // returned token would most likely be a relatively long lived JWT
            var tokenResponse = await httpClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,

                ClientId = "book-api-consumer",
                ClientSecret = "secret",
                Scope = "book-api.full-access"
            });

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return 1;
            }

            Console.WriteLine(tokenResponse.Json);

            var apiClient = new BookApiClient(new TokenCredentials(tokenResponse.AccessToken), 
                httpClient, false)
            {
                BaseUri = new Uri("http://localhost:5001")
            };

            // query API
            var authors = await apiClient.Authors.GetAllAsync();

            foreach (var author in authors)
            {
                Console.WriteLine($"Name: {author.Name}");
            }

            return 0;
        }
    }
}
