using BDD.Playwright.Core.Interfaces;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.AgentPages;
using BDD.Playwright.GBIZ.Pages.AgentsPages;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using BDD.Playwright.GBIZ.Steps.AgentsStepDefinition;

namespace GoodVille.GBIZ.Reqnroll.Automation.Steps.AgentsStepDefinition
{
    [Binding]
    public class AgentTC21_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public JsonMyBusinessHomePage _jsonMyBusinessHomePage;
        public AgentTC13_StepDefinition _agentTC13_StepDefinition;
        public AgentTC17_StepDefinition _agentTC17_StepDefinition;
        public MyBusinessHomePage _myBusinessHomePage;
        public Accounting_MakeAPayment _accounting_MakeAPayment;
        private readonly IFileReader _fileReader;

        // Constructor
        public AgentTC21_StepDefinition(
            ScenarioContext scenarioContext,
            MyBusinessHomePage myBusinessHomePage,
            CommonXpath commonXpath,
            JsonMyBusinessHomePage jsonMyBusinessHomePage,
            AgentTC13_StepDefinition agentTC13_StepDefinition,
            Accounting_MakeAPayment accounting_MakeAPayment,
            AgentTC17_StepDefinition agentTC17_StepDefinition,
            IFileReader fileReader

        ) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _jsonMyBusinessHomePage = jsonMyBusinessHomePage;
            _myBusinessHomePage = myBusinessHomePage;
            _agentTC13_StepDefinition = agentTC13_StepDefinition;
            _agentTC17_StepDefinition = agentTC17_StepDefinition;
            _accounting_MakeAPayment = accounting_MakeAPayment;
            _commonXpath = commonXpath;
            _fileReader = fileReader;
        }

        [When("User enters mandatory fields for policy search in business page")]
        public async Task WhenUserEntersMandatoryFieldsForPolicySearchInBusinessPageAsync()
        {
            await _jsonMyBusinessHomePage.PolicySearchAsync("Agent_TC21");
        }

        [When("User verifies that each link in the Quick Links section navigates to its correct page")]
        public async Task WhenUserVerifiesThatEachLinkInTheQuickLinksSectionNavigatesToItsCorrectPageAsync()
        {
            await Button.ScrollIntoViewAsync(_myBusinessHomePage.MyBusiness_Text, true, 1);
            await _agentTC13_StepDefinition.SectionTitleVerifyMethodAsync(_myBusinessHomePage.ChangePassword_Link, _myBusinessHomePage.ChangePassword_Text, "Change Password", "Back");
            await _agentTC13_StepDefinition.SectionTitleVerifyMethodAsync(_myBusinessHomePage.ManageStaff_Link, _myBusinessHomePage.ManageStaff_Text, "Manage Staff", "Back");
            await _agentTC13_StepDefinition.SectionTitleVerifyMethodAsync(_myBusinessHomePage.OrderSupplies_Link, _myBusinessHomePage.OrderSupplies_Text, "Agency Supply Order Form", "Back");
            await _agentTC13_StepDefinition.SectionTitleVerifyMethodAsync(_myBusinessHomePage.FAQAndHelp_Link, _myBusinessHomePage.FAQAndHelp_Text, "Questions Frequently Asked by Agents", "Back");
            await _agentTC13_StepDefinition.SectionTitleVerifyMethodAsync(_myBusinessHomePage.MailingPreferences_Link, _myBusinessHomePage.MailingPreferences_Text, "Mailing Preferences", "Back");
            await _agentTC13_StepDefinition.SectionTitleVerifyMethodAsync(_myBusinessHomePage.DailyTransactions_Link, _myBusinessHomePage.DailyTransactions_Text, "Daily Transactions", "Back");
            await _agentTC13_StepDefinition.SectionTitleVerifyMethodAsync(_myBusinessHomePage.ContactUs_Link, _myBusinessHomePage.ContactUs_Text, "Contact Us", "Back");
            await _agentTC13_StepDefinition.SectionTitleVerifyMethodAsync(_myBusinessHomePage.HolidaySchedule_Link, _myBusinessHomePage.HolidaySchedule_Text, "Holiday Schedule", "Back");
            await _agentTC13_StepDefinition.SectionTitleVerifyMethodAsync(_myBusinessHomePage.ViewActiveCreditReports_Link, _myBusinessHomePage.ViewActiveCreditReports_Text, "Credit Search", "Back");
            await _agentTC13_StepDefinition.SectionTitleVerifyMethodAsync(_myBusinessHomePage.RiskAddressGrouping_Link, _myBusinessHomePage.RiskAddressGrouping_Text, "Risk Address Grouping", "Back");
            await _agentTC13_StepDefinition.SectionTitleVerifyMethodAsync(_myBusinessHomePage.JoinSession_Link, _myBusinessHomePage.JoinSession_Text, "Join a Session", "Back");
        }

        [When("User verifies that each link in the whats new section navigates to its correct page")]
        public async Task WhenUserVerifiesThatEachLinkInTheWhatsNewSectionNavigatesToItsCorrectPageAsync()
        {
            await Button.ScrollIntoViewAsync(_myBusinessHomePage.MyBusiness_Text, true, 1);
            await TextLink.ClickTextLinkAsync(_myBusinessHomePage.TestQAUpdate_Link, true, 1);
            await TextLink.ClickTextLinkAsync(_myBusinessHomePage.Update_Link, true, 1);
        }

        [When("User Select the Delaware state and Business Cover LOB from dropdowns under Document Downloads section")]
        public async Task WhenUserSelectTheDelawareStateAndBusinessCoverLOBFromDropdownsUnderDocumentDownloadsSectionAsync()
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter.");
            }

            var profileKey = "Agent_TC21";
            var filePath = "MyBusinessHomePage\\MyBusinessHomePage.json";

            // Read state and LOB from JSON data
            var state = _fileReader.GetOptionalValue(filePath, $"{profileKey}.State");
            var lineOfBusiness = _fileReader.GetOptionalValue(filePath, $"{profileKey}.LineofBusiness");

            await DropDown.SelectDropDownAsync(_myBusinessHomePage.SelectState_Dropdown, state, true, 1);
            await DropDown.SelectDropDownAsync(_myBusinessHomePage.SelectLineOfBusiness_Dropdown, lineOfBusiness, true, 1);
        }

        /* [When("User click on Search Button")]
        public async Task WhenUserClickOnSearchButtonAsync()
        {
            await Button.ClickButtonAsync(_page, _myBusinessHomePage.QuickSearch_Button, ActionType.Click, true, 2);
        }*/

        [When("User click on Search Button and Verify the Delaware Document Downloads page opens or not")]
        public async Task WhenUserClickOnSearchButtonAndVerifyTheDelawareDocumentDownloadsPageOpensOrNotAsync()
        {
            await _agentTC13_StepDefinition.SectionTitleVerifyMethodAsync(_myBusinessHomePage.SearchButton, _myBusinessHomePage.DelawareDocumentDownloadsText, "Delaware Document Downloads", "Back");
        }

        [When("User Verify the Goodville Contacts table is displayed or not.")]
        public async Task WhenUserVerifyTheGoodvilleContactsTableIsDisplayedOrNot_Async()
        {
           /* if (await Label.VerifyTextCssAsync(_myBusinessHomePage.ShadowHost_GoodvilleContacts, _myBusinessHomePage.ShadowElement_GoodvilleContacts, "Goodville Contacts"))
            {
                Console.WriteLine("Goodville Contacts has been Displayed");
            }*/
        }
    }
}