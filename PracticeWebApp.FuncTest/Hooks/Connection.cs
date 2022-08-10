namespace PracticeWebApp.FuncTest.Hooks
{
    using BoDi;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class Connection
    {
        private static CustomWebApplicationFactory<Program> webApplicationFactory = null!;
        private readonly IObjectContainer objectContainer;

        public Connection(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            webApplicationFactory = new CustomWebApplicationFactory<Program>();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
        }

        [BeforeScenario]
        public void InitializeClient()
        {
            var httpClient = webApplicationFactory.CreateClient();
            this.objectContainer.RegisterInstanceAs(httpClient);
        }
    }
}
