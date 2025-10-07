namespace BDD.Playwright.Test.Hooks
{
    using System.Diagnostics;
    using System.Text;
    using BDD.Playwright.Core.Configuration;
    using BDD.Playwright.Core.Engine;
    using BDD.Playwright.Core.Factories;
    using BDD.Playwright.Core.Helpers;
    using BDD.Playwright.Core.Interfaces;
    using BDD.Playwright.Core.Loggers;
    using BDD.Playwright.Core.Models.SaveTestResultModels;
    using Microsoft.Playwright;
    using Reqnroll;
    using Reqnroll.BoDi;

    /// <summary>
    /// Implements core BDD Hooks for the test lifecycle, including setup and teardown for test runs, features, scenarios, and steps.
    /// Manages Playwright browser lifecycle, logging, dependency injection, and test result publishing.
    /// </summary>
    [Binding]
    public class Hooks
    {
        private static readonly string[] Separators = { "Retry(", ")" };
        private readonly Stopwatch stopWatch = new();
        private readonly IObjectContainer objectContainer;
        private readonly ScenarioContext scenarioContext;
        private readonly FeatureContext featureContext;
        private ApplicationLogger? specLogger = null!;
        private PlaywrightInit? playwrightInit = null!;

        /// <summary>
        /// Initializes a new instance of the <see cref="Hooks"/> class.
        /// Sets up feature, scenario, and object container contexts for dependency injection and logging.
        /// </summary>
        /// <param name="featureContext">The feature context for the current test.</param>
        /// <param name="scenarioContext">The scenario context for the current test.</param>
        /// <param name="objectContainer">The object container for dependency injection.</param>
        public Hooks(FeatureContext featureContext, ScenarioContext scenarioContext, IObjectContainer objectContainer)
        {
            this.featureContext = featureContext;
            this.objectContainer = objectContainer;
            this.scenarioContext = scenarioContext;
            this.scenarioContext.Set<string>(string.Empty, "Logs");
        }

        /// <summary>
        /// Initializes the ExtentReports reporting system before any test runs.
        /// </summary>
        [BeforeTestRun]
        public static void BeforeTestRun() => ExtentReportHelper.ExtentReportsInit();

        /// <summary>
        /// Tears down the ExtentReports reporting system after all test runs are complete.
        /// </summary>
        [AfterTestRun]
        public static void AfterTestRun() => ExtentReportHelper.ExtentReportTearDown();

        /// <summary>
        /// Creates a new feature node in the ExtentReports before the feature starts.
        /// </summary>
        /// <param name="featureContext">The feature context for the current test.</param>
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext) => ExtentReportHelper.CreateFeature(featureContext.FeatureInfo.Title);

        /// <summary>
        /// Executes after each test step, creating a step node in ExtentReports.
        /// </summary>
        /// <param name="scenarioContext">The scenario context for the current test.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [AfterStep]
        public static async Task AfterStep(ScenarioContext scenarioContext) => await ExtentReportHelper.CreateStepAsync(scenarioContext);

        /// <summary>
        /// Executes before each test step, storing the current step text in the scenario context.
        /// </summary>
        /// <param name="scenarioContext">The scenario context for the current test.</param>
        [BeforeStep]
        public static void BeforeStep(ScenarioContext scenarioContext)
        {
            var stepText = scenarioContext.StepContext.StepInfo.Text;
            scenarioContext["CurrentStepText"] = stepText; // Store in ScenarioContext
        }

        /// <summary>
        /// Sets up scenario dependencies, address providers, round robin manager, and Playwright browser before each scenario.
        /// Also initializes scenario reporting and logging.
        /// </summary>
        /// <param name="ioc">The object container for dependency injection.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [BeforeScenario]
        public async Task BeforeScenarioAsync(ObjectContainer ioc)
        {
            CustomLogger.Configure();
            specLogger = new ApplicationLogger();
            scenarioContext.Set<ApplicationLogger>(specLogger, "Logger");

            // Initialization of GlobalConfig
            _ = new GlobalConfig();

            specLogger.WriteLine("Setting up file reader.");
            ioc.RegisterInstanceAs<IFileReader>(FileReaderFactory.CreateJsonFileReader(GlobalConfig.Settings.TestDataFolderPath));

            specLogger.WriteLine("Setting up cloud storage provider.");

            // Set up cloud storage provider
            if (!ioc.IsRegistered<ICloudStorageManager>())
            {
                var cloudStorageConfig = GlobalConfig.Settings.CloudStorageConfig;

                // Only create storage manager if cloud storage is enabled
                if (cloudStorageConfig?.Enabled == true)
                {
                    var cloudStorage = cloudStorageConfig.Provider switch
                    {
                        "Azure" when cloudStorageConfig.AzureConfig != null =>
                            CloudStorageFactory.CreateAzureStorageManager(cloudStorageConfig.AzureConfig.ConnectionString),
                        "AWS" when cloudStorageConfig.AwsConfig != null =>
                            CloudStorageFactory.CreateAmazonStorageManger(),
                        "Google" when cloudStorageConfig.GoogleConfig != null =>
                            CloudStorageFactory.CreateGoogleStorageManager(),
                        _ => throw new ArgumentException($"Unsupported or misconfigured cloud storage provider: {cloudStorageConfig.Provider}")
                    };

                    ioc.RegisterInstanceAs<ICloudStorageManager>(cloudStorage);
                }
                else
                {
                    specLogger.WriteLine("Cloud storage is disabled or not configured.");
                }
            }

            // Register address providers based on configuration
            specLogger.WriteLine("Setting up address providers.");
            /*foreach (var (listName, addressList) in GlobalConfig.Settings.AddressLists)
            {
                var provider = addressList.Source?.ToLowerInvariant() switch
                {
                    "localfile" when addressList.LocalFileConfig != null =>
                        AddressProviderFactory.CreateLocalFileAddressProvider(
                            ioc.Resolve<IFileReader>(),
                            addressList.LocalFileConfig.FilePath,
                            addressList.LocalFileConfig.DataKey),

                    "cloud" when addressList.CloudConfig != null =>
                        AddressProviderFactory.CreateCloudAddressProvider(
                            ioc.Resolve<ICloudStorageManager>(),
                            addressList.CloudConfig.Container,
                            addressList.CloudConfig.FileName),

                    _ => throw new ArgumentException(
                        $"Invalid or missing configuration for address list '{listName}'")
                };

                // Register with name for access in step definitions
                scenarioContext.Set(provider, $"AddressProvider_{listName}");
            }

            if (scenarioContext.TryGetValue("AddressProvider_AdditionalLocations", out IAddressProvider additionalProvider))
            {
                var additionalLocations = await additionalProvider.LoadAddressesAsync();

                if (additionalLocations == null || additionalLocations.Count == 0)
                {
                    throw new InvalidOperationException("AdditionalLocations could not be loaded.");
                }

                scenarioContext.Set(additionalLocations, "AdditionalLocations");
            }

            specLogger.WriteLine("Setting up round robin manager.");
            var roundRobinConfig = GlobalConfig.Settings.RoundRobinConfiguration;
            if (roundRobinConfig.Enabled)
            {
                var manager = roundRobinConfig.Source?.ToLowerInvariant() switch
                {
                    "cloud" when roundRobinConfig.CloudConfig != null =>
                        await RoundRobinFactory.CreateCloudRoundRobinAsync(
                            ioc.Resolve<ICloudStorageManager>(),
                            scenarioContext.Get<IAddressProvider>("AddressProvider_RoundRobin"),
                            roundRobinConfig.CloudConfig.Container),

                    // Add other round robin types as needed
                    _ => throw new ArgumentException(
                        $"Invalid or missing round robin configuration: {roundRobinConfig.Source}")
                };

                ioc.RegisterInstanceAs<IRoundRobinManager>(manager);
            }*/

            specLogger.WriteLine($"Start Scenario:{scenarioContext.ScenarioInfo.Title}");
            stopWatch.Start();

            if (scenarioContext.ScenarioInfo.Arguments != null
                    && scenarioContext.ScenarioInfo.Arguments.Count > 0)
            {
                var scenarioTitle = new StringBuilder();
                scenarioTitle.Append(scenarioContext.ScenarioInfo.Title);
                if (scenarioContext.ScenarioInfo.Arguments.Count < 3)
                {
                    foreach (var argument in scenarioContext.ScenarioInfo.Arguments)
                    {
                        scenarioTitle.Append($"{argument}");
                    }
                }
                else
                {
                    if (!featureContext.ContainsKey(scenarioContext.ScenarioInfo.Title))
                    {
                        featureContext.TryAdd(scenarioContext.ScenarioInfo.Title, "0");
                    }

                    var cnt = Convert.ToInt32(featureContext[scenarioContext.ScenarioInfo.Title]);
                    scenarioTitle.Append($" - {++cnt}");
                    featureContext[scenarioContext.ScenarioInfo.Title] = cnt;
                }

                scenarioContext["CurrentScenarioTitle"] = scenarioTitle.ToString();
                ExtentReportHelper.CreateScenario(scenarioTitle.ToString(), featureContext.FeatureInfo.Title);
            }
            else
            {
                ExtentReportHelper.CreateScenario(scenarioContext.ScenarioInfo.Title, featureContext.FeatureInfo.Title);
            }

            if (!(scenarioContext.ScenarioInfo.Tags.Contains("NoWeb") || featureContext.FeatureInfo.Tags.Contains("NoWeb")))
            {
                playwrightInit = new PlaywrightInit();
                scenarioContext.Set(playwrightInit, "PlaywrightInit");
                await playwrightInit.InitializeAsync(featureContext, scenarioContext, specLogger);
            }
            else
            {
                var apiPlaywright = await Microsoft.Playwright.Playwright.CreateAsync();
                var browser = await apiPlaywright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
                var apiContext = (await browser.NewContextAsync()).APIRequest;
                scenarioContext.Set(apiContext, "ApiPlaywright");
            }

            specLogger.WriteLine($"End of Scenario:{scenarioContext.ScenarioInfo.Title}");
        }

        /// <summary>
        /// Handles scenario teardown, including retry logic, browser closure, round robin config saving, and test result publishing.
        /// </summary>
        /// <param name="ioc">The object container for dependency injection.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [AfterScenario]
        public async Task AfterScenarioAsync(ObjectContainer ioc)
        {
            if (specLogger == null)
            {
                throw new InvalidOperationException("specLogger is not initialized.");
            }

            specLogger.WriteLine("***Start After Scenario***");
            var retryInterval = TimeSpan.FromMilliseconds(5000);
            if (scenarioContext.TestError != null)
            {
                var retryCount = 0;
                var retryTag = scenarioContext.ScenarioInfo.Tags.FirstOrDefault(tag => tag.StartsWith("Retry"));
                if (retryTag != null)
                {
                    retryCount = ExtractRetryCount(retryTag);
                }
                else if (featureContext.FeatureInfo.Tags.Any(tag => tag.StartsWith("Retry")))
                {
                    var featureRetryTag = featureContext.FeatureInfo.Tags.FirstOrDefault(tag => tag.StartsWith("Retry"));
                    retryCount = ExtractRetryCount(featureRetryTag);
                }
                else if (int.Parse(GlobalConfig.Settings.RetryCount) > retryCount)
                {
                    retryCount = int.Parse(GlobalConfig.Settings.RetryCount);
                }

                if (retryCount > 0)
                {
                    void RetryAction()
                    {
                        if (scenarioContext.TestError != null)
                        {
                            specLogger.WriteLine("Scenario failed. Retrying...");
                            throw new Exception("Scenario failed and will be retried.");
                        }
                    }

                    try
                    {
                        RetryHelper.WaitAndRetry(RetryAction, retryCount, retryInterval);
                    }
                    catch (Exception ex)
                    {
                        specLogger.WriteLine($"Test scenario failed after {retryCount} retries: {ex.Message}");
                        throw;
                    }
                }
            }

            // Close browser if the tags do not contain "NoWeb"
            if (!(scenarioContext.ScenarioInfo.Tags.Contains("NoWeb") || featureContext.FeatureInfo.Tags.Contains("NoWeb")))
            {
                if (playwrightInit != null)
                {
                    await playwrightInit.CloseBrowserAsync();
                }
                else
                {
                    specLogger.WriteLine("PlaywrightInit was not initialized, skipping browser cleanup.");
                }
            }

            // Save round robin configuration for scenario if available.
            if (ioc.IsRegistered<IRoundRobinManager>())
            {
                var roundRobinManager = ioc.Resolve<IRoundRobinManager>();
                await roundRobinManager.SaveScenarioRoundRobinConfigAsync();
            }

            // Only publish test results from Azure pipeline run
            // if ("AZURE".Equals(GlobalConfig.ExecutionType))
            // {
            CustomLogger.WriteLine("Test result Update started...");
            //await UpdateTestTestResultAsync(featureContext, scenarioContext);
            CustomLogger.WriteLine("Test result Update completed...");

            // }
            // else
            // {
            //    _logger.WriteLine($"Current ExecutionType: {GlobalConfig.ExecutionType}. So Test results not publishing to Dashbaord!");
            //
            // }
            specLogger.WriteLine("***End After Scenario***");
        }

        /// <summary>
        /// Extracts the retry count from a scenario or feature tag in the format "Retry(n)".
        /// </summary>
        /// <param name="tag">The tag string to parse.</param>
        /// <returns>The extracted retry count, or 0 if not found.</returns>
        private static int ExtractRetryCount(string? tag)
        {
            if (!string.IsNullOrEmpty(tag) && tag.StartsWith("Retry(") && tag.EndsWith(')'))
            {
                var parts = tag.Split(Separators, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length > 0 && int.TryParse(parts[0], out var retryCount))
                {
                    return retryCount;
                }
            }

            return 0;
        }

        /// <summary>
        /// Publishes the test result to the dashboard or external system.
        /// </summary>
        /// <param name="featureContext">The feature context for the current test.</param>
        /// <param name="scenarioContext">The scenario context for the current test.</param>
        /// <returns>True if the result was saved successfully; otherwise, false.</returns>
        private async Task<bool> UpdateTestTestResultAsync(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            stopWatch.Stop();
            if (specLogger == null)
            {
                throw new InvalidOperationException("specLogger is not initialized.");
            }

            var saveTestResultRequest = new SaveTestResultRequest
            {
                Id = GlobalConfig.Settings.Id,
                RunID = GlobalConfig.Settings.RunId,
                ProjectName = GlobalConfig.Settings.ProjectName.ToString(),
                Environment = GlobalConfig.Settings.Environment,
                FeatureName = featureContext.FeatureInfo.Title,
                ScenarioName = scenarioContext.ScenarioInfo.Title,
                ExecutedDateTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssZ"),
                Result = ExtractTestResult(scenarioContext.ScenarioExecutionStatus),
                MachineName = Environment.MachineName,
                ExecutedBy = Environment.UserName,
                ExecutionType = GlobalConfig.Settings.ExecutionType,
                Tags = string.Join(", ", scenarioContext.ScenarioInfo.Tags),
                FailureReason = scenarioContext.TestError?.Message ?? string.Empty,
                Category = GlobalConfig.Settings.Category ?? string.Empty,

                // duration = stopWatch.Elapsed,
                SprintName = GlobalConfig.Settings.SprintName,
                Duration = stopWatch.Elapsed,
                ReleaseLink = GlobalConfig.Settings.ReleaseLink,
            };
            var saveSuccess = await SaveTestResults.SaveResults(saveTestResultRequest);

            if (saveSuccess)
            {
                specLogger.WriteLine("Results saved successfully.");
                return true;
            }
            else
            {
                specLogger.WriteLine("Failed to save results.");
                return false;
            }
        }

        /// <summary>
        /// Maps the scenario execution status to a test result string.
        /// </summary>
        /// <param name="testStatus">The scenario execution status.</param>
        /// <returns>A string representing the test result.</returns>
        private static string ExtractTestResult(ScenarioExecutionStatus testStatus)
        {
            var testResult = testStatus switch
            {
                ScenarioExecutionStatus.OK => "Passed",
                ScenarioExecutionStatus.UndefinedStep or ScenarioExecutionStatus.TestError or ScenarioExecutionStatus.BindingError => "Failed",
                ScenarioExecutionStatus.Skipped => "Skipped",
                _ => "Ignored",
            };
            return testResult;
        }
    }
}