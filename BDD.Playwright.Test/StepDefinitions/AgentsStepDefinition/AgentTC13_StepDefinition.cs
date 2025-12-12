using BDD.Playwright.Core.Loggers;
using BDD.Playwright.GBIZ.Pages.AgentPages;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.GlobalPages;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using BDD.Playwright.Test.StepDefinitions.Public_StepDefinition;
using Microsoft.Playwright;
using Reqnroll;
using System;
using System.Threading.Tasks;

namespace BDD.Playwright.GBIZ.Steps.AgentsStepDefinition
{
    [Binding]
    public class AgentTC13_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly string _scenarioTitle;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public LoginPage _loginPage;
        private readonly TC9_StepDefinition _tC9StepDefinition;
        private readonly PolicyDetails_RecurringEFTPage _policyDetailsRecurringEFTPage;
        public Accounting_MakeAPayment _accounting_MakeAPayment;
        // Xpaths
        public string PoliciesRequiringPayment_Text => "//span[contains(text(),'Policies Requiring Payment')]";
        public string PendingAgencySweepPayments_Text => "//span[contains(text(),'Pending Agency Sweep Payments')]";
        public string AgencySweepTransactionHistory_Text => "//span[contains(text(),'Agency Sweep Transaction History')]";
        public string PolicyNumber_Link => "//a[contains(text(),'{0}')]";
        public string AccountingHome_Text => "//div[contains(text(),'Accounting')]";
        public string AccountingMakeAPayment_Text => "//div[contains(text(),'Make A Payment')]";
        public string AccountingFAQ_Link => "//a[normalize-space()='FAQ']";
        public string AccountingFAQ_Text => "//div[contains(text(),'Accounting Frequently Asked Questions (FAQ)')]";
        public string AccountingGuidelines_Link => "//a[normalize-space()='Accounting Guidelines']";
        public string AccountingGuidelines_Text => "//div[contains(text(),'Accounting Guidelines')]";
        public string AccountingPaymentOptions_Link => "//a[normalize-space()='Payment Options']";
        public string AccountingPaymentOptions_Text => "//div[contains(text(),'Payment Options')]";
        public string AccountingManageSweepPayments_Link => "//a[normalize-space()='Manage Sweep Payments']";
        public string AccountingManageSweepPayments_Text => "//div[contains(text(),'Manage Sweep Payments')]";
        public string AccountingAgencySweepTransactionHistoryDetail_Text => "//div[contains(text(),'Agency Sweep Transaction History Detail')]";
        public string AccountingManageSweepPayments_StartDate_Input => "//input[@name='startdate']";
        public string AccountingManageSweepPayments_EndDate_Input => "//input[@name='enddate']";
        public string AccountingSweepTransaction_AccountNumber_Link => "//a[contains(text(),'German General Account')]";
        public string AccountingAdminSearchBox_Input => "//input[@id='adminSearchctrl']";

