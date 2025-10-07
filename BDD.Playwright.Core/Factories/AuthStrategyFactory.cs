namespace BDD.Playwright.Core.Factories
{
    using BDD.Playwright.Core.AuthStrategies;
    using BDD.Playwright.Core.Interfaces;

    /// <summary>
    /// Factory for creating <see cref="IAuthenticationStrategy"/> instances for different authentication mechanisms.
    /// Supports Basic Authentication, JWT, and OAuth strategies.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Use this factory to abstract the instantiation of authentication strategies, allowing test code to remain agnostic to the underlying authentication mechanism.
    /// </para>
    /// </remarks>
    /// <example>
    /// <para>
    /// Example usage:
    /// </para>
    /// <code language="csharp">
    /// // Create a basic authentication strategy
    /// IAuthenticationStrategy basicAuth = AuthStrategyFactory.CreateBasicAuthStrategy("user", "pass");
    ///
    /// // Create a JWT authentication strategy
    /// IAuthenticationStrategy jwtAuth = AuthStrategyFactory.CreateJwtStrategy("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...");
    ///
    /// // Create an OAuth authentication strategy
    /// IAuthenticationStrategy oauthAuth = AuthStrategyFactory.CreateOAuthStrategy(
    ///     "tenant-id",
    ///     "client-id",
    ///     "client-secret",
    ///     new[] { "scope1", "scope2" }
    /// );
    /// </code>
    /// </example>
    public class AuthStrategyFactory
    {
        /// <summary>
        /// Creates a basic authentication strategy with username and password.
        /// </summary>
        /// <param name="username">The username for basic authentication.</param>
        /// <param name="password">The password for basic authentication.</param>
        /// <returns>An <see cref="IAuthenticationStrategy"/> for basic authentication.</returns>
        public static IAuthenticationStrategy CreateBasicAuthStrategy(string username, string password) => new BasicAuthStrategy(username, password);

        /// <summary>
        /// Creates a JWT authentication strategy with a JWT token.
        /// </summary>
        /// <param name="jwtToken">The JWT token to use for authentication.</param>
        /// <returns>An <see cref="IAuthenticationStrategy"/> for JWT authentication.</returns>
        public static IAuthenticationStrategy CreateJwtStrategy(string jwtToken) => new JwtStrategy(jwtToken);

        /// <summary>
        /// Creates an OAuth authentication strategy with tenant ID, client ID, client secret, and scopes.
        /// </summary>
        /// <param name="tenantId">The tenant ID for OAuth authentication.</param>
        /// <param name="clientId">The client ID for OAuth authentication.</param>
        /// <param name="clientSecret">The client secret for OAuth authentication.</param>
        /// <param name="scopes">An array of scopes for OAuth authentication.</param>
        /// <returns>An <see cref="IAuthenticationStrategy"/> for OAuth authentication.</returns>
        public static IAuthenticationStrategy CreateOAuthStrategy(string tenantId, string clientId, string clientSecret, string[] scopes) => new OAuthStrategy(tenantId, clientId, clientSecret, scopes);
    }
}