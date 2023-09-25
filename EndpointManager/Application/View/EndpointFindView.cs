namespace Application.View
{
    using Domain.Base;
    using Domain.Endpoint.Enum;
    using Domain.Endpoint.Service;

    /// <summary>
    /// Endpoint find view.
    /// </summary>
    public class EndpointFindView
    {
        private readonly IEndpointService endpointService;

        /// <summary>
        /// Initializes a new instance of the <see cref="EndpointFindView"/> class.
        /// Insert View.
        /// </summary>
        /// <param name="endpointService">Endpoint service.</param>
        public EndpointFindView(IEndpointService endpointService)
        {
            this.endpointService = endpointService;
        }

        /// <summary>
        /// Show Find View.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task Show()
        {
            Console.WriteLine("Inform the serial number:");
            var serialNumber = Console.ReadLine();

            if (string.IsNullOrEmpty(serialNumber))
            {
                throw new ArgumentException("Inform serial number!");
            }

            var endpoint = await endpointService.GetEndpointBySerialNumber(serialNumber);

            if (endpoint == null)
            {
                throw new ArgumentException("Endpoint not found, are you sure the serial is correct?");
            }

            var header = "Serial Number|Model Type|Meter Number|Firmware Version|Switch State";
            Console.WriteLine(header);

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
