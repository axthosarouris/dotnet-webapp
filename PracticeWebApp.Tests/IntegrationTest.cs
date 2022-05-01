using NUnit.Framework;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.AspNetCore.TestHost;

namespace PracticeWebApp.Tests
{
    internal class IntegrationTest
    {
        //private HttpClient _httpClient = null!;

        //public async Task InitializeAsync()
        //{
        //    var hostBuilder = 
        //    //var hostBuilder = new Program()
        //    //    .ConfigureWebHost(webHostBuilder =>
        //    //    {
        //    //        webHostBuilder.UseTestServer();
        //    //    })
        //    //    .ConfigureServices((_, services) =>
        //    //    {
        //    //        services.AddSingleton(_profileServiceMock.Object);
        //    //    });

        //    var host = await hostBuilder.StartAsync();
        //    _httpClient = host.GetTestClient();
        //}

        [Test]
        public async Task SetupAsync()
        {
            var application = new WebApplicationFactory<Program>()
        .WithWebHostBuilder(builder =>
        {
            TestServer testServer = new TestServer(builder);            
        });

            HttpClient client = application.CreateClient();
            HttpResponseMessage response = await client.GetAsync("/GetPing");
            response.EnsureSuccessStatusCode();
        }

        //[Test]
        //public void ShouldContainOKResponseCode()
        //{
            
        //}

        //[Test]
        //public void ShouldContainExpectedBody()
        //{

        //}
    }
}
