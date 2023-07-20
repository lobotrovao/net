namespace Domain.Base
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface with basic operation services.
    /// </summary>
    /// <typeparam name="TEntity">Entity model.</typeparam>
    /// <typeparam name="TKeyType">Primary key type.</typeparam>
    public interface IBaseService<TEntity, TKeyType>
        where TEntity : BaseEntity<TKeyType>
        where TKeyType : struct
    {
        /// <summary>
        /// Persist entity in database.
        /// </summary>
        /// <param name="entity">Entity.</param>
        /// <returns>Entity persisted.</returns>
        Task<TEntity> Add(TEntity entity);

        /// <summary>
        /// Get all elements from database.
        /// </summary>
        /// <returns>All entities.</returns>
        Task<IList<TEntity>> GetAll();

        /// <summary>
        /// Get entity by id.
        /// </summary>
        /// <param name="id">Identification.</param>
        /// <returns>Entity.</returns>
        Task<TEntity> GetById(TKeyType id);

        /// <summary>
        /// Remove entity.
        /// </summary>
        /// <param name="id">Id entity.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task Remove(TKeyType id);

        /// <summary>
        /// Update entity.
        /// </summary>
        /// <param name="entity">Entity.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task Update(TEntity entity);

        /// <summary>
        /// Save changes in context.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task SaveChanges();
    }
}
