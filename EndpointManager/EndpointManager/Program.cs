namespace EndpointManager
{
    using Application;
    using Application.Service;
    using Application.View;
    using Domain.Base;
    using Domain.Endpoint.Enum;
    using Domain.Endpoint.Model;
    using Domain.Endpoint.Repository;
    using Domain.Endpoint.Service;
    using Infrastructure.DatabaseConfigurations;
    using Infrastructure.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Start App.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main, boot application.
        /// </summary>
        /// <param name="args">Application arguments.</param>
        /// <returns>Host application.</returns>
        public static async Task Main(string[] args)
        {
            // Create host builder and configure datacontext and DI.
            using var host = CreateHostBuilder(args).Build();

            // Show main view.
            await Startup(host.Services);

            await host.RunAsync();
        }

        /// <summary>
        /// Boot app main view.
        /// </summary>
        /// <param name="services">Services.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task Startup(IServiceProvider services)
        {
            using var serviceScope = services.CreateScope();
            var provider = serviceScope.ServiceProvider;

            var endpointManager = provider.GetRequiredService<EndpointManagerMainView>();
            await endpointManager.ShowMainMenu();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                })
                .ConfigureServices(services =>
           {
               ////services.AddScoped<IEndpointService, EndpointService>();
               services.AddDbContext<EndpointManagerDatabaseContext>(options => options.UseInMemoryDatabase("EndpointManager"), ServiceLifetime.Scoped);
               services.AddScoped<IEndpointRepository, EndpointRepository>();
               services.AddScoped<IEndpointService, EndpointService>();
               services.AddTransient<EndpointManagerMainView>();
               services.AddTransient<EndpointInsertView>();
               services.AddTransient<EndpointEditView>();
               services.AddTransient<EndpointDeleteView>();
               services.AddTransient<EndpointListView>();
               services.AddTransient<EndpointFindView>();
               ////services.AddHostedService<App>();
           });
        }
    }
}