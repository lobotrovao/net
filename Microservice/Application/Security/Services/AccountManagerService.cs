namespace Application.Security.Services
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using Application.Security.Dto;
    using Application.Security.Interfaces;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;

    /// <summary>
    /// Provide User operations.
    /// </summary>
    public class AccountManagerService : IAccountManagerService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountManagerService"/> class.
        /// </summary>
        /// <param name="userManager">UserManager.</param>
        /// <param name="roleManager">RoleManager.</param>
        /// <param name="configuration">ConfigurationProperties.</param>
        public AccountManagerService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.configuration = configuration;
        }

        /// <inheritdoc/>
        public async Task<LoginResponse> Login(LoginRequest request)
        {
            var user = await userManager.FindByNameAsync(request.Username);
            if (user != null && await userManager.CheckPasswordAsync(user, request.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: configuration["JWT:ValidIssuer"],
                    audience: configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

                return new LoginResponse
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo
                };
            }

            return null;
        }

        /// <inheritdoc/>
        public async Task<RegisterUserResponse> Register(RegisterUserRequest request)
        {
            var userExists = await userManager.FindByNameAsync(request.Username);
            if (userExists != null)
            {
                return new RegisterUserResponse { Message = "User already exists!" };
            }

            IdentityUser user = new IdentityUser()
            {
                Email = request.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = request.Username
            };
            var result = await userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                return new RegisterUserResponse { Message = "User creation failed! Please check user details and try again." };
            }

            return new RegisterUserResponse { Message = "User created successfully!" };
        }
    }
}
