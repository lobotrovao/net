namespace Domain.Endpoint.Enum
{
    using Domain.Base;

    /// <summary>
    /// Model of available endpoints.
    /// </summary>
    public class EndpointModelType : BaseEnumeration
    {
        /// <summary>
        /// For NSX1P2W, this value will always be 16.
        /// </summary>
        public static EndpointModelType NSX1P2W = new (16, nameof(NSX1P2W));

        /// <summary>
        /// For NSX1P3W, this value will always be 17.
        /// </summary>
        public static EndpointModelType NSX1P3W = new (17, nameof(NSX1P3W));

        /// <summary>
        /// For NSX2P3W, this value will always be 18.
        /// </summary>
        public static EndpointModelType NSX2P3W = new (18, nameof(NSX2P3W));

        /// <summary>
        /// For NSX3P4W, this value will always be 19.
        /// </summary>
        public static EndpointModelType NSX3P4W = new (19, nameof(NSX3P4W));

        /// <summary>
        /// Initializes a new instance of the <see cref="EndpointModelType"/> class.
        /// </summary>
        /// <param name="id">Id enum.</param>
        /// <param name="name">Name enum.</param>
        public EndpointModelType(int id, string name)
        : base(id, name)
        {
        }
    }
}
