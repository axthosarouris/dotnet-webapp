using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace PracticeWebApp.Tests.integrationTests;

public class PingTest : IClassFixture<WebApplicationFactory<Program>>
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

    private static class JsonMapper
    {
        private static JsonSerializerOptions defaultOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public static TValue? Deserialize<TValue>(Stream json, JsonSerializerOptions? options = null)
        {
            return options == null
                ? JsonSerializer.Deserialize<TValue>(json, defaultOptions)
                : JsonSerializer.Deserialize<TValue>(json, options);
        }
    }
}