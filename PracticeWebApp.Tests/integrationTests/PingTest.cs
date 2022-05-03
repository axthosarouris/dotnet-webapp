using System.Net;
using System.Net.Http;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace PracticeWebApp.Tests.integrationTests;

public partial class PingTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient client;
    private readonly WebApplicationFactory<Program> factory;

    public PingTest()
    {
        var webApplicationFactory = new CustomWebApplicationFactory<Program>();
        client = webApplicationFactory.CreateClient();
    }

    [Fact]
    public void ShouldReturnExpectedPingMessage()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "/ping");
        var response = client.SendAsync(request).Result;
        var actual = JsonMapper.Deserialize<Ping>(response.Content.ReadAsStream());
        var expected = new Ping { Message = "Hello" };
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        actual.Should().BeEquivalentTo(expected);
    }
}