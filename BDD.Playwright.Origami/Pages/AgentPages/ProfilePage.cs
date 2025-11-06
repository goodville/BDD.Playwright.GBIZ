using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using Microsoft.Playwright;
using Reqnroll;

namespace BDD.Playwright.Origami.Pages.AgentPages
{
    public class ProfilePage : BasePage
    {
        public ProfilePage(ScenarioContext scenarioContext) : base(scenarioContext) { }

        #region Xpath
        public string ShadowHostSlidePanelShadow { get; set; } = ".gg-leftnav.hydrated";
        public string ShadowHostTopPanelShadow { get; set; } = ".gg-header.hydrated";
        public string ProfileUserName_Link { get; set; } = "div.sublinks.blue[part='gg-topbar-item'] a[href*='/agents/profile/']";
        public string GeneralInformationSlidePanelShadow { get; set; } = "div.gg-leftnavlinkgrid > a[href*='/agents/profile/']";
        public string ChangePasswordSlidePanelShadow { get; set; } = "div.gg-leftnavlinkgrid > a[href*='/agents/profile/index.cfm?f=changepassword']";
        public string ChangeEmailAddressSlidePanelShadow { get; set; } = "div.gg-leftnavlinkgrid > a[href*='/agents/profile/index.cfm?f=changeemail']";
        public string PersonalProfileSlidePanelShadow { get; set; } = "div.gg-leftnavlinkgrid > a[href*='/agents/profile/index.cfm?f=updateprofile']";
        public string FirstName_Inp { get; set; } = "//input[@name='FirstName']";
        public string LastName_Inp { get; set; } = "//input[@name='LastName']";
        public string MiddleInitial_Inp { get; set; } = "//input[@name='MiddleInitial']";
        public string UserName_Inp { get; set; } = "//input[@name='UserName']";
        public string CompanyName_Inp { get; set; } = "//input[@name='CompanyName']";
        public string Update_Btn { get; set; } = "//input[@value='Update']";
        public string CurrentPassword_Inp { get; set; } = "//input[@id='currentpassword']";
        public string NewPassword_Inp { get; set; } = "//input[@id='password']";
        public string ReEnterPassword_Inp { get; set; } = "//input[@id='passwordconfirm']";
        public string RenterEmailAddress_Inp { get; set; } = "//input[@id='emailconfirm']";
        public string WhydoneedEmailAddress_Inp { get; set; } = "//a[contains(text(),'Why do you need my email address?')]";
        public string WhydoneedEmailAddressorPassword_Close_Btn { get; set; } = "//button[./span[contains(text(),'Close')]]";
        public string ClickHeretoaddEmailAddress_Inp { get; set; } = "//a[contains(text(),'Click Here')]";
        public string NewEmail_Inp { get; set; } = "//input[@id='email']";
        public string NewAlternateEmail_Inp { get; set; } = "//input[@name='altemail']";
        public string WhydoneedPassword_Inp { get; set; } = "//a[contains(text(),'Why do you need my password?')]";
        public string UpdatedSuccessMessage_Text { get; set; } = "//div[contains(text(),'Your request has been processed.')]";
        public string ChnageEmailAddress_Text { get; set; } = "//div[contains(text(),'Change Email Address')]";
        public string DefaultBook_Inp { get; set; } = "//input[@name= 'DefaultBook']";
        public string DefaultOffice_Drp { get; set; } = "//Select[@name= 'DefaultOffice']";
        public string DefaultState_Drp { get; set; } = "//Select[@name= 'DefaultState']";
        public string PersonalAutoDataPrefill_Radio { get; set; } = "//input[@name= 'AutoPrefill' and @value='{0}']";
        public string DOB_Inp { get; set; } = "//input[@name= 'dob']";
        public string Extension_Inp { get; set; } = "//input[@name= 'Extension']";
        public string Fax_Inp { get; set; } = "//input[@name= 'Fax']";
        public string Initials_Inp { get; set; } = "//input[@name= 'Initials']";
        public string Phone_Inp { get; set; } = "//input[@name= 'Phone']";
        public string Title_Inp { get; set; } = "//input[@name= 'Title']";
        public string DocumentAgree_CheckBox { get; set; } = "//input[@name='documents_agree' and @type='checkbox']";
        public string DocumentBooks_checkbox { get; set; } = "//input[@name='documents_books' and @value='{0}']";
        #endregion

        public async Task GeneralInformationUpdateAsync()
        {
            await Button.ClickButtonAsync(GeneralInformationSlidePanelShadow, ActionType.Click, true, 1);
            await page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
            await InputField.SetTextAreaInputFieldAsync(FirstName_Inp, "Test_qa", true, 1);
            await InputField.SetTextAreaInputFieldAsync(MiddleInitial_Inp, "Q", true, 1);
            await InputField.SetTextAreaInputFieldAsync(LastName_Inp, "Agent2", true, 1);
            await InputField.SetTextAreaInputFieldAsync(UserName_Inp, "yutest2", true, 1);
            await InputField.SetTextAreaInputFieldAsync(CompanyName_Inp, "Development Agency", true, 1);
            await Button.ClickButtonAsync(Update_Btn, ActionType.Click, true, 1);
            await page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
            await Task.Delay(2000);
            await Label.VerifyTextAsync(UpdatedSuccessMessage_Text, "Your request has been processed.", true, 1);
        }

