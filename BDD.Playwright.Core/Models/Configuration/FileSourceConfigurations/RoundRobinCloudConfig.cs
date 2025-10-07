namespace BDD.Playwright.Core.Models.Configuration.FileSourceConfigurations
{
    /// <summary>
    /// Represents configuration settings for a round-robin cloud source.
    /// Used to specify the container or bucket where round-robin configuration files are stored.
    /// </summary>
    public class RoundRobinCloudConfig
    {
        /// <summary>
        /// Gets or sets the cloud storage container/bucket where round-robin configuration files are stored.
        /// </summary>
        public string Container { get; set; }
    }
}
