namespace BDD.Playwright.Core.Managers.AddressProviders
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BDD.Playwright.Core.Interfaces;
    using BDD.Playwright.Core.Models.RoundRobin;
    using Newtonsoft.Json;

    /// <summary>
    /// Provides addresses by retrieving and deserializing address data from a cloud storage service.
    /// </summary>
    internal class CloudAddressProvider : IAddressProvider
    {
        private readonly ICloudStorageManager cloudStorageManager;
        private readonly string storageContainer;
        private readonly string fileName;

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudAddressProvider"/> class.
        /// </summary>
        /// <param name="cloudStorageManager">The cloud storage manager used to access cloud storage.</param>
        /// <param name="storageContainer">The name of the container in cloud storage where the address file is stored.</param>
        /// <param name="fileName">The name of the file containing address data.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="cloudStorageManager"/>, <paramref name="storageContainer"/>, or <paramref name="fileName"/> is <c>null</c>.
        /// </exception>
        public CloudAddressProvider(ICloudStorageManager cloudStorageManager, string storageContainer, string fileName)
        {
            this.cloudStorageManager = cloudStorageManager ?? throw new ArgumentNullException(nameof(cloudStorageManager));
            this.storageContainer = storageContainer ?? throw new ArgumentNullException(nameof(storageContainer));
            this.fileName = fileName ?? throw new ArgumentNullException(nameof(fileName));
        }

        /// <summary>
        /// Asynchronously loads a list of <see cref="Address"/> objects from the specified file in cloud storage.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains a list of <see cref="Address"/> objects.
        /// </returns>
        /// <exception cref="JsonException">
        /// Thrown if the address data cannot be deserialized from the file content.
        /// </exception>
        public async Task<IList<Address>> LoadAddressesAsync()
        {
            var addressJson = await cloudStorageManager.DownloadFileAsStringAsync(storageContainer, fileName);
            return JsonConvert.DeserializeObject<List<Address>>(addressJson);
        }
    }
}
