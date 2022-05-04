using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TechTalk.SpecFlow;

namespace PracticeWebApp.FuncTest.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private static TestServer testServer;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            var application = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(conf =>
                    {
                        conf.ConfigureServices(services =>
                        {
                            services.AddControllers();
                        });
                    }
                );
                
                application.CreateClient(new WebApplicationFactoryClientOptions
                {
                    AllowAutoRedirect = false,
                });
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            
        }
    }
}