namespace BDD.Playwright.Core.AuthStrategies
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BDD.Playwright.Core.Interfaces;
    using Microsoft.Identity.Client;

    /// <summary>
    /// Implements the OAuth 2.0 client credentials flow authentication strategy using Microsoft Authentication Library (MSAL).
    /// </summary>
    /// <param name="tenantId">The Azure Active Directory tenant ID.</param>
    /// <param name="clientId">The application's client ID.</param>
    /// <param name="clientSecret">The application's client secret.</param>
    /// <param name="scopes">The scopes required for the token.</param>
    internal class OAuthStrategy(string tenantId, string clientId, string clientSecret, string[] scopes) : IAuthenticationStrategy
    {
        private readonly string tenantId = tenantId;
        private readonly string clientId = clientId;
        private readonly string clientSecret = clientSecret;
        private readonly string[] scopes = scopes;

        /// <summary>
        /// Asynchronously generates the authentication headers required for OAuth Bearer authentication.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains a dictionary
        /// with the 'Authorization' header set to the 'Bearer {token}' value.
        /// </returns>
        public async Task<Dictionary<string, string>> GetAuthHeadersAsync()
        {
            var token = await GetOAuthTokenAsync();
            return new Dictionary<string, string> { { "Authorization", $"Bearer {token}" }, };
        }

        /// <summary>
        /// Acquires an OAuth token using the client credentials flow.
        /// </summary>
        /// <returns>The acquired access token as a string.</returns>
        private async Task<string> GetOAuthTokenAsync()
        {
            var app = ConfidentialClientApplicationBuilder
                .Create(clientId)
                .WithClientSecret(clientSecret)
                .WithAuthority(AzureCloudInstance.AzurePublic, tenantId)
                .Build();

            AuthenticationResult result = null;
            try
            {
                result = await app.AcquireTokenForClient(scopes).ExecuteAsync();
                return result.AccessToken;
            }
            catch (MsalServiceException ex)
            {
                // Handle service exceptions (e.g., network issues, invalid credentials)
                Console.WriteLine($"Service Error: {ex.Message}");
                throw;
            }
            catch (MsalClientException ex)
            {
                // Handle client exceptions (e.g., invalid configuration)
                Console.WriteLine($"Client Error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                Console.WriteLine($"General Error: {ex.Message}");
                throw;
            }
        }
    }
}
