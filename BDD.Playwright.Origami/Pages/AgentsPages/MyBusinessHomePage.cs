using BDD.Playwright.Core.Interfaces;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.GlobalPages;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using Microsoft.Playwright;
using Reqnroll;
using System;
using System.Threading.Tasks;

namespace BDD.Playwright.GBIZ.Pages.AgentsPages
{
    public class MyBusinessHomePage : BasePage
    {
        private readonly IReqnrollOutputHelper _ReqnrollLogger;
        private readonly ScenarioContext _scenarioContext;
        private readonly IFileReader _fileReader;
        private readonly CommonXpath _commonXpath;
        private readonly LoginPage _loginPage;

        public MyBusinessHomePage(ScenarioContext scenarioContext, IFileReader fileReader, IReqnrollOutputHelper reqnrollLogger, LoginPage loginPage, CommonXpath commonXpath) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _fileReader = fileReader;
            _ReqnrollLogger = reqnrollLogger;
            _loginPage = loginPage;
            _commonXpath = commonXpath;
        }

        #region Xpath Properties
        public string MyBusiness_Text => "//div[contains(text(),'My Business')]";
        public string LastName_Input => "//input[@name='LastName']";
        public string Name_Input => "//input[@name='Name']";
        public string QuickSearchNumber_Input => "//input[@id='qs_number']";
        public string QuickSearchType_Dropdown => "//select[@id='quicksearchtype']";
        public string QuickSearch_Button => "//label[@class='label']//input[@value='Search']";
        //What's New Links:
        public string WhatsNew_UpdateImage_Link => "//a[@href='/agents/pdf/index.cfm?dir=updates%5C&filename=il570xN.5229837286gupl.png']";
        public string WhatsNew_NewsletterJuly2022_Link => "//a[@href='https://myemail.constantcontact.com/Goodville-Mutual-s-Update-Newsletter-No-6-July-2022.html?soid=1137932736453&aid=O7d-vO7HTgE ']";
        public string WhatsNew_NewEmployeesOctober2018_Link => "//a[@href='/agents/pdf/index.cfm?dir=updates%5C&filename=Update 14 2018 New Employees October Top Ten.pdf']";
        //Quick Links:
        public string ChangePassword_Link => "//span[normalize-space()='Change Password']";
        public string ManageStaff_Link => "//span[normalize-space()='Manage Staff']";
        public string OrderSupplies_Link => "//span[normalize-space()='Order Supplies']";
        public string FAQAndHelp_Link => "//span[normalize-space()='FAQ and Help']";
        public string MailingPreferences_Link => "//span[normalize-space()='Mailing Preferences']";
        public string DailyTransactions_Link => "//span[normalize-space()='Daily Transactions']";
        public string ContactUs_Link => "//span[normalize-space()='Contact Us']";
        public string HolidaySchedule_Link => "//span[normalize-space()='Holiday Schedule']";
        public string RiskAddressGrouping_Link => "//span[normalize-space()='Risk Address Grouping']";
        public string JoinSession_Link => "//span[normalize-space()='Join a Session']";
        public string ViewActiveCreditReports_Link => " //span[normalize-space()='View Active Credit Reports']";
        public string TestQAUpdate_Link => "//b[contains(text(),'Test QA update')]";
        public string Update_Link => " //b[contains(text(),'Update #14, November 2018')]";

        public string ChangePassword_Text => "//div[contains(text(),'Change Password')]";
        public string ManageStaff_Text => "//div[contains(text(),'Manage Staff')]";
        public string OrderSupplies_Text => "//h1[contains(text(),'Agency Supply Order Form')]";
        public string FAQAndHelp_Text => "//h1[contains(text(),'Questions Frequently Asked by Agents')]";
        public string MailingPreferences_Text => "//div[contains(text(),'Mailing Preferences')]";
        public string DailyTransactions_Text => "//div[contains(text(),'Daily Transactions')]";
        public string ContactUs_Text => "//span[normalize-space()='Contact Us']";
        public string HolidaySchedule_Text => "//h1[contains(text(),'Holiday Schedule')]";
        public string RiskAddressGrouping_Text => "//div[contains(text(),'Risk Address Grouping')]";
        public string JoinSession_Text => "//h2[contains(text(),'Join a Session')]";
        public string ViewActiveCreditReports_Text => "//div[contains(text(),'Credit Search')]";
        public string SelectState_Dropdown => "//select[@name='state']";
        public string SelectLineOfBusiness_Dropdown => "//select[@name='manualcode']";
        public string SearchButton => "//select[@name='manualcode']//following::input[@value='Search']";
        public string DelawareDocumentDownloadsText => "//div[contains(text(),'Delaware Document Downloads')]";
        public string ShadowElement_GoodvilleContacts => "div.title";
        public string ShadowHost_GoodvilleContacts => ".modacross.modcolumned.hydrated";
        public string PolicyNumber_Link => "//td[contains(text(),'450012')]";
        #endregion

