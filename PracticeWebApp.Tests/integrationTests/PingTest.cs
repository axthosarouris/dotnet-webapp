using NUnit.Framework;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using PracticeWebApp.Tests.integrationTests;

namespace PracticeWebApp.Tests
{
    internal class PingTest
    {
        private HttpResponseMessage _response = new();
        [SetUp]
        public void SetUpAsync()
        {
            var webApplicationFactory = new CustomWebApplicationFactory<Program>();
            var client = webApplicationFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "/ping");
            _response = client.SendAsync(request).Result;
        }

        [Test]
        public void ShouldReturnSuccessStatusCode()
        {
            _response.EnsureSuccessStatusCode();
        }

        [Test]
        public async Task ShouldReturnHello()
        {
            var actual = JsonConvert.DeserializeObject<Ping>(
                value: await _response.Content.ReadAsStringAsync());

            Assert.AreEqual("Hello", actual?.Message);
        }

    }
}