        public AgentTC13_StepDefinition(
            ScenarioContext scenarioContext,
            LoginPage loginPage,
            CommonXpath commonXpath,
            PolicyDetails_RecurringEFTPage policyDetailsRecurringEFTPage,
            TC9_StepDefinition tC9StepDefinition,
            Accounting_MakeAPayment accounting_MakeAPayment) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _scenarioTitle = scenarioContext.ScenarioInfo.Title;
            _loginPage = loginPage;
            _commonXpath = commonXpath;
            _tC9StepDefinition = tC9StepDefinition;
            _policyDetailsRecurringEFTPage = policyDetailsRecurringEFTPage;
            _accounting_MakeAPayment = accounting_MakeAPayment;
        }

        public async Task SectionTitleVerifyMethodAsync(string RequiredXpath, string SectionTitleXpath, string ExpectedSectionTitle, string ReturnToPage)
        {
            await TextLink.ClickTextLinkAsync(RequiredXpath, true, 1);
            var ActualSectionTitle = await Label.GetTextAsync(SectionTitleXpath, true, 1);
            if (ActualSectionTitle == ExpectedSectionTitle)
            {
                logger.WriteLine(ExpectedSectionTitle);
            }
            else
            {
                throw new Exception("About Us page Title is not Matching it is displaying " + ActualSectionTitle);
            }

            if (ReturnToPage == "Back")
            {
                await page.GoBackAsync();
                logger.WriteLine("Back clicked");
            }
            else
            {
                await TextLink.ClickTextLinkAsync(ReturnToPage, true, 1);
            }
        }

        [When("User verifies Policies Requiring Payment, Pending Agency Sweep Payments and Transaction History sections are displayed")]
        public async Task WhenUserVerifiesPoliciesRequiringPaymentPendingAgencySweepPaymentsAndTransactionHistorySectionsAreDisplayedAsync()
        {
            await page.Locator(PoliciesRequiringPayment_Text).WaitForAsync(new() { State = WaitForSelectorState.Visible });
            await Label.VerifyTextAsync(PoliciesRequiringPayment_Text, "POLICIES REQUIRING PAYMENT", true, 1);
            await Label.VerifyTextAsync(PendingAgencySweepPayments_Text, "PENDING AGENCY SWEEP PAYMENTS", true, 1);
            await Label.VerifyTextAsync(AgencySweepTransactionHistory_Text, "AGENCY SWEEP TRANSACTION HISTORY", true, 1);
        }

        [When("the user clicks on policy number under the Policies Requiring Payment table")]
        public async Task WhenTheUserClicksOnPolicyNumberUnderThePoliciesRequiringPaymentTableAsync()
        {
            var policyNumber = string.Format(PolicyNumber_Link, "PA230011 Clymire Remhars");
            await TextLink.ClickTextLinkAsync(policyNumber, true, 1);
            logger.WriteLine("User clicked on the policy number under Policies Requiring Payment table.");
        }

        [When("the Make a Payment page is displayed")]
        public async Task WhenTheMakeAPaymentPageIsDisplayedAsync()
        {
            await Label.VerifyTextAsync(AccountingMakeAPayment_Text, "Make A Payment", true, 1);
        }

        [When("the user searches Agency Sweep Transaction History by entering SweepStartDate and SweepEndDate, and clicks the Search button")]
        public async Task WhenTheUserSearchesAgencySweepTransactionHistoryByEnteringSweepStartDateAndSweepEndDateAndClicksTheSearchButtonAsync()
        {
            await InputField.SetTextAreaInputFieldAsync(AccountingManageSweepPayments_StartDate_Input, "01/01/2016", true, 1);
            await InputField.SetTextAreaInputFieldAsync(AccountingManageSweepPayments_EndDate_Input, DateTime.Now.ToString("MM/dd/yyyy"), true, 1);
            await Button.ClickButtonAsync(_commonXpath.Policynumbersearch, PageElements.ActionType.Click, true, 2);
        }

        [When("clicks on the first sweep history result")]
        public async Task WhenClicksOnTheFirstSweepHistoryResultAsync()
        {
            await page.Locator(AccountingSweepTransaction_AccountNumber_Link).Nth(1).WaitForAsync(new() { State = WaitForSelectorState.Visible });
            await page.Locator(AccountingSweepTransaction_AccountNumber_Link).Nth(1).ClickAsync();
            //await TextLink.ClickTextLinkAsync(AccountingSweepTransaction_AccountNumber_Link, true, 1);
        }

        [Then("the Agency Sweep Transaction History Detail page is displayed")]
        public async Task ThenTheAgencySweepTransactionHistoryDetailPageIsDisplayedAsync()
        {
            await page.Locator(AccountingAgencySweepTransactionHistoryDetail_Text).WaitForAsync(new() { State = WaitForSelectorState.Visible });
            logger.WriteLine("Agency Sweep Transaction History Detail page is displayed.");
        }

        [Then("the user verifies the menu links on the left part of the Accounting page are working")]
        public async Task ThenTheUserVerifiesTheMenuLinksOnTheLeftPartOfTheAccountingPageAreWorkingAsync()
        {
            await Button.ScrollIntoViewAsync(_accounting_MakeAPayment.Accounting_MakeAPayment_Button, true, 1);
            await SectionTitleVerifyMethodAsync(_accounting_MakeAPayment.Accounting_MakeAPayment_Button, AccountingMakeAPayment_Text, "Make A Payment", "Back");
            await SectionTitleVerifyMethodAsync(AccountingFAQ_Link, AccountingFAQ_Text, "Accounting Frequently Asked Questions (FAQ)", "Back");
            await SectionTitleVerifyMethodAsync(AccountingGuidelines_Link, AccountingGuidelines_Text, "Accounting Guidelines", "Back");
            await SectionTitleVerifyMethodAsync(AccountingPaymentOptions_Link, AccountingPaymentOptions_Text, "Payment Options", "Back");
            await SectionTitleVerifyMethodAsync(AccountingManageSweepPayments_Link, AccountingManageSweepPayments_Text, "Manage Sweep Payments", "Back");
        }

        [When("the user enters {string} in the Admin Search box and clicks the Search button")]
        public async Task WhenTheUserEntersInTheAdminSearchBoxAndClicksTheSearchButtonAsync(string test)
        {
            await InputField.SetTextAreaInputFieldAsync(AccountingAdminSearchBox_Input, test, true, 1);
            await Button.ClickButtonAsync(_commonXpath.Policynumbersearch, PageElements.ActionType.Click, true, 1);
        }

        [Then("the Home page is displayed")]
        public async Task ThenTheHomePageIsDisplayedAsync()
        {
            await page.Locator(AccountingHome_Text).WaitForAsync(new() { State = WaitForSelectorState.Visible });
            await Label.VerifyTextAsync(AccountingHome_Text, "Accounting", true, 1);
            logger.WriteLine("Accounting Home page is displayed.");
        }
    }
}