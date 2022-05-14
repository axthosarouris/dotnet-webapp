using System;
using System.IO;
using System.Net.Http;
using System.Reflection;
using BoDi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PracticeWebApp.Tests.integrationTests;
using TechTalk.SpecFlow;

namespace PracticeWebApp.FuncTest.Hooks
{
    [Binding]
    public sealed class Connection
    {
     
        private readonly IObjectContainer objectContainer;
        private static CustomWebApplicationFactory<Program> _webApplicationFactory = null!;


        public Connection(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }


        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            _webApplicationFactory = new CustomWebApplicationFactory<Program>();
        }

        [BeforeScenario]
        public void InitializeClient()
        {
            var httpClient = _webApplicationFactory.CreateClient();
            objectContainer.RegisterInstanceAs(httpClient);
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
          
        }
    }
}