using BDD.Playwright.Core.Interfaces;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using Microsoft.Playwright;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD.Playwright.GBIZ.Pages.PublicPages
{
    public class MakeAPaymentPage : BasePage
    {
        private readonly IFileReader _fileReader;
        private readonly ScenarioContext _scenarioContext;
        public MakeAPaymentPage(ScenarioContext scenarioContext, IFileReader fileReader) : base(scenarioContext)
        {
            _fileReader = fileReader;

            _scenarioContext = scenarioContext;
        }

        public string EFTOneTime_Radiobutton { get; set; } = "//label[contains(text(),'EFT One Time')]";
        public string ValidationTooltip_Icon { get; set; } = "//img[@class='mat-mdc-tooltip-trigger dp-icon type-determined active']";
        public string CreditCardOneTime_Radiobutton { get; set; } = "//label[contains(text(),'Credit Card (One Time)')]";
        public string PayPlan_Dropdown { get; set; } = "//select[@class='form-control multipart-content-selection']";
        public string PayInstallment_Radiobutton { get; set; } = "//label[contains(text(),'Pay installment')]";
        public string PayInFull_Radiobutton { get; set; } = "//label[contains(text(),'Pay in full')]";
        public string OneIncPaymentContinue_Button { get; set; } = "//div[@class='ng-scope']//button[@id='oneIncPayment']";
        public string NoticeContinue_Button { get; set; } = "//button[contains(text(),'CONTINUE')]";
        public string Notice_Text { get; set; } = "//h1[contains(text(),'NOTICE')]";
        public string OneIncCancel_Button { get; set; } = "//div[@class='ng-scope']//button[@class='oneIncPaymentButton'][normalize-space()='CANCEL']";

        public string PayPal_Button { get; set; } = "//div[@class='paypal-button-label-container']";
        public string GooglePay_Button { get; set; } = "//button[@class='btn-wide portal-button__button btn black en gpay-button pay']";
        public string UseAnotherPaymentMethod_Button { get; set; } = "//button[normalize-space()='Use Another payment method']";
        public string PaymentSwitch_Radiobutton { get; set; } = "//div[@class='mdc-switch__shadow']";
        public string MakeAPaymentReview_Button { get; set; } = "//*[@id=\"cdk-step-content-0-0\"]/div/p1c-generic-wizard-step-widget/div/div/div/div/portal-button-widget[4]/portal-button-control/div/div/button";
        public string MakeAPaymentCancel_Button { get; set; } = "//button[contains(text(),'CANCEL')]";
        public string AccountNumber_Input { get; set; } = "//input[@id='accountNumber']";
        public string RepeatAccountNumber_Input { get; set; } = "//input[@id='repeatAccountNumber']";
        public string RoutingNumber_Input { get; set; } = "//input[@id='routingNumber']";
        public string CardNumber_Input { get; set; } = "//input[@id='cardNumber']";
        public string ExpirationDate_Input { get; set; } = "//input[@id='expirationDate']";
        public string CVC_Input { get; set; } = "//input[@id='cvc']";
        public string NameOnAccount_Input { get; set; } = "//input[@id='nameOnAccount']";
        public string NameOnCard_Input { get; set; } = "//input[@id='nameOnCard']";
        public string BillingAddress_Input { get; set; } = "//input[@id='billingAddress']";
        public string BillingZip_Input { get; set; } = "//input[@id='billingZip']";
        public string Checking_RadioButton { get; set; } = "//input[@value='Checking'][@type='radio']";
        public string Savings_RadioButton { get; set; } = "//input[@value='Savings'][@type='radio']";
        public string ReviewPayment_Button { get; set; } = "//button[contains(text(),'Review')]";

        public string Review_Button { get; set; } = "//button[contains(text(),' REVIEW ')]";
        public string GoBack_Button { get; set; } = "//button[contains(text(),'Go Back')]";
        public string Pay_Button { get; set; } = "//button[contains(text(),'PAY')]";
        public string PaymentConfirmation_Text { get; set; } = "//div[contains(text(),\"You're all set!\")]";
        public string Email_Address { get; set; } = "//*[@id='emailAddress']";
        public string Send_Email { get; set; } = "#cdk-step-content-0-4 > div > p1c-generic-wizard-step-widget > div > div > div > div > gm2-send-email-widget > gm2-send-email-control > div > div > div > div > oicc-text-input > mat-form-field > div.mat-mdc-text-field-wrapper.mdc-text-field.ng-tns-c3736059725-6.mdc-text-field--outlined > div > div.mat-mdc-form-field-icon-suffix.ng-tns-c3736059725-6.ng-star-inserted > button.send-receipt__button.send-receipt__icon-button.mdc-icon-button.mat-mdc-icon-button.mat-unthemed.mat-mdc-button-base.ng-tns-c3736059725-6.ng-star-inserted > span.mat-mdc-button-touch-target";
        public string NoBalanceDue_Text { get; set; } = "//span[contains(text(),'No balance due.')]";
        public string Click_Close { get; set; } = "//*[@id=\"cdk-step-content-0-4\"]/div/p1c-generic-wizard-step-widget/div/div/div/div/dce-partial-screen-flow-brifge-widget/gm2-inline-alert-widget/div/gm2-inline-alert-control/div/div/div/div[2]/button";
        public string Click_PrintBtn { get; set; } = "//button[contains(text(),'PRINT RECEIPT')]";
        public async Task MakeAPaymentAsync(string profileKey)
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter.");
            }

            try
            {
                logger.WriteLine($"Starting MakeAPayment process using profile: {profileKey}");
                var filePath = "MakeAPayment\\MakeAPaymentData.json";

                // Read values from JSON
                var eftOneTime = _fileReader.GetOptionalValue(filePath, $"{profileKey}.EFTOneTime");
                var creditCardOneTime = _fileReader.GetOptionalValue(filePath, $"{profileKey}.CreditCardOneTime");
                var payPlan = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PayPlan");
                var accountNumber = _fileReader.GetOptionalValue(filePath, $"{profileKey}.AccountNumber");
                var repeatAccountNumber = _fileReader.GetOptionalValue(filePath, $"{profileKey}.RepeatAccountNumber");
                var routingNumber = _fileReader.GetOptionalValue(filePath, $"{profileKey}.RoutingNumber");
                var nameOnAccount = _fileReader.GetOptionalValue(filePath, $"{profileKey}.NameOnAccount");
                var checking = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Checking");
                var savings = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Savings");
                var cardNumber = _fileReader.GetOptionalValue(filePath, $"{profileKey}.CardNumber");
                var expirationDate = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ExpirationDate");
                var cvc = _fileReader.GetOptionalValue(filePath, $"{profileKey}.CVV");
                var billingAddress = _fileReader.GetOptionalValue(filePath, $"{profileKey}.BillingAddress");
                var billingZip = _fileReader.GetOptionalValue(filePath, $"{profileKey}.BillingZip");

                await page.WaitForLoadStateAsync(LoadState.NetworkIdle);

               
                if (eftOneTime == "Yes")
                {
                    await Checkbox.SelectCheckboxAsync(EFTOneTime_Radiobutton, true, true, 2);
                }

                if (creditCardOneTime == "Yes")
                {
                    await Checkbox.SelectCheckboxAsync(CreditCardOneTime_Radiobutton, true, true, 2);
                }

                if (payPlan == "Installment")
                {
                    await Checkbox.SelectCheckboxAsync(PayInstallment_Radiobutton, true, true, 2);
                }
                else if (payPlan == "Full")
                {
                    await Checkbox.SelectCheckboxAsync(PayInFull_Radiobutton, true, true, 2);
                }

                await Button.ClickButtonAsync(OneIncPaymentContinue_Button, ActionType.Click, true, 1);

                // Handle EFT details in iframe
                if (eftOneTime == "Yes")
                {
                    var frame = page.FrameLocator("#PortalOneFrame");
                    
                    await frame.Locator(Review_Button).ClickAsync();
                    await frame.Locator(AccountNumber_Input).FillAsync(accountNumber);
                   
                    await frame.Locator(RepeatAccountNumber_Input).FillAsync(repeatAccountNumber);
                    await frame.Locator(RoutingNumber_Input).FillAsync(routingNumber);
                    await frame.Locator(NameOnAccount_Input).FillAsync(nameOnAccount);

                    if (checking == "Yes")
                    {
                        await frame.Locator(Checking_RadioButton).ClickAsync();
                        //await Checkbox.SelectCheckboxAsync(Checking_RadioButton, true, true, 1);
                    }

                    if (savings == "Yes")
                    {
                        await frame.Locator(Savings_RadioButton).ClickAsync();
                       
                        //await Checkbox.SelectCheckboxAsync(Savings_RadioButton, true, true, 1);
                    }

                    await frame.Locator(ReviewPayment_Button).ClickAsync();
                    await frame.Locator(Pay_Button).ClickAsync();
                    var confirmationText = frame.Locator(PaymentConfirmation_Text);
                    await confirmationText.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
                    var actualText = await confirmationText.InnerTextAsync();
                    if (actualText.Contains("You're all set!"))
                    {
                        Console.WriteLine("Payment confirmation text verified successfully.");
                    }
                    else
                    {
                        throw new Exception($"Expected text not found. Actual text: {actualText}");
                    }

                    await frame.Locator(Send_Email).ClickAsync();
                    await frame.Locator(Click_Close).ClickAsync();
                    //await frame.Locator(Click_Close).ClickAsync();
                    await frame.Locator(Click_PrintBtn).ClickAsync();
                    
                }

                
                if (creditCardOneTime == "Yes")
                {
                    var frame = page.FrameLocator("#PortalOneFrame");
                 
                    await frame.Locator(NoticeContinue_Button).ClickAsync();
                    await frame.Locator(UseAnotherPaymentMethod_Button).ClickAsync();
                    await Task.Delay(3000);
                    // Replace this line:
                    // await frame.Locator(CardNumber_Input).Nth(1).TypeAsync(cardNumber);

                    // With this line:
                    //await frame.Locator(CardNumber_Input).Nth(1).FillAsync(cardNumber);

                    await frame.Locator(CardNumber_Input).PressSequentiallyAsync(cardNumber);
                    await page.Keyboard.PressAsync("Tab");
                    await frame.Locator(ExpirationDate_Input).FillAsync(expirationDate);
                    await frame.Locator(CVC_Input).FillAsync(cvc);
                    var locator3 = frame.Locator(NameOnCard_Input);
                    await locator3.ClickAsync();
                    await locator3.PressAsync("Control+A"); // Select all text
                    await locator3.PressAsync("Delete");    // Delete selected text
                    await locator3.FillAsync(nameOnAccount);
                    var locator1 = frame.Locator(BillingAddress_Input);
                    await locator1.ClickAsync();
                    await locator1.PressAsync("Control+A"); // Select all text
                    await locator1.PressAsync("Delete");    // Delete selected text
                    await locator1.FillAsync(billingAddress);

                    var locator2 = frame.Locator(BillingZip_Input);
                    await locator2.ClickAsync();
                    await locator2.PressAsync("Control+A"); // Select all text
                    await locator2.PressAsync("Delete");    // Delete selected text
                    await locator2.FillAsync(billingZip);
                    await frame.Locator(CardNumber_Input).PressSequentiallyAsync(cardNumber);
                    await page.Keyboard.PressAsync("Tab");

                    await frame.Locator(ReviewPayment_Button).ClickAsync();
                    await frame.Locator(Pay_Button).ClickAsync();
                    var confirmationText = frame.Locator(PaymentConfirmation_Text);
                    await confirmationText.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
                    var actualText = await confirmationText.InnerTextAsync();
                    if (actualText.Contains("You're all set!"))
                    {
                        Console.WriteLine("Payment confirmation text verified successfully.");
                    }
                    else
                    {
                        throw new Exception($"Expected text not found. Actual text: {actualText}");
                    }

                    await frame.Locator(Send_Email).ClickAsync();
                    await frame.Locator(Click_Close).ClickAsync();
                    //await frame.Locator(Click_Close).ClickAsync();
                    await frame.Locator(Click_PrintBtn).ClickAsync();

                    //await page.Locator(ValidationTooltip_Icon).WaitForAsync();
                }

                await Button.ClickButtonAsync(ReviewPayment_Button, ActionType.Click, true, 1);

            }
            catch (Exception ex)
            {
                throw new Exception($"Error while executing MakeAPayment for profile {profileKey}: {ex.Message}", ex);
            }
        }

        public async Task MakeAccountPaymentDetailsAsync(string profileKey)
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter.");
            }

            var filePath = "MakeAPayment\\MakeAPaymentData.json";
            var creditCardOneTime = _fileReader.GetOptionalValue(filePath, $"{profileKey}.CreditCardOneTime");

            if (creditCardOneTime == "Yes")
            {
                var frame = page.FrameLocator("#PortalOneFrame");
                var cardNumber = _fileReader.GetOptionalValue(filePath, $"{profileKey}.CardNumber");
                var expirationDate = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ExpirationDate");
                var cvc = _fileReader.GetOptionalValue(filePath, $"{profileKey}.CVV");
                var accountNumber = _fileReader.GetOptionalValue(filePath, $"{profileKey}.NameOnAccount");
                var billingAddress = _fileReader.GetOptionalValue(filePath, $"{profileKey}.BillingAddress");
                var billingZip = _fileReader.GetOptionalValue(filePath, $"{profileKey}.BillingZip");
                await Task.Delay(2000);
                var frame1 = page.FrameLocator("#PortalOneFrame");
                await frame1.Locator(CardNumber_Input).PressSequentiallyAsync(cardNumber);
                await page.Keyboard.PressAsync("Tab");
                await frame1.Locator(ExpirationDate_Input).FillAsync(expirationDate);
                await frame1.Locator(CVC_Input).FillAsync(cvc);
                var locator3 = frame.Locator(NameOnCard_Input);
                await locator3.ClickAsync();
                await locator3.PressAsync("Control+A"); // Select all text
                await locator3.PressAsync("Delete");    // Delete selected text
                await locator3.FillAsync(accountNumber);
                var locator1 = frame.Locator(BillingAddress_Input);
                await locator1.ClickAsync();
                await locator1.PressAsync("Control+A"); // Select all text
                await locator1.PressAsync("Delete");    // Delete selected text
                await locator1.FillAsync(billingAddress);

                var locator2 = frame.Locator(BillingZip_Input);
                await locator2.ClickAsync();
                await locator2.PressAsync("Control+A"); // Select all text
                await locator2.PressAsync("Delete");    // Delete selected text
                await locator2.FillAsync(billingZip);
                await frame.Locator(CardNumber_Input).PressSequentiallyAsync(cardNumber);
                await page.Keyboard.PressAsync("Tab");
                await frame.Locator(ReviewPayment_Button).ClickAsync();
                await frame.Locator(Pay_Button).ClickAsync();
            }
            else
            {
                var accountNumber = _fileReader.GetOptionalValue(filePath, $"{profileKey}.AccountNumber");
                var repeatAccountNumber = _fileReader.GetOptionalValue(filePath, $"{profileKey}.RepeatAccountNumber");
                var routingNumber = _fileReader.GetOptionalValue(filePath, $"{profileKey}.RoutingNumber");
                var nameOnAccount = _fileReader.GetOptionalValue(filePath, $"{profileKey}.NameOnAccount");
                // await InputField.SetInputFieldByJavaScriptAsync(CardNumber_Input, cardNumber, true, 1);
                await Task.Delay(2000);
                var frame = page.FrameLocator("#PortalOneFrame");
                await frame.Locator(AccountNumber_Input).PressSequentiallyAsync(accountNumber);
                await page.Keyboard.PressAsync("Tab");
                await frame.Locator(RepeatAccountNumber_Input).PressSequentiallyAsync(repeatAccountNumber);
                await page.Keyboard.PressAsync("Tab");
                await frame.Locator(RoutingNumber_Input).FillAsync(routingNumber);
                var locator3 = frame.Locator(NameOnAccount_Input);
                await locator3.ClickAsync();
                await locator3.PressAsync("Control+A"); // Select all text
                await locator3.PressAsync("Delete");    // Delete selected text
                await locator3.FillAsync(nameOnAccount);

                //await InputField.SetTextAreaInputFieldAsync(CardNumber_Input, cardNumber, true, 1);
                // await InputField.SetTextAreaInputFieldAsync(ExpirationDate_Input, expirationDate, true, 1);
                // await InputField.SetTextAreaInputFieldAsync(CVC_Input, cvc, true, 1);
                // await InputField.SetTextAreaInputFieldAsync(NameOnCard_Input, nameOnAccount, true, 1);
                // await InputField.SetTextAreaInputFieldAsync(BillingAddress_Input, billingAddress, true, 1);
                //  await InputField.SetTextAreaInputFieldAsync(BillingZip_Input, billingZip, true, 1);

                // Wait for validation tooltip
                /* await page.Locator(ValidationTooltip_Icon).WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 60000 });
                 logger.WriteLine("Validation tooltip icon found - form is ready!");
                 await Task.Delay(2000);
                 await InputField.SetTextAreaInputFieldAsync(NameOnCard_Input, nameOnAccount, true, 1);*/
            }
        }
    }
}

