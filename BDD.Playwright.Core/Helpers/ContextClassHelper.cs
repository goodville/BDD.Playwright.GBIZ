namespace BDD.Playwright.Core.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using BDD.Playwright.Core.CustomAttributes;

    /// <summary>
    /// Helper class for working with context objects and properties decorated with <see cref="GherkinNameAttribute"/>.
    /// Provides methods to retrieve context instances and property values by their Gherkin names.
    /// </summary>
    public class ContextClassHelper
    {
        /// <summary>
        /// Retrieves an instance from the provided list of context objects that matches the specified Gherkin context type.
        /// </summary>
        /// <param name="contextObjects">A list of context objects to search.</param>
        /// <param name="contextType">The Gherkin name of the context type to find.</param>
        /// <returns>The matching context object instance.</returns>
        /// <exception cref="InvalidOperationException">Thrown if no matching context type is found.</exception>
        public static object GetContextInstace(List<object> contextObjects, string contextType)
        {
            var instance = contextObjects.FirstOrDefault(obj =>
            obj.GetType().GetCustomAttributes(typeof(GherkinNameAttribute), false)
            .Cast<GherkinNameAttribute>()
            .Any(attr => attr.GherkinName == contextType));

            return instance ?? throw new InvalidOperationException($"Unknown context type {contextType}");
        }

        /// <summary>
        /// Gets the value of a property from the specified context instance by its Gherkin name.
        /// </summary>
        /// <param name="contextInstance">The context object instance.</param>
        /// <param name="gherkinPropertyName">The Gherkin name of the property to retrieve.</param>
        /// <returns>The value of the property.</returns>
        /// <exception cref="KeyNotFoundException">Thrown if the property is not found.</exception>
        public static object GetPropertyValueByGherkinName(object contextInstance, string gherkinPropertyName)
        {
            var property = GetPropertyByGherkinName(contextInstance, gherkinPropertyName);
            return property.GetValue(contextInstance);
        }

        /// <summary>
        /// Gets the <see cref="PropertyInfo"/> of a property from the specified context instance by its Gherkin name.
        /// </summary>
        /// <param name="contextInstance">The context object instance.</param>
        /// <param name="gherkinPropertyName">The Gherkin name of the property to find.</param>
        /// <returns>The <see cref="PropertyInfo"/> of the matching property.</returns>
        /// <exception cref="KeyNotFoundException">Thrown if the property is not found.</exception>
        public static PropertyInfo GetPropertyByGherkinName(object contextInstance, string gherkinPropertyName)
        {
            var property = contextInstance.GetType()
            .GetProperties()
            .FirstOrDefault(p => p.GetCustomAttributes(typeof(GherkinNameAttribute), false)
            .Cast<GherkinNameAttribute>()
            .Any(attr => attr.GherkinName == gherkinPropertyName));

            return property ?? throw new KeyNotFoundException($"Property '{gherkinPropertyName}' not found in {contextInstance.GetType().Name}.");
        }
    }
}
