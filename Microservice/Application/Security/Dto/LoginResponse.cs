namespace Application.Security.Dto
{
    using System;

    /// <summary>
    /// Dto that contains result for login operation.
    /// </summary>
    public class LoginResponse
    {
        /// <summary>
        /// Gets or Sets Expiration token time.
        /// </summary>
        public DateTime Expiration { get; set; }

        /// <summary>
        /// Gets or Sets Jwt Token.
        /// </summary>
        public string Token { get; set; }
    }
}
