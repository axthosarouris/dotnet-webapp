namespace PracticeWebApp.FuncTest.Steps
{
    using System.Net;
    using System.Net.Http;
    using FluentAssertions;
    using TechTalk.SpecFlow;
    using Xunit;

    /// <summary>
    /// This class includes the setup for our functional tests.
    /// </summary>
    [Binding]
    public sealed class StepDefinitions
    {
        private readonly HttpClient httpClient;
        private string pingName = null!;
        private HttpResponseMessage response = null!;

        public StepDefinitions(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        [Given("that my name is {string}")]
        public void GivenThatMyNameIs(string name)
        {
            this.pingName = name;
        }

        [When("I call Ping")]
        public void WhenICallPing()
        {
            Assert.NotNull(this.httpClient);
            var request = new HttpRequestMessage(HttpMethod.Get, $"/ping/{this.pingName}");
            this.response = this.httpClient.SendAsync(request).Result;
            this.response.Should().NotBeNull();
            this.response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Then("I receive {string}")]

        public void ThenIReceive(string apiMessage)
        {
            var result = this.response.Content.ReadAsStringAsync().Result;
            result.Should().Contain(apiMessage);
        }
    }
}
