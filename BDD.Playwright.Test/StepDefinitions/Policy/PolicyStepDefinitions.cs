using BDD.Playwright.Core.Interfaces;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.GlobalPages;
using BDD.Playwright.GBIZ.Pages.PublicPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD.Playwright.Test.StepDefinitions.Policy
{
    [Binding]
    public class PolicyStepDefinitions : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IFileReader _fileReader;
        private readonly ReportAClaimFormPage _reportAClaimForm;
        private readonly LoginPage _loginPage;
        public PolicyStepDefinitions(ScenarioContext scenarioContext, IFileReader fileReader, ReportAClaimFormPage reportAClaimFormPage, LoginPage loginPage) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _fileReader = fileReader;
            _reportAClaimForm = reportAClaimFormPage;
            _loginPage = loginPage;
        }

        [Given(@"User logs into GBIZ")]
        public async Task GivenUserLogsIntoGBIZAsync()
        {
            var url = _fileReader.GetValue($"Urls\\GBIZUrls.json", "GBIZ");
            Console.WriteLine($"GBIZ URL: {url}");
            await page.GotoAsync(url);
        }

        [When("User Click on Agents or Members using json")]
        public async Task WhenUserClickOnAgentsOrMembersUsingJsonAsync()
        {
            await _loginPage.LoginUsingJSONAsync();
        }

        [When(@"User Click on Agents or Members")]
        public async Task WhenUserClickonAgentsorMembersAsync()
        {
            await _loginPage.LoginUsingJSONAsync();
        }

        [When("User enters mandatory fields for auto claim report from {string}")]
        public async Task WhenUserEntersMandatoryFieldsForAutoClaimReportFromAsync(string ProfileKey)
        {
            await _reportAClaimForm.ReportAClaimAsync(ProfileKey);
            await _reportAClaimForm.AutoClaimInformationAsync(ProfileKey);
        }

        [When(@"User Submits the Auto Claim Report")]
        public async Task WhenUserSubmitstheAutoClaimReportAsync()
        {
            await _reportAClaimForm.ClaimSubmitAsync();
        }

        [When("User enters mandatory all fields for auto claim report from {string}")]
        public async Task WhenUserEntersMandatoryAllFieldsForAutoClaimReportFromAsync(string ProfileKey)
        {
            await _reportAClaimForm.ReportAClaimAsync(ProfileKey);
        }

        [When("User enters mandatory fields for Homeowner claim report from {string}")]
        public async Task WhenUserEntersMandatoryFieldsForHomeownerClaimReportFromAsync(string ProfileKey)
        {
            await _reportAClaimForm.HomeClaimInformationAsync(ProfileKey);
        }

        [When("User Submits the Homeowner Claim Report")]
        public async Task WhenUserSubmitsTheHomeownerClaimReportAsync()
        {
            await _reportAClaimForm.ClaimSubmitAsync();
        }
    }
}
