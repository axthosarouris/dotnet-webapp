namespace PracticeWebApp
{
    public class Program
    {
        /// <summary>
        /// The entrypoint of our application.
        /// </summary>
        /// <param name="args">Parameters used for host configuration.</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// The CreateHostBuilder method is using the CreateDefaultBuilder method, which in essence adds some features
        /// like Dependency Injection support to our application.
        /// </summary>
        /// <returns>IHostBuilder.</returns>
        /// /// <param name="args">Parameters used for host configuration.</param>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}
