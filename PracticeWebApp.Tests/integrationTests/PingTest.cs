namespace PracticeWebApp.Tests.IntegrationTests
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Newtonsoft.Json;
    using NUnit.Framework;

    public partial class PingTest
    {
        private HttpResponseMessage response = new ();

        [SetUp]
        public void SetUpAsync()
        {
            var webApplicationFactory = new CustomWebApplicationFactory<Program>();
            var client = webApplicationFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"/ping/{this.RandomString()}");
            this.response = client.SendAsync(request).Result;
        }

        [Test]
        public void ShouldReturnSuccessStatusCode()
        {
            this.response.EnsureSuccessStatusCode();
        }

        [Test]
        public async Task ShouldReturnHello()
        {
            var readAsStringAsync = await this.response.Content.ReadAsStringAsync();
            var actual = JsonConvert.DeserializeObject<Ping>(readAsStringAsync);

            actual!.Message.Should().Contain("Hello");
        }

        private string RandomString()
        {
            return Faker.Name.First();
        }
    }
}
