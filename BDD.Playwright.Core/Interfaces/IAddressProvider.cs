namespace BDD.Playwright.Core.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BDD.Playwright.Core.Models.RoundRobin;

    /// <summary>
    /// Defines a contract for retrieving a list of <see cref="Address"/> objects from a data source.
    /// Implementations may load addresses from local files, cloud storage, or other sources.
    /// </summary>
    public interface IAddressProvider
    {
        /// <summary>
        /// Asynchronously loads the available <see cref="Address"/> objects from the underlying data source.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains a list of <see cref="Address"/> objects.
        /// </returns>
        /// <exception cref="System.ArgumentException">
        /// Thrown if required configuration (such as file path or data key) is missing in implementations that require it.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// Thrown if the data source does not contain the expected address data.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown if required dependencies (such as storage manager or container name) are null in implementations that require them.
        /// </exception>
        Task<IList<Address>> LoadAddressesAsync();
    }
}
