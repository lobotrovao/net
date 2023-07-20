namespace Application.Example
{
    using Application.Base;
    using Domain.Example.Model;
    using Domain.Example.Repository;
    using Domain.Example.Service;

    /// <summary>
    /// Example service.
    /// </summary>
    public class ExampleService : BaseService<ExampleEntity, long>, IExampleService
    {
        private readonly IExampleRepository exampleRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExampleService"/> class.
        /// </summary>
        /// <param name="exampleRepository">Example Repository.</param>
        public ExampleService(IExampleRepository exampleRepository)
            : base(exampleRepository)
        {
            this.exampleRepository = exampleRepository;
        }
    }
}
