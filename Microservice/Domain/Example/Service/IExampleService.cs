namespace Domain.Example.Service
{
    using Domain.Base;
    using Domain.Example.Model;

    /// <summary>
    /// Example service.
    /// </summary>
    public interface IExampleService : IBaseService<ExampleEntity, long>
    {
    }
}
