namespace Infrastructure.Repositories.Example
{
    using Domain.Example.Model;
    using Domain.Example.Repository;
    using Infrastructure.DatabaseConfigurations;
    using Infrastructure.Repositories.Base;

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public class ExampleRepository : BaseRepository<ExampleEntity, long>, IExampleRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExampleRepository"/> class.
        /// </summary>
        /// <param name="databaseContext">DatabaseContext.</param>
        public ExampleRepository(ApplicationDbContext databaseContext)
            : base(databaseContext)
        {
        }
    }
}
