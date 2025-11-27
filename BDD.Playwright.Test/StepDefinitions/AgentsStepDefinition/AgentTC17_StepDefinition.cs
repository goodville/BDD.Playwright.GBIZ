using System;
using System.Threading.Tasks;
using BDD.Playwright.GBIZ.Pages.AgentPages;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.GlobalPages;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using Microsoft.Playwright;
using Reqnroll;

namespace BDD.Playwright.GBIZ.Steps.AgentsStepDefinition
{
    [Binding]
    public class AgentTC17_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public LoginPage _loginPage;

        public AgentTC17_StepDefinition(
            ScenarioContext scenarioContext,
            LoginPage loginPage,
            CommonXpath commonXpath) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _loginPage = loginPage;
            _commonXpath = commonXpath;
        }

        #region Xpath
        public string SelectState_Dropdown => "//select[@name='state']";
        public string PABusiness_docSearch => "//input[@name='keywords']";
        public string Doc_SubmitbUtton => "//input[@type='submit']";
        public string DocumentsVerify_Text => "//div[contains(text(),'{0}')]";
        #endregion

        [When("User navigates to Documents page")]
        public async Task WhenUserNavigatesToDocumentsPageAsync()
        {
            await Button.ClickButtonCssAsync(_commonXpath.ShadowHostSlidePanelShadow, _commonXpath.DocumentsSidePanelShadow);
        }

        [When("User Navigates to PennsylvaniaSate Drpdown")]
        public async Task WhenUserNavigatesToPennsylvaniaSateDrpdownAsync()
        {
            await DropDown.SelectDropDownAsync(SelectState_Dropdown, "Pennsylvania", true, 1);
        }

        [When("User enter {string} in PAbusiness cover documents search page")]
        public async Task WhenUserEnterInPAbusinessCoverDocumentsSearchPageAsync(string cov)
        {
            await InputField.SetTextAreaInputFieldAsync(PABusiness_docSearch, cov, true, 1);
            await Button.ClickButtonAsync(PABusiness_docSearch, PageElements.ActionType.Click, true, 1);
        }

        [When("User Click on PASearch Submit buTton")]
        public async Task WhenUserClickOnPASearchSubmitBuTtonAsync()
        {
            await Button.ClickButtonAsync(Doc_SubmitbUtton, PageElements.ActionType.Click, true, 1);
        }

        [When("User verifies the displayed pennsylvania docuements for cov")]
        public async Task WhenUserVerifiesTheDisplayedPennsylvaniaDocuementsForCovAsync()
        {
            await Label.VerifyTextAsync(string.Format(DocumentsVerify_Text, "Bulletins"), "BULLETINS", true, 1);
            await Label.VerifyTextAsync(string.Format(DocumentsVerify_Text, "Extended Non-owned Coverage"), "Extended Non-owned Coverage", true, 1);
            await Label.VerifyTextAsync(string.Format(DocumentsVerify_Text, "Applications & Supplements"), "APPLICATIONS & SUPPLEMENTS", true, 1);
            await Label.VerifyTextAsync(string.Format(DocumentsVerify_Text, "Business Cover Application"), "Business Cover Application", true, 1);
            await Label.VerifyTextAsync(string.Format(DocumentsVerify_Text, "CL1045A"), "CL1045A", true, 1);
            await Label.VerifyTextAsync(string.Format(DocumentsVerify_Text, "CL1045B"), "CL1045B", true, 1);
            await Label.VerifyTextAsync(string.Format(DocumentsVerify_Text, "Brochures & Ads"), "BROCHURES & ADS", true, 1);
        }

        [When("User navigates to Delaware state dropdown")]
        public async Task WhenUserNavigatesToDelawareStateDropdownAsync()
        {
            await DropDown.SelectDropDownAsync(SelectState_Dropdown, "Delaware", true, 1);
        }

        [When("User Verifies the displayed Delaware docs")]
        public async Task WhenUserVerifiesTheDisplayedDelawareDocsAsync()
        {
            await Label.VerifyTextAsync(string.Format(DocumentsVerify_Text, "Endorsements"), "ENDORSEMENTS", true, 1);
            await Label.VerifyTextAsync(string.Format(DocumentsVerify_Text, "BCP"), "BCP", true, 1);
        }

        [When("User navigates to illinois state dropdown")]
        public async Task WhenUserNavigatesToIllinoisStateDropdownAsync()
        {
            await DropDown.SelectDropDownAsync(SelectState_Dropdown, "Illinois", true, 1);
        }

        [When("User Verifies the displayed Illinois docs")]
        public async Task WhenUserVerifiesTheDisplayedIllinoisDocsAsync()
        {
            await Label.VerifyTextAsync(string.Format(DocumentsVerify_Text, "BP322"), "BP322", true, 1);
            await Label.VerifyTextAsync(string.Format(DocumentsVerify_Text, "CGLYCR"), "CGLYCR", true, 1);
        }

        [When("User navigates to Indiana state dropdown")]
        public async Task WhenUserNavigatesToIndianaStateDropdownAsync()
        {
            await DropDown.SelectDropDownAsync(SelectState_Dropdown, "Indiana", true, 1);
        }

        [When("User Verifies the displayed Indiana docs")]
        public async Task WhenUserVerifiesTheDisplayedIndianaDocsAsync()
        {
            await Label.VerifyTextAsync(string.Format(DocumentsVerify_Text, "Endorsements"), "ENDORSEMENTS", true, 1);
            await Label.VerifyTextAsync(string.Format(DocumentsVerify_Text, "BCP"), "BCP", true, 1);
        }

        [When("User navigates to Kansas state dropdown")]
        public async Task WhenUserNavigatesToKansasStateDropdownAsync()
        {
            await DropDown.SelectDropDownAsync(SelectState_Dropdown, "Kansas", true, 1);
        }

        [When("User Verifies the displayed KanSas docs")]
        public async Task WhenUserVerifiesTheDisplayedKanSasDocsAsync()
        {
            await Label.VerifyTextAsync(string.Format(DocumentsVerify_Text, "Endorsements"), "ENDORSEMENTS", true, 1);
            await Label.VerifyTextAsync(string.Format(DocumentsVerify_Text, "BP322"), "BP322", true, 1);
        }

        [When("User navigates to Ohio state dropdown")]
        public async Task WhenUserNavigatesToOhioStateDropdownAsync()
        {
            await DropDown.SelectDropDownAsync(SelectState_Dropdown, "Ohio", true, 1);
        }

        [When("User Verifies the displayed Ohio docs")]
        public async Task WhenUserVerifiesTheDisplayedOhioDocsAsync()
        {
            await Label.VerifyTextAsync(string.Format(DocumentsVerify_Text, "Endorsements"), "ENDORSEMENTS", true, 1);
            await Label.VerifyTextAsync(string.Format(DocumentsVerify_Text, "BCP"), "BCP", true, 1);
        }

        [When("User navigates to Ohio Transition state dropdown")]
        public async Task WhenUserNavigatesToOhioTransitionStateDropdownAsync()
        {
            await DropDown.SelectDropDownAsync(SelectState_Dropdown, "Ohio Transition", true, 1);
        }

        [When("User Verifies the displayed Ohio Transition docs")]
        public async Task WhenUserVerifiesTheDisplayedOhioTransitionDocsAsync()
        {
            await Label.VerifyTextAsync(string.Format(DocumentsVerify_Text, "Endorsements"), "ENDORSEMENTS", true, 1);
            await Label.VerifyTextAsync(string.Format(DocumentsVerify_Text, "BCP"), "BCP", true, 1);
        }

        [When("User navigates to Oklahoma state dropdown")]
        public async Task WhenUserNavigatesToOklahomaStateDropdownAsync()
        {
            await DropDown.SelectDropDownAsync(SelectState_Dropdown, "Oklahoma", true, 1);
        }

        [When("User Verifies the displayed Oklahoma docs")]
        public async Task WhenUserVerifiesTheDisplayedOklahomaDocsAsync()
        {
            await Label.VerifyTextAsync(string.Format(DocumentsVerify_Text, "Endorsements"), "ENDORSEMENTS", true, 1);
            await Label.VerifyTextAsync(string.Format(DocumentsVerify_Text, "BP322"), "BP322", true, 1);
        }

        [When("User navigates to Ohio Pennsylvania state dropdown")]
        public async Task WhenUserNavigatesToOhioPennsylvaniaStateDropdownAsync()
        {
            await DropDown.SelectDropDownAsync(SelectState_Dropdown, "Pennsylvania", true, 1);
        }

        [When("User navigates to Verginia state dropdown")]
        public async Task WhenUserNavigatesToVerginiaStateDropdownAsync()
        {
            await DropDown.SelectDropDownAsync(SelectState_Dropdown, "Virginia", true, 1);
        }

        [When("User Verifies the displayed Verginia docs")]
        public async Task WhenUserVerifiesTheDisplayedVerginiaDocsAsync()
        {
            await Label.VerifyTextAsync(string.Format(DocumentsVerify_Text, "Endorsements"), "ENDORSEMENTS", true, 1);
            await Label.VerifyTextAsync(string.Format(DocumentsVerify_Text, "BP322"), "BP322", true, 1);
        }
    }
}