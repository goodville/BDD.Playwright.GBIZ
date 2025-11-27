using BDD.Playwright.Core.Interfaces;
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
    public class ReportAClaimFormPage : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IFileReader _fileReader;
        private readonly IPage _page;
        public ReportAClaimFormPage(ScenarioContext scenarioContext, IFileReader fileReader) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _fileReader = fileReader;
            _page = scenarioContext.Get<IPage>("Page");

        }
        public string PolicyInformationSection_Verify { get; set; } = "//ph-section-policy-information[@class='policyInformationSection']";
        public string Breadcrumb_Verify { get; set; } = "//ol[contains(@class,'breadcrumb')]";
        public string HomePhoneNumber_Inp { get; set; } = "//input[@id='phHomeNumber']";
        public string WorkPhoneNumber_Inp { get; set; } = "//input[@id='phWorkNumber']";
        public string CellPhoneNumber_Inp { get; set; } = "//input[@id='phCellNumber']";
        public string OtherPhoneNumber_Inp { get; set; } = "//input[@id='phOtherNumber']";
        public string ReceiveText_CheckBox { get; set; } = "//input[@id='receiveTexts' and @type='checkbox']";
        public string Email_Inp { get; set; } = "//input[@id='phEmail']";
        public string PreferredContact_Radio { get; set; } = "//span[./input[contains(@id,'phPreferences') and @value='{0}']]/label";
        public string AreyouInsured_Radio { get; set; } = "//span[./input[contains(@id,'prepIsInsured') and @value='{0}']]/label";
        public string Whoareyou_Drp { get; set; } = "//select[@id='prepWho']";
        public string Whoareyou_Describe_Inp { get; set; } = "//input[@id='prepDescribe']";
        public string Whoareyou_ReportedBy_Inp { get; set; } = "//input[@id='prepReportedBy']";
        public string FullName_Inp { get; set; } = "//input[@id='prepFullName']";
        public string PrepareInformationEmail_Inp { get; set; } = "//input[@id='prepEmail']";
        public string AccidentTime_Inp { get; set; } = "//input[@id='autoTimeLoss']";
        public string AccidentTime_AMorPM_Drp { get; set; } = "//div[./input[@id='autoTimeLoss']]/select";
        public string LossLocation_Inp { get; set; } = "//input[@id='autoLossLocation']";
        public string DecribeAccident_Inp { get; set; } = "//textarea[@id='autoDescribe']";
        public string InsuredVehicle_Drp { get; set; } = "//select[@id='autoInsuredVehicle']";
        public string InsuredVehicle_Year_Inp { get; set; } = "//input[@id='autoYear']";
        public string InsuredVehicle_Make_Inp { get; set; } = "//input[@id='autoMake']";
        public string InsuredVehicle_Model_Inp { get; set; } = "//input[@id='autoModel']";
        public string Driver_Inp { get; set; } = "//input[@id='autoDriver']";
        public string DecribeDamage_Inp { get; set; } = "//textarea[@id='autoDescribeDamage']";
        public string AuthorityContact_Radio { get; set; } = "//span[./input[contains(@id,'autoAuthoritiesContacted') and @value='{0}']]/label";
        public string VehicleDrivable_Radio { get; set; } = "//span[./input[contains(@id,'autoIsVehicleDrivable') and @value='{0}']]/label";
        public string OtherVehicleInvolved_Radio { get; set; } = "//span[./input[contains(@id,'autoIsOtherVehicleInvolved') and @value='{0}']]/label";
        public string AnyInjury_Radio { get; set; } = "//span[./input[contains(@id,'autoIsAnyInjured') and @value='{0}']]/label";
        public string Authority_What_Inp { get; set; } = "//input[@id='autoWhatAuthority']";
        public string Authority_IncidentNumber_Inp { get; set; } = "//input[@id='autoIncidentNumber']";
        public string LocationVehicle_BusinessName_Inp { get; set; } = "//input[@id='autoLOHBusinessName']";
        public string LocationVehicle_Address_Inp { get; set; } = "//input[@id='autoLOHAddress']";
        public string LocationVehicle_AddressLine2_Inp { get; set; } = "//input[@id='autoLOHAddress2']";
        public string LocationVehicle_City_Inp { get; set; } = "//input[@id='autoLOHCity']";
        public string LocationVehicle_State_Inp { get; set; } = "//input[@id='autoLOHState']";
        public string LocationVehicle_Zip_Inp { get; set; } = "//input[@id='autoLOHZip']";
        public string LocationVehicle_ContactPhone_Inp { get; set; } = "//input[@id='autoLOHContactPhone']";
        public string LocationVehicle_ContactPerson_Inp { get; set; } = "//input[@id='autoLOHContactPerson']";
        public string Vehicleinvolved_Year_Inp { get; set; } = "//input[contains(@id,'invYear')]";
        public string Vehicleinvolved_Make_Inp { get; set; } = "//input[contains(@id,'invMake')]";
        public string Vehicleinvolved_Model_Inp { get; set; } = "//input[contains(@id,'invModel')]";
        public string Vehicleinvolved_InsuranceCarrier_Inp { get; set; } = "//input[contains(@id,'invInsuranceCarrier')]";
        public string Vehicleinvolved_OwnerName_Inp { get; set; } = "//input[contains(@id,'invOwnerName')]";
        public string Vehicleinvolved_OwnerAddress_Inp { get; set; } = "//input[contains(@id,'invOwnerAddress')]";
        public string Vehicleinvolved_Driver_Inp { get; set; } = "//input[contains(@id,'invDriver')]";
        public string Vehicleinvolved_ContactEmail_Inp { get; set; } = "//input[contains(@id,'invEmail')]";
        public string Vehicleinvolved_ContactPhone_Inp { get; set; } = "//input[contains(@id,'invPhone')]";
        public string Vehicleinvolved_DescribeVehicleDamage_Inp { get; set; } = "//textarea[contains(@id,'invDescribe')]";
        public string Injury_Name_Inp { get; set; } = "//input[contains(@id,'injName')]";
        public string Injury_Address_Inp { get; set; } = "//input[contains(@id,'injAddress')]";
        public string Injury_ContactEmail_Inp { get; set; } = "//input[contains(@id,'injEmail')]";
        public string Injury_ContactPhone_Inp { get; set; } = "//input[contains(@id,'injPhone')]";
        public string Injury_Age_Inp { get; set; } = "//input[contains(@id,'injAge')]";
        public string Injury_DescribeExtentofInjury_Inp { get; set; } = "//input[contains(@id,'injDescribe')]";
        public string Injury_Type_Radio { get; set; } = "//span[./input[contains(@id,'injType')]]/label[contains(text(),'{0}')]";
        public string AddAnotherVehicle_Btn { get; set; } = "//button[./span[contains(text(),'Add Another Vehicle')]]";
        public string AddAnotherInjury_Btn { get; set; } = "//button[./span[contains(text(),'Add Another Injury')]]";
        public string Submit_Btn { get; set; } = "//button[contains(text(),'Submit')]";
        public string FileUploaded_Btn { get; set; } = "//button[contains(text(),'CHOOSE FILE')]";
        public string AddPhoneNumber_Btn { get; set; } = "//button[contains(text(),'Add number')]";
        public string ClaimNumber_Text { get; set; } = "//div[./div[./strong[contains(text(),'Claim Number')]]]/div[2]";
        public string HomeOwner_LossLocation_Drp { get; set; } = "//select[@id='propLossLocation']";
        public string HomeOwner_LossLocation_Inp { get; set; } = "//input[@id='propLocationOfLoss']";
        public string HomeOwner_DescribeDamage_Inp { get; set; } = "//textarea[@id='propDescribeDamage']";
        public string HomeOwner_EstimateRepair_Radio { get; set; } = "//span[./input[contains(@id,'autoRepairEstimate') and @value='{0}']]/label";
        public string HomeOwner_AccidentTime_Inp { get; set; } = "//input[@id='propTimeLoss']";
        public string HomeOwner_AccidentTime_AMorPM_Drp { get; set; } = "//div[./input[@id='propTimeLoss']]/select";
        public string DamageAmount_Radio { get; set; } = "//span[./input[contains(@id,'autoDamages5000') and contains(@value,'{0}')]]/label";
        public string LossNoticeRecived_Text { get; set; } = "//p[contains(text(),'We have received the claim that you reported on our website. A claims adjuster has been assigned and will contact you within 8 working hours. We have also sent a copy of the claim report to your agent. If you have any questions concerning your claim, please contact your agent or our claims department.')]";
        public string PolicyHolderInformation_Text { get; set; } = "//div[./h3[contains(text(),'Policyholder')]]/div";
        public string AgentInformation_Text { get; set; } = "//div[./h3[contains(text(),'Agent Information')]]/div";
        public string GoodvilleInformation_Text { get; set; } = "//div[./h3[contains(text(),'Goodville Mutual Information')]]/div";
        public async Task VerifyReportAClaimFormPageAsync(string profileKey)
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter.");
            }

            try
            {
                var filePath = "ReportAClaimFormPage\\ReportAClaimFormPage.json";
                var expectedText = _fileReader.GetValue(filePath, profileKey)?.ToString();

                if (string.IsNullOrWhiteSpace(expectedText))
                {
                    throw new Exception($"No data found for key '{profileKey}' in JSON file '{filePath}'.");
                }

                var actualText = await _page.Locator(PolicyInformationSection_Verify).InnerTextAsync();
                var expectedLines = expectedText.Split('\n', StringSplitOptions.RemoveEmptyEntries)
                                                .Select(x => x.Trim())
                                                .ToList();
                foreach (var line in expectedLines)
                {
                    if (!actualText.Contains(line, StringComparison.OrdinalIgnoreCase))
                    {
                        throw new Exception($"Mismatch found — Expected line not present: '{line}'");
                    }

                    logger.WriteLine($"Verified text line: '{line}'");
                }

                logger.WriteLine("ReportAClaimFormPage verification successful.");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error verifying ReportAClaimFormPage: {ex.Message}");
                throw;
            }
        }

        public async Task ReportAClaimAsync(string profileKey)
        {
            try
            {
                var filePath = "ReportAClaimFormPage\\ReportAClaimFormPage.json";

                // Read all fields from JSON using profileKey
                var homePhoneNumber = _fileReader.GetValue(filePath, $"{profileKey}.HomePhoneNumber");
                var workPhoneNumber = _fileReader.GetValue(filePath, $"{profileKey}.WorkPhoneNumber");
                var cellPhoneNumber = _fileReader.GetValue(filePath, $"{profileKey}.CellPhoneNumber");
                var otherPhoneNumber = _fileReader.GetValue(filePath, $"{profileKey}.OtherPhoneNumber");
                var receiveText = _fileReader.GetValue(filePath, $"{profileKey}.ReceiveText");
                var email = _fileReader.GetValue(filePath, $"{profileKey}.Email");
                var preferredContact = _fileReader.GetValue(filePath, $"{profileKey}.PreferedContactPhoneNumber");
                var preferredContactEmailorPhone = _fileReader.GetValue(filePath, $"{profileKey}.PreferredContactEmailorPhone");
                var areYouInsured = _fileReader.GetValue(filePath, $"{profileKey}.AreyouInsuredYesorNo");
                var whoAreYou = _fileReader.GetValue(filePath, $"{profileKey}.Whoareyou");
                var whoAreYouDescribe = _fileReader.GetValue(filePath, $"{profileKey}.Whoareyou_Describe");
                var whoAreYouReportedBy = _fileReader.GetValue(filePath, $"{profileKey}.Whoareyou_ReportedBy");
                var fullName = _fileReader.GetValue(filePath, $"{profileKey}.FullName");
                var prepareInformationEmail = _fileReader.GetValue(filePath, $"{profileKey}.PrepareInformationEmail");
                //var preferredContactXpath = string.Format(PreferredContact_Radio, preferredContact);
                //var insuredXpath = string.Format(AreyouInsured_Radio, areYouInsured);

                // Start form interactions
                await InputField.SetTextAreaInputFieldAsync(HomePhoneNumber_Inp, homePhoneNumber, true, 1);

                if (!string.IsNullOrEmpty(workPhoneNumber))
                {
                    await Button.ClickButtonAsync(AddPhoneNumber_Btn, PageElements.ActionType.Click, true, 1);
                    await InputField.SetTextAreaInputFieldAsync(WorkPhoneNumber_Inp, workPhoneNumber, true, 1);
                }

                if (!string.IsNullOrEmpty(cellPhoneNumber))
                {
                    await Button.ClickButtonAsync(AddPhoneNumber_Btn, PageElements.ActionType.Click, true, 1);
                    await InputField.SetTextAreaInputFieldAsync(CellPhoneNumber_Inp, cellPhoneNumber, true, 1);
                }

                if (!string.IsNullOrEmpty(otherPhoneNumber))
                {
                    await Button.ClickButtonAsync(AddPhoneNumber_Btn, PageElements.ActionType.Click, true, 1);
                    await InputField.SetTextAreaInputFieldAsync(OtherPhoneNumber_Inp, otherPhoneNumber, true, 1);
                }

                if (receiveText?.ToLower() == "yes")
                {
                    await Checkbox.SelectCheckboxAsync(ReceiveText_CheckBox, true, true, 1);
                }

                await InputField.SetTextAreaInputFieldAsync(Email_Inp, email, true, 1);

              /*  var preferredContactXpath = string.Format(PreferredContact_Radio, preferredContact);
                await RadioButton.SelectRadioButtonAsync(preferredContactXpath, PreferredContact_Radio, true, 1);*/

                var preferredContactEmailOrPhoneXpath = string.Format(PreferredContact_Radio, preferredContactEmailorPhone);
                await RadioButton.SelectRadioButtonAsync(preferredContactEmailOrPhoneXpath,PreferredContact_Radio,true, 1);
                var areYouInsuredXpath = string.Format(AreyouInsured_Radio, areYouInsured);
                await RadioButton.SelectRadioButtonAsync(areYouInsuredXpath,AreyouInsured_Radio, true, 1);

                if (areYouInsured?.ToLower() == "no")
                {
                    await DropDown.SelectDropDownAsync(Whoareyou_Drp, whoAreYou, true, 1);

                    if (whoAreYou == "Other")
                    {
                        await InputField.SetTextAreaInputFieldAsync(Whoareyou_Describe_Inp, whoAreYouDescribe, true, 1);
                        await InputField.SetTextAreaInputFieldAsync(Whoareyou_ReportedBy_Inp, whoAreYouReportedBy, true, 1);
                    }
                }

                await InputField.SetTextAreaInputFieldAsync(FullName_Inp, fullName, true, 1);
                await InputField.SetTextAreaInputFieldAsync(PrepareInformationEmail_Inp, prepareInformationEmail, true, 1);
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error in ReportAClaimAsync: {ex.Message}");
                throw;
            }
        }

        public async Task AutoClaimInformationAsync(string profileKey)
        {
            var filePath = "ReportAClaimFormPage\\ReportAClaimFormPage.json";
            var accidentTime = _fileReader.GetValue(filePath, $"{profileKey}.AccidentTime");
            var accidentAmPm = _fileReader.GetValue(filePath, $"{profileKey}.AccidentTimeAMorPM");
            var lossLocation = _fileReader.GetValue(filePath, $"{profileKey}.LossLocation");
            var describeAccident = _fileReader.GetValue(filePath, $"{profileKey}.DescribeAccident");

            await InputField.SetTextAreaInputFieldAsync(AccidentTime_Inp, accidentTime, true, 1);
            if (accidentAmPm == "PM")
            {
                await DropDown.SelectDropDownAsync(AccidentTime_AMorPM_Drp, "PM", true, 1);
            }

            await InputField.SetTextAreaInputFieldAsync(LossLocation_Inp, lossLocation, true, 1);
            await TextArea.SetTextAreaFieldAsync(DecribeAccident_Inp, describeAccident, true, 1);

            // Insured vehicle
            var insuredVehicleType = _fileReader.GetValue(filePath, $"{profileKey}.InsuredVehicle");
            await DropDown.SelectDropDownAsync(InsuredVehicle_Drp, insuredVehicleType, true, 1);

            if (insuredVehicleType == "Other")
            {
                await InputField.SetTextAreaInputFieldAsync(InsuredVehicle_Year_Inp, _fileReader.GetValue(filePath, $"{profileKey}.InsuredVehicleYear"), true, 1);
                await InputField.SetTextAreaInputFieldAsync(InsuredVehicle_Make_Inp, _fileReader.GetValue(filePath, $"{profileKey}.InsuredVehicleMake"), true, 1);
                await InputField.SetTextAreaInputFieldAsync(InsuredVehicle_Model_Inp, _fileReader.GetValue(filePath, $"{profileKey}.InsuredVehicleModel"), true, 1);
            }

            await InputField.SetTextAreaInputFieldAsync(Driver_Inp, _fileReader.GetValue(filePath, $"{profileKey}.Driver"), true, 1);
            await TextArea.SetTextAreaFieldAsync(DecribeDamage_Inp, _fileReader.GetValue(filePath, $"{profileKey}.DescribeDamage"), true, 1);

            // Authority contact
            var authorityYesOrNo = _fileReader.GetValue(filePath, $"{profileKey}.AuthorityContactYesorNo");
            var authorityContact = string.Format(AuthorityContact_Radio, authorityYesOrNo);
            await RadioButton.SelectRadioButtonAsync(authorityContact, AuthorityContact_Radio, true, 1);

            if (authorityYesOrNo.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                await InputField.SetTextAreaInputFieldAsync(Authority_What_Inp, _fileReader.GetValue(filePath, $"{profileKey}.AuthorityWhat"), true, 1);
                await InputField.SetTextAreaInputFieldAsync(Authority_IncidentNumber_Inp, _fileReader.GetValue(filePath, $"{profileKey}.AuthorityIncidentNumber"), true, 1);
            }

            // Vehicle drivable
            var vehicleDrivableYesOrNo = _fileReader.GetValue(filePath, $"{profileKey}.VehicleDrivableYesorNo");
            var vehicleDrivableRadio = string.Format(VehicleDrivable_Radio, vehicleDrivableYesOrNo);
            await RadioButton.SelectRadioButtonAsync(vehicleDrivableRadio, VehicleDrivable_Radio, true, 1);

            if (!vehicleDrivableYesOrNo.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                await InputField.SetTextAreaInputFieldAsync(LocationVehicle_BusinessName_Inp, _fileReader.GetValue(filePath, $"{profileKey}.LocationVehicleBusinessName"), true, 1);
                await InputField.SetTextAreaInputFieldAsync(LocationVehicle_Address_Inp, _fileReader.GetValue(filePath, $"{profileKey}.LocationVehicleAddress"), true, 1);

                var addressLine2 = _fileReader.GetValue(filePath, $"{profileKey}.LocationVehicleAddressLine2");
                if (!string.IsNullOrEmpty(addressLine2))
                {
                    await InputField.SetTextAreaInputFieldAsync(LocationVehicle_AddressLine2_Inp, addressLine2, true, 1);
                }

                await InputField.SetTextAreaInputFieldAsync(LocationVehicle_City_Inp, _fileReader.GetValue(filePath, $"{profileKey}.LocationVehicleCity"), true, 1);
                await InputField.SetTextAreaInputFieldAsync(LocationVehicle_State_Inp, _fileReader.GetValue(filePath, $"{profileKey}.LocationVehicleState"), true, 1);
                await InputField.SetTextAreaInputFieldAsync(LocationVehicle_Zip_Inp, _fileReader.GetValue(filePath, $"{profileKey}.LocationVehicleZip"), true, 1);
                await InputField.SetTextAreaInputFieldAsync(LocationVehicle_ContactPerson_Inp, _fileReader.GetValue(filePath, $"{profileKey}.LocationVehicleContactPerson"), true, 1);
                await InputField.SetTextAreaInputFieldAsync(LocationVehicle_ContactPhone_Inp, _fileReader.GetValue(filePath, $"{profileKey}.LocationVehicleContactPhone"), true, 1);
               
            }

            // Other vehicles involved
            var vehicleInvolvedYesOrNo = _fileReader.GetValue(filePath, $"{profileKey}.OtherVehicleInvolvedYesorNo");
            var vehicleInvolvedRadio = string.Format(OtherVehicleInvolved_Radio, vehicleInvolvedYesOrNo);
            await RadioButton.SelectRadioButtonAsync(vehicleInvolvedRadio, OtherVehicleInvolved_Radio, true, 1);

            if (vehicleInvolvedYesOrNo.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                var vehicleCount = int.Parse(_fileReader.GetValue(filePath, $"{profileKey}.NumberofVehicleinvolved"));
                for (var i = 1; i <= vehicleCount; i++)
                {
                    await InputField.SetTextAreaInputFieldAsync(Vehicleinvolved_Year_Inp, _fileReader.GetValue(filePath, $"{profileKey}.AutoClaim_Vehicleinvolved{i}Year"), true, i);
                    await InputField.SetTextAreaInputFieldAsync(Vehicleinvolved_Make_Inp, _fileReader.GetValue(filePath, $"{profileKey}.AutoClaim_Vehicleinvolved{i}Make"), true, i);
                    await InputField.SetTextAreaInputFieldAsync(Vehicleinvolved_Model_Inp, _fileReader.GetValue(filePath, $"{profileKey}.AutoClaim_Vehicleinvolved{i}Model"), true, i);
                    await InputField.SetTextAreaInputFieldAsync(Vehicleinvolved_InsuranceCarrier_Inp, _fileReader.GetValue(filePath, $"{profileKey}.AutoClaim_Vehicleinvolved{i}InsuranceCarrier"), true, i);
                    await InputField.SetTextAreaInputFieldAsync(Vehicleinvolved_OwnerName_Inp, _fileReader.GetValue(filePath, $"{profileKey}.AutoClaim_Vehicleinvolved{i}OwnerName"), true, i);
                    await InputField.SetTextAreaInputFieldAsync(Vehicleinvolved_OwnerAddress_Inp, _fileReader.GetValue(filePath, $"{profileKey}.AutoClaim_Vehicleinvolved{i}OwnerAddress"), true, i);
                    await InputField.SetTextAreaInputFieldAsync(Vehicleinvolved_Driver_Inp, _fileReader.GetValue(filePath, $"{profileKey}.AutoClaim_Vehicleinvolved{i}Driver"), true, i);
                    await InputField.SetTextAreaInputFieldAsync(Vehicleinvolved_ContactEmail_Inp, _fileReader.GetValue(filePath, $"{profileKey}.AutoClaim_Vehicleinvolved{i}ContactEmail"), true, i);
                    await InputField.SetTextAreaInputFieldAsync(Vehicleinvolved_ContactPhone_Inp, _fileReader.GetValue(filePath, $"{profileKey}.AutoClaim_Vehicleinvolved{i}ContactPhone"), true, i);
                    await TextArea.SetTextAreaFieldAsync(Vehicleinvolved_DescribeVehicleDamage_Inp, _fileReader.GetValue(filePath, $"{profileKey}.AutoClaim_Vehicleinvolved{i}DescribeVehicleDamage"), true, i);

                    if (vehicleCount > 1 && i < vehicleCount)
                    {
                        await Button.ClickButtonAsync(AddAnotherVehicle_Btn, PageElements.ActionType.Click, true, 1);
                    }
                }
            }

            var anyInsuredYesOrNo = _fileReader.GetValue(filePath, $"{profileKey}.AnyInjuryYesorNo");
            var anyInjuryYesorNoRadio = string.Format(AnyInjury_Radio, anyInsuredYesOrNo);
            await RadioButton.SelectRadioButtonAsync(anyInjuryYesorNoRadio, AnyInjury_Radio, true, 1);

            if (_fileReader.GetValue(filePath, $"{profileKey}.AnyInjuryYesorNo").Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                var injuryCount = int.Parse(_fileReader.GetValue(filePath, $"{profileKey}.NumberofInjuries"));
                for (var j = 1; j <= injuryCount; j++)
                {
                    await InputField.SetTextAreaInputFieldAsync(Injury_Name_Inp, _fileReader.GetValue(filePath, $"{profileKey}.AutoClaim_Injury{j}Name"), true, j);
                    await InputField.SetTextAreaInputFieldAsync(Injury_Address_Inp, _fileReader.GetValue(filePath, $"{profileKey}.AutoClaim_Injury{j}Address"), true, j);
                    await InputField.SetTextAreaInputFieldAsync(Injury_ContactEmail_Inp, _fileReader.GetValue(filePath, $"{profileKey}.AutoClaim_Injury{j}ContactEmail"), true, j);
                    await InputField.SetTextAreaInputFieldAsync(Injury_ContactPhone_Inp, _fileReader.GetValue(filePath, $"{profileKey}.AutoClaim_Injury{j}ContactPhone"), true, j);
                    await InputField.SetTextAreaInputFieldAsync(Injury_Age_Inp, _fileReader.GetValue(filePath, $"{profileKey}.AutoClaim_Injury{j}Age"), true, j);
                    await TextArea.SetTextAreaFieldAsync(Injury_DescribeExtentofInjury_Inp, _fileReader.GetValue(filePath, $"{profileKey}.AutoClaim_Injury{j}DescribeExtentofInjury"), true, j);
                    //await InputField.SetTextAreaInputFieldAsync(Injury_Type_Radio, _fileReader.GetValue(filePath, $"{profileKey}.AutoClaim_Injury{j}Type"), true, j);
                    var injuryTypeValue = _fileReader.GetValue(filePath, $"{profileKey}.AutoClaim_Injury{j}Type");
                    var injuryTypeRadio = string.Format(Injury_Type_Radio, injuryTypeValue);
                    await RadioButton.SelectRadioButtonAsync(injuryTypeRadio, Injury_Type_Radio, true, j);

                    if (injuryCount > 1 && j < injuryCount)
                    {
                        await Button.ClickButtonAsync(AddAnotherInjury_Btn, PageElements.ActionType.Click, true, 1);
                    }
                }
            }
        }
        public async Task HomeClaimInformationAsync(string profileKey)
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter.");
            }

            try
            {
                var filePath = "HomeOwnerClaimReport\\HomeOwnerClaimReport.json";
                var accidentTime = _fileReader.GetOptionalValue(filePath, $"{profileKey}.AccidentTime");
                var accidentTimeAMorPM = _fileReader.GetOptionalValue(filePath, $"{profileKey}.AccidentTimeAMorPM");
                var lossLocation = _fileReader.GetOptionalValue(filePath, $"{profileKey}.LossLocation");
                var lossLocationAddress = _fileReader.GetOptionalValue(filePath, $"{profileKey}.LossLocationAddress");
                var describeAccident = _fileReader.GetOptionalValue(filePath, $"{profileKey}.DecribeAccident");
                var estimateRepairYesOrNo = _fileReader.GetOptionalValue(filePath, $"{profileKey}.EstimateRepairYesorNo");
                var damageAmountYesOrNoOrDontKnow = _fileReader.GetOptionalValue(filePath, $"{profileKey}.DamageAmountYesorNoorDontKnow");

                logger.WriteLine($"Starting Home Claim Information for profile: {profileKey}");
                await page.WaitForLoadStateAsync(LoadState.NetworkIdle, new PageWaitForLoadStateOptions
                {
                    Timeout = 30000
                });
                await InputField.SetTextAreaInputFieldAsync(HomeOwner_AccidentTime_Inp, accidentTime, true, 1, "AccidentTime");
                if (!string.IsNullOrEmpty(accidentTimeAMorPM))
                {
                    await DropDown.SelectDropDownAsync(HomeOwner_AccidentTime_AMorPM_Drp, accidentTimeAMorPM, true, 1, "AccidentTimeAMorPM");
                }

                await DropDown.SelectDropDownAsync(HomeOwner_LossLocation_Drp, lossLocation, true, 1, "LossLocation");
                if (lossLocation.Equals("Other", StringComparison.OrdinalIgnoreCase))
                {
                    await InputField.SetTextAreaInputFieldAsync(HomeOwner_LossLocation_Inp, lossLocationAddress, true, 1, "LossLocationAddress");
                }

                await TextArea.SetTextAreaFieldAsync(HomeOwner_DescribeDamage_Inp, describeAccident, true, 1, "DescribeAccident");
                var estimateRepairRadio = string.Format(HomeOwner_EstimateRepair_Radio, estimateRepairYesOrNo);
                await RadioButton.SelectRadioButtonAsync(estimateRepairRadio, HomeOwner_EstimateRepair_Radio, true, 1);

                var damageAmountRadio = string.Format(DamageAmount_Radio, damageAmountYesOrNoOrDontKnow);
                await RadioButton.SelectRadioButtonAsync(damageAmountRadio, DamageAmount_Radio, true, 1);
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error in HomeClaimInformationAsync: {ex.Message}");
                throw;
            }
        }
        public async Task ClaimSubmitAsync()
        {
            await page.Locator(Submit_Btn).ClickAsync();
            await Task.Delay(3000);
            await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await page.EvaluateAsync("window.scrollTo(0, 0);");
            await page.SetViewportSizeAsync(1920, 1080);
            var claimNumber = await page.Locator(ClaimNumber_Text).InnerTextAsync();

            if (!string.IsNullOrEmpty(claimNumber))
            {
                Console.WriteLine($"Claim Number is {claimNumber}");
            }
            else
            {
                throw new Exception("Unable to process your request due to some error");
            }
        }
    }
}

