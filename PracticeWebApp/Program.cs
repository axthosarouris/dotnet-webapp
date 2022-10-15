using Microsoft.OpenApi.Models;
using Npgsql;
using PracticeWebApp;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
    config.SwaggerDoc("v1", new OpenApiInfo { Title = "SpecFlowCalculatorAPI", Version = "v1" }));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => { SwaggerPageAppearsAtProjectRoot(options); });
}

MigrateDatabase(app);

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();

void SwaggerPageAppearsAtProjectRoot(SwaggerUIOptions swaggerUiOptions)
{
    swaggerUiOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    swaggerUiOptions.RoutePrefix = string.Empty;
}

static async void MigrateDatabase(WebApplication app)
{
    try
    {
        if (!app.Environment.IsEnvironment("InMemory"))
        {
            await PerformMigration(app.Configuration);
        }
    }
    catch (Exception ex)
    {
        Console.Error.Write(ex.Message);
        throw;
    }
}

static async Task PerformMigration(IConfiguration configuration)
{
    var connectionDetails = configuration.GetSection("DbConnectionDetails").Get<DbConnectionDetails>();
    await using var conn = new NpgsqlConnection(connectionDetails.ConnectionString(configuration).ConnectionString);
    await conn.OpenAsync();
    var migrationFiles = configuration.GetValue<string>("MigrationFiles");
    var evolve = new Evolve.Evolve(conn, msg => Console.Out.Write(msg))
    {
        Locations = new[] { migrationFiles }, IsEraseDisabled = true,
    };

    evolve.Migrate();
}

public partial class Program
{
}
