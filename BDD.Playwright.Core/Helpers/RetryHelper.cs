namespace BDD.Playwright.Core.Helpers
{
    using System;
    using System.Threading;
    using BDD.Playwright.Core.Loggers;

    /// <summary>
    /// Provides helper methods for executing actions with retry logic.
    /// Useful for handling transient failures in test automation, such as flaky network calls or UI interactions.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The <see cref="WaitAndRetry"/> method executes the specified action and retries it if an exception is thrown,
    /// waiting for the specified interval between attempts. All attempts and failures are logged using <see cref="CustomLogger"/>.
    /// </para>
    /// </remarks>
    /// <example>
    /// <para>
    /// Example usage:
    /// </para>
    /// <code language="csharp">
    /// RetryHelper.WaitAndRetry(() =>
    /// {
    ///     // Code that may intermittently fail
    ///     PerformUnreliableOperation();
    /// }, maxRetries: 3, retryInterval: TimeSpan.FromSeconds(2));
    /// </code>
    /// </example>
    public class RetryHelper
    {
        /// <summary>
        /// Executes the specified action, retrying up to <paramref name="maxRetries"/> times if an exception occurs.
        /// Waits for <paramref name="retryInterval"/> between retries. Logs each attempt and failure.
        /// </summary>
        /// <param name="action">The action to execute.</param>
        /// <param name="maxRetries">The maximum number of retry attempts.</param>
        /// <param name="retryInterval">The time to wait between retries.</param>
        /// <exception cref="Exception">
        /// Thrown if the action fails on all retry attempts. The thrown exception contains the last error as its inner exception.
        /// </exception>
        public static void WaitAndRetry(Action action, int maxRetries, TimeSpan retryInterval)
        {
            var retryCount = 0;
            while (retryCount < maxRetries)
            {
                try
                {
                    CustomLogger.WriteLine($"Attempt {retryCount + 1}...");
                    action();
                    break;
                }
                catch (Exception ex)
                {
                    retryCount++;
                    CustomLogger.WriteLine($"Retry {retryCount} failed: {ex.Message}");

                    if (retryCount >= maxRetries)
                    {
                        throw new Exception($"Getting Exception : {ex.Message} after {retryCount} retries.", ex);
                    }

                    Thread.Sleep(retryInterval);
                }
            }
        }
    }
}
