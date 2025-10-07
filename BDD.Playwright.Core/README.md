# BDD.Playwright.Core

## Overview
Core library for BDD (Behavior Driven Development) test automation using Playwright and Reqnroll. This library provides the fundamental infrastructure, helpers, and utilities needed to support automated testing across insurance platforms.

## Key Features
- **Configurable Test Framework**: Flexible configuration system supporting multiple environments and execution modes
- **Logging Infrastructure**: Comprehensive logging system with both step-level and global logging capabilities
- **Report Generation**: Built-in ExtentReports integration for detailed test execution reporting
- **Screenshot Management**: Automated screenshot capture for test failures and debugging
- **Security Integration**: Azure Key Vault integration for secure credential management
- **Cross-browser Support**: Support for multiple browsers through Playwright
- **Parallel Execution**: Support for concurrent test execution
- **Context Management**: Sophisticated test context handling and sharing

## Project StructureBDD.Playwright.Core/
├── Configuration/           # Configuration management
│   ├── GlobalConfig/        # Global settings
│   └── TestSettings/        # Environment-specific settings
├── Engine/                  # Core test execution
│   ├── Browser/             # Browser management
│   └── Parallel/            # Parallel execution support
├── Helpers/                 # Utility classes
│   ├── ContextClassHelper/
│   ├── DataTableHelper/
│   └── ExtentReportHelper/
├── Interfaces/              # Core contracts
│   ├── IPageObject/
│   └── ITestContext/
├── Loggers/                 # Logging implementation
│   └── ApplicationLogger/
└── PageElements/            # Base page components
    └── BaseElement/
## Key Components

### Base Classes
- **BaseElement**: Foundation for page elements with common functionality
- **BasePage**: Template for page objects with standard operations
- **BaseTest**: Core test setup and teardown functionality

### Helpers
- **ContextClassHelper**: Manages test context and data sharing
- **DataTableHelper**: Handles BDD scenario data tables
- **ExtentReportHelper**: Generates detailed test reports

### Logging Infrastructure
- **ApplicationLogger**: Structured logging with:
  - Timestamped entries
  - Step-level log accumulation
  - Global logging integration
  - Screenshot integration
  - Environment information

## Configuration

### Core Settings{
    "Browser": "chrome",
    "Headless": false,
    "GlobalTimeout": 30,
    "PageLevelScreenshot": true,
    "RetryCount": 0
}
### Security Configuration{
    "KeyVaultName": "TestAutomationVault",
    "Authentication": {
        "Enabled": true,
        "Provider": "AzureAD"
    }
}
### Logging Configuration{
    "Logging": {
        "LogLevel": "Information",
        "IncludeTimestamp": true,
        "ScreenshotOnFailure": true
    }
}
## Usage Examples

### Initialize Test Context// Set up browser context
var browser = await playwright.ChromiumAsync();
var context = await browser.NewContextAsync();
scenarioContext.Set(context, "BrowserContext");

// Initialize logger
var logger = new ApplicationLogger(scenarioContext);
logger.WriteLine("Test initialization complete");

### Base Page Implementation
public class LoginPage : BasePage
{
    public LoginPage(ScenarioContext context) : base(context)
    {
        // Page initialization
    }

    public async Task LoginAsync(string username, string password)
    {
        await SetTextAsync("Username", username);
        await SetTextAsync("Password", password);
        await ClickButtonAsync("Login");
    }
}
### Extent Reporting
public async Task LogTestStep(string stepName, string details)
{
    await ExtentReportHelper.LogStepAsync(stepName, details);
    await TakeScreenshotAsync($"Step_{stepName}");
}
## Best Practices
1. Always use the provided logging infrastructure
2. Implement new page objects following the BasePage pattern
3. Use configuration settings from GlobalConfig
4. Handle async operations correctly with Task-based patterns
5. Follow the established error handling patterns
6. Implement proper waits and synchronization
7. Use strongly-typed context objects

## Contributing
1. Follow C# coding standards and StyleCop rules
2. Include XML documentation for public APIs
3. Add appropriate unit tests for new functionality
4. Use meaningful commit messages
5. Submit PRs with clear descriptions
6. Follow async/await best practices
7. Maintain backward compatibility

## Troubleshooting
1. Browser Issues:
   - Check browser configuration
   - Verify Playwright installation
   - Review screenshot artifacts

2. Test Context Issues:
   - Validate context initialization
   - Check context sharing
   - Review parallel execution settings

3. Logging Issues:
   - Verify log configuration
   - Check file permissions
   - Review log levels

## Support
For questions or issues:
1. Check existing documentation
2. Review logging output
3. Analyze test reports
4. Consult with team leads
5. Submit detailed bug reports