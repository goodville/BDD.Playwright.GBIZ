// Address.cs
namespace BDD.Playwright.Core.Models.RoundRobin
{
    using Newtonsoft.Json;

    /// <summary>
    /// Represents an address entity used for round robin state selection in test scenarios.
    /// Contains standard address fields such as street, city, state, state code, and zip code.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This class is typically used to provide address data for test scenarios that require rotating or distributing addresses across test runs.
    /// </para>
    /// </remarks>
    /// <example>
    /// <code language="csharp">
    /// var address = new Address
    /// {
    ///     Address1 = "123 Main St",
    ///     City = "Austin",
    ///     State = "Texas",
    ///     StateCode = "TX",
    ///     ZipCode = "78701"
    /// };
    /// </code>
    /// </example>
    public class Address
    {
        /// <summary>
        /// Gets or sets the street address.
        /// </summary>
        public string Address1 { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the state or province.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the state or province code (e.g., "TX" for Texas).
        /// </summary>
        public string StateCode { get; set; }

        /// <summary>
        /// Gets or sets the zip or postal code.
        /// </summary>
        [JsonProperty("ZIPCode")]
        public string ZipCode { get; set; }
    }
}