namespace Domain.Base
{
    /// <summary>
    /// Class that define a entity.
    /// </summary>
    /// <typeparam name="TKeyType">Entity Key Type.</typeparam>
    public class BaseEntity<TKeyType>
        where TKeyType : struct
    {
        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public TKeyType Id { get; set; }
    }
}
