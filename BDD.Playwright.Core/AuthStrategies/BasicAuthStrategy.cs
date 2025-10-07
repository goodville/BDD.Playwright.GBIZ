namespace BDD.Playwright.Core.AuthStrategies
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BDD.Playwright.Core.Interfaces;

    /// <summary>
    /// Implements the Basic Authentication strategy by encoding credentials into a Base64 string.
    /// </summary>
    /// <param name="username">The username for authentication.</param>
    /// <param name="password">The password for authentication.</param>
    internal class BasicAuthStrategy(string username, string password) : IAuthenticationStrategy
    {
        private readonly string username = username;
        private readonly string password = password;

        /// <summary>
        /// Asynchronously generates the authentication headers required for Basic Authentication.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains a dictionary
        /// with the 'Authorization' header set to the Base64 encoded credentials.
        /// </returns>
        public Task<Dictionary<string, string>> GetAuthHeadersAsync()
        {
            var byteArray = System.Text.Encoding.ASCII.GetBytes($"{username}:{password}");
            var base64String = Convert.ToBase64String(byteArray);
            return Task.FromResult(new Dictionary<string, string> { { "Authorization", $"Basic {base64String}" }, });
        }
    }
}
