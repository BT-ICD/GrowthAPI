
using Growth.API.AuthData;
using Growth.API.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace Growth.API
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
            var connectionString = Configuration.GetConnectionString("cnn");
            Growth.Repository.Configure.ConfigureServices(services, connectionString);
            services.AddControllers();
            //For Authentication related interface
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            //Authenticate Repository and Token options as dependency injection
            services.AddScoped<IAuthenticate, AuthenticateRepository>();
            services.Configure<TokenSettingsOptions>(Configuration.GetSection(TokenSettingsOptions.TokenSettings));
            services.AddScoped<TokenGenerator>();
            //To add Swagger
            services.AddSwaggerGen();
            //To add CORS as extension method
            services.ConfigureCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //To create new user
            //SeedDB.Initialize(app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope().ServiceProvider);

            app.UseHttpsRedirection();

            //To add Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c=> 
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Growth Api v1");
                }
            );
            app.UseRouting();
            //To enable CORS
            app.UseCors("_myAllowSpecificOrigins");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireCors("_myAllowSpecificOrigins");
            });
        }
    }
}
