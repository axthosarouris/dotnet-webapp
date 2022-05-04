using System.Net.Http;
using TechTalk.SpecFlow;

namespace PracticeWebApp.FuncTest.Steps
{
    [Binding]
    public sealed class StepDefinitions
    {
        [Given(@"that my name is ""(.*)""")]
        public void GivenThatMyNameIs(string orestis)
        {
            
        }
        
        [When(@"I call Ping")]
        public void WhenICallPing()
        { ;
        }
        
        [Then(@"I receive ""(.*)""")]
        public void ThenIReceive(string hello)
        {
            
        }




    }

}