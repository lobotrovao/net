namespace Application.View
{
    using Domain.Endpoint.Service;

    /// <summary>
    /// Endpoint dele view.
    /// </summary>
    public class EndpointDeleteView
    {
        private readonly IEndpointService endpointService;

        /// <summary>
        /// Initializes a new instance of the <see cref="EndpointDeleteView"/> class.
        /// Insert View.
        /// </summary>
        /// <param name="endpointService">Endpoint service.</param>
        public EndpointDeleteView(IEndpointService endpointService)
        {
            this.endpointService = endpointService;
        }

        /// <summary>
        /// Delete view.
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

            Console.WriteLine("Endpoint founded, do you wish to proced with deletation? Y/N");
            var option = Console.ReadLine().ToUpper();

            switch (option)
            {
                case "Y":
                    await endpointService.DeleteEndpoint(endpoint);
                    Console.WriteLine("Endpoint deleted successful!");
                    break;
                case "N":
                    break;
                default:
                    throw new InvalidOperationException("Invalid operation!");
            }
        }
    }
}
