namespace BDD.Playwright.Core.Engine
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using BDD.Playwright.Core.Configuration;
    using BDD.Playwright.Core.Loggers;
    using Microsoft.Playwright;
    using NUnit.Framework;
    using Reqnroll;
    using Reqnroll.Tracing;

    /// <summary>
    /// Initializes and manages Playwright browser instances for automated tests.
    /// Handles browser creation, context management, page lifecycle, and teardown for each test scenario.
    /// Supports multiple browsers and execution modes as configured in <see cref="GlobalConfig"/>.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This class is intended to be used in BDD test automation projects to provide a consistent and configurable Playwright environment.
    /// It manages browser and page lifecycles, integrates with Reqnroll contexts, and provides utilities for screenshot capture and logging.
    /// </para>
    /// </remarks>
    /// <example>
    /// <para>
    /// Example usage:
    /// </para>
    /// <code language="csharp">
    /// var playwrightInit = new PlaywrightInit();
    /// await playwrightInit.InitializeAsync(featureContext, scenarioContext, logger);
    /// IPage page = playwrightInit.Page;
    /// // ... perform test actions ...
    /// await playwrightInit.TakeScreenshotOfCurrentPageAsync();
    /// await playwrightInit.CloseBrowserAsync();
    /// </code>
    /// </example>
    public class PlaywrightInit
    {
        private IPlaywright playwright;
        private IBrowser browser;
        private ScenarioContext scenarioContext;
        private FeatureContext featureContext;
        private ApplicationLogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlaywrightInit"/> class.
        /// </summary>
        public PlaywrightInit()
        {
        }

        /// <summary>
        /// Gets the active Playwright Page instance for the current test scenario.
        /// </summary>
        public IPage Page { get; private set; } // Expose the page

        /// <summary>
        /// Initializes the Playwright environment, creates a browser instance, and sets up a new page for the test.
        /// The browser type, execution mode (local/grid), and headless state are determined by the global configuration.
        /// </summary>
        /// <param name="featureContext">The Reqnroll feature context.</param>
        /// <param name="scenarioContext">The Reqnroll scenario context.</param>
        /// <param name="logger">The application logger for logging initialization steps.</param>
        /// <returns>A task that represents the asynchronous initialization operation.</returns>
        /// <exception cref="NotImplementedException">Thrown when Grid execution is attempted, as it is not yet supported.</exception>
        /// <exception cref="ArgumentException">Thrown for an unsupported browser type.</exception>
        /// <exception cref="Exception">Thrown if Playwright fails to start for any reason.</exception>
        public async Task InitializeAsync(FeatureContext featureContext, ScenarioContext scenarioContext, ApplicationLogger logger)
        {
            this.featureContext = featureContext;
            this.scenarioContext = scenarioContext;
            this.logger = logger;
            var browserType = GlobalConfig.Settings.Browser;
            if (string.IsNullOrEmpty(browserType))
            {
                browserType = "chromium"; // Default to chromium
            }

            var executionType = GlobalConfig.Settings.ExecutionType;
            var headless = GlobalConfig.Settings.Headless;

            try
            {
                logger.WriteLine($"Starting Playwright initialization with browser: {browserType}, headless: {headless}");
                playwright = await Playwright.CreateAsync();
                logger.WriteLine("Playwright instance created successfully");

                var browserLaunchOptions = new BrowserTypeLaunchOptions
                {
                    // Add common options here (headless, etc.)
                    Headless = bool.Parse(headless),
                    Args = ["--start-maximized", "--disable-dev-shm-usage", "--no-sandbox"],
                    Timeout = 60000, // 60 seconds timeout
                };

                logger.WriteLine($"Attempting to launch browser: {browserType}");

                switch (browserType.ToLower())
                {
                    case "chromium":
                        if (executionType.Equals("GRID"))
                        {
                            // Playwright remotes are different, check their documentation
                            throw new NotImplementedException("Playwright Grid execution not yet implemented");
                        }
                        else
                        {
                            browser = await playwright.Chromium.LaunchAsync(browserLaunchOptions);
                        }

                        break;
                    case "firefox":
                        browser = executionType.Equals("GRID")
                            ? throw new NotImplementedException("Playwright Grid execution not yet implemented")
                            : await playwright.Firefox.LaunchAsync(browserLaunchOptions);
                        break;

                    case "chrome": // Added "chrome" case (distinction from "chromium" is important)
                        if (executionType.Equals("GRID", StringComparison.OrdinalIgnoreCase))
                        {
                            throw new NotImplementedException("Playwright Grid execution not yet implemented");
                        }
                        else
                        {
                             browserLaunchOptions.Channel = "chrome";
                             browser = await playwright.Chromium.LaunchAsync(browserLaunchOptions); // Chrome uses Chromium
                        }

                        break;
                    case "webkit":
                        browser = executionType.Equals("GRID")
                            ? throw new NotImplementedException("Playwright Grid execution not yet implemented")
                            : await playwright.Webkit.LaunchAsync(browserLaunchOptions);
                        break;
                    case "msedge":
                        if (executionType.Equals("GRID"))
                        {
                            throw new NotImplementedException("Playwright Grid execution not yet implemented");
                        }
                        else
                        {
                            browserLaunchOptions.Channel = "msedge";
                            browser = await playwright.Chromium.LaunchAsync(browserLaunchOptions);
                        }

                        break;
                    default:
                        throw new ArgumentException($"Unsupported browser type: {browserType}");
                }

                logger.WriteLine($"Browser {browserType} launched successfully");

                var browserOptions = new BrowserNewContextOptions
                {
                    IgnoreHTTPSErrors = true,
                    ViewportSize = bool.Parse(headless) ? new ViewportSize { Width = 1920, Height = 1080 } : ViewportSize.NoViewport,
                };
                var context = await browser.NewContextAsync(browserOptions);
                logger.WriteLine("Browser context created successfully");

                Page = await context.NewPageAsync();
                logger.WriteLine("New page created successfully");

                this.scenarioContext.Set<IPage>(Page, "Page");
                this.scenarioContext.Set<IBrowserContext>(context, "BrowserContext");
                this.logger.WriteLine($"browser '{browserType}' has launched successfully");
            }
            catch (Exception e)
            {
                logger.WriteLine($"Playwright has failed to start with browser type '{browserType}'");
                logger.WriteLine($"Error details: {e.Message}");
                logger.WriteLine($"Stack trace: {e.StackTrace}");
                throw new Exception($"Playwright has failed to start with browser type '{browserType}': {e.Message}", e);
            }
        }

        /// <summary>
        /// Closes the browser, page, and disposes the Playwright instance gracefully.
        /// Ensures all resources are released and logs any errors encountered during teardown.
        /// </summary>
        /// <returns>A task that represents the asynchronous close operation.</returns>
        public async Task CloseBrowserAsync()
        {
            try
            {
                // Retrieve ScenarioContext if available
                if (scenarioContext != null && scenarioContext.ContainsKey("Page"))
                {
                    var page = scenarioContext.Get<IPage>("Page");
                    if (page != null)
                    {
                        await page.CloseAsync();
                    }
                }

                // Close the current page if it exists
                if (Page != null)
                {
                    await Page.CloseAsync();
                    Page = null; // Nullify to prevent re-use
                }

                // Close the browser instance
                if (browser != null)
                {
                    await browser.CloseAsync();

                    browser = null;
                }

                // Dispose of Playwright if it was initialized
                if (playwright != null)
                {
                    playwright.Dispose();
                    playwright = null;
                }
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error closing browser: {ex.Message}");
            }
        }

        /// <summary>
        /// Takes a screenshot of the current page, saves it to the test results directory,
        /// and attaches it to the NUnit test context for reporting.
        /// </summary>
        /// <returns>The relative file path of the saved screenshot.</returns>
        public async Task<string> TakeScreenshotOfCurrentPageAsync()
        {
            var screenshotFileName = GetScreenshotFileName();
            var screenshotDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestResults", "screenshots");
            var screenshotFilePath = Path.Combine(screenshotDirectory, screenshotFileName);
            var screenshotRelativeFilePath = "screenshots/" + screenshotFileName;

            Directory.CreateDirectory(screenshotDirectory); // Create if it doesn't exist

            // Try to get CurrentPage first (for DuckCreek), fall back to main Page (for Guidewire)
            IPage pageToCapture;
            if (scenarioContext.ContainsKey("CurrentPage"))
            {
                pageToCapture = scenarioContext.Get<IPage>("CurrentPage");
                logger.WriteLine("Taking screenshot from CurrentPage");
            }
            else
            {
                pageToCapture = Page;
                logger.WriteLine("Taking screenshot from main Page");
            }

            await pageToCapture.ScreenshotAsync(new PageScreenshotOptions { Path = screenshotFilePath }); // Playwright screenshot

            TestContext.AddTestAttachment(screenshotFilePath);

            return screenshotRelativeFilePath;
        }

        public async Task<string> TakeScreenshotBase64Async()
        {
            IPage pageToCapture;
            if (scenarioContext.ContainsKey("CurrentPage"))
            {
                pageToCapture = scenarioContext.Get<IPage>("CurrentPage");
                logger.WriteLine("Taking screenshot from CurrentPage");
            }
            else
            {
                pageToCapture = Page;
                logger.WriteLine("Taking screenshot from main Page");
            }

            var screenshotBytes = await pageToCapture.ScreenshotAsync();
            return Convert.ToBase64String(screenshotBytes);
        }

        /// <summary>
        /// Generates a unique screenshot file name based on the feature, scenario, timestamp, and test status.
        /// </summary>
        /// <returns>A formatted string for the screenshot file name.</returns>
        private string GetScreenshotFileName()
        {
            var featureTitle = featureContext?.FeatureInfo.Title.ToIdentifier();
            var scenarioTitle = scenarioContext?.ScenarioInfo.Title.ToIdentifier();

            // Truncate to 8 characters to avoid long paths
            var featureShort = featureTitle?.Length > 8 ? featureTitle[..8] : featureTitle;
            var scenarioShort = scenarioTitle?.Length > 8 ? scenarioTitle[..8] : scenarioTitle;

            // Use a short timestamp and test status
            var timestamp = DateTime.Now.ToString("MMddHHmmss");
            var status = TestContext.CurrentContext.Result.Outcome.Status;

            return $"SS_{featureShort}_{scenarioShort}_{timestamp}_{status}.png";
        }
    }
}