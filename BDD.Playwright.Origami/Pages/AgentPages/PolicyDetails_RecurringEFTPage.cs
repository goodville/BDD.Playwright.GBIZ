using BDD.Playwright.Core.Interfaces;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.GlobalPages;
using BDD.Playwright.GBIZ.Pages.PublicPages;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using Microsoft.Playwright;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BDD.Playwright.GBIZ.Pages.AgentPages
{
    public class PolicyDetails_RecurringEFTPage : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly string _scenarioTitle;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public MakeAPaymentPage _makeAPaymentPage;
        private readonly IFileReader _fileReader;

        public PolicyDetails_RecurringEFTPage(
            ScenarioContext scenarioContext,
            CommonXpath commonXpath,
            MakeAPaymentPage makeAPaymentPage,
            IFileReader fileReader
        ) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _scenarioTitle = scenarioContext.ScenarioInfo.Title;
            _makeAPaymentPage = makeAPaymentPage;
            _commonXpath = commonXpath;
            _fileReader = fileReader;
        }

        public string ReccuringEFT_button => "//button[normalize-space()='Recurring EFT']";
        public string PolicyWallet_Link => "//div[contains(text(),'Policy Wallet')]";
        public string AddNewPayment_Button => "//span[normalize-space()='Add new payment method']";

        public async Task AddPaymentForRecurringEFTAsync()
        {
            await Button.ClickButtonAsync(ReccuringEFT_button, PageElements.ActionType.Click, true, 1);
            await page.Locator(PolicyWallet_Link).WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 60000 });
            await page.Locator(PolicyWallet_Link).WaitForAsync(new() { State = WaitForSelectorState.Attached, Timeout = 60000 });
            await TextLink.ClickTextLinkAsync(PolicyWallet_Link, true, 1);
            await Button.ClickButtonAsync(_commonXpath.Create_Button, PageElements.ActionType.Click, true, 1);

            // Wait for iframe to appear and switch context
            await page.Locator("//iframe[@aria-label='Payment method']").WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 60000 });
            await IFrame.SwitchToIframeByXpathAsync("//iframe[@aria-label='Payment method']");
            await Button.ClickButtonAsync(AddNewPayment_Button, PageElements.ActionType.Click, true, 1);
            var filePath = "ReccuringPaymentEFTPage.json";
            var profileKey = "Agent_TC11";

            var accountNumber = _fileReader.GetOptionalValue(filePath, $"{profileKey}.AccountNumber");
            var repeatAccountNumber = _fileReader.GetOptionalValue(filePath, $"{profileKey}.RepeatAccountNumber");
            var routingNumber = _fileReader.GetOptionalValue(filePath, $"{profileKey}.RoutingNumber");
            var nameOnAccount = _fileReader.GetOptionalValue(filePath, $"{profileKey}.NameOnAccount");
            var checking = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Checking");
            var savings = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Savings");

            await page.Locator(_makeAPaymentPage.AccountNumber_Input).WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 60000 });
            await InputField.SetTextAreaInputFieldAsync(_makeAPaymentPage.AccountNumber_Input, accountNumber, true, 1);

            await page.Locator(_makeAPaymentPage.RepeatAccountNumber_Input).WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 60000 });
            await InputField.SetTextAreaInputFieldAsync(_makeAPaymentPage.RepeatAccountNumber_Input, repeatAccountNumber, true, 1);

            await page.Locator(_makeAPaymentPage.RoutingNumber_Input).WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 60000 });
            await InputField.SetTextAreaInputFieldAsync(_makeAPaymentPage.RoutingNumber_Input, routingNumber, true, 1);

            await page.Locator(_makeAPaymentPage.NameOnAccount_Input).WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 60000 });
            await InputField.SetTextAreaInputFieldAsync(_makeAPaymentPage.NameOnAccount_Input, nameOnAccount, true, 1);

            if (checking == "Yes")
            {
                await Checkbox.SelectCheckboxAsync(_makeAPaymentPage.Checking_RadioButton, true, true, 1);
            }

            if (savings == "Yes")
            {
                await Checkbox.SelectCheckboxAsync(_makeAPaymentPage.Savings_RadioButton, true, true, 1);
            }

        await Task.Delay(5000); 
        }

        public async Task RemovePolicyWalletPaymentMethodAsync()
        {
            await Button.ClickButtonAsync(_commonXpath.Open_Button, PageElements.ActionType.Click, true, 1);
            await page.Locator("//iframe[@aria-label='Payment method']").WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 60000 });
            await IFrame.SwitchToIframeByXpathAsync("//iframe[@aria-label='Payment method']");
            await Button.ClickButtonAsync(_commonXpath.Remove_Button, PageElements.ActionType.Click, true, 1);
            await Button.ClickButtonAsync(_commonXpath.RemovePaymentMethod_Remove_Button, PageElements.ActionType.Click, true, 1);
            await Button.ClickButtonAsync(_commonXpath.Close_Button, PageElements.ActionType.Click, true, 2);
            await IFrame.CloseAsync();
            await page.Locator(_commonXpath.Create_Button).WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 60000 });
            var createBtn = page.Locator(_commonXpath.Create_Button);
            await createBtn.WaitForAsync(new() { State = WaitForSelectorState.Attached, Timeout = 60000 });
            // Optionally check for enabled if you have a helper
        }
    }
}