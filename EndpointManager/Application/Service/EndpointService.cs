namespace Application.Service
{
    using System.Threading.Tasks;
    using Domain.Base;
    using Domain.Endpoint.Enum;
    using Domain.Endpoint.Model;
    using Domain.Endpoint.Repository;
    using Domain.Endpoint.Service;
    using Infrastructure.Repositories;

    /// <summary>
    /// Endpoint services.
    /// </summary>
    public class EndpointService : BaseService<EndpointEntity, int, IEndpointRepository>, IEndpointService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EndpointService"/> class.
        /// </summary>
        /// <param name="repository">Endpoint repository.</param>
        public EndpointService(IEndpointRepository repository)
            : base(repository)
        {
        }

        /// <inheritdoc/>
        public async Task<EndpointEntity> GetEndpointBySerialNumber(string serialNumber)
        {
            var entity = await GetRepository.GetEndpointBySerialNumber(serialNumber);

            if (entity == null)
            {
                throw new ArgumentNullException("Endpoint not found");
            }

            return entity;
        }

        /// <inheritdoc/>
        public async Task<EndpointEntity> CreateNewEndpoint(EndpointEntity endpoint)
        {
            if (string.IsNullOrEmpty(endpoint.SerialNumber))
            {
                throw new ArgumentException("Serial number must be informed!");
            }

            if (string.IsNullOrEmpty(endpoint.FirmwareVersion))
            {
                throw new ArgumentException("Firmeware version must be informed!");
            }

            var modelType = BaseEnumeration.GetAll<EndpointModelType>().FirstOrDefault(x => x.Id == endpoint.ModelId);
            var switchState = BaseEnumeration.GetAll<SwitchStateType>().FirstOrDefault(x => x.Id == endpoint.State);

            if (modelType == null)
            {
                throw new ArgumentException("Inexistent model!");
            }

            if (switchState == null)
            {
                throw new ArgumentException("Inexistent state!");
            }

            var endpointAux = await GetRepository.GetEndpointBySerialNumber(endpoint.SerialNumber);

            if (endpointAux != null)
            {
                throw new ArgumentException("Serial Number already exists!");
            }

            return await Add(endpoint);
        }

        /// <inheritdoc/>
        public async Task UpdateEndpoint(EndpointEntity endpoint)
        {
            if (string.IsNullOrEmpty(endpoint.SerialNumber))
            {
                throw new ArgumentException("Serial number must be informed!");
            }

            var switchState = BaseEnumeration.GetAll<SwitchStateType>().FirstOrDefault(x => x.Id == endpoint.State);

            if (switchState == null)
            {
                throw new ArgumentException("Inexistent state!");
            }

            var endpointAux = await GetRepository.GetEndpointBySerialNumber(endpoint.SerialNumber);

            if (endpointAux == null)
            {
                throw new ArgumentException("Serial Number not found!");
            }

            await Update(endpoint);
        }

        /// <inheritdoc/>
        public async Task DeleteEndpoint(EndpointEntity endpoint)
        {
            var endpointAux = await GetRepository.GetEndpointBySerialNumber(endpoint.SerialNumber);

            if (endpointAux == null)
            {
                throw new ArgumentException("Serial Number not found!");
            }

            await Remove(endpointAux.Id);
        }
    }
}
