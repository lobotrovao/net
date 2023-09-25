namespace Application.Service
{
    using Domain.Base;

    /// <summary>
    /// Basic operations for services
    /// </summary>
    /// <typeparam name="TEntity">Entity.</typeparam>
    /// <typeparam name="TKeyType">Primary key type.</typeparam>
    /// <typeparam name="TRepository">Repository.</typeparam>
    public abstract class BaseService<TEntity, TKeyType, TRepository> : IBaseService<TEntity, TKeyType>
        where TEntity : BaseEntity<TKeyType>
        where TKeyType : struct
        where TRepository : IBaseRepository<TEntity, TKeyType>
    {
        private TRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseService{TEntity, TRepository, TIdType}"/> class.
        /// </summary>
        /// <param name="mapper">Automapper.</param>
        /// <param name="repository">Data repository.</param>
        public BaseService(TRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Gets repository.
        /// </summary>
        public TRepository GetRepository => repository;

        /// <summary>
        /// Get all objects.
        /// </summary>
        /// <returns>All avatares.</returns>
        public async Task<IList<TEntity>> GetAll()
        {
            var entities = await repository.GetAll();
            return entities;
        }

        /// <summary>
        /// Get object by id.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>AvatarDTO.</returns>
        public async Task<TEntity> GetById(TKeyType id)
        {
            var entity = await repository.GetById(id);
            return entity;
        }

        /// <summary>
        /// Create new object.
        /// </summary>
        /// <param name="entity">Entity.</param>
        /// <returns>New AvatarDTO.</returns>
        public async Task<TEntity> Add(TEntity entity)
        {
            var result = await repository.Add(entity);
            return result;
        }

        /// <summary>
        /// Remove object.
        /// </summary>
        /// <param name="id">Id to remove.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task Remove(TKeyType id)
        {
            await repository.Remove(id);
        }

        /// <summary>
        /// Update object.
        /// </summary>
        /// <param name="entity">Entity.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task Update(TEntity entity)
        {
            await repository.Update(entity);
        }

        /// <summary>
        /// Apply changes in database.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task SaveChanges()
        {
            return repository.SaveChanges();
        }
    }
}
