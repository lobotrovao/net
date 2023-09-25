namespace Domain.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Enumerations (or enum types for short). Enumeration classes that enable all the rich features of an object-oriented language.
    /// </summary>
    public class BaseEnumeration : IComparable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseEnumeration"/> class.
        /// </summary>
        /// <param name="id">Id of value.</param>
        /// <param name="name">Description of value.</param>
        protected BaseEnumeration(int id, string name) => (Id, Name) = (id, name);

        /// <summary>
        /// Gets description of value.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets id of value.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Return all enums available.
        /// </summary>
        /// <typeparam name="T">Enum Type.</typeparam>
        /// <returns>enums available.</returns>
        public static IEnumerable<T> GetAll<T>()
            where T : BaseEnumeration
            =>
            typeof(T).GetFields(BindingFlags.Public |
                                BindingFlags.Static |
                                BindingFlags.DeclaredOnly)
                     .Select(f => f.GetValue(null))
                     .Cast<T>();

        /// <summary>
        /// Get de Name, description of enum.
        /// </summary>
        /// <returns>Enum Name.</returns>
        public override string ToString() => Name;

        /// <summary>
        /// Check equality.
        /// </summary>
        /// <param name="obj">Enum.</param>
        /// <returns>True or false.</returns>
        public override bool Equals(object obj)
        {
            if (obj is not BaseEnumeration otherValue)
            {
                return false;
            }

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Id.Equals(otherValue.Id);

            return typeMatches && valueMatches;
        }

        /// <summary>
        /// Compare Enum Ids.
        /// </summary>
        /// <param name="other">Enum to compare.</param>
        /// <returns>Less than 0, 0 or greater than 0.</returns>
        public int CompareTo(object other)
        {
            return Id.CompareTo(((BaseEnumeration)other).Id);
        }
    }
}
