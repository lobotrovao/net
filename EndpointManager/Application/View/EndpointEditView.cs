namespace Application.View
{
    using Domain.Endpoint.Enum;
    using Domain.Endpoint.Service;

    /// <summary>
    /// Endpoint edit view.
    /// </summary>
    public class EndpointEditView
    {
        private readonly IEndpointService endpointService;

        /// <summary>
        /// Initializes a new instance of the <see cref="EndpointEditView"/> class.
        /// Insert View.
        /// </summary>
        /// <param name="endpointService">Endpoint service.</param>
        public EndpointEditView(IEndpointService endpointService)
        {
            this.endpointService = endpointService;
        }

        /// <summary>
        /// Edit View.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task Show()
        {
            Console.WriteLine("Inform the serial number:");
            var serialNumber = Console.ReadLine().ToUpper();

            if (string.IsNullOrEmpty(serialNumber))
            {
                throw new ArgumentException("Inform serial number!");
            }

            var endpoint = await endpointService.GetEndpointBySerialNumber(serialNumber);

            if (endpoint == null)
            {
                throw new ArgumentException("Endpoint not found, are you sure the serial is correct?");
            }

            Console.WriteLine("Endpoint found.");
            Console.WriteLine("Change Switch Sate to:");
            foreach (SwitchStateType stateType in SwitchStateType.GetAll<SwitchStateType>())
            {
                Console.WriteLine(string.Format("             {0}     COD: {1}", stateType.Name.PadLeft(16), stateType.Id));
            }

            Console.WriteLine("Enter cod:");
            var switchStateId = Console.ReadLine();

            if (string.IsNullOrEmpty(switchStateId))
            {
                throw new ArgumentException("Incorrect State!");
            }

            var switchState = SwitchStateType.GetAll<SwitchStateType>().FirstOrDefault(x => x.Id == int.Parse(switchStateId));

            if (switchState == null)
            {
                throw new ArgumentException("Inexistent state!");
            }

            endpoint.State = switchState.Id;

            await endpointService.UpdateEndpoint(endpoint);

            Console.WriteLine("Endpoint updated successful!");
        }
    }
}
