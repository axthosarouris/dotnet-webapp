
using Xunit;

namespace PracticeWebApp.Tests;

public class Tests
{
    [Fact]
    public void ShouldReturnHelloOrestisWhenInputIsOrestis()
    {
        string input = "world";
        string returnedString = VerifyTestIsWorking.GetString(input);
        Assert.Equal($"Hello {input}", returnedString);
    }
}