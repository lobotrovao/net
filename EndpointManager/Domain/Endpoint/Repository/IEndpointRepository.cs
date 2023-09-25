namespace Domain.Endpoint.Repository
{
    using Domain.Base;
    using Domain.Endpoint.Model;

    /// <summary>
    /// Interface for database operations.
    /// </summary>
    public interface IEndpointRepository : IBaseRepository<EndpointEntity, int>
    {
        /// <summary>
        /// Get Endpoint by serial number.
        /// </summary>
        /// <param name="serialNumber">Serial number.</param>
        /// <returns>Endpoint.</returns>
        Task<EndpointEntity> GetEndpointBySerialNumber(string serialNumber);
    }
}
