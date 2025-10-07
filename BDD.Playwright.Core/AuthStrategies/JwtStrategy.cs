namespace BDD.Playwright.Core.AuthStrategies
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BDD.Playwright.Core.Interfaces;

    /// <summary>
    /// Implements a JWT (JSON Web Token) authentication strategy using a pre-existing token.
    /// </summary>
    /// <param name="jwtToken">The JWT token to be used for authentication.</param>
    internal class JwtStrategy(string jwtToken) : IAuthenticationStrategy
    {
        private readonly string jwtToken = jwtToken;

        /// <summary>
        /// Generates the authentication headers required for JWT Bearer authentication.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains a dictionary
        /// with the 'Authorization' header set to the 'Bearer {token}' value.
        /// </returns>
        public Task<Dictionary<string, string>> GetAuthHeadersAsync() => Task.FromResult(new Dictionary<string, string> { { "Authorization", $"Bearer {jwtToken}" }, });
    }
}
