using System.IO;
using System.Text.Json;

namespace PracticeWebApp.Tests.integrationTests;

public partial class PingTest
{
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