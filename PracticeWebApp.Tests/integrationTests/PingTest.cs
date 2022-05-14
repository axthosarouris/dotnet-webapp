using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;

namespace PracticeWebApp.Tests.integrationTests
{
    public partial class PingTest
    {
        private HttpResponseMessage _response = new();

        [SetUp]
        public void SetUpAsync()
        {
            var webApplicationFactory = new CustomWebApplicationFactory<Program>();
            var client = webApplicationFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"/ping/{randomString()}");
            _response = client.SendAsync(request).Result;
        }

        private string randomString()
        {
           return Faker.Name.First();
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

            actual!.Message.Should().Contain("Hello");
        }
    }
}