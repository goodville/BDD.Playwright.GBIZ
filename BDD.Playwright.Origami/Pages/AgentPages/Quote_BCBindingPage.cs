using BDD.Playwright.Core.Interfaces;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.GlobalPages;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using Reqnroll;

namespace bdd.playwright.gbiz.pages.agentpages
{
    public class Quote_BCBindingPage : BasePage
    {
        private readonly ScenarioContext _ScenarioContext;
        public FeatureContext _FeatureContext;
        public CommonXpath _CommonXpath;
        private readonly IFileReader _FileReader;
        public LoginPage _LoginPage;
        public CommonPage _commonPage;

        public Quote_BCBindingPage(
            ScenarioContext scenarioContext,
            LoginPage loginPage,
            CommonXpath commonXpath,
            CommonPage commonPage,
            IFileReader fileReader)
            : base(scenarioContext)
        {
            _ScenarioContext = scenarioContext;
            _LoginPage = loginPage;
            _CommonXpath = commonXpath;
            _FileReader = fileReader;
            _commonPage = commonPage;
        }

        #region Xpath
        public string Office_Drp { get; set; } = "//select[@name='binding_office']";
        public string Producer_Drp { get; set; } = "//select[@name='binding_producer']";
        public string AgentEmail { get; set; } = "//input[@name='agentEmail']";
        public string InsuranceTransferredAgency { get; set; } = "//input[@name='insuranceTransferred' and @value='{0}']";
        public string CoverageDeclined { get; set; } = "//input[@name='coverageDeclined' and @value='{0}']";
        public string ApplicantConvictedArson { get; set; } = "//input[@name='applicantConvictedArson' and @value='{0}']";
        public string BindingDestinationEmail { get; set; } = "//input[@name='binding_destinationemail' and @value='{0}']";
        public string Remarks { get; set; } = "//textarea[@name='binding_remarks']";
        public string CoverageBound { get; set; } = "//input[@name='binding_iscoveragebound' and @value='{0}']";
        public string AgreeTerms { get; set; } = "//input[@name='binding_agreetoterms']";
        public string TenantDogs { get; set; } = "//input[@id='fld_no_tenantDogs' and @value='{0}']";
        public string DroneUse { get; set; } = "//input[@id='fld_no_droneUse' and @value='{0}']";
        public string BUSSINESS_COVER { get; set; } = "//input[@name='business_cover' and @value='{0}']";
        public string NumberOfYearsExperience { get; set; } = "//input[@name='numberOfYearsExperience']";
        public string Subcontractwork { get; set; } = "//input[@name='subcontractwork' and @value='{0}']";
        public string Demolition { get; set; } = "//input[@name='demolition' and @value='{0}']";
        public string RoofOnly { get; set; } = "//input[@name='roofOnly' and @value='{0}']";
        public string AsbestosWork { get; set; } = "//input[@name='asbestosWork' and @value='{0}']";
        public string EIFS { get; set; } = "//input[@name='EIFS' and @value='{0}']";
        public string Message_btn { get; set; } = "//div[normalize-space()='Message Overrides']";
        public string Apply_Override_btn { get; set; } = "//span[contains(text(),'Apply Override')]";

        #endregion

