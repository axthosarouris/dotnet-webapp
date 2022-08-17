namespace PracticeWebApp
{
    using Npgsql;
    using Environments = Microsoft.Extensions.Hosting.EnvironmentName;

    public class Program
    {
        private const string AspnetcoreEnvironment = "ASPNETCORE_ENVIRONMENT";

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            MigrateDatabase();
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }

        private static async void MigrateDatabase()
        {
            try
            {
                if (NotInDevelopmentMode())
                {
                    await PerformMigration();
                }
            }
            catch (Exception ex)
            {
                Console.Error.Write(ex.Message);
                throw;
            }
        }

        private static bool NotInDevelopmentMode()
        {
            var runningEnvironment = Environment.GetEnvironmentVariable(AspnetcoreEnvironment);
            return !runningEnvironment?.Equals("Development") ?? false;
        }

        private static async Task PerformMigration()
        {
            var location = "db/migrations";
            var connString =
                "Host=127.0.0.1;Username=orestis;Password=mypassword;Database=webappexampledatabase";

            await using var conn = new NpgsqlConnection(connString);
            await conn.OpenAsync();
            var evolve = new Evolve.Evolve(conn, msg => Console.Out.Write(msg))
            {
                Locations = new[] { location }, IsEraseDisabled = true,
            };

            evolve.Migrate();
        }
    }
}
