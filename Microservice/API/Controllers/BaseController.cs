namespace API.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain.Base;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Basic http operations used as template for others.
    /// </summary>
    /// <typeparam name="TEntity">Entity.</typeparam>
    /// <typeparam name="TKeyType">Primary key type.</typeparam>
    public class BaseController<TEntity, TKeyType> : ControllerBase
        where TEntity : BaseEntity<TKeyType>
        where TKeyType : struct
    {
        private readonly IBaseService<TEntity, TKeyType> service;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController{TEntity, TKeyType}"/> class.
        /// </summary>
        /// <param name="service">Domain service.</param>
        public BaseController(IBaseService<TEntity, TKeyType> service)
        {
            this.service = service;
        }

        /// <summary>
        /// Get all objects.
        /// </summary>
        /// <returns>List.</returns>
        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await service.GetAll();
        }

        /// <summary>
        /// Get object by id.
        /// </summary>
        /// <param name="id">Avatar Id.</param>
        /// <returns>List.</returns>
        [HttpGet("{id}")]
        [Authorize]
        public async Task<TEntity> GetById(TKeyType id)
        {
            return await service.GetById(id);
        }

        /// <summary>
        /// Create new object.
        /// </summary>
        /// <param name="dto">AvatarDTO.</param>
        /// <returns>New Avatar.</returns>
        [HttpPost]
        [Authorize]
        public async Task<TEntity> Save([FromBody] TEntity dto)
        {
            return await service.Add(dto);
        }

        /// <summary>
        /// Delete object by id.
        /// </summary>
        /// <param name="id">Identification.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpDelete("{id}")]
        [Authorize]
        public async Task Delete(TKeyType id)
        {
            await service.Remove(id);
        }

        /// <summary>
        /// Update object.
        /// </summary>
        /// <param name="dto">DTO input.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpPut]
        [Authorize]
        public async Task Update([FromBody] TEntity dto)
        {
            await service.Update(dto);
        }
    }
}
