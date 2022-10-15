namespace PracticeWebApp;

using Npgsql;

public class DbConnectionDetails
{
    public string? Host { get; set; }

    public string? Database { get; set; }

    public string? Username { get; set; }

    public NpgsqlConnectionStringBuilder ConnectionString(IConfiguration configuration)
    {
        var builder = new NpgsqlConnectionStringBuilder();
        builder.Database = this.Database;
        builder.Host = this.Host;
        builder.Username = this.Username;
        builder.Password = configuration.GetValue<string>("db:password");
        return builder;
    }
}
