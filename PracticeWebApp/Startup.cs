namespace PracticeWebApp
{
    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.SwaggerUI;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(
                c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "SpecFlowCalculatorAPI", Version = "v1" });
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options => { SwaggerPageAppearsAtProjectRoot(options); });

                void SwaggerPageAppearsAtProjectRoot(SwaggerUIOptions swaggerUiOptions)
                {
                    swaggerUiOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    swaggerUiOptions.RoutePrefix = string.Empty;
                }
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
        }
    }
}
