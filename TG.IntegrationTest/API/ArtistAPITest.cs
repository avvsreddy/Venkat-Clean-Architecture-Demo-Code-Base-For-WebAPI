using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using TG.CandidateProfiling.API;
using NUnit.Framework;

namespace Chinook.IntegrationTest.API
{
    public class ArtistApiTest
    {
        private readonly HttpClient _client;

        public ArtistApiTest()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                
                .UseStartup<Startup>());
            _client = server.CreateClient();
        }

       [Test]
        public async Task ArtistGetAllTest(string method="GET")
        {
            // Arrange
            var request = new HttpRequestMessage(new HttpMethod(method), "/api/Artist/");

            // Act
            var response = await _client.SendAsync(request);

            // Assert
            Assert.Equals(HttpStatusCode.OK, response.StatusCode);
        }

       [Test]
        public async Task ArtistGetTestByID()
        {
            // Arrange
            var request = new HttpRequestMessage(new HttpMethod("GET"), $"http://localhost:44335/api/Album/artist/1");

            // Act
            var response = await _client.SendAsync(request);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
