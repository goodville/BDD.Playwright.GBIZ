using AventStack.ExtentReports.Gherkin.Model;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using BDD.Playwright.Origami.Pages.AgentPages;
using GoodVille.GBIZ.Reqnroll.Automation.Pages.GlobalPages;

namespace GoodVille.GBIZ.Specflow.Automation.Steps.AgentsStepDefinition
{
    [Binding]
    public class AgentTC48_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public LoginPage _loginPage;
        public ProfilePage _profilePage;
        // Constructor
        public AgentTC48_StepDefinition(ScenarioContext scenarioContext, LoginPage loginPage, CommonXpath commonXpath, ProfilePage profilePage) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _loginPage = loginPage;
            _commonXpath = commonXpath;
            _profilePage = profilePage;
        }
        [When(@"User Click on the Quotinglink")]
        public async Task UserClickontheQuotinglinkandverifyOnlineQuotingtextisdisplayedAsync()
        {
            //commonFunctions.UserWaitForPageToLoadCompletly();
            await Button.ClickButtonCssAsync(_commonXpath.ShadowHost, _commonXpath.QuotingSidePanelShadow);
            await Task.Delay(2000);
            await Label.VerifyTextAsync(_commonXpath.OnlineQuoting_Text, "Online Quoting", true, 1);
        }

        [When(@"User Selects and verify the header is Business Cover")]
        public async Task UserSelectsAndVerifyTheHeaderIsBusinessCoverAsync()
        {
            await Label.VerifyTextAsync(_commonXpath.OnlineQuoting_Text, "Online Quoting", true, 1);
            await Button.ClickButtonAsync(_commonXpath.NewQuoteLink, ActionType.Click, true, 1);
            await Task.Delay(2000);
            await Button.ClickButtonAsync(_commonXpath.BusinessCoverQuote, ActionType.Click, true, 1);
            await Task.Delay(2000);
        }

        [When(@"User select the Business Cover Option")]
        public async Task UserSelectBusinessCoverOptionAsync()
        {
           // waits.WaitUntilElementVisible(By.XPath(_commonXpath.FarmownersButton), 20);
            //Thread.Sleep(2000);
            await Button.ClickButtonAsync(_commonXpath.BusinessCoverQuote, ActionType.Click, true, 1);
            await Task.Delay(2000);
        }
        [Then(@"verify the 'I have informed the insured' checkbox is present")]
        public async Task VerifyCheckboxIsPresentAsync()
        {
            var isCheckboxPresent = await Checkbox.VerifyCheckboxExistAsync(_commonXpath.InfoLMICnsuredCheckbox, true, 1, "I have informed the insured");
            // Assert.IsTrue(isCheckboxPresent, "'I have informed the insured' checkbox is not present.");
            await Label.VerifyTextAsync(_commonXpath.InfoLMICnsuredCheckbox, "I have informed the insured", true, 1);
        }

        [Then(@"verify the 'continue' button is present")]
        public async Task VerifyContinueButtonIsPresentAsync()
        {
            var isButtonPresent = await Button.VerifyButtonExistAsync(_commonXpath.Quote_Continue_Btn, true, 1, "Continues");
            await Label.VerifyTextAsync(_commonXpath.Quote_Continue_Btn, "Continue", true, 1);
            //Assert.IsTrue(isButtonPresent, "'Continue' button is not present.");
        }

        [When(@"User select the 'I have informed the insured' checkbox and click continue button")]
        public async Task UserSelecttheIhaveinformedtheinsuredCheckboxandClickContinueAsync()
        {
            await Button.ClickButtonAsync(_commonXpath.InfoLMICnsuredCheckbox, ActionType.Click, true, 1);
            await Button.ClickButtonAsync(_commonXpath.Quote_Continue_Btn, ActionType.Click, true, 1);
        }

        [Then(@"verify the Farmowners text is present")]
        public async Task VerifyFarmownersTextIsPresentAsync()
        {
            await Label.VerifyTextAsync(_commonXpath.PersonalAuto_FullText, "Farmowners", true, 1);
            await Label.GetTextAsync(_commonXpath.PersonalAuto_FullText, true, 1);
            // Regex pattern: Farmowners - followed by digits
            var pattern = @"^Farmowners - \d+$";
            await Label.VerifyTextFormatAsync("//div[@id='formHeaderLeft']", pattern, true, 1, "Policy Header");
            // Assert.IsTrue(isVerified, "Policy header format does not match expected.");
        }

        [When(@"User Clicks on the Logout Button")]
        public async Task UserClickontheLogoutButtonAsync()
        {
            //await Button.ClickButtonAsyncCss(_commonXpath.ShadowHost_Logout, _commonXpath.SignOutShadow1);
            await Button.ClickButtonCssAsync("gg-navigation", "a[href*='logout']");
            Console.WriteLine("Agent Logout Successfully.");
        }
    }
}
