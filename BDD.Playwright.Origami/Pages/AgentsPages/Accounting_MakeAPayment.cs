using BDD.Playwright.Core.Interfaces;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.GlobalPages;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using Microsoft.Playwright;
using OpenQA.Selenium.BiDi.BrowsingContext;
using Reqnroll;
using System;
using System.Threading.Tasks;

namespace BDD.Playwright.GBIZ.Pages.AgentPages
{
    public class Accounting_MakeAPayment : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public LoginPage _loginPage;
        private readonly IFileReader _fileReader;

        public Accounting_MakeAPayment(ScenarioContext scenarioContext, LoginPage loginPage, CommonXpath commonXpath, IFileReader fileReader)
            : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _loginPage = loginPage;
            _commonXpath = commonXpath;
            _fileReader = fileReader;
        }

        public string Accounting_MakeAPayment_Button => "//a[contains(text(),'Make a payment')]";
        public string PolicyNumber_Input => "//input[@id='pcyInput']";
        public string AmountCollected_Input => "//input[@id='amount']";
        public string AgencySweep_PaymentMethod_RadioButton => "//label[contains(text(),'Agency Sweep')]";
        public string CreditCard_PaymentMethod_RadioButton => "//label[contains(text(),'Credit Card (One Time)')]";
        public string EFT_PaymentMethod_RadioButton => "//label[contains(text(),'EFT One Time')]";
        public string PayPlan_Dropdown => "//select[contains(@formcontrolname,'changePlanCollected')]";
        public string AddNewPayment_Button => "//a[@class='mat-mdc-tooltip-trigger list-group-item payment-method-list__add-new btn btn-secondary mat-mdc-tooltip-disabled']";
        public string AccountNumber_Input => "//input[@id='accountNumber']";
        public string RepeatAccountNumber_Input => "//input[@id='repeatAccountNumber']";
        public string RoutingNumber_Input => "//input[@id='routingNumber']";
        public string Savings_Radiobutton => "//input[@value='Savings']";
        public string EFTSavings_Radiobutton => "//label[contains(text(),'Savings')]";
        public string Default_Checkbox => "//div[contains(@class,'payment-method-create')]//button//i[contains(@class,'payment-method')]";
        public string MakePaymentSubmit_Button => "//button[contains(text(),'Submit')]";
        public string MakePaymentReview_Button => "//button[contains(text(),'REVIEW')]";
        public string MakePaymentEFTReview_Button => "//div[@class='action-buttons__next-button ng-star-inserted']//button[contains(text(), 'Review')]";
        public string MakePayment_CreditCard_Review_Button => "//div//button[contains(text(),'Review')]";
        public string MakePayment_PaytenDollar => "//button[text()=' PAY $10.00 ']";
        public string Dollardue_MakePayment_Text => "//span[@class='totPrem']";
        public string CreditcardActive_Icon => "//div[contains(@class,'card-type-list')]//img[contains(@class,'active')]";
        public string PayButton => "//button[contains(text(), 'PAY $')]";
        public string GoBackButton => "(//button[contains(text(),'Go Back')])[1]";
        public string ExpirationDate_Input => "//input[@id='expirationDate']";
        public string CardNumber_Input => "//input[@id='cardNumber']";
        public string CVV_Input => "//oicc-number-input//input[@id='cvc']";
        public string Continue_AccountingMakeAPayment => "//button[@id='oneIncPayment']";
        public string AcknowledgeContinue_AccountingMakeAPayment => "//button[contains(text(),'CONTINUE')]";
        public string UseAnotherPaymentMethod => "//button[text()=' Use Another payment method ']";
        public string EmailAdress_Input => "//input[@placeholder='Enter Email']";
        public string EmailSend_Icon => "//span[@class='mat-mdc-button-touch-target']";
        public string DownloadReceipt_Button => "//button[contains(text(),'DOWNLOAD RECEIPT')]";
        public string Close_Button => "(//div[@class='portal-button']//button[contains(text(),'CLOSE')])[1]";
        public string Email_Close_Button => " (//div[contains(@class, 'inline-alert__buttons')]//button[contains(text(),' Close')])[4]";
        public string Accounting_ManageSweepPayments_Button => "//a[contains(text(),'Manage Sweep Payments')]";
        public string ManageSweepPayments_ManageButton => "//button[contains(text(),'Manage')]";
        public string ManageSweepPayments_GoBackButton => "//button[contains(text(),' GO BACK ')]";
        public string ManageSweepPayments_BankAccountButton => "//span[contains(text(),'Bank Account')]";
        public string ManageSweepPayments_RemoveButton => "//button[contains(@aria-label,'this is your current default payment option')]";
        public string ManageSweepPayments_ConfirmRemoveButton => "//button[contains(text(),'REMOVE')]";
        public string Verify_PaymentMethod_Removal => "//div[contains(text(),'0019')]";
        public string Verify_AccountNumber_exists => "//div[contains(text(),'Account Number')]";

        // Example method for entering policy data using JSON test data
        public async Task EnterPolicyDataAsync(string profileKey)
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter.");
            }

            var filePath = "Accounting_MakeAPaymentPage\\Accounting_MakeAPaymentPage.json";
            var policyNumber = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PolicyNumber");
            var amountCollected = _fileReader.GetOptionalValue(filePath, $"{profileKey}.AmountCollected");

            await InputField.SetTextAreaInputFieldAsync(PolicyNumber_Input, policyNumber, true, 1, "AccountNumber");
            await page.Locator(Dollardue_MakePayment_Text).WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 60000 });
            await InputField.SetTextAreaInputFieldAsync(AmountCollected_Input, amountCollected, true, 1, "Amount Collected");
            await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await Task.Delay(5000);
           // await InputField.SetTextAreaInputFieldAsync(AmountCollected_Input, amountCollected, true, 1, "Amount Collected");
           // await page.Keyboard.PressAsync("Tab");
            
            
       }

        public async Task EnterPolicyDataWithScenarioContextAsync()
        {
            var profileKey = "Agent_TC9";
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter.");
            }

            var filePath = "Accounting_MakeAPaymentPage\\Accounting_MakeAPaymentPage.json";

            var policyNumber = _scenarioContext["DFpolicyNumber"].ToString();
            var amountCollected = _fileReader.GetOptionalValue(filePath, $"{profileKey}.AmountCollected");
            await InputField.SetTextAreaInputFieldAsync(PolicyNumber_Input, policyNumber, true, 1, "AccountNumber");
            await page.Locator(Dollardue_MakePayment_Text).WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 60000 });
            await InputField.SetTextAreaInputFieldAsync(AmountCollected_Input, amountCollected, true, 1, "Amount Collected");
            await Task.Delay(2000);
        }

        public async Task EnterAccountDetailsAsync(string profileKey)
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter.");
            }

            var filePath = "Accounting_MakeAPaymentPage\\Accounting_MakeAPaymentPage.json";
            var accountNumber = _fileReader.GetOptionalValue(filePath, $"{profileKey}.AccountNumber");
            var repeatAccountNumber = _fileReader.GetOptionalValue(filePath, $"{profileKey}.RepeatAccountNumber");
            var routingNumber = _fileReader.GetOptionalValue(filePath, $"{profileKey}.RoutingNumber");

            await Task.Delay(5000);
            await InputField.SetTextAreaInputFieldAsync(AccountNumber_Input, accountNumber, true, 1, "Account Number");
            await Task.Delay(5000);
            await InputField.SetTextAreaInputFieldAsync(RepeatAccountNumber_Input, repeatAccountNumber, true, 1, "Repeat Account Number");
            await Task.Delay(5000);
            await InputField.SetTextAreaInputFieldAsync(RoutingNumber_Input, routingNumber, true, 1, "Routing Number");
            await page.Keyboard.PressAsync("Tab");
        }

        public async Task EnterPaymentDetailsAsync(string profileKey)
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter.");
            }

            var filePath = "Accounting_MakeAPaymentPage\\Accounting_MakeAPaymentPage.json";
            var accountNumber = _fileReader.GetOptionalValue(filePath, $"{profileKey}.AccountNumber");
            var repeatAccountNumber = _fileReader.GetOptionalValue(filePath, $"{profileKey}.RepeatAccountNumber");
            var routingNumber = _fileReader.GetOptionalValue(filePath, $"{profileKey}.RoutingNumber");

            ////await InputField.SetTextAreaInputFieldAsync(AccountNumber_Input, accountNumber, true, 2, "Account Number");
            //await InputField.SetTextAreaInputFieldAsync(RepeatAccountNumber_Input, repeatAccountNumber, true, 2, "Repeat Account Number");
            //await InputField.SetTextAreaInputFieldAsync(RoutingNumber_Input, routingNumber, true, 2, "Routing Number");
            //await page.Keyboard.PressAsync("Tab");
            var frame = page.FrameLocator("#PortalOneFrame");
            await frame.Locator(AccountNumber_Input).Nth(1).PressSequentiallyAsync(accountNumber);
            await frame.Locator(RepeatAccountNumber_Input).Nth(1).FillAsync(repeatAccountNumber);
            await frame.Locator(RoutingNumber_Input).Nth(1).FillAsync(routingNumber);
            
        }

        public async Task EnterCreditCardDetailsAsync(string profileKey)
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter.");
            }

            var filePath = "Accounting_MakeAPaymentPage\\Accounting_MakeAPaymentPage.json";
            var creditCardNumber = _fileReader.GetOptionalValue(filePath, $"{profileKey}.CreditCardNumber");
            var expirationDate = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ExpirationDate");
            var cvv = _fileReader.GetOptionalValue(filePath, $"{profileKey}.CVV");

            await Task.Delay(5000);
            await InputField.SetInputFieldAsync(CardNumber_Input, creditCardNumber, true, 1, "CreditCard Number");
            await Task.Delay(1000);
            await page.Locator(CreditcardActive_Icon).WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 60000 });
            await InputField.SetTextAreaInputFieldAsync(ExpirationDate_Input, expirationDate, true, 1, "Expirationdate");
            await Task.Delay(5000);
            await InputField.SetTextAreaInputFieldAsync(CVV_Input, cvv, true, 1, "CVV");
            await Task.Delay(5000);
            await page.Keyboard.PressAsync("Tab");
            await page.Keyboard.PressAsync("Tab");
            await Task.Delay(20000);
        }

        public async Task EnterEmailIdAndSendAsync(string profileKey)
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter.");
            }

            var filePath = "Accounting_MakeAPaymentPage\\Accounting_MakeAPaymentPage.json";
            var emailAddress = _fileReader.GetOptionalValue(filePath, $"{profileKey}.EmailID");
            //await InputField.SetInputFieldByJavaScriptAsync(EmailAdress_Input, emailAddress, true, 1);
            await Task.Delay(2000);
            var frame = page.FrameLocator("#PortalOneFrame");
            var emailInputLocator = frame.Locator(EmailAdress_Input).Nth(0);
            await emailInputLocator.ClickAsync();
            await emailInputLocator.PressAsync("Control+A"); // Select all text
            await emailInputLocator.PressAsync("Delete");    // Delete selected text
            await emailInputLocator.FillAsync(emailAddress);
            await Task.Delay(5000);
            await frame.Locator(EmailSend_Icon).Nth(1).ClickAsync();
            //await Button.ClickButtonAsync(EmailSend_Icon, PageElements.ActionType.Click, true, 2);
            await Task.Delay(5000);
            await frame.Locator(Email_Close_Button).ClickAsync();
            //await Button.ClickButtonAsync(Email_Close_Button, PageElements.ActionType.Click, true, 1);
        }
    }
}