        public async Task ChangePasswordAsync()
        {
            await page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
            await Button.ClickButtonAsync(ChangePasswordSlidePanelShadow, ActionType.Click, true, 1);
            await page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
            await TextLink.ClickTextLinkAsync(ClickHeretoaddEmailAddress_Inp, true, 1);
            await Label.VerifyTextAsync(ChnageEmailAddress_Text, "Change Email Address", true, 1);
            // Simulate browser back navigation
            await page.GoBackAsync();
            await InputField.SetTextAreaInputFieldAsync(CurrentPassword_Inp, "4Quality$", true, 1);
            await InputField.SetTextAreaInputFieldAsync(NewPassword_Inp, "3Rohith$", true, 1);
            await InputField.SetTextAreaInputFieldAsync(ReEnterPassword_Inp, "3Rohith$", true, 1);
            await InputField.SetTextAreaInputFieldAsync(NewEmail_Inp, "Test_qa2@goodville.com", true, 1);
            await InputField.SetTextAreaInputFieldAsync(RenterEmailAddress_Inp, "Test_qa2@goodville.com", true, 1);
            await TextLink.ClickTextLinkAsync(WhydoneedEmailAddress_Inp, true, 1);
            await Button.ClickButtonAsync(WhydoneedEmailAddressorPassword_Close_Btn, ActionType.Click, true, 1);
            await Label.VerifyTextAsync(WhydoneedEmailAddress_Inp, "Why do you need my email address?", true, 1);
            await Button.ClickButtonAsync(Update_Btn, ActionType.Click, true, 1);
            await page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
            await Task.Delay(2000);
            await Label.VerifyTextAsync(UpdatedSuccessMessage_Text, "Your request has been processed.", true, 1);
        }

        public async Task ChangeEmailAddressAsync()
        {
            await page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
            await Button.ClickButtonAsync(ChangeEmailAddressSlidePanelShadow, ActionType.Click, true, 1);
            await page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
            var b = new Random().Next(1, 9999999);
            var email = $"{b}rohith.kayala@goodville.com";
            await InputField.SetTextAreaInputFieldAsync(NewEmail_Inp, email, true, 1);
            await InputField.SetTextAreaInputFieldAsync(RenterEmailAddress_Inp, email, true, 1);
            await InputField.SetTextAreaInputFieldAsync(NewAlternateEmail_Inp, email, true, 1);
            await InputField.SetTextAreaInputFieldAsync(NewPassword_Inp, "4Quality&", true, 1);
            await TextLink.ClickTextLinkAsync(WhydoneedPassword_Inp, true, 1);
            await Button.ClickButtonAsync(WhydoneedEmailAddressorPassword_Close_Btn, ActionType.Click, true, 1);
            await Label.VerifyTextAsync(WhydoneedPassword_Inp, "Why do you need my password?", true, 1);
            await Button.ClickButtonAsync(Update_Btn, ActionType.Click, true, 1);
            await page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
            await Task.Delay(2000);
            await Label.VerifyTextAsync(UpdatedSuccessMessage_Text, "Your request has been processed.", true, 1);
        }

        public async Task PersonalProfileAsync(string personalAutoPrefill_YorN, string noOfBooksToSelect, string bookCodes)
        {
            await page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
            await Button.ClickButtonAsync(PersonalProfileSlidePanelShadow, ActionType.Click, true, 1);
            await page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
            await InputField.SetTextAreaInputFieldAsync(DefaultBook_Inp, "3700", true, 1);
            await DropDown.SelectDropDownAsync(DefaultOffice_Drp, "#1", true, 1);
            await DropDown.SelectDropDownAsync(DefaultState_Drp, "Pennsylvania", true, 1);
            var personalAutoPrefillRadio = string.Format(PersonalAutoDataPrefill_Radio, personalAutoPrefill_YorN);
            await RadioButton.SelectRadioButtonAsync(personalAutoPrefillRadio, personalAutoPrefill_YorN, true, 1);
            await InputField.SetTextAreaInputFieldAsync(Phone_Inp, "(717) 555-1111", true, 1);
            await Checkbox.SelectCheckboxAsync(DocumentAgree_CheckBox, true, true, 1);
            var options = bookCodes.Split().ToList();
            for (var i = 0; i < int.Parse(noOfBooksToSelect); i++)
            {
                var bookCodeToSelect = string.Format(DocumentBooks_checkbox, options[i]);
                await Checkbox.SelectCheckboxAsync(bookCodeToSelect, true, true, 1);
            }

            await Button.ClickButtonAsync(Update_Btn, ActionType.Click, true, 3);
            await page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
            await Task.Delay(2000);
            await Label.VerifyTextAsync(UpdatedSuccessMessage_Text, "Your request has been processed.", true, 1);
        }
    }
}
