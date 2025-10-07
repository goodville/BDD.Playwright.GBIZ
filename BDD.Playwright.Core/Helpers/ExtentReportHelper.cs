namespace BDD.Playwright.Core.Helpers
{
    using System;
    using System.Collections.Concurrent;
    using System.IO;
    using System.Threading.Tasks;
    using AventStack.ExtentReports;
    using AventStack.ExtentReports.Gherkin.Model;
    using AventStack.ExtentReports.Model;
    using AventStack.ExtentReports.Reporter;
    using AventStack.ExtentReports.Reporter.Config;
    using BDD.Playwright.Core.Configuration;
    using BDD.Playwright.Core.Engine;
    using BDD.Playwright.Core.Loggers;
    using Reqnroll;
    using Reqnroll.Bindings;

    /// <summary>
    /// Provides static helper methods for creating and managing ExtentReports throughout the test execution lifecycle.
    /// Handles report initialization, teardown, and the creation of feature, scenario, and step entries for BDD test reporting.
    /// Supports thread-safe management of features and scenarios, and attaches logs and screenshots to steps as needed.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This class is designed to be used in BDD test automation projects that utilize ExtentReports and Reqnroll.
    /// It ensures that reporting is consistent, thread-safe, and integrates with custom logging and screenshot capture.
    /// </para>
    /// </remarks>
    /// <example>
    /// <para>
    /// Example usage:
    /// </para>
    /// <code language="csharp">
    /// // Initialize reporting at the start of the test run
    /// ExtentReportHelper.ExtentReportsInit();
    ///
    /// // For each feature and scenario
    /// ExtentReportHelper.CreateFeature("Login Feature");
    /// ExtentReportHelper.CreateScenario("Valid Login", "Login Feature");
    ///
    /// // For each step in a scenario
    /// await ExtentReportHelper.CreateStepAsync(scenarioContext);
    ///
    /// // At the end of the test run
    /// ExtentReportHelper.ExtentReportTearDown();
    /// </code>
    /// </example>
    public class ExtentReportHelper
    {
        // Use ConcurrentDictionaries for thread safety
        private static readonly ConcurrentDictionary<string, ExtentTest> FeatureMap = new ConcurrentDictionary<string, ExtentTest>();
        private static readonly ConcurrentDictionary<string, ExtentTest> ScenarioMap = new ConcurrentDictionary<string, ExtentTest>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtentReportHelper"/> class.
        /// </summary>
        protected ExtentReportHelper()
        {
        }

        /// <summary>
        /// Gets or sets the central ExtentReports instance that manages all test reports.
        /// </summary>
        public static ExtentReports ExtentReports { get; set; }

        /// <summary>
        /// Gets or sets the current ExtentTest instance representing a Gherkin feature.
        /// </summary>
        public static ExtentTest FeatureExtentTest { get; set; }

        /// <summary>
        /// Gets or sets the current ExtentTest instance representing a Gherkin scenario.
        /// </summary>
        public static ExtentTest ScenarioExtentTest { get; set; }

        /// <summary>
        /// Gets or sets the absolute file path for the generated HTML report.
        /// </summary>
        public static string ReportFilePath { get; set; }

        /// <summary>
        /// Initializes the ExtentReports service, configures the HTML reporter, and sets up system information.
        /// This should be called once at the beginning of the test run.
        /// </summary>
        public static void ExtentReportsInit()
        {
            var reportFileName = $"PlaywrightUIAutomationTest.Report_{DateTime.Now:yyyyMMddHHmmss}.html";
            ReportFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestResults", reportFileName);
            var htmlReporter = new ExtentSparkReporter(ReportFilePath);
            htmlReporter.Config.Theme = Theme.Standard;
            htmlReporter.Config.DocumentTitle = "Automation Test Execution Report";
            htmlReporter.Config.ReportName = "<img src='../logo.png' style='width:60px;height:40px;background-color: #ffffff;' /> Test Execution Report";

            ExtentReports = new ExtentReports();
            ExtentReports.AttachReporter(htmlReporter);

            ExtentReports.AddSystemInfo("Project Name", "PlaywrightUIAutomation");
            ExtentReports.AddSystemInfo("Executed By", Environment.UserName);
            ExtentReports.AddSystemInfo("Machine Name", Environment.MachineName);
        }

        /// <summary>
        /// Finalizes the report by adding any remaining logs and flushing the report to disk.
        /// This should be called once at the end of the test run.
        /// </summary>
        public static void ExtentReportTearDown()
        {
            ExtentReports.AddTestRunnerLogs($"<br><a href=\"{CustomLogger.GetLogFileName()}\" target=\"_blank\">View Log File</a>");
            ExtentReports.Flush();
        }
        /// <summary>
        /// Creates a new feature test entry in the report or retrieves an existing one if it has already been created.
        /// This ensures that all scenarios for a feature are grouped together.
        /// </summary>
        /// <param name="featureTitle">The title of the feature from the .feature file.</param>
        public static void CreateFeature(string featureTitle)
            => FeatureExtentTest = FeatureMap.GetOrAdd(featureTitle, ExtentReports.CreateTest<Feature>(featureTitle));

        /// <summary>
        /// Creates a new scenario node under its corresponding feature in the report.
        /// </summary>
        /// <param name="scenarioTitle">The title of the scenario from the .feature file.</param>
        /// <param name="featureTitle">The title of the parent feature.</param>
        public static void CreateScenario(string scenarioTitle, string featureTitle)
        {
            if (FeatureMap.TryGetValue(featureTitle, out var feature))
            {
                // Use GetOrAdd for scenarios as well
                ScenarioExtentTest = ScenarioMap.GetOrAdd(scenarioTitle, feature.CreateNode<Scenario>(scenarioTitle));
            }
        }

        /// <summary>
        /// Creates a step entry in the report for the current step being executed.
        /// It logs the step details, status (Pass/Fail/Skip), and attaches a screenshot on failure or if configured.
        /// </summary>
        /// <param name="scenarioContext">The current Reqnroll scenario context, used to access step info, status, and test data.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static async Task CreateStepAsync(ScenarioContext scenarioContext)
        {
            var stepLogger = scenarioContext.Get<ApplicationLogger>("Logger");
            var logText = "<details><summary>Step Details</summary><pre>" + stepLogger.Read() + "</pre></details><br>";
            Media media = null;

            // Ensure stepInfo is retrieved correctly (as in the previous example)
            if (scenarioContext.ContainsKey("CurrentStepText"))
            {
                var stepInfo = scenarioContext.Get<string>("CurrentStepText");

                string screenshotRelativeFilePath;
                switch (scenarioContext.ScenarioExecutionStatus)
                {
                    case ScenarioExecutionStatus.OK:
                        if (GlobalConfig.Settings.PageLevelScreenshot.Equals("Yes", StringComparison.InvariantCultureIgnoreCase) && scenarioContext.ContainsKey("PlaywrightInit")) // Use correct key
                        {
                            var playwrightInit = scenarioContext.Get<PlaywrightInit>("PlaywrightInit");
                            var screenshotBase64 = await playwrightInit.TakeScreenshotBase64Async();
                            media = MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshotBase64).Build();
                        }

                        CreateNode(scenarioContext, stepInfo, logText, media, Status.Pass); // Pass the retrieved stepInfo
                        CustomLogger.WriteLine(logText);
                        break;

                    case ScenarioExecutionStatus.TestError:
                        logText += "<pre>" + scenarioContext.TestError?.Message + "</pre>"; // Null-conditional operator
                        if (scenarioContext.ContainsKey("PlaywrightInit")) // Use correct key
                        {
                            var playwrightInit = scenarioContext.Get<PlaywrightInit>("PlaywrightInit");
                            var screenshotBase64 = await playwrightInit.TakeScreenshotBase64Async();
                            media = MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshotBase64).Build();
                        }

                        CreateNode(scenarioContext, stepInfo, logText, media, Status.Fail); // Pass the retrieved stepInfo
                        break;

                    case ScenarioExecutionStatus.Skipped:
                        CreateNode(scenarioContext, stepInfo, logText, media, Status.Skip); // Pass the retrieved stepInfo
                        break;

                    default:
                        break;
                }
            }
            else
            {
                CustomLogger.WriteLine("CurrentStepText not found in ScenarioContext. Cannot log step details.");
            }
        }

        /// <summary>
        /// A private helper method to create a Gherkin-specific node (Given, When, Then) within the current scenario.
        /// </summary>
        /// <param name="scenarioContext">The current Reqnroll scenario context.</param>
        /// <param name="stepInfo">The text of the current step.</param>
        /// <param name="logText">The detailed log text to include with the step.</param>
        /// <param name="media">The media object (e.g., screenshot) to attach to the step.</param>
        /// <param name="status">The execution status of the step.</param>
        private static void CreateNode(ScenarioContext scenarioContext, string stepInfo, string logText, Media media, Status status)
        {
            string scenarioTitle = null;
            if (scenarioContext.ContainsKey("CurrentScenarioTitle"))
            {
                scenarioTitle = scenarioContext["CurrentScenarioTitle"].ToString();
            }

            // Retrieve the scenario test node using the scenario title
            if (ScenarioMap.TryGetValue(scenarioTitle ?? scenarioContext.ScenarioInfo.Title, out var scenario))
            {
                switch (scenarioContext.StepContext?.StepInfo?.StepDefinitionType)
                {
                    case StepDefinitionType.Given:
                        scenario.CreateNode<Given>(stepInfo).Log(status, logText, media);
                        break;
                    case StepDefinitionType.When:
                        scenario.CreateNode<When>(stepInfo).Log(status, logText, media);
                        break;
                    case StepDefinitionType.Then:
                        scenario.CreateNode<Then>(stepInfo).Log(status, logText, media);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                CustomLogger.WriteLine($"Scenario '{scenarioContext.ScenarioInfo.Title}' not found in _scenarioMap.");
            }
        }
    }
}