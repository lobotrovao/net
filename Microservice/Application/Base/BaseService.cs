namespace Application.Base
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain.Base;

    /// <summary>
    /// Basic service operations.
    /// </summary>
    /// <typeparam name="TEntity">Entity.</typeparam>
    /// <typeparam name="TKeyType">Primary key type.</typeparam>
    public abstract class BaseService<TEntity, TKeyType>
        where TEntity : BaseEntity<TKeyType>
        where TKeyType : struct
    {
        private readonly IBaseRepository<TEntity, TKeyType> baseRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseService{TEntity, TKeyType, TRepository}"/> class.
        /// </summary>
        /// <param name="baseRepository">Base repository.</param>
        protected BaseService(IBaseRepository<TEntity, TKeyType> baseRepository)
        {
            this.baseRepository = baseRepository;
        }

        /// <summary>
        /// Persist entity in database.
        /// </summary>
        /// <param name="entity">Entity.</param>
        /// <returns>Entity persisted.</returns>
        public async virtual Task<TEntity> Add(TEntity entity)
        {
            var result = await baseRepository.Add(entity);

            await SaveChanges();
            return result;
        }

        /// <summary>
        /// Get all elements from database.
        /// </summary>
        /// <returns>All entities.</returns>
        public async virtual Task<IList<TEntity>> GetAll()
        {
            return await baseRepository.GetAll();
        }

        /// <summary>
        /// Get entity by id.
        /// </summary>
        /// <param name="id">Identification.</param>
        /// <returns>Entity.</returns>
        public async virtual Task<TEntity> GetById(TKeyType id)
        {
            return await baseRepository.GetById(id);
        }

        /// <summary>
        /// Remove entity.
        /// </summary>
        /// <param name="id">Id entity.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async virtual Task Remove(TKeyType id)
        {
            await baseRepository.Remove(id);
        }

        /// <summary>
        /// Update entity.
        /// </summary>
        /// <param name="entity">Entity.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async virtual Task Update(TEntity entity)
        {
            await baseRepository.Update(entity);
        }

        /// <summary>
        /// Save changes in context.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async virtual Task SaveChanges()
        {
            await baseRepository.SaveChanges();
        }
    }
}
