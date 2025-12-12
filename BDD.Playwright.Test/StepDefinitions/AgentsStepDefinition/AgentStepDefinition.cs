using BDD.Playwright.Core.Interfaces;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.AgentPages;
using BDD.Playwright.GBIZ.Pages.AgentsPages;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.GlobalPages;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using BDD.Playwright.Origami.Pages.AgentPages;
using Microsoft.Playwright;
using Reqnroll;
using System.Threading;

namespace BDD.Playwright.GBIZ.Steps.AgentsStepDefinition
{
    [Binding]
    public class AgentStepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly CommonXpath _commonXpath;
        private readonly MyBusinessHomePage _myBusinessHomePage;
        private readonly LoginPage _loginPage;
        private readonly FooterLink _footerLink;
        private readonly AgentTC13_StepDefinition _agentTC13_StepDefinition;
        private readonly QuickSearchPage _quickSearchPage;

        public AgentStepDefinition(
            ScenarioContext scenarioContext,
            LoginPage loginPage,
            CommonXpath commonXpath,
            FooterLink footerLink,
            QuickSearchPage quickSearchPage,
            AgentTC13_StepDefinition agentTC13_StepDefinition,
            MyBusinessHomePage myBusinessHomePage) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
           // _agentTC13_StepDefinition = agentTC13_StepDefinition;
            _loginPage = loginPage;
            _commonXpath = commonXpath;
            _footerLink = footerLink;
            _quickSearchPage = quickSearchPage;
            _myBusinessHomePage = myBusinessHomePage;
            _agentTC13_StepDefinition = agentTC13_StepDefinition;
        }

        #region Xpath Selectors
        public string Downloaddocs => "//div[contains(text(),'Document Downloads')]";
        public string ComAuto_Dropdown => "//select[@name='manualcode']";
        public string Continue_DownloadDocs => "//input[@value='Continue']";
        public string GoodvilleContact_text => "(//*[@id=\"modules\"]//*['Your Goodville Contacts'])[38]";
        public string ForgotPassword_button => "//a[contains(text(),'Forgot password?')]";
        public string EmaiAddreS_FielD => "//input[@name='email']";
        public string ContinueButton_webMail => "//button[contains(text(),'CONTINUE')]";
        #endregion

        [When(@"User clicks on Privacy, Contact and Term condtions Links")]
        public async Task WhenUserClicksonPrivacyContactandTermConditionsLinksAsync()
        {
            await _footerLink.PrivacyMethodAsync();
            await _footerLink.ContactUsMethodAsync();
            await _footerLink.TermMethodAsync();
        }

        [When(@"User will Search for an Policy from {string}")]
        public async Task WhenUserwillSearchforanPolicyAsync(string profileKey)
        {
            await _quickSearchPage.QuickSearchMethodAsync(profileKey);
        }

        [When("User will Search for an Policy with radio {string} and input {string}")]
        public async Task WhenUserWillSearchForAnPolicyWithRadioAndInputAsync(string p0, string p1)
        {
            await _quickSearchPage.QuickSearchMethodWithStringAsync(p0, p1);
        }

        [When("User verifies download documents for delaware state")]
        public async Task WhenUserVerifiesDownloadDocumentsForDelawareStateAsync()
        {
           await Label.VerifyTextAsync(Downloaddocs, "DOCUMENT DOWNLOADS", true, 1);
        }

        [When("User navigates to line of business as commercial auto dropdown")]
        public async Task WhenUserNavigatesToLineOfBusinessAsCommercialAutoDropdownAsync()
        {
            await DropDown.SelectDropDownAsync(ComAuto_Dropdown, "Commercial Auto", true, 1);
        }

        [When("User click on continue button for download document page")]
        public async Task WhenUserClickOnContinueButtonForDownloadDocumentPageAsync()
        {
            await Button.ClickButtonAsync(Continue_DownloadDocs, ActionType.Click, true, 2);
        }

        [When("User verifies each links of QuickLink page")]
        public async Task WhenUserVerifiesEachLinksOfQuickLinkPageAsync()
        {
            await _agentTC13_StepDefinition.SectionTitleVerifyMethodAsync(_myBusinessHomePage.ContactUs_Link, _myBusinessHomePage.ContactUs_Text, "Contact Us", "Back");
            await _agentTC13_StepDefinition.SectionTitleVerifyMethodAsync(_myBusinessHomePage.HolidaySchedule_Link, _myBusinessHomePage.HolidaySchedule_Text, "Holiday Schedule", "Back");
            await _agentTC13_StepDefinition.SectionTitleVerifyMethodAsync(_myBusinessHomePage.ViewActiveCreditReports_Link, _myBusinessHomePage.ViewActiveCreditReports_Text, "Credit Search", "Back");
            await _agentTC13_StepDefinition.SectionTitleVerifyMethodAsync(_myBusinessHomePage.RiskAddressGrouping_Link, _myBusinessHomePage.RiskAddressGrouping_Text, "Risk Address Grouping", "Back");
            await _agentTC13_StepDefinition.SectionTitleVerifyMethodAsync(_myBusinessHomePage.JoinSession_Link, _myBusinessHomePage.JoinSession_Text, "Join a Session", "Back");
        }

        [When("User verifies goodville contact text")]
        public async Task WhenUserVerifiesGoodvilleContactTextAsync()
        {
            await Label.VerifyTextAsync(GoodvilleContact_text, "Your Goodville Contacts", true, 1);
        }

        [When("User navigates to seeall Link page")]
        public async Task WhenUserNavigatesToSeeallLinkPageAsync()
        {
            await Button.ClickButtonCssAsync(_commonXpath.ShadowHost_SeeAllLink, _commonXpath.SeeAll_dOcumentshadow);
        }

        [When("User Click on Agent page")]
        public async Task WhenUserClickOnAgentPageAsync()
        {
            await Button.ClickButtonAsync(_commonXpath.AgentPortal, ActionType.Click, true, 1);
        }

        [When("User Navigates to forgot password button")]
        public async Task WhenUserNavigatesToForgotPasswordButtonAsync()
        {
            await Button.ClickButtonAsync(ForgotPassword_button, ActionType.Click, true, 1);
        }

        [When("User enter {string} in emailAddress field")]
        public async Task WhenUserEnterInEmailAddressFieldAsync(string email)
        {
            await InputField.SetTextAreaInputFieldAsync(EmaiAddreS_FielD, email, true, 1);
            await Button.ClickButtonAsync(EmaiAddreS_FielD, ActionType.Click, true, 1);
        }

        [When("User Navigates to EmailAddress Continu Button")]
        public async Task WhenUserNavigatesToEmailAddressContinuButtonAsync()
        {
            await Button.ClickButtonAsync(ContinueButton_webMail, ActionType.Click, true, 1);
        }

        [When("user navigates to webmail using new tab")]
        public async Task WhenUserNavigatesToWebmailUsingNewTabAsync()
        {
            var newPage = await page.Context.NewPageAsync();
            await newPage.GotoAsync("https://outlook.office.com/mail/webdev5emails@goodville.com/");
            // Optionally, store/switch context if following actions target this page
        }
    }
}