namespace BDD.Playwright.Core.Loggers
{
    using System;
    using System.Text;

    /// <summary>
    /// Provides logging functionality for BDD steps by accumulating log messages
    /// and forwarding them to the global <see cref="ApplicationLogger"/>.
    /// </summary>
    public class ApplicationLogger
    {
        // Accumulates log messages for individual steps.
        private readonly StringBuilder stepLog = new ();

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationLogger"/> class.
        /// </summary>
        public ApplicationLogger()
        {
            // The _stepLog is initialized inline.
        }

        /// <summary>
        /// Writes a log message with a timestamp to the internal step log and forwards it to the global logger.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void WriteLine(string message)
        {
            // Format the message with the current date/time.
            var formattedMessage = $"{DateTime.Now:yyyy-MM-dd-HH:mm:ss}: {message}";

            // Append the formatted message to the internal log.
            stepLog.AppendLine(formattedMessage);

            // Forward the original message to the global _logger.
            CustomLogger.WriteLine(message);
        }

        /// <summary>
        /// Reads and clears the accumulated log messages.
        /// </summary>
        /// <returns>A string containing all accumulated log messages.</returns>
        public string Read()
        {
            var logContent = stepLog.ToString();

            // Clear the internal log after reading.
            stepLog.Clear();
            return logContent;
        }
    }
}