namespace Application.View
{
    using Domain.Endpoint.Enum;
    using Domain.Endpoint.Model;
    using Domain.Endpoint.Service;

    /// <summary>
    /// View Endpoint Insert.
    /// </summary>
    public class EndpointInsertView
    {
        private readonly IEndpointService endpointService;

        /// <summary>
        /// Initializes a new instance of the <see cref="EndpointInsertView"/> class.
        /// Insert View.
        /// </summary>
        /// <param name="endpointService">Endpoint service.</param>
        public EndpointInsertView(IEndpointService endpointService)
        {
            this.endpointService = endpointService;
        }

        /// <summary>
        /// Show insert form view.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task Show()
        {
            Console.WriteLine("SerialNumber:");
            var serialNumber = Console.ReadLine();

            Console.WriteLine("Model:");

            foreach (EndpointModelType model in EndpointModelType.GetAll<EndpointModelType>())
            {
                Console.WriteLine(string.Format("      {0}     COD: {1}", model.Name, model.Id));
            }

            Console.WriteLine("Enter cod:");
            var modelId = Console.ReadLine();

            Console.WriteLine("Meter Number:");
            var meterNumber = Console.ReadLine();
            Console.WriteLine("Firmware Version:");

            var firmwareVersion = Console.ReadLine();
            Console.WriteLine("Switch State:");

            foreach (SwitchStateType stateType in SwitchStateType.GetAll<SwitchStateType>())
            {
                Console.WriteLine(string.Format("             {0}     COD: {1}", stateType.Name.PadLeft(16), stateType.Id));
            }

            Console.WriteLine("Enter cod:");
            var switchStateId = Console.ReadLine();

            if (string.IsNullOrEmpty(serialNumber))
            {
                throw new ArgumentException("Serial number must be informed!");
            }

            if (string.IsNullOrEmpty(modelId))
            {
                throw new ArgumentException("Incorrect Model!");
            }

            if (string.IsNullOrEmpty(meterNumber))
            {
                throw new ArgumentException("Meter number must be informed!");
            }

            if (string.IsNullOrEmpty(firmwareVersion))
            {
                throw new ArgumentException("Firmeware version must be informed!");
            }

            if (string.IsNullOrEmpty(modelId))
            {
                throw new ArgumentException("Incorrect Model!");
            }

            if (string.IsNullOrEmpty(switchStateId))
            {
                throw new ArgumentException("Incorrect State!");
            }

            var modelType = Domain.Base.BaseEnumeration.GetAll<EndpointModelType>().FirstOrDefault(x => x.Id == int.Parse(modelId));
            var switchState = Domain.Base.BaseEnumeration.GetAll<SwitchStateType>().FirstOrDefault(x => x.Id == int.Parse(switchStateId));

            if (modelType == null)
            {
                throw new ArgumentException("Inexistent model!");
            }

            if (switchState == null)
            {
                throw new ArgumentException("Inexistent state!");
            }

            var entity = new EndpointEntity()
            {
                SerialNumber = serialNumber,
                ModelId = modelType.Id,
                MeterNumber = int.Parse(meterNumber),
                FirmwareVersion = firmwareVersion,
                State = switchState.Id
            };

            var result = await endpointService.CreateNewEndpoint(entity);

            if (entity != null)
            {
                Console.WriteLine("Endpoint created!");
            }
            else
            {
                Console.WriteLine("Error creating new endpoint.");
            }
        }
    }
}
