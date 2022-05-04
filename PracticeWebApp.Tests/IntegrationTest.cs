using NUnit.Framework;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.AspNetCore.TestHost;
using System.Text.Json;
using System.Text.Json.Serialization;
using ThirdParty.Json.LitJson;
using Newtonsoft.Json;

namespace PracticeWebApp.Tests
{
    internal class IntegrationTest
    {        

        [Test]
        public async Task ShouldReturnSuccessStatusCode()
        {
            var application = new WebApplicationFactory<Program>()
        .WithWebHostBuilder(builder => {});

            HttpClient client = application.CreateClient();
            HttpResponseMessage response = await client.GetAsync("/ping");
            response.EnsureSuccessStatusCode();
        }

        [Test]
        public async Task ShouldReturnHello()
        {
            var application = new WebApplicationFactory<Program>()
        .WithWebHostBuilder(builder => { });

            HttpClient client = application.CreateClient();
            HttpResponseMessage response = await client.GetAsync("/ping");
            var actual = JsonConvert.DeserializeObject<Ping>(
                await response.Content.ReadAsStringAsync());
            Assert.AreEqual("Hello", actual.Message);
        }
       
    }
}
