using AventStack.ExtentReports.Gherkin.Model;
using bdd.playwright.gbiz.pages.agentpages;
using BDD.Playwright.Core.Interfaces;
using BDD.Playwright.Core.Loggers;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.AgentPages;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using BDD.Playwright.Origami.Pages.AgentPages;
using GoodVille.GBIZ.Reqnroll.Automation.Pages.GlobalPages;

namespace GoodVille.GBIZ.Reqnroll.Automation.Steps.AgentsStepDefinition
{
    [Binding]
    public class AgentTC65_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public LoginPage _loginPage;
        public QuotePage _quotePage;
        public Quote_ApplicantPage _quoteApplicantPage;
        public Quote_BuildingPage _quoteBuildingPage;
        public Quote_DwellingPage _quoteDwellingPage;
        public Quote_LocationPage _quoteLocationPage;
        private readonly IFileReader _fileReader;

        public AgentTC65_StepDefinition(
            ScenarioContext scenarioContext,
            LoginPage loginPage,
            CommonXpath commonXpath,
            QuotePage quotePage,
           // NewQuote_TradesmanCoverPage tradesmanCoverPage,
            Quote_ApplicantPage quoteApplicantPage,
            Quote_DwellingPage quoteDwellingPage,
            Quote_BuildingPage quote_BuildingPage,
            Quote_LocationPage quote_LocationPage,
            IFileReader fileReader)
            : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _loginPage = loginPage;
            _commonXpath = commonXpath;
            _quotePage = quotePage;
            _quoteApplicantPage = quoteApplicantPage;
            _quoteDwellingPage = quoteDwellingPage;
            _quoteBuildingPage = quote_BuildingPage;
            _quoteLocationPage = quote_LocationPage;
            _fileReader = fileReader;
        }

        [When(@"User select the Farm Owner Option")]
        public async Task UserselecttheFarmOwnerOptionAsync()
        {
            await Task.Delay(2000);
            await Button.ClickButtonAsync(_commonXpath.FarmownersButton, ActionType.Click, true, 1);
        }

        [When(@"User enter the mandatory fields in the New Quote Page for the Farm Owner from json {string}")]
        public async Task UserenterthemandatoryfieldsintheNewQuotePagefortheFarmOwnerAsync(string profileKey)
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available.");
            }

            var filePath = "QuoteApplicantPage\\QuoteApplicantPage.json";

            await InputField.SetTextAreaInputFieldAsync(_quoteApplicantPage.BookCode_Inp, _fileReader.GetOptionalValue(filePath, $"{profileKey}.BookBusiness"), true, 1);
            await DropDown.SelectDropDownAsync(_quoteApplicantPage.Producer_Drp, _fileReader.GetOptionalValue(filePath, $"{profileKey}.Producer"), true, 1);
            await RadioButton.SelectRadioButtonAsync(_quoteApplicantPage.FOPage_TypeOfBusiness_RadioBtn, "Individual", true, 1);
            await InputField.SetTextAreaInputFieldAsync(_quoteApplicantPage.NamedInsured_FirstName_Inp, _fileReader.GetOptionalValue(filePath, $"{profileKey}.FirstName"), true, 1);
            await InputField.SetTextAreaInputFieldAsync(_quoteApplicantPage.NamedInsured_LastName_Inp, _fileReader.GetOptionalValue(filePath, $"{profileKey}.LastName"), true, 1);
            await InputField.SetTextAreaInputFieldAsync(_quoteApplicantPage.NamedInsured_DOB_Inp, _fileReader.GetOptionalValue(filePath, $"{profileKey}.DOB"), true, 1);
            await DropDown.SelectDropDownAsync(_quoteApplicantPage.FORelationToInsured_Drpdwn, _fileReader.GetOptionalValue(filePath, $"{profileKey}.RelationShipToInsured"), true, 1);
            await InputField.SetTextAreaInputFieldAsync(_quoteApplicantPage.AddressLine1_Inp, _fileReader.GetOptionalValue(filePath, $"{profileKey}.Address"), true, 1);
            await InputField.SetTextAreaInputFieldAsync(_quoteApplicantPage.City_Inp, _fileReader.GetOptionalValue(filePath, $"{profileKey}.City"), true, 1);
            await DropDown.SelectDropDownAsync(_quoteApplicantPage.State_Drp1, _fileReader.GetOptionalValue(filePath, $"{profileKey}.State"), true, 1);
            await InputField.SetTextAreaInputFieldAsync(_quoteApplicantPage.ZipCode_Inp1, _fileReader.GetOptionalValue(filePath, $"{profileKey}.Zip1"), true, 1);
            await Button.ClickButtonAsync(_quoteApplicantPage.FOCopyToAddLocation_Btn, ActionType.Click, true, 1);
            await Button.ClickButtonAsync(_quoteApplicantPage.FOPage_FarmOperation_Btn, ActionType.Click, true, 1);
            await Button.ClickButtonAsync(_quoteApplicantPage.FOPage_FarmOperation_RadioBtn, ActionType.Click, true, 1);
            await InputField.SetTextAreaInputFieldAsync(_quoteApplicantPage.FOPage_FarmOperationPercentage_Txt, _fileReader.GetOptionalValue(filePath, $"{profileKey}.FarmOperationPercentage"), true, 1);
        }

        [When(@"User Click on Next Button")]
        public async Task UserClickonNextButtonAsync()
        {
            await Task.Delay(2000);
            await Button.ScrollIntoViewAsync(_quoteApplicantPage.NextButton, true, 1, "Next Button");
            await Button.ClickButtonForStaleElementWithoutDepenAsync(_quoteApplicantPage.NextButton, ActionType.Click, true, 1, "Next Button");
        }

        [When(@"User enter the Location details in the Farm Owner page from json {string}")]
        public async Task UserentertheLocationdetailsintheFarmOwnerpageAsync(string profileKey)
        {
            var filePath = "QuoteLocationPage\\QuoteLocationPage.json";

            await Task.Delay(5000);

            await InputField.SetTextAreaInputFieldAsync(
                _quoteApplicantPage.TCPage_MilesToFireDept_Inp,
                _fileReader.GetOptionalValue(filePath, $"{profileKey}.Miles"),
                true,
                1);

            await InputField.SetTextAreaInputFieldAsync(
                _quoteApplicantPage.TCPage_RespondingFireDept_Inp,
                _fileReader.GetOptionalValue(filePath, $"{profileKey}.RespondingFireDepartment"),
                true,
                1);

            await Task.Delay(2000);

            await InputField.SetTextAreaInputFieldAsync(
                _quoteApplicantPage.FOPage_NumberOfAcres_Inp,
                _fileReader.GetOptionalValue(filePath, $"{profileKey}.NumberOfAcres"),
                true,
                1);

            await InputField.SetTextAreaInputFieldAsync(
                _quoteApplicantPage.FOPage_NumberOfAcresLeased_Inp,
                _fileReader.GetOptionalValue(filePath, $"{profileKey}.NumberOfAcresLeased"),
                true,
                1);

            await InputField.SetTextAreaInputFieldAsync(
                _quoteApplicantPage.FOPage_NumberOfAcresRented_Inp,
                _fileReader.GetOptionalValue(filePath, $"{profileKey}.NumberOfAcresRented"),
                true,
                1);

            await Checkbox.SelectCheckboxAsync(_quoteApplicantPage.Residence_Drpdwn, true, true, 1);
            await Checkbox.SelectCheckboxAsync(_quoteApplicantPage.Farmbuil_Drp, true, true, 1);
            await Checkbox.SelectCheckboxAsync(_quoteApplicantPage.Biogas_DigesterDrp, true, true, 1);
            await Checkbox.SelectCheckboxAsync(_quoteApplicantPage.Solarpanel_Drp, true, true, 1);

            await Button.ScrollIntoViewAsync(_quoteApplicantPage.FOPage_Save_Btn, true, 1, "Save Button");
            await Button.ClickButtonAsync(_quoteApplicantPage.FOPage_Save_Btn, ActionType.Click, true, 1);

            await InputField.SetTextAreaInputFieldAsync(
                _quoteApplicantPage.FOPage_NumberOfDogs_Inp,
                _fileReader.GetOptionalValue(filePath, $"{profileKey}.NumberOfDogs"),
                true,
                1);

            await Checkbox.SelectCheckboxAsync(_quoteApplicantPage.Premises_Dropdown, true, true, 1);

            await RadioButton.SelectRadioButtonAsync(
                string.Format(_quoteApplicantPage.FOPage_OutdoorWoodFurnance_RadioBtn, _fileReader.GetOptionalValue(filePath, $"{profileKey}.Isthereanoutdoorwoodfurnaceatthislocation")),
                "Value",
                true,
                1);

            await RadioButton.SelectRadioButtonAsync(
                string.Format(_quoteApplicantPage.FOPage_SwimmingPool_RadioBtn, _fileReader.GetOptionalValue(filePath, $"{profileKey}.Isthereaswimmingpoolatthislocation")),
                "Value",
                true,
                1);

            await RadioButton.SelectRadioButtonAsync(
                string.Format(_quoteApplicantPage.FOPage_Pond_RadioBtn, _fileReader.GetOptionalValue(filePath, $"{profileKey}.Isthereapondatthislocation")),
                "Value",
                true,
                1);

            await RadioButton.SelectRadioButtonAsync(
                string.Format(_quoteApplicantPage.FOPage_ZipLine_RadioBtn, _fileReader.GetOptionalValue(filePath, $"{profileKey}.Isthereaziplineonpremises")),
                "Value",
                true,
                1);

            await RadioButton.SelectRadioButtonAsync(
                string.Format(_quoteApplicantPage.FOPage_Trampoline_RadioBtn, _fileReader.GetOptionalValue(filePath, $"{profileKey}.Isthereatrampolineatthislocation")),
                "value",
                true,
                1);

            await RadioButton.SelectRadioButtonAsync(
                string.Format(_quoteApplicantPage.FOPage_ManualPits_RadioBtn, _fileReader.GetOptionalValue(filePath, $"{profileKey}.Isthereamanurepitatthislocation")),
                "value",
                true,
                1);

            await RadioButton.SelectRadioButtonAsync(
                string.Format(_quoteApplicantPage.FOPage_Premises_RadioBtn, _fileReader.GetOptionalValue(filePath, $"{profileKey}.InspectThePremises")),
                "value",
                true,
                1);
        }

        [When(@"User Click on Add Dwelling and enter the fields from json {string}")]
        public async Task UserClickonAddDwellingandenterthefieldsAsync(string profileKey)
        {
            await Task.Delay(2000);
            await Button.ScrollIntoViewAsync(_quoteDwellingPage.AddDwelling_btn, true, 1, "Add Dwelling Button");
            await Button.ClickButtonAsync(_quoteDwellingPage.AddDwelling_btn, ActionType.Click, true, 1);

            var filePath = "QuoteBuildingPage\\QuoteBuildingPage.json";
            await DropDown.SelectDropDownAsync(
                _quoteDwellingPage.Location_drpdwn,
                _fileReader.GetOptionalValue(filePath, $"{profileKey}.Location"),
                true,
                1);

            var ownBuildingValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.InsuredOwnBuilding");
            if (!string.IsNullOrEmpty(ownBuildingValue))
            {
                var ownRadio = string.Format(_quoteDwellingPage.OwnedByTheInsured_RadioBtn, ownBuildingValue);
                await RadioButton.SelectRadioButtonAsync(ownRadio, "value", true, 1);
            }

            await InputField.SetTextAreaInputFieldAsync(
                _quoteDwellingPage.YearOfConstruction_FO,
                _fileReader.GetOptionalValue(filePath, $"{profileKey}.YearsOfConstruction"),
                true,
                1);

            var occupationTypeValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.OccupancyType_FO");
            if (!string.IsNullOrEmpty(occupationTypeValue))
            {
                var occupationRadio = string.Format(_quoteDwellingPage.OccupationType_RadioBtn, occupationTypeValue);
                await RadioButton.SelectRadioButtonAsync(occupationRadio, "value", true, 1);
            }

            await DropDown.SelectDropDownAsync(
                _quoteDwellingPage.NumberOfFamilies_drpdwn,
                _fileReader.GetOptionalValue(filePath, $"{profileKey}.NumberOfFamilies_FO"),
                true,
                1);

            var buildingConstructValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Construction_FO");
            if (!string.IsNullOrEmpty(buildingConstructValue))
            {
                var buildRadio = string.Format(_quoteDwellingPage.DwellingUnderConstruction_RadioBtn, buildingConstructValue);
                await RadioButton.SelectRadioButtonAsync(buildRadio, "value", true, 1);
            }

            var flatRoofValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.FlatRoof_FO");
            if (!string.IsNullOrEmpty(flatRoofValue))
            {
                var flatRoofRadio = string.Format(_quoteDwellingPage.FlatRoof_RadioBtn, flatRoofValue);
                await RadioButton.SelectRadioButtonAsync(flatRoofRadio, "value", true, 1);
            }

            await Button.ScrollIntoViewAsync(_quoteDwellingPage.LimitsCoveragesDiscounts_SubTab, true, 1, "Save Button");
            await Button.ClickButtonAsync(_quoteDwellingPage.LimitsCoveragesDiscounts_SubTab, ActionType.Click, true, 1);
            await Task.Delay(6000);

            await DropDown.SelectDropDownAsync(
                _quoteDwellingPage.PolicyForm_DrpDwn,
                _fileReader.GetOptionalValue(filePath, $"{profileKey}.PolicyForm_FO"),
                true,
                1);

            var policyPlanFormValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PolicyPlanForm_FO");
            if (!string.IsNullOrEmpty(policyPlanFormValue))
            {
                var planRadio = string.Format(_quoteDwellingPage.PolicyPlanForm_RadioBtn, policyPlanFormValue);
                await RadioButton.SelectRadioButtonAsync(planRadio, "value", true, 1);
            }

            await InputField.SetTextAreaInputFieldAsync(
                _quoteDwellingPage.PolicyDwellingCoverage_Inp,
                _fileReader.GetOptionalValue(filePath, $"{profileKey}.PolicyDwellingCoverage_FO"),
                true,
                1);

            await DropDown.SelectDropDownAsync(
                _quoteDwellingPage.AllPerilDeductible_drpdwn,
                _fileReader.GetOptionalValue(filePath, $"{profileKey}.AllPerilDeductible"),
                true,
                1);

            await DropDown.SelectDropDownAsync(
                _quoteDwellingPage.WindHailDeductible_drpdwn,
                _fileReader.GetOptionalValue(filePath, $"{profileKey}.WindHailDeductible"),
                true,
                1);

            var earthquakeValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.EarthquakeFO");
            if (!string.IsNullOrEmpty(earthquakeValue))
            {
                var earthquakeRadio = string.Format(_quoteDwellingPage.DwellingEarthquake_Radiobtn, earthquakeValue);
                await RadioButton.SelectRadioButtonAsync(earthquakeRadio, "value", true, 1);
            }

            var roofSurfaceValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.RoofSurfaceFO");
            if (!string.IsNullOrEmpty(roofSurfaceValue))
            {
                var roofSurfaceRadio = string.Format(_quoteDwellingPage.DwellingRoofSurface_Radiobtn, roofSurfaceValue);
                await RadioButton.SelectRadioButtonAsync(roofSurfaceRadio, "value", true, 1);
            }
        }
    }
}