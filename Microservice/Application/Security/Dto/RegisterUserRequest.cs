namespace Application.Security.Dto
{
    /// <summary>
    /// Register user request.
    /// </summary>
    public class RegisterUserRequest
    {
        /// <summary>
        /// Gets or sets username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets Password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets Email.
        /// </summary>
        public string Email { get; set; }
    }
}
