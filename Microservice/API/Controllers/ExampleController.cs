namespace API.Controllers
{
    using Domain.Example.Model;
    using Domain.Example.Service;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Example controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExampleController : BaseController<ExampleEntity, long>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExampleController"/> class.
        /// </summary>
        /// <param name="service">Service.</param>
        public ExampleController(IExampleService service)
            : base(service)
        {
        }
    }
}
