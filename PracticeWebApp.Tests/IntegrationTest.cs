using NUnit.Framework;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using PracticeWebApp.Tests.integrationTests;

namespace PracticeWebApp.Tests
{
    internal class IntegrationTest
    {
        private HttpResponseMessage? response;
        [SetUp]
        public void SetUpAsync()
        {
            var webApplicationFactory = new CustomWebApplicationFactory<Program>();
            HttpClient client = webApplicationFactory.CreateClient();        
            var request = new HttpRequestMessage(HttpMethod.Get, "/ping");
            response = client.SendAsync(request).Result;            
        }

        [Test]
        public void ShouldReturnSuccessStatusCode()
        {
            response?.EnsureSuccessStatusCode();
        }

        [Test]
        public async Task ShouldReturnHello()
        {            
            var actual = JsonConvert.DeserializeObject<Ping>(
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                value: await response?.Content?.ReadAsStringAsync());
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            Assert.AreEqual("Hello", actual.Message);
        }
       
    }
}