        public async Task BindingDataFillAsync(string profileKey)
        {
            if (_FileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available.");
            }

            var filePath = "QuoteBindingPage\\QuoteBindingPage.json";

            // Office
            var agencyOffice = _FileReader.GetOptionalValue(filePath, $"{profileKey}.AgencyOffice");
            if (!string.IsNullOrEmpty(agencyOffice))
            {
                await DropDown.SelectDropDownAsync(Office_Drp, agencyOffice, true, 1);
            }

            // Producer
            var agencyProducer = _FileReader.GetOptionalValue(filePath, $"{profileKey}.AgencyProducer");
            if (!string.IsNullOrEmpty(agencyProducer))
            {
                //await page.Locator("//select[@name='binding_producer']").FillAsync(agencyProducer);
                await DropDown.SelectDropDownAsync(Producer_Drp, agencyProducer, true, 1);
                await Task.Delay(2000);
            }
            // AgentEmail
            var agentEmail = _FileReader.GetOptionalValue(filePath, $"{profileKey}.AgentEmail");
            if (!string.IsNullOrEmpty(agentEmail))
            {
                await InputField.SetInputFieldAsync(AgentEmail, agentEmail, true, 1);
            }

            // InsuranceTransferredAgency
            var insuranceTransferredAgency = _FileReader.GetOptionalValue(filePath, $"{profileKey}.HasInsurancebeenTransferredWithinAgency");
            if (!string.IsNullOrEmpty(insuranceTransferredAgency))
            {
                var radio = string.Format(InsuranceTransferredAgency, insuranceTransferredAgency);
                await RadioButton.SelectRadioButtonAsync(radio, "value", true, 1);
            }

            // CoverageDeclined
            var coverageDeclined = _FileReader.GetOptionalValue(filePath, $"{profileKey}.CoverageDeclined");
            if (!string.IsNullOrEmpty(coverageDeclined))
            {
                var radio = string.Format(CoverageDeclined, coverageDeclined);
                await RadioButton.SelectRadioButtonAsync(radio, "value", true, 1);
            }

            // ApplicantConvictedArson
            var applicantConvictedArson = _FileReader.GetOptionalValue(filePath, $"{profileKey}.ApplicantConvictedArson");
            if (!string.IsNullOrEmpty(applicantConvictedArson))
            {
                var radio = string.Format(ApplicantConvictedArson, applicantConvictedArson);
                await RadioButton.SelectRadioButtonAsync(radio, "value", true, 1);
            }

            // BindingDestinationEmail
            var bindingDestinationEmail = _FileReader.GetOptionalValue(filePath, $"{profileKey}.EmailRecipient");
            if (!string.IsNullOrEmpty(bindingDestinationEmail))
            {
                var radio = string.Format(BindingDestinationEmail, bindingDestinationEmail);
                await RadioButton.SelectRadioButtonAsync(radio, "value", true, 1);
            }

            // Remarks
            var remarks = _FileReader.GetOptionalValue(filePath, $"{profileKey}.Remarks");
            if (!string.IsNullOrEmpty(remarks))
            {
                await InputField.SetTextAreaInputFieldAsync(Remarks, remarks, true, 1);
            }

            // CoverageBound
            var coverageBound = _FileReader.GetOptionalValue(filePath, $"{profileKey}.IsCoverageBound");
            if (!string.IsNullOrEmpty(coverageBound))
            {
                var radio = string.Format(CoverageBound, coverageBound);
                await RadioButton.SelectRadioButtonAsync(radio, "value", true, 1);
            }

            // AgreeTerms
            var agreeTerms = _FileReader.GetOptionalValue(filePath, $"{profileKey}.AgreeTerms");
            if (!string.IsNullOrEmpty(agreeTerms) && agreeTerms == "Yes")
            {
                await Checkbox.SelectCheckboxAsync(AgreeTerms, true, true, 1);
            }

            await Checkbox.VerifyCheckboxExistAsync(AgreeTerms, true, 1, "I agree to the above terms and conditions.");

            // BUSINESS_COVER
            var businessCover = _FileReader.GetOptionalValue(filePath, $"{profileKey}.TenantDogs");
            if (!string.IsNullOrEmpty(businessCover))
            {
                var radio = string.Format(TenantDogs, businessCover);
                await RadioButton.SelectRadioButtonAsync(radio, "No", true, 1);
            }

            // NumberOfYearsExperience
            var yearsExperience = _FileReader.GetOptionalValue(filePath, $"{profileKey}.NumberOfYearsExperience");
            if (!string.IsNullOrEmpty(yearsExperience))
            {
                await InputField.SetInputFieldAsync(NumberOfYearsExperience, yearsExperience, true, 1);
            }

            // Subcontractwork
            var subcontractwork = _FileReader.GetOptionalValue(filePath, $"{profileKey}.Subcontractwork");
            if (!string.IsNullOrEmpty(subcontractwork))
            {
                var radio = string.Format(Subcontractwork, subcontractwork);
                await RadioButton.SelectRadioButtonAsync(radio, "value", true, 1);
            }

            // DroneUse
            var droneUse = _FileReader.GetOptionalValue(filePath, $"{profileKey}.Droneuse");
            if (!string.IsNullOrEmpty(droneUse))
            {
                var radio = string.Format(DroneUse, droneUse);
                await RadioButton.SelectRadioButtonAsync(radio, "value", true, 1);
            }

            // Demolition
            var demolition = _FileReader.GetOptionalValue(filePath, $"{profileKey}.Demolition");
            if (!string.IsNullOrEmpty(demolition))
            {
                var radio = string.Format(Demolition, demolition);
                await RadioButton.SelectRadioButtonAsync(radio, "value", true, 1);
            }

            // RoofOnly
            var roofOnly = _FileReader.GetOptionalValue(filePath, $"{profileKey}.RoofOnly");
            if (!string.IsNullOrEmpty(roofOnly))
            {
                var radio = string.Format(RoofOnly, roofOnly);
                await RadioButton.SelectRadioButtonAsync(radio, "value", true, 1);
            }

            // AsbestosWork
            var asbestosWork = _FileReader.GetOptionalValue(filePath, $"{profileKey}.AsbestosWork");
            if (!string.IsNullOrEmpty(asbestosWork))
            {
                var radio = string.Format(AsbestosWork, asbestosWork);
                await RadioButton.SelectRadioButtonAsync(radio, "value", true, 1);
            }

            // EIFS
            var eifs = _FileReader.GetOptionalValue(filePath, $"{profileKey}.EIFS");
            if (!string.IsNullOrEmpty(eifs))
            {
                var radio = string.Format(EIFS, eifs);
                await RadioButton.SelectRadioButtonAsync(radio, "value", true, 1);
            }

           /*await Button.ClickButtonAsync(Message_btn, ActionType.Click, true, 1);
            await Task.Delay(3000);
            await _commonPage.CheckAllMessageOverrideCheckboxes1Async();
            page.Dialog += async (_, dialog) => await dialog.AcceptAsync();
            //await Task.Delay(2000);
            await Button.ClickButtonAsync(Apply_Override_btn, ActionType.Click, true, 1);*/
            await Task.Delay(2000);
        }
    }
}