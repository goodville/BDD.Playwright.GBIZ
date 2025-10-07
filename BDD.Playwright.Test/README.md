# BDD.Playwright.Test

## Overview
Comprehensive test automation project implementing BDD scenarios for Guidewire and Duck Creek applications using Playwright and Reqnroll. This project contains the actual test scenarios, step definitions, and test data management for automated testing across multiple insurance platforms.

## Features
- **BDD Scenarios**: Gherkin-based test scenarios with clear business context
- **Step Definitions**: Strongly-typed implementation of test steps
- **Test Data Management**: JSON-based test data handling with dynamic data support
- **Multiple Application Support**: Tests for PolicyCenter, BillingCenter, and ClaimsCenter
- **Cross-module Integration**: End-to-end testing across insurance platforms
- **Parallel Execution**: Support for concurrent test execution
- **Extensive Reporting**: Detailed test execution reports via ExtentReports

## Project StructureBDD.Playwright.Test/
├── Features/
│   ├── Guidewire/
│   │   ├── API/                      # API test scenarios
│   │   ├── UI/                       # UI test scenarios
│   │   │   ├── Designatedfunctions/
│   │   │   │   ├── BC/               # BillingCenter functions
│   │   │   │   ├── CC/               # ClaimsCenter functions
│   │   │   │   └── PC/               # PolicyCenter functions
│   │   │   └── HighlevelScenarios/
│   │   │       ├── BillingCenter/
│   │   │       ├── ClaimsCenter/
│   │   │       └── PolicyCenter/
│   └── DuckCreek/                    # Duck Creek specific features
├── StepDefinitions/
│   ├── UI/
│   │   ├── BillingCenter/
│   │   ├── ClaimsCenter/
│   │   └── PolicyCenter/
│   └── API/
├── Data/
│   └── JsonTestData/
│       ├── BillingCenter/
│       ├── ClaimsCenter/
│       └── PolicyCenter/
├── Hooks/                            # Test execution hooks
└── ParallelExecution/                # Parallel test configuration

## Key Components

### Step Definitions
- **Policy Management**
  - `GuidewirePolicyCreationSteps`: Policy creation and management
  - `GuidewirePolicySearchPageSteps`: Policy search operations
  - `GuidewirePolicySubmissionWizardSteps`: Policy submission workflow
  - `GuidewirePolicyAssignTaskSteps`: Task assignment handling

- **Billing Operations**
  - `BillingCenterNavigationSteps`: Navigation in BillingCenter
  - `BillingCenterTransactionSteps`: Payment transactions
  - `BillingCenterPaymentScheduleSteps`: Payment schedule management

- **Claims Processing**
  - `ClaimsCenterAddNoteSteps`: Claims notes functionality
  - `ClaimsStatusSteps`: Claims status management

### Test Data Files
- **PolicyCenter**
  - `PolicyCreationTestData.json`: Policy creation data
  - `PolicySearchTestData.json`: Search criteria data

- **BillingCenter**
  - `AccountTestData.json`: Billing account data
  - `PaymentTestData.json`: Payment transaction data

## Example Scenarios

### Policy ManagementFeature: Policy Lifecycle Processing
@policy_center @billing_center @claim_center
Scenario: End-to-end Policy Processing
    Given the user logs into "PolicyCenter" as "Superuser"
    And the user has an active "Personal Auto" policy
    When the user creates new FNOL
    Then the claim should be associated with the correct policy number

### Billing OperationsFeature: Billing Search Functionality
@billing_center
Scenario: Validate Policy Billing Information
    Given the user logs into "BillingCenter" as "Superuser"
    When the user searches for the policy in billing center
    Then the billing information should match policy details

## Test Data Management
1. Store test data in JSON files under Data/JsonTestData/
2. Use data loading steps to reference test data in scenarios
3. Implement round-robin data providers for dynamic data
4. Support environment-specific test data configurations

## Running Tests

### Prerequisites
- .NET 8.0 SDK
- Visual Studio 2022 or later
- Required NuGet packages:
  - Reqnroll.NUnit (v2.4.1)
  - NUnit3TestAdapter
  - StyleCop.Analyzers
  - Microsoft.Playwright

