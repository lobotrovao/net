namespace Domain.Example.Repository
{
    using Domain.Base;
    using Example.Model;

    /// <summary>
    /// Example repository, basic database operations.
    /// </summary>
    public interface IExampleRepository : IBaseRepository<ExampleEntity, long>
    {
    }
}
