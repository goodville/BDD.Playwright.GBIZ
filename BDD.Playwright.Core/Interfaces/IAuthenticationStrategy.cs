namespace BDD.Playwright.Core.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

   /// <summary>
    /// Defines a contract for different authentication strategies to generate authorization headers.
    /// </summary>
    public interface IAuthenticationStrategy
    {
        /// <summary>
        /// Asynchronously generates the authentication headers required for an API request.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains a dictionary
        /// of header names and values to be added to the request.
        /// </returns>
        Task<Dictionary<string, string>> GetAuthHeadersAsync();
    }
}
