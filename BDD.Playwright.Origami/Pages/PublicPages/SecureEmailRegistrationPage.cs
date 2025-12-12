using BDD.Playwright.Core.Interfaces;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using Microsoft.Playwright;
using Reqnroll;
namespace BDD.Playwright.Origami.Pages.CommonPage
{
    public class SecureEmailRegistrationPage : BasePage
    {
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;
        private readonly IFileReader _fileReader;
        //public BaseElement _baseElement;

        public SecureEmailRegistrationPage(ScenarioContext scenarioContext, IFileReader fileReader) : base(scenarioContext)
        {
            _fileReader = fileReader;
            // _baseElement = new BaseElement(scenarioContext);

        }
        #region Xpath
        public string Email_Inp => "//input[contains(@id,'username')]";
        public string FirstName_Inp => "//input[contains(@id,'fname')]";
        public string LastName_Inp => "//input[contains(@id,'lname')]";
        public string Password_Inp => "//input[contains(@id,'password')]";
        public string ConfirmPassword_Inp => "//input[contains(@id,'confirm')]";
        public string Continue_Btn => "//input[contains(@id,'continueButton')]";
        public string SuccessfulRegistration_Text => "//h1[contains(text(),'Activation Request Sent')]";
        #endregion

        public async Task RegistrationMethodAsync(string profileKey)
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter.");
            }

            try
            {
                logger.WriteLine($"Starting to fill RegistrationMethod information using profile: {profileKey}");

                var filePath = "SecureEmailRegistration\\SecureEmailRegistration.json";

                // Get values from JSON - Quote Details

                var email_Inp = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Email_Inp");
                var firstName_Inp = _fileReader.GetOptionalValue(filePath, $"{profileKey}.FirstName_Inp");
                var lastName_Inp = _fileReader.GetOptionalValue(filePath, $"{profileKey}.LastName_Inp");
                var password_Inp = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Password_Inp");
                var confirmPassword_Inp = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ConfirmPassword_Inp");

                /*Random a = new Random();
                int b = a.Next(1, 9999999);
                string UserName = b.ToString() + commonFunctions.SecureEmailRegistration_Email_LabelAndValue.Item2;*/
                await InputField.SetTextAreaInputFieldAsync(Email_Inp, email_Inp, true, 1);
                // Wait for dialog root
                await Button.ClickButtonAsync(Continue_Btn, ActionType.Click, true, 1);
                await InputField.SetTextAreaInputFieldAsync(FirstName_Inp, firstName_Inp, true, 1);
                await InputField.SetTextAreaInputFieldAsync(LastName_Inp, lastName_Inp, true, 1);
                await InputField.SetTextAreaInputFieldAsync(Password_Inp, password_Inp, true, 1);
                await InputField.SetTextAreaInputFieldAsync(ConfirmPassword_Inp, confirmPassword_Inp, true, 1);
                await Button.ClickButtonAsync(Continue_Btn, ActionType.Click, true, 1);
                await Label.VerifyTextAsync(SuccessfulRegistration_Text, "Activation Request Sent", true, 1);
               
                logger.WriteLine($"Retrieved Registration Method data for: {Email_Inp}{confirmPassword_Inp}");

                // Note: Form filling implementation would go here using the same pattern as BasicInformationPage
                // with the page elements (Button, InputField, DropDown, etc.) once they are properly resolved

                logger.WriteLine($"Successfully filled Registration Method information using profile: {profileKey}");
                logger.WriteLine("Registration Method Page Details Entered Successfully from JSON Data");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error filling Registration Method data: {ex.Message}");
                throw new Exception($"Failed to fill Registration Method data using profile '{profileKey}': {ex.Message}", ex);
            }
        }
    }
}