        public async Task PolicySearchAsync(string profileKey)
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter.");
            }

            var filePath = "MyBusinessHomePage\\MyBusinessHomePage.json";
            try
            {
                _ReqnrollLogger.WriteLine($"Starting Policy Search with profile: {profileKey}");

                var lastName = _fileReader.GetOptionalValue(filePath, $"{profileKey}.LastName");
                var name = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Name");
                var quickSearchNumber = _fileReader.GetOptionalValue(filePath, $"{profileKey}.QuickSearchNumber");
                var quickSearchType = _fileReader.GetOptionalValue(filePath, $"{profileKey}.QuickSearchType");

                await InputField.SetTextAreaInputFieldAsync(LastName_Input, lastName, true, 1);
                await InputField.SetTextAreaInputFieldAsync(Name_Input, name, true, 1);
                await InputField.SetTextAreaInputFieldAsync(QuickSearchNumber_Input, quickSearchNumber, true, 1);
                await DropDown.SelectDropDownAsync(QuickSearchType_Dropdown, quickSearchType, true, 1);
                await Button.ClickButtonAsync(QuickSearch_Button, ActionType.Click, true, 1);

                _ReqnrollLogger.WriteLine("Policy Search details entered successfully from JSON Data.");
            }
            catch (Exception ex)
            {
                _ReqnrollLogger.WriteLine($"Error in PolicySearchAsync: {ex.Message}");
                throw;
            }
        }

        public async Task PolicySearchWithHardcodedDataAsync()
        {
            var lastName = "Smith";
            var name = "John";
            var quickSearchNumber = "123456";
            var quickSearchType = "Policy";

            await InputField.SetTextAreaInputFieldAsync(LastName_Input, lastName, true, 1);
            await InputField.SetTextAreaInputFieldAsync(Name_Input, name, true, 1);
            await InputField.SetTextAreaInputFieldAsync(QuickSearchNumber_Input, quickSearchNumber, true, 1);
            await DropDown.SelectDropDownAsync(QuickSearchType_Dropdown, quickSearchType, true, 1);
            await Button.ClickButtonAsync(QuickSearch_Button, ActionType.Click, true, 1);
        }

        public async Task ClickAllLinksAsync()
        {
            await TextLink.ClickTextLinkAsync(WhatsNew_UpdateImage_Link, true, 1);
            await TextLink.ClickTextLinkAsync(WhatsNew_NewsletterJuly2022_Link, true, 1);
            await TextLink.ClickTextLinkAsync(WhatsNew_NewEmployeesOctober2018_Link, true, 1);
            await TextLink.ClickTextLinkAsync(ChangePassword_Link, true, 1);
            await TextLink.ClickTextLinkAsync(ManageStaff_Link, true, 1);
            await TextLink.ClickTextLinkAsync(OrderSupplies_Link, true, 1);
            await TextLink.ClickTextLinkAsync(FAQAndHelp_Link, true, 1);
            await TextLink.ClickTextLinkAsync(MailingPreferences_Link, true, 1);
            await TextLink.ClickTextLinkAsync(DailyTransactions_Link, true, 1);
            await TextLink.ClickTextLinkAsync(ContactUs_Link, true, 1);
            await TextLink.ClickTextLinkAsync(HolidaySchedule_Link, true, 1);
            await TextLink.ClickTextLinkAsync(RiskAddressGrouping_Link, true, 1);
            await TextLink.ClickTextLinkAsync(JoinSession_Link, true, 1);
        }
    }
}