namespace Domain.Endpoint.Enum
{
    using Domain.Base;

    /// <summary>
    /// Switch State types.
    /// </summary>
    public class SwitchStateType : BaseEnumeration
    {
        /// <summary>
        /// For Disconnected, this value will always be 0.
        /// </summary>
        public static SwitchStateType Disconnected = new (0, nameof(Disconnected));

        /// <summary>
        /// For Connected, this value will always be 1.
        /// </summary>
        public static SwitchStateType Connected = new (1, nameof(Connected));

        /// <summary>
        /// For Connected, this value will always be 2.
        /// </summary>
        public static SwitchStateType Armed = new (2, nameof(Armed));

        /// <summary>
        /// Initializes a new instance of the <see cref="SwitchStateType"/> class.
        /// </summary>
        /// <param name="id">Id enum.</param>
        /// <param name="name">Name enum.</param>
        public SwitchStateType(int id, string name)
        : base(id, name)
        {
        }
    }
}
