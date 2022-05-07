using Swashbuckle.AspNetCore.SwaggerUI;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    ConfigureSwagger();

}

void ConfigureSwagger()
{
    app.UseSwagger();
    app.UseSwaggerUI(options => { SwaggerPageAppearsAtProjectRoot(options); });
    
    void SwaggerPageAppearsAtProjectRoot(SwaggerUIOptions swaggerUiOptions)
    {
        swaggerUiOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        swaggerUiOptions.RoutePrefix = string.Empty;
    }
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }