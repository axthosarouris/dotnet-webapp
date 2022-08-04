namespace PracticeWebApp.Tests.integrationTests
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Newtonsoft.Json;
    using NUnit.Framework;

    public partial class PingTest
    {
        private HttpResponseMessage _response = new ();

        [SetUp]
        public void SetUpAsync()
        {
            var webApplicationFactory = new CustomWebApplicationFactory<Program>();
            var client = webApplicationFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"/ping/{this.RandomString()}");
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
            var readAsStringAsync =  _response.Content.ReadAsStringAsync().Result;
            var actual = JsonConvert.DeserializeObject<Ping>(readAsStringAsync);

            actual!.Message.Should().Contain("Hello");
        }

        private string RandomString()
        {
            return Faker.Name.First();
        }
    }
}
