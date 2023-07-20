namespace Application.Security.Dto
{
    /// <summary>
    ///  Dto used in login operations.
    /// </summary>
    public class LoginRequest
    {
        /// <summary>
        /// Gets or sets username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets password.
        /// </summary>
        public string Password { get; set; }
    }
}
