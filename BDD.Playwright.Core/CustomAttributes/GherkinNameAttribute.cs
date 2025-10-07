namespace BDD.Playwright.Core.CustomAttributes
{
    using System;

    /// <summary>
    /// Attribute for specifying a Gherkin name for a class or property.
    /// Used to map C# classes or properties to their corresponding Gherkin names in BDD scenarios.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This attribute can be applied to classes or properties to provide a custom Gherkin name, which is useful for aligning code with Gherkin feature files.
    /// </para>
    /// <para>
    /// Example usage:
    /// <code language="csharp">
    /// [GherkinName("MyGherkinName")]
    /// public class MyClass { }
    /// </code>
    /// </para>
    /// </remarks>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class GherkinNameAttribute : Attribute
    {
        /// <summary>
        /// Gets the Gherkin name associated with the class or property.
        /// </summary>
        public string GherkinName { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GherkinNameAttribute"/> class.
        /// </summary>
        /// <param name="gherkinName">The Gherkin name to associate with the class or property.</param>
        public GherkinNameAttribute(string gherkinName) => GherkinName = gherkinName;
    }
}