### Configuration
1. Set up core environment settings in `appsettings.json`:{
    "ProjectName": "PlaywrightUIAutomation",
    "ProductName": "guidewire",
    "Browser": "chrome",
    "Headless": "false",
    "Environment": "QA",
    "ExecutionType": "LOCAL",
    "PageLevelScreenshot": "Yes",
    "GlobalTimeout": 30,
    "WebElementTimeout": 30,
    "TestDataFolderPath": "Data\\JsonTestData"
}
2. Configure Cloud Storage for test artifacts:{
    "CloudStorageConfig": {
        "Enabled": true,
        "Provider": "Azure",
        "AzureConfig": {
            "ConnectionString": "DefaultEndpointsProtocol=https;AccountName=your-account;AccountKey=your-key;EndpointSuffix=core.windows.net"
        }
    }
}
3. Set up Round Robin Configuration for data rotation:{
    "RoundRobinConfiguration": {
        "Enabled": true,
        "Source": "Cloud",
        "CloudConfig": {
            "Container": "roundrobinconfig"
        }
    }
}
4. Configure Address Providers for test data:{
    "AddressLists": {
        "RoundRobin": {
            "Name": "Addresses",
            "Source": "LocalFile",
            "LocalFileConfig": {
                "FilePath": "Addresses\\Addresses.json",
                "DataKey": "Addresses"
            }
        },
        "AdditionalLocations": {
            "Name": "AdditionalLocations",
            "Source": "LocalFile",
            "LocalFileConfig": {
                "FilePath": "Addresses\\AdditionalLocations.json",
                "DataKey": "AdditionalLocations"
            }
        }
    }
}
5. Set up Product Environment Configuration:{
    "products": [
        {
            "name": "Guidewire",
            "environments": {
                "QA": {
                    "productSuites": {
                        "PolicyCenter": {
                            "url": "https://pc-dev.example.com/PolicyCenter.do",
                            "username": "su",
                            "password": "gw",
                            "apiEndpoint": "https://pc-dev.example.com/rest/"
                        }
                    }
                }
            }
        }
    ]
}

### Configuration Details

#### Cloud Storage
- **Enabled**: Toggle cloud storage functionality
- **Provider**: Supported providers: Azure, AWS, Google
- **ConnectionString**: Provider-specific connection string
- Used for storing test artifacts, screenshots, and logs

#### Round Robin Configuration
- **Enabled**: Enable/disable data rotation
- **Source**: Data source type (Cloud, Database, LocalFile)
- **Container**: Cloud storage container for configuration
- Ensures test data variation and prevents data conflicts

#### Address Provider
- **Source**: Data source configuration (LocalFile, Cloud, Database)
- **FilePath**: Path to local address data files
- **DataKey**: JSON key for address data
- Supports multiple address lists for different test scenarios
- Enables dynamic address data for location-based testing

#### Environment Settings
- **GlobalTimeout**: Default timeout for all operations (seconds)
- **WebElementTimeout**: Element interaction timeout (seconds)
- **PageLevelScreenshot**: Enable/disable automatic screenshots
- **Authentication**: Toggle authentication requirements
- **RetryCount**: Number of retry attempts for failed operations

## Best Practices
1. Follow BDD principles and clear scenario writing
2. Maintain scenario independence
3. Use appropriate tags for test organization
4. Implement robust step definitions
5. Handle test data properly
6. Include proper logging
7. Follow parallel execution guidelines

## Contributing
1. Follow BDD best practices
2. Use clear, descriptive scenario names
3. Maintain test data integrity
4. Document new step definitions
5. Follow C# coding standards
6. Include XML documentation
7. Test in multiple environments

## Troubleshooting
1. Test data issues:
   - Verify JSON file paths
   - Check data format
   - Validate environment configuration

2. UI Automation issues:
   - Review page object selectors
   - Check element visibility
   - Verify wait conditions
   - Review synchronization settings

3. Integration issues:
   - Validate cross-module dependencies
   - Check service availability
   - Review authentication settings

For detailed implementation examples, refer to the existing scenarios in the Features directory.