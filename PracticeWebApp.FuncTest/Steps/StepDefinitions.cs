using System.Net;
using System.Net.Http;
using FluentAssertions;
using TechTalk.SpecFlow;
using Xunit;

namespace PracticeWebApp.FuncTest.Steps
{
    [Binding]
    public sealed class StepDefinitions
    {
        private readonly HttpClient _httpClient;
        private string _pingName = null!;
        private HttpResponseMessage _response = null!;

        public StepDefinitions(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        [Given("that my name is {string}")]
        public void GivenThatMyNameIs(string name)
        {
            _pingName = name;
        }

        [When("I call Ping")]
        public void WhenICallPing()
        {
            Assert.NotNull(_httpClient);
            var request = new HttpRequestMessage(HttpMethod.Get, $"/ping/{_pingName}");
            _response = _httpClient.SendAsync(request).Result;
            _response.Should().NotBeNull();
            _response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Then("I receive {string}")]
        public void ThenIReceive(string apiMessage)
        {
            var result = _response.Content.ReadAsStringAsync().Result;
            result.Should().Contain(apiMessage);
        }
    }
}