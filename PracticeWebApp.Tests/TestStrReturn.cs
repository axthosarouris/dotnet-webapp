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
        string returnedString = StrReturn.GetString(arg);
        Assert.AreEqual(returnedString, $"Hello {arg}");
    }
}