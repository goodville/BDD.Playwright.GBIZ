using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using Microsoft.Playwright;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD.Playwright.Test.StepDefinitions.Public_StepDefinition
{
    [Binding]
    public class TC6_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public CommonXpath _commonXpath;
        public TC6_StepDefinition(ScenarioContext scenarioContext, CommonXpath commonXpath) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _commonXpath = commonXpath;
        }

        /* [When(@"User Click on the Contact Us and Click on the Secure Mail and Verify the Title and sends an email to company for policy issue")]
         public async Task WhenUserClickOnTheContactUsandClickOnTheSecureMailandVerifyTheTitleAsync()
         {
             await await TextLink.ClickTextLinkAsyncAsync(_commonXpath.ContactUs_Link, true, 1);
             var contactUsPageTitle = await page.TitleAsync();
             if (contactUsPageTitle == "Goodville Mutual Casualty Company - Contact Us")
             {
                 Console.WriteLine("Contact Us Page Title is Goodville Mutual Casualty Company - Contact Us");
             }
             else
             {
                 throw new Exception($"Contact Us page Title is not Matching, it is displaying {contactUsPageTitle}");
             }

             var popup = await page.RunAndWaitForPopupAsync(async () =>
             {
                 await await TextLink.ClickTextLinkAsyncAsync(_commonXpath.SecureEmail_Link, true, 1);
             });

             var secureEmailPageTitle = await popup.TitleAsync();
             if (secureEmailPageTitle == "Encrypted Email Login")
             {
                 Console.WriteLine("Secure Email Page Title is Encrypted Email Login");
             }
             else
             {
                 throw new Exception($"Secure Email page Title is not Matching, it is displaying {secureEmailPageTitle}");
             }

             await popup.CloseAsync();
             await Task.Delay(1000);
             await await DropDown.SelectDropDowAsyncAsync(_commonXpath.SelectaTopic_Drp, "General", true, 1);
             await await InputField.SetTextAreaInputFieldAsyncAsync(_commonXpath.Name_Inp, "Public Tc6", true, 1);
             await await InputField.SetTextAreaInputFieldAsyncAsync(_commonXpath.EmailAddress_Inp, "rohith.kayala@goodville.com", true, 1);
             await await InputField.SetTextAreaInputFieldAsyncAsync(_commonXpath.PhoneNumber_Inp, "(302) 422-9010", true, 1);
             await await InputField.SetTextAreaInputFieldAsyncAsync(_commonXpath.PolicyNumber_Inp, "MP0109", true, 1);
             await TextArea.SetTextAreaFieldAsync(_commonXpath.Message_Inp, "Testing", true, 1);

             await Task.Delay(1000);
             await IFrame.SwitchToIframeAsync();
             await page.EvaluateAsync(@"() => {
     document.getElementById('g-recaptcha-response').value = 'test-token';
 }");
             await Task.Delay(3000);
             await IFrame.CloseAsync();
             await Button.ClickButtonAsync(_commonXpath.Submit_Btn, ActionType.Click, true, 1);
             await await Label.VerifyTextAsyncAsync(_commonXpath.EmailSentSuccessfulMessage_Validation, "Your message has been sent. You will receive a response to your inquiry as soon as possible.", true, 1);
         }*/

        [When(@"User Click on the Contact Us and Click on the Secure Mail and Verify the Title and sends an email to company for policy issue")]
        public async Task WhenUserClickOnTheContactUsAndClickOnTheSecureMailAndVerifyTheTitleAsync()
        {
            await TextLink.ClickTextLinkAsync(_commonXpath.ContactUs_Link, true, 1);
            await page.WaitForLoadStateAsync(LoadState.NetworkIdle);

            // Verify Contact Us page title
            var contactUsPageTitle = await page.TitleAsync();
            if (contactUsPageTitle == "Goodville Mutual Casualty Company - Contact Us")
            {
               logger.WriteLine("Contact Us Page Title is Goodville Mutual Casualty Company - Contact Us");
            }
            else
            {
                throw new Exception("Contact Us page Title is not Matching it is displaying " + contactUsPageTitle);
            }

            var popup = await page.RunAndWaitForPopupAsync(async () =>
            {
               await TextLink.ClickTextLinkAsync(_commonXpath.SecureEmail_Link, true, 1);
            });

            await TextLink.ClickTextLinkAsync(_commonXpath.SecureEmail_Link, true, 1);
            await page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
            var secureEmailPageTitle = await popup.TitleAsync();
            if (secureEmailPageTitle == "Encrypted Email Login")
            {
                logger.WriteLine("Secure Email Page Title is Encrypted Email Login");
            }
            else
            {
                throw new Exception("Secure Email page Title is not Matching it is displaying " + secureEmailPageTitle);
            }

            await popup.CloseAsync();
            await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await page.WaitForTimeoutAsync(2000);
            await DropDown.SelectDropDownAsync(_commonXpath.SelectaTopic_Drp, "General", true, 1);
            await InputField.SetTextAreaInputFieldAsync(_commonXpath.Name_Inp, "Public Tc6", true, 1);
            await InputField.SetTextAreaInputFieldAsync(_commonXpath.EmailAddress_Inp, "rohith.kayala@goodville.com", true, 1);
            await InputField.SetTextAreaInputFieldAsync(_commonXpath.PhoneNumber_Inp, "(302) 422-9010", true, 1);
            await InputField.SetTextAreaInputFieldAsync(_commonXpath.PolicyNumber_Inp, "MP0109", true, 1);
            await TextArea.SetTextAreaFieldAsync(_commonXpath.Message_Inp, "Testing", true, 1);

            await page.WaitForTimeoutAsync(1000);
            await IFrame.SwitchToIframeAsync();
            //var frame = page.FrameLocator("iframe");
            await page.EvaluateAsync(@"() => {
    document.getElementById('g-recaptcha-response').value = 'test-token';
}");
            //await page.ClickAsync("button[type='submit']");
            //await Checkbox.SelectCheckboxAsync(_commonXpath.ReCaptcha_CheckBox, true, true, 1);
            await IFrame.CloseAsync();
            await Button.ClickButtonAsync(_commonXpath.Submit_Btn, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(3000);
            await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await Label.VerifyTextAsync(_commonXpath.EmailSentSuccessfulMessage_Validation, "Your message has been sent. You will receive a response to your inquiry as soon as possible.", true, 1);
        }
    }
}
