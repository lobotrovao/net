namespace Application.Security.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Application.Security.Dto;

    /// <summary>
    /// Provide User operations.
    /// </summary>
    public interface IAccountManagerService
    {
        /// <summary>
        /// Perform login operation.
        /// </summary>
        /// <param name="request">LoginRequestDto.</param>
        /// <returns>LoginResponseDto.</returns>
        Task<LoginResponse> Login(LoginRequest request);

        /// <summary>
        /// Register common user.
        /// </summary>
        /// <param name="request">request</param>
        /// <returns>RegisterUserResponse.</returns>
        Task<RegisterUserResponse> Register(RegisterUserRequest request);
    }
}
