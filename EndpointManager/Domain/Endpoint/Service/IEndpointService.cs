namespace Domain.Endpoint.Service
{
    using Domain.Base;
    using Domain.Endpoint.Model;

    /// <summary>
    /// Interface for service operations.
    /// </summary>
    public interface IEndpointService : IBaseService<EndpointEntity, int>
    {
        /// <summary>
        /// Get Endpoint by serial number.
        /// </summary>
        /// <param name="serialNumber">Serial number.</param>
        /// <returns>Endpoint.</returns>
        Task<EndpointEntity> GetEndpointBySerialNumber(string serialNumber);

        /// <summary>
        /// Create new endpoint.
        /// </summary>
        /// <param name="endpoint">Endpoint entity.</param>
        /// <returns>New Endpoint.</returns>
        Task<EndpointEntity> CreateNewEndpoint(EndpointEntity endpoint);

        /// <summary>
        /// Update endpoint state.
        /// </summary>
        /// <param name="endpoint">Endpoint.</param>
        /// <returns>Void.</returns>
        Task UpdateEndpoint(EndpointEntity endpoint);

        /// <summary>
        /// Delete endpoint.
        /// </summary>
        /// <param name="endpoint">Endpoint.</param>
        /// <returns>Void.</returns>
        Task DeleteEndpoint(EndpointEntity endpoint);
    }
}
