namespace Domain.Example.Model
{
    using System;
    using Domain.Base;

    /// <summary>
    /// Example entity.
    /// </summary>
    public class ExampleEntity : BaseEntity<long>
    {
        /// <summary>
        /// Gets or sets name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets age.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Gets or sets Value.
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// Gets or sets creationDate.
        /// </summary>
        public DateTime CreationDate { get; set; }
    }
}
