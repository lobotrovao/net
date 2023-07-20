namespace API
{
    using Infrastructure.DatabaseConfigurations;
    using Infrastructure.Security;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Cors.Infrastructure;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;
    using Scrutor;

    /// <summary>
    /// Startup class.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">Configuration properties.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets Configuratio.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">ServiceCollection.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // For entity framework.
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:Application"]));

            // For microsoft identity
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // For authentication, Identity and Jwt
            services.AddAppAuthentication(Configuration);

            // For Cors
            services.AddCors(options => options.AddPolicy("MyApplication", builder => builder.AllowAnyOrigin().AllowAnyHeader()));

            // For DI
            services.Scan(scan => scan
            .FromApplicationDependencies()
             .AddClasses(x => x.InNamespaces(new string[] { "Application", "Infrastructure", "Domain" }))
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                    .AsSelfWithInterfaces()
                        .WithScopedLifetime());

            // For Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">AppplicationBuilder.</param>
        /// <param name="env">WebHostEnviroment.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCors("MyApplication");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "My API V1");
            });
        }
    }
}
