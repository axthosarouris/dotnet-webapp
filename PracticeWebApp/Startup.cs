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

        /// <summary>
        /// This method gets called by the runtime and adds services to the built in IoC container.
        /// </summary>
        /// <param name="services">The dependent classes.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SpecFlowCalculatorAPI", Version = "v1" });
            });
        }

        /// <summary>
        /// This method gets called by the runtime and is used configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">Framework service injected by the IoC container.</param>
        /// <param name="env">Provides information about the web hosting environment an application is running in.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
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
            });
        }
    }
}
