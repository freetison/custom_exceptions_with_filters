using custom_exceptions_with_filters.DependencyInjection;
using custom_exceptions_with_filters.Filters;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace custom_exceptions_with_filters
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers(options =>
            {
                options.SuppressAsyncSuffixInActionNames = false;
                options.RespectBrowserAcceptHeader = true;
                options.Filters.Add(new ValidateModelStateAttribute());
                options.Filters.Add<ApiExceptionFilter>();
            }).ConfigureApiBehaviorOptions(options => {
                options.SuppressModelStateInvalidFilter = true;
            }).AddFluentValidation(fv => {
                  fv.RegisterValidatorsFromAssembly((typeof(Startup).Assembly));
                  fv.DisableDataAnnotationsValidation = true;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "custom_exceptions_with_filters", Version = "v1" });
            });

            services.AddValidationExceptionFactory();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "custom_exceptions_with_filters v1"));
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
