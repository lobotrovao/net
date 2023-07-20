namespace Infrastructure.DatabaseConfigurations
{
    using Infrastructure.EntityConfigurations;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Main application datacontext.
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        /// <param name="options">Context options.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// Create entity models based on EntityConfigurations and 3rd party entities.
        /// </summary>
        /// <param name="builder">Model builder.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Apply configurations for entities type configured in this module.
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(builder);
        }
    }
}
