namespace BDD.Playwright.Core.Loggers
{
    using System;
    using System.IO;
    using BDD.Playwright.Core.Helpers;
    using log4net;
    using log4net.Appender;
    using log4net.Config;
    using log4net.Core;
    using log4net.Layout;

    /// <summary>
    /// Provides a static logging helper using log4net and integrates log output with ExtentReports.
    /// </summary>
    public static class CustomLogger
    {
        // The log4net logger instance.
        private static ILog logger;

        // The name of the current log file.
        private static string logFileName;

        // Indicates if the logger has been configured.
        private static bool isConfigured = false;

        // The full file path for the current log file.
        private static string logFilePath;

        /// <summary>
        /// Configures the logger if it has not been configured yet.
        /// </summary>
        public static void Configure()
        {
            if (isConfigured)
            {
                return;
            }

            // Create and configure the file appender.
            var fileAppender = GetFileAppender();
            BasicConfigurator.Configure(fileAppender);

            // Retrieve the logger instance.
            // Note: Ensure that ApplicationLogger is a valid type or change it to typeof(_logger) if that is intended.
            logger = LogManager.GetLogger(typeof(ApplicationLogger));
            isConfigured = true;
        }

        /// <summary>
        /// Gets the full file path of the current log file.
        /// </summary>
        /// <returns>The log file path.</returns>
        public static string GetLogFilePath() => logFilePath;

        /// <summary>
        /// Gets the log file name.
        /// </summary>
        /// <returns>The log file name.</returns>
        public static string GetLogFileName() => logFileName;

        /// <summary>
        /// Writes a log message with a timestamp to the log file and sends the log output to the test runner logs.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public static void WriteLine(string message)
        {
            // Prepend the current date/time to the message.
            message = $"{DateTime.Now:yyyy-MM-dd-HH:mm:ss}: {message}";
            logger.Info(message);

            // Add the log message to the ExtentReports logs with different styling based on content.
            if (message.Contains("***"))
            {
                ExtentReportHelper.ExtentReports.AddTestRunnerLogs($"<div style=\"background:#ffefe6;font-weight:bold;\">{message}<br></div>");
            }
            else
            {
                ExtentReportHelper.ExtentReports.AddTestRunnerLogs($"<div style=\"background: #f2eeed;\">{message}<br></div>");
            }
        }

        /// <summary>
        /// Creates and configures a file appender for log4net.
        /// </summary>
        /// <returns>A configured <see cref="FileAppender"/>.</returns>
        private static FileAppender GetFileAppender()
        {
            // Create a unique log file name based on the current date and time.
            logFileName = $"PlaywrightAutomation.Log_{DateTime.Now:yyyyMMddHHmmss}.log";
            logFilePath = Path.Combine("TestResults", logFileName);

            // Initialize and configure the file appender.
            var fileAppender = new FileAppender
            {
                Name = logFileName,
                Layout = GetPatternLayout(),
                Threshold = Level.All,
                AppendToFile = true,
                File = logFilePath,
            };
            fileAppender.ActivateOptions();

            return fileAppender;
        }

        /// <summary>
        /// Creates and configures a pattern layout for log4net.
        /// </summary>
        /// <returns>A configured <see cref="PatternLayout"/>.</returns>
        private static PatternLayout GetPatternLayout()
        {
            var patternLayout = new PatternLayout
            {
                ConversionPattern = "%message%newline",
            };
            patternLayout.ActivateOptions();
            return patternLayout;
        }
    }
}