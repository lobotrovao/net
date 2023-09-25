namespace Infrastructure.DatabaseConfigurations
{
    using Domain.Endpoint.Model;
    using Infrastructure.EntityConfigurations;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Database context configuration.
    /// </summary>
    public class EndpointManagerDatabaseContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EndpointManagerDatabaseContext"/> class.
        /// </summary>
        /// <param name="options">Context options.</param>
        public EndpointManagerDatabaseContext(DbContextOptions<EndpointManagerDatabaseContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets Users.
        /// </summary>
        public DbSet<EndpointEntity> Endpoints { get; set; }

        /// <summary>
        /// Configure database entities.
        /// </summary>
        /// <param name="modelBuilder">Model builder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EndpointEntityTypeConfiguration());
        }
    }
}