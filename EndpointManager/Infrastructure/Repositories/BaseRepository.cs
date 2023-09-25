namespace Infrastructure.Repositories
{
    using Domain.Base;
    using Infrastructure.DatabaseConfigurations;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Base database operations.
    /// </summary>
    /// <typeparam name="TEntity">Entity.</typeparam>
    /// <typeparam name="TKeyType">Primary key type.</typeparam>
    public abstract class BaseRepository<TEntity, TKeyType> : IBaseRepository<TEntity, TKeyType>
        where TEntity : BaseEntity<TKeyType>
        where TKeyType : struct
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{TEntity, TKeyType}"/> class.
        /// </summary>
        /// <param name="databaseContext">Database context.</param>
        public BaseRepository(EndpointManagerDatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
            DataSet = databaseContext.Set<TEntity>();
        }

        /// <summary>
        /// Gets Database aplication context.
        /// </summary>
        public EndpointManagerDatabaseContext DatabaseContext { get; private set; }

        /// <summary>
        /// Gets entity dataset.
        /// </summary>
        public DbSet<TEntity> DataSet { get; private set; }

        /// <summary>
        /// Persist entity in database.
        /// </summary>
        /// <param name="entity">Entity.</param>
        /// <returns>Entity persisted.</returns>
        public async virtual Task<TEntity> Add(TEntity entity)
        {
            var result = await DataSet.AddAsync(entity);

            await SaveChanges();
            return result.Entity;
        }

        /// <summary>
        /// Get all elements from database.
        /// </summary>
        /// <returns>All entities.</returns>
        public async virtual Task<IList<TEntity>> GetAll()
        {
            return await DataSet.ToListAsync();
        }

        /// <summary>
        /// Get entity by id.
        /// </summary>
        /// <param name="id">Identification.</param>
        /// <returns>Entity.</returns>
        public async virtual Task<TEntity> GetById(TKeyType id)
        {
            return await DataSet.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Remove entity.
        /// </summary>
        /// <param name="id">Id entity.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async virtual Task Remove(TKeyType id)
        {
            var objDb = await DataSet.FindAsync(id);
            DataSet.Remove(objDb);
            await SaveChanges();
        }

        /// <summary>
        /// Update entity.
        /// </summary>
        /// <param name="entity">Entity.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async virtual Task Update(TEntity entity)
        {
            DatabaseContext.Entry(entity).State = EntityState.Modified;
            await SaveChanges();
        }

        /// <summary>
        /// Save changes in context.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async virtual Task SaveChanges()
        {
            await DatabaseContext.SaveChangesAsync();
        }
    }
}
