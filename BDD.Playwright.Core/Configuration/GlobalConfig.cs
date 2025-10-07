namespace BDD.Playwright.Core.Configuration
{
    using System;
    using System.IO;
    using BDD.Playwright.Core.Helpers;
    using BDD.Playwright.Core.Loggers;
    using BDD.Playwright.Core.Models.Configuration;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Manages and provides access to the global test automation configuration.
    /// Loads settings from <c>appsettings.json</c>, overrides them with environment variables,
    /// and integrates with external services such as Azure Key Vault and Azure DevOps.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The <see cref="GlobalConfig"/> class centralizes configuration management for the test automation framework.
    /// It ensures that all settings are loaded, overridden, and made available via the static <see cref="Settings"/> property.
    /// </para>
    /// <para>
    /// Settings are loaded in the following order:
    /// <list type="number">
    /// <item>From <c>appsettings.json</c> in the application base directory.</item>
    /// <item>Overridden by environment variables (e.g., for CI/CD pipeline integration).</item>
    /// <item>Secrets and additional data (such as database connection strings) are fetched from Azure Key Vault if required.</item>
    /// <item>Azure DevOps sprint name and release link are integrated if available.</item>
    /// </list>
    /// </para>
    /// </remarks>
    /// <example>
    /// <para>
    /// Example usage:
    /// </para>
    /// <code language="csharp">
    /// // Access global test settings anywhere in the test framework
    /// var env = GlobalConfig.Settings.Environment;
    /// var browser = GlobalConfig.Settings.Browser;
    /// </code>
    /// </example>
    public class GlobalConfig
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GlobalConfig"/> class.
        /// Builds the configuration from <c>appsettings.json</c>, overrides values with
        /// environment variables, and fetches secrets or additional data where necessary.
        /// </summary>
        /// <remarks>
        /// This constructor is typically called once at application startup to initialize the static <see cref="Settings"/> property.
        /// </remarks>
        public GlobalConfig()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                        .SetBasePath(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location))
                        .AddJsonFile($"appsettings.json")
                        .Build();

            var settings = configuration.Get<TestAutomationSettings>();

            // Following parameters are Overridden from pipeline run
            settings.Environment = GetEnv("Environment", settings.Environment);
            settings.Headless = GetEnv("Headless", settings.Headless);
            settings.ExecutionType = GetEnv("ExecutionType", settings.ExecutionType);
            settings.RemoteHubURL = GetEnv("RemoteHubURL", settings.RemoteHubURL);
            settings.Category = GetEnv("Category", settings.Category);
            settings.Browser = GetEnv("Browser", settings.Browser);
            settings.ProductName = GetEnv("ProductName", settings.ProductName);
            settings.ReleaseLink = Environment.GetEnvironmentVariable("RELEASE_RELEASEWEBURL");

            settings.SprintName = ADOManager.GetADOSprintName().ToString();

            // Added below condition as AKV is not accessible from ODW machines.
            if (settings.ExecutionType == "AZURE")
            {
                settings.DBConnectionQA = KeyVaultManager.GetSecret("VMDBString");
            }

            Settings = settings;

            LogSettings();
        }

        /// <summary>
        /// Gets the static instance of the test automation settings.
        /// This property holds the deserialized and processed configuration, making it globally accessible.
        /// </summary>
        public static TestAutomationSettings Settings { get; private set; }

        /// <summary>
        /// Retrieves an environment variable by its key, returning a fallback value if the variable is not set.
        /// </summary>
        /// <param name="key">The name of the environment variable.</param>
        /// <param name="fallback">The value to return if the environment variable is not found.</param>
        /// <returns>The value of the environment variable or the fallback value.</returns>
        private static string GetEnv(string key, string fallback) => Environment.GetEnvironmentVariable(key) ?? fallback;

        /// <summary>
        /// Logs the final configuration settings to the custom logger for visibility and debugging.
        /// Includes both pipeline and default configuration parameters.
        /// </summary>
        private static void LogSettings()
        {
            var s = Settings;
            CustomLogger.WriteLine("======================Pipeline Configuration Parameters======================");
            CustomLogger.WriteLine($"Environment is- {s.Environment} ");
            CustomLogger.WriteLine($"ExecutionType is- {s.ExecutionType} ");
            CustomLogger.WriteLine($"Category is- {s.Category} ");
            CustomLogger.WriteLine($"Browser Type is- {s.Browser} ");
            CustomLogger.WriteLine($"ReleaseLink  is- {s.ReleaseLink} ");

            CustomLogger.WriteLine($"RELEASE_RELEASEID  is- {Environment.GetEnvironmentVariable("RELEASE_RELEASEID")} ");
            CustomLogger.WriteLine($"Release_ReleaseName  is- {Environment.GetEnvironmentVariable("Release_ReleaseName")} ");

            // Default Configuration Parameters
            CustomLogger.WriteLine("======================Default Configuration Parameters======================");
            CustomLogger.WriteLine($"ProjectName  is- {s.ProjectName} ");
            CustomLogger.WriteLine($"SprintName  is- {s.SprintName} ");
            CustomLogger.WriteLine($"KeyVaultName  is- {s.KeyVaultName} ");
            CustomLogger.WriteLine($"DashboardURL is- {s.DashboardURL} ");
            CustomLogger.WriteLine($"PageLevelScreenshot is- {s.PageLevelScreenshot} ");
            CustomLogger.WriteLine("===========================================================================");
        }
    }
}