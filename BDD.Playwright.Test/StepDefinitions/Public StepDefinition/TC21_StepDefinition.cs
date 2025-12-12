using BDD.Playwright.Core.Interfaces;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.PublicPages;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BDD.Playwright.Test.StepDefinitions.Public_StepDefinition
{
    [Binding]
    public class TC21_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public CommonXpath _commonXpath;
        private readonly ReportAClaimStartPage _reportAClaimStartPage;
        private readonly IFileReader _fileReader;
        public TC21_StepDefinition(ScenarioContext scenarioContext, CommonXpath commonXpath, ReportAClaimStartPage reportAClaimStartPage, IFileReader fileReader) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _commonXpath = commonXpath;
            _reportAClaimStartPage = reportAClaimStartPage;
            _fileReader = fileReader;
        }

        [When("User click on report a claim and click submits and verifies the date of loss error message")]
        public async Task WhenUserClickOnReportAClaimAndClickSubmitsAndVerifiesTheDateOfLossErrorMessageAsync()
        {
            await TextLink.ClickTextLinkAsync(_commonXpath.PolicyHolderReportaClaim_Link, true, 1);
            await Button.ClickButtonAsync(_commonXpath.Submit_Btn, ActionType.Click, true, 1);
            await Label.VerifyTextAsync(_reportAClaimStartPage.ErrorMessage_Text, "Please enter a valid date of loss", true, 1);
        }

        [When("User enters value for policyNumber, zipcode and submits and verifies the date error message")]
        public async Task WhenUserEntersValueForPolicyNumberZipcodeAndSubmitsAndVerifiesTheDateErrorMessageAsync()
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter.");
            }

            try
            {
                var filePath = "ReportAClaimStartPage\\ReportAClaimStartPage.json";
                var profileKey = "ReportAclaimTC19";
                var policyNumber_Input = _fileReader.GetOptionalValue(filePath, $"{profileKey}.policyNumber_Input");
                var zipCode_Input = _fileReader.GetOptionalValue(filePath, $"{profileKey}.zipCode_Input");
                var dateOfLoss = _fileReader.GetOptionalValue(filePath, $"{profileKey}.DateOfLoss");

                logger.WriteLine($"Starting to enter claim start page details for profile: {profileKey}");
                await page.WaitForLoadStateAsync(LoadState.NetworkIdle, new PageWaitForLoadStateOptions
                {
                   Timeout = 30000
                });
                await InputField.SetTextAreaInputFieldAsync(_reportAClaimStartPage.PolicyNumber_Input, policyNumber_Input, true, 1, "policyNumber_Input");
                await InputField.SetTextAreaInputFieldAsync(_reportAClaimStartPage.ZipCode_Input, zipCode_Input, true, 1, "zipCode_Input");
                await InputField.SetTextAreaInputFieldAsync(_reportAClaimStartPage.OccurrenceDate_Input, dateOfLoss, true, 1, "DateOfLoss");
                await Button.ClickButtonAsync(_commonXpath.Submit_Btn, ActionType.Click, true, 1);
                await Label.VerifyTextAsync(_reportAClaimStartPage.ErrorMessage_Text, "Please enter a valid date of loss", true, 1);
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error in WhenUserEnterValueForPolicyNumberZipcodeAndDateAsync: {ex.Message}");
                throw;
            }
        }

        [When("User enters value for policyNumber, date and submits and verifies the zipcode error message")]
        public async Task WhenUserEntersValueForPolicyNumberDateAndSubmitsAndVerifiesTheZipcodeErrorMessageAsync()
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter.");
            }

            try
            {
                var filePath = "ReportAClaimStartPage\\ReportAClaimStartPage.json";
                var profileKey = "ReportAclaimTC19";
                var policyNumber = _fileReader.GetOptionalValue(filePath, $"{profileKey}.policyNumber_Input");
                var dateOfLoss = _fileReader.GetOptionalValue(filePath, $"{profileKey}.DateOfLoss");

                logger.WriteLine($"Starting to enter claim start page details for profile: {profileKey}");
                await page.ReloadAsync(new PageReloadOptions { Timeout = 30000 });
                await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
                await InputField.SetTextAreaInputFieldAsync(_reportAClaimStartPage.PolicyNumber_Input, policyNumber, true, 1, "Policy Number");
                await InputField.SetTextAreaInputFieldAsync(_reportAClaimStartPage.OccurrenceDate_Input, dateOfLoss, true, 1, "Date of Loss");
                await Button.ClickButtonAsync(_commonXpath.Submit_Btn, ActionType.Click, true, 1);
                await Label.VerifyTextAsync(_reportAClaimStartPage.ErrorMessage_Text, "Please enter a valid zip code.", true, 1);
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error in WhenUserEntersValueForPolicyNumberDateAndSubmitsAndVerifiesTheZipcodeErrorMessageAsync: {ex.Message}");
                throw;
            }
        }

        [When("User Enters value for date, zipcode and submits and verifies the policy number error message")]
        public async Task WhenUserEntersValueForDateZipcodeAndSubmitsAndVerifiesThePolicyNumberErrorMessageAsync()
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter.");
            }

            try
            {
                var filePath = "ReportAClaimStartPage\\ReportAClaimStartPage.json";
                var profileKey = "ReportAclaimTC19";
                var policyNumber_Input = _fileReader.GetOptionalValue(filePath, $"{profileKey}.policyNumber_Input");
                var zipCode_Input = _fileReader.GetOptionalValue(filePath, $"{profileKey}.zipCode_Input");
                var dateOfLoss = _fileReader.GetOptionalValue(filePath, $"{profileKey}.DateOfLoss");

                await page.ReloadAsync(new PageReloadOptions { Timeout = 30000 });
                await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
                await InputField.SetTextAreaInputFieldAsync(_reportAClaimStartPage.PolicyNumber_Input, policyNumber_Input, true, 1);
                await InputField.SetTextAreaInputFieldAsync(_reportAClaimStartPage.ZipCode_Input, zipCode_Input, true, 1);
                await Button.ClickButtonAsync(_commonXpath.Submit_Btn, ActionType.Click, true, 1);
                await Label.VerifyTextAsync(_reportAClaimStartPage.ErrorMessage_Text, "Please enter a valid policy number.", true, 1);
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error in WhenUserEntersValueForDateZipcodeAndSubmitsAndVerifiesThePolicyNumberErrorMessageAsync: {ex.Message}");
                throw;
            }
        }
    }
}
