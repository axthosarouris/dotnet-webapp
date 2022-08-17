using Microsoft.OpenApi.Models;
using Npgsql;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
    config.SwaggerDoc("v1", new OpenApiInfo { Title = "SpecFlowCalculatorAPI", Version = "v1" }));

var app = builder.Build();

// Configure the HTTP request pipeline.
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
        if (NotInDevelopmentMode(app))
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

static bool NotInDevelopmentMode(WebApplication app)
{
    return !app.Environment.IsDevelopment();
}

static async Task PerformMigration()
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

public partial class Program
{
}
