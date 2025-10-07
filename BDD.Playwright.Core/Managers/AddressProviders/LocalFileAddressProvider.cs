namespace BDD.Playwright.Core.Managers.AddressProviders
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BDD.Playwright.Core.Interfaces;
    using BDD.Playwright.Core.Models.RoundRobin;
    using Newtonsoft.Json;

    /// <summary>
    /// Provides addresses from a local file.
    /// </summary>
    internal class LocalFileAddressProvider : IAddressProvider
    {
        private readonly IFileReader fileReader;
        private readonly string filePath;
        private readonly string dataKey;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalFileAddressProvider"/> class.
        /// </summary>
        /// <param name="fileReader">The file reader used to access the local file.</param>
        /// <param name="filePath">The path to the local file containing address data.</param>
        /// <param name="dataKey">The key used to retrieve the address data from the file.</param>
        public LocalFileAddressProvider(IFileReader fileReader, string filePath, string dataKey)
        {
            this.fileReader = fileReader;
            this.filePath = filePath;
            this.dataKey = dataKey;
        }

        /// <summary>
        /// Asynchronously loads a list of <see cref="Address"/> objects from the specified local file.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains a list of <see cref="Address"/> objects.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown if <c>filePath</c> or <c>dataKey</c> is null or empty.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the file does not contain address data for the specified key.
        /// </exception>
        /// <exception cref="JsonException">
        /// Thrown if the address data cannot be deserialized from the file content.
        /// </exception>
        public async Task<IList<Address>> LoadAddressesAsync()
        {
            return await Task.Run(() =>
            {
                if (string.IsNullOrEmpty(filePath) || string.IsNullOrEmpty(dataKey))
                {
                    throw new ArgumentException("File path and data key must be provided.");
                }

                var addressJson = fileReader.GetValue(filePath, dataKey);

                return string.IsNullOrEmpty(addressJson)
                    ? throw new InvalidOperationException($"No addresses found in the file at {filePath} with key {dataKey}.")
                    : JsonConvert.DeserializeObject<List<Address>>(addressJson);
            });
        }
    }
}
