namespace Application.View
{
    using Domain.Base;
    using Domain.Endpoint.Enum;
    using Domain.Endpoint.Model;
    using Domain.Endpoint.Service;

    /// <summary>
    /// Endpoint list view.
    /// </summary>
    public class EndpointListView
    {
        private readonly IEndpointService endpointService;

        /// <summary>
        /// Initializes a new instance of the <see cref="EndpointListView"/> class.
        /// Insert View.
        /// </summary>
        /// <param name="endpointService">Endpoint service.</param>
        public EndpointListView(IEndpointService endpointService)
        {
            this.endpointService = endpointService;
        }

        /// <summary>
        /// Show all registered endpoints.
        /// </summary>
        /// <param name="endpoints">List endpoints.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task Show()
        {
            IList<EndpointEntity> endpoints = await endpointService.GetAll();

            if (!endpoints.Any())
            {
                Console.WriteLine("0 Endpoints!");
            }

            var header = "Serial Number|Model Type|Meter Number|Firmware Version|Switch State";
            Console.WriteLine(header);

            foreach (EndpointEntity endpoint in endpoints)
            {
                var modelType = BaseEnumeration.GetAll<EndpointModelType>().FirstOrDefault(x => x.Id == endpoint.ModelId).Name;
                var switchState = BaseEnumeration.GetAll<SwitchStateType>().FirstOrDefault(x => x.Id == endpoint.State).Name;

                var line = string.Format(
                    "{0}|{1}|{2}|{3}|{4}",
                    endpoint.SerialNumber.PadLeft(13),
                    modelType.PadLeft(10),
                    endpoint.MeterNumber.ToString().PadLeft(12),
                    endpoint.FirmwareVersion.PadLeft(16),
                    switchState.PadLeft(12));

                Console.WriteLine(line);
            }
        }
    }
}
