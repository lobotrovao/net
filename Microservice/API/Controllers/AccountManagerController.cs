namespace API.Controllers
{
    using System.Threading.Tasks;
    using Application.Security.Dto;
    using Application.Security.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Controller responsible for executing user operations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AccountManagerController : ControllerBase
    {
        private readonly IAccountManagerService accountManagerService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountManagerController"/> class.
        /// </summary>
        /// <param name="accountManagerService">AccountManagerService.</param>
        public AccountManagerController(IAccountManagerService accountManagerService)
        {
            this.accountManagerService = accountManagerService;
        }

        /// <summary>
        /// Authenticate user.
        /// </summary>
        /// <param name="request">LoginRequestDto.</param>
        /// <returns>LoginResponseDto.</returns>
        [HttpPost]
        [Route("Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest request)
        {
            var result = await accountManagerService.Login(request);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return Unauthorized();
            }
        }

        /// <summary>
        /// Register new user.
        /// </summary>
        /// <param name="request">RegisterUserRequestDto.</param>
        /// <returns>RegisterUserResponseDto.</returns>
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
        {
            var result = await accountManagerService.Register(request);

            return Ok(result);
        }
    }
}
