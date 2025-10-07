// SaveTestResultRequest.cs
namespace BDD.Playwright.Core.Models.SaveTestResultModels
{
    using System;

    /// <summary>
    /// Represents a request to save the result of a test execution.
    /// Contains metadata about the test run, scenario, environment, outcome, and execution context.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This model is typically used to send test result data to a reporting or results storage service.
    /// </para>
    /// </remarks>
    public class SaveTestResultRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier for the test result.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the test run ID.
        /// </summary>
        public int RunID { get; set; }

        /// <summary>
        /// Gets or sets the project name.
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// Gets or sets the test environment name.
        /// </summary>
        public string Environment { get; set; }

        /// <summary>
        /// Gets or sets the feature name.
        /// </summary>
        public string FeatureName { get; set; }

        /// <summary>
        /// Gets or sets the scenario name.
        /// </summary>
        public string ScenarioName { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the test was executed.
        /// </summary>
        public string ExecutedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the test result (e.g., "Passed", "Failed").
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// Gets or sets the machine name where the test was executed.
        /// </summary>
        public string MachineName { get; set; }

        /// <summary>
        /// Gets or sets the user who executed the test.
        /// </summary>
        public string ExecutedBy { get; set; }

        /// <summary>
        /// Gets or sets the execution type (e.g., "Local", "Grid", "Azure").
        /// </summary>
        public string ExecutionType { get; set; }

        /// <summary>
        /// Gets or sets the tags associated with the test.
        /// </summary>
        public string Tags { get; set; }

        /// <summary>
        /// Gets or sets the reason for failure, if the test failed.
        /// </summary>
        public string FailureReason { get; set; }

        /// <summary>
        /// Gets or sets the test category.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the sprint name associated with the test run.
        /// </summary>
        public string SprintName { get; set; }

        /// <summary>
        /// Gets or sets the duration of the test execution.
        /// </summary>
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// Gets or sets the release link (e.g., Azure DevOps release URL).
        /// </summary>
        public string ReleaseLink { get; set; }
    }
}