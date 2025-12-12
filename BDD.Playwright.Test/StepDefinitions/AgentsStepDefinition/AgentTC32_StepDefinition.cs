using AventStack.ExtentReports.Gherkin.Model;
using BDD.Playwright.Core.Loggers;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using BDD.Playwright.Origami.Pages.AgentPages;
using GoodVille.GBIZ.Reqnroll.Automation.Pages.GlobalPages;

namespace GoodVille.GBIZ.Specflow.Automation.Steps.AgentsStepDefinition
{
    [Binding]
    public class AgentTC32_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public LoginPage _loginPage;
        public ProfilePage _profilePage;
        // Constructor
        public AgentTC32_StepDefinition(ScenarioContext scenarioContext, LoginPage loginPage, CommonXpath commonXpath, ProfilePage profilePage) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _loginPage = loginPage;
            _commonXpath = commonXpath;
            _profilePage = profilePage;
        }

        [When(@"User Clicks on the  Homeowners page")]
        public async Task UserClicksOnTheHomeownersPageAsync()
        {
            await Button.ClickButtonCssAsync(_commonXpath.ShadowHost, _commonXpath.QuotingSidePanelShadow);
            //await Button.ClickButtonAsync(_commonXpath.QuotingSidePanelShadow, ActionType.Click, true, 1);
            //await Label.VerifyTextAsync(_commonXpath.OnlineQuoting_Text, "Online Quoting", true, 1);
            await Button.ClickButtonAsync(_commonXpath.NewQuoteLink, ActionType.Click, true, 1);
            await Button.ClickButtonAsync(_commonXpath.Quote_Homeowners, ActionType.Click, true, 1);
            var isCheckboxPresent = await Checkbox.VerifyCheckboxExistAsync(_commonXpath.IHaveInformedInsured, true, 1, "I have informed the insured");
            // Optionally, add assertion:
            // Assert.IsTrue(isCheckboxPresent, "'I have informed the insured' checkbox is not present.");
            //await Label.VerifyTextAsync(_commonXpath.IHaveInformedInsured, "I have informed the insured", true, 1);
            await Button.ClickButtonAsync(_commonXpath.IHaveInformedInsured, ActionType.Click, true, 1);
            await Button.ClickButtonAsync(_commonXpath.OnlineQuoting_ContinueLink, ActionType.Click, true, 1);
        }

        [When(@"User Enter applicant information for change quote")]
        public async Task UserEnterApplicantInformationForChangeQuoteAsync()
        {
            await DropDown.SelectDropDownAsync(_commonXpath.HomeOwners_QuoteType, "Change", true, 1);
            await Task.Delay(6000);
            await InputField.SetTextAreaInputFieldAsync(_commonXpath.HomeOwners_QuoteChange_PolicyInput, "566188", true, 1);
            await Task.Delay(5000);
            await Button.ClickButtonAsync(_commonXpath.HomeOwners_PolicyInput_Reload, ActionType.Click, true, 1);
            await Task.Delay(6000);
            await DropDown.SelectDropDownAsync(_commonXpath.HomeOwners_PolicyInput_Producer, "Test_qa Agent2", true, 1);
            await Task.Delay(3000);
            await Button.ClickButtonAsync(_commonXpath.HomeOwners_PolicyInput_RCCost_Yes, ActionType.Click, true, 1);
            await Button.ClickButtonAsync(_commonXpath.HomeOwners_PolicyInput_ContinueToProInfo, ActionType.Click, true, 1);
            await Task.Delay(20000);
            //await _commonFunctions.ScrollUpAsync();
            //await _commonFunctions.UserWaitForPageToLoadCompletlyAsync();
            await Button.ClickButtonAsync(_commonXpath.HomeOwners_PolicyInput_RCEstTab, ActionType.Click, true, 1);
            await Button.ClickButtonAsync(_commonXpath.HomeOwners_PolicyInput_pdfdocdownload, ActionType.Click, true, 1);
            await Task.Delay(3000);
            await Button.ClickButtonAsync(_commonXpath.HomeOwners_PolicyInput_Edit_ReorderBtn, ActionType.Click, true, 1);
            await Task.Delay(15000);
            await DropDown.SelectDropDownAsync(_commonXpath.HomeOwners_PolicyInput_ConQuality, "Modest/Fair", true, 1);
            await Task.Delay(3000);
            await TextLink.ClickTextLinkAsync(_commonXpath.HomeOwners_PolicyInput_AddOtherArea, true, 1);
            await Task.Delay(8000);
            await DropDown.SelectDropDownAsync(_commonXpath.HomeOwners_PolicyInput_OA_AreaType, "Balcony", true, 1);
            await Task.Delay(15000);
            await InputField.SetTextAreaInputFieldAsync(_commonXpath.HomeOwners_PolicyInput_OA_SqFtA, "200", true, 1);
            await InputField.SetTextAreaInputFieldAsync(_commonXpath.HomeOwners_PolicyInput_OA_SqFtYear, "2024", true, 1);
            await Button.ClickButtonAsync(_commonXpath.HomeOwners_PolicyInput_OrderEstimate, ActionType.Click, true, 1);
            await Task.Delay(20000);
            //await _commonFunctions.UserWaitForPageToLoadCompletlyAsync();
            await Label.VerifyTextAsync(_commonXpath.HomeOwners_OA_VarifyText1, "balcony", true, 1);
            await Label.VerifyTextAsync(_commonXpath.HomeOwners_OA_VarifyText2, "2024", true, 1);
            await Label.VerifyTextAsync(_commonXpath.HomeOwners_OA_VarifyText3, "200", true, 1);
            await Button.ClickButtonAsync(_commonXpath.HomeOwners_OA_EditReorderEst, ActionType.Click, true, 1);
            await Task.Delay(18000);
            await DropDown.SelectDropDownAsync(_commonXpath.HomeOwners_OA_ConsQuality, "Average/Standard", true, 1);
            await Task.Delay(5000);
            await Button.ClickButtonAsync(_commonXpath.HomeOwners_DeleteOA, ActionType.Click, true, 3);
            await Task.Delay(5000);
            await Button.ClickButtonAsync(_commonXpath.HomeOwners_OrderEst, ActionType.Click, true, 1);
            await Task.Delay(5000);
        }
    }
}