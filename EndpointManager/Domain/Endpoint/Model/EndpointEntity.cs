namespace Domain.Endpoint.Model
{
    using Domain.Base;
    using Domain.Endpoint.Enum;

    /// <summary>
    /// Endpoint entity.
    /// </summary>
    public class EndpointEntity : BaseEntity<int>
    {
        /// <summary>
        /// Gets or sets endpoint Serial Number.
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// Gets or sets model Id.
        /// </summary>
        public int ModelId { get; set; }

        /// <summary>
        /// Gets or sets meter Number.
        /// </summary>
        public int MeterNumber { get; set; }

        /// <summary>
        /// Gets or sets firmware Version.
        /// </summary>
        public string FirmwareVersion { get; set; }

        /// <summary>
        /// Gets or sets state.
        /// </summary>
        public int State { get; set; }
    }
}
