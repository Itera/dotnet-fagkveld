using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Xunit;

namespace API.Integrationtests
{
    public class ValuesControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        
        public ValuesControllerTests()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task Should_Return_List_Of_Values()
        {
            var response = await _client.GetAsync("/api/values/");
            response.EnsureSuccessStatusCode();

            var items = JsonConvert.DeserializeObject<string[]>(
                await response.Content.ReadAsStringAsync());

            Assert.Equal("value1", items[0]);
            Assert.Equal("value2", items[1]);
        }

        [Fact]
        public async Task Should_Support_Content_Negotiation_Xml()
        {
            var response = await _server
                .CreateRequest("/api/values")
                .AddHeader("Accept", "application/xml")
                .GetAsync();

            response.EnsureSuccessStatusCode();

            Assert.Equal("application/xml", response.Content.Headers.ContentType.MediaType);
            Assert.Equal("utf-8", response.Content.Headers.ContentType.CharSet);
        }
    }
}
