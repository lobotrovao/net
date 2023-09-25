namespace Infrastructure.Repositories
{
    using Domain.Endpoint.Model;
    using Domain.Endpoint.Repository;
    using Infrastructure.DatabaseConfigurations;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Endpoint repository operations.
    /// </summary>
    public class EndpointRepository : BaseRepository<EndpointEntity, int>, IEndpointRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EndpointRepository"/> class.
        /// </summary>
        /// <param name="context">Database context.</param>
        public EndpointRepository(EndpointManagerDatabaseContext context)
            : base(context)
        {
        }

        /// <inheritdoc/>
        public async Task<EndpointEntity> GetEndpointBySerialNumber(string serialNumber)
        {
            var entity = await DataSet.Where(x => x.SerialNumber.Equals(serialNumber)).FirstOrDefaultAsync();
            return entity;
        }
    }
}
