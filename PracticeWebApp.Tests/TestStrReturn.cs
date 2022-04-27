using NUnit.Framework;
namespace PracticeWebApp.Tests;

public class Tests
{
    string arg;

    [SetUp]
    public void Setup()
    {
        arg = "Orestis";
    }

    [Test]
    public void ShouldReturnHelloOrestisWhenInputIsOrestis()
    {
        string returnedString = VerifyTestIsWorking.GetString(arg);
        Assert.AreEqual($"Hello {arg}", returnedString);
    }
}