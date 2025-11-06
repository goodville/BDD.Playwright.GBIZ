using BDD.Playwright.Core.Interfaces;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using Reqnroll;

namespace BDD.Playwright.GBIZ.Pages.AgentPages
{
    public class NewQuote_ApplicantPage : BasePage
    {
        private readonly IReqnrollOutputHelper _ReqnrollLogger;
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;
        private readonly IFileReader _fileReader;
        //public BaseElement _baseElement;
        // Constructor
        public NewQuote_ApplicantPage(ScenarioContext scenarioContext, IFileReader fileReader) : base(scenarioContext)
        {
            _fileReader = fileReader;
            // _baseElement = new BaseElement(scenarioContext);
        }
        #region Xpath
        public string QuoteNumber_Text => "//div[@id='formHeaderLeft']";
        public string QuoteType_Drp => "//select[contains(@id,'quoteType')]";
        public string QuoteDescription_Inp => "//input[contains(@id,'quoteDescription')]";
        public string EffectiveDate_Inp => "//input[contains(@id,'effectivedate')]";
        public string QuoteRollOver_Radio => "//input[contains(@id,'rollover') and @value='{0}']";
        public string QuoteRoolOverPreviousPremium => "//input[contains(@id,'rolloverPremium')]";
        public string QuoteRollOverPreviousLimit => "//input[contains(@id,'rolloverPremiumLimit')]";
        public string BookCode_Inp => "//input[contains(@id,'bookofbusiness')]";
        public string Office_Text => "//div[contains(@id,'descriptor_applicant_officedisplay')]";
        public string Producer_Drp => "//select[contains(@id,'applicant_producer')]";
        public string NamedInsured_FirstName_Inp => "//input[contains(@id,'ni_firstName')]";
        public string NamedInsured_MiddleName_Inp => "//input[contains(@id,'ni_middleName')]";
        public string NamedInsured_LastName_Inp => "//input[contains(@id,'ni_lastName')]";
        public string NamedInsured_Suffix_Drp => "//select[contains(@id,'ni_suffix')]";
        public string NamedInsured_SSN_Inp => "//input[contains(@id,'ni_socialSecurityNumber')]";
        public string NamedInsured_DOB_Inp => "//input[contains(@id,'ni_dateOfBirthtext')]";
        public string SecondNamedInsured_FirstName_Inp => "//input[contains(@id,'ci_firstName')]";
        public string SecondNamedInsured_MiddleName_Inp => "//input[contains(@id,'ci_middleName')]";
        public string SecondNamedInsured_LastName_Inp => "//input[contains(@id,'ci_lastName')]";
        public string SecondNamedInsured_Suffix_Drp => "//select[contains(@id,'ci_suffix')]";
        public string SecondNamedInsured_SSN_Inp => "//input[contains(@id,'ci_socialSecurityNumber')]";
        public string SecondNamedInsured_DOB_Inp => "//input[contains(@id,'ci_dateOfBirthtext')]";
        public string AddOtherNamedInsured_Radio => "//input[contains(@id,'otherNamedInsureds') and @value='{0}']";
        public string AddOtherNamedInsuredReason_Inp => "//textarea[contains(@id,'otherNamedInsuredReason')]";
        public string AddressLine1_Inp => "//input[contains(@id,'sa_address1')]";
        public string AddressLine2_Inp => "//input[contains(@id,'sa_address2')]";
        public string City_Inp => "//input[contains(@id,'sa_city')]";
        public string ZipCode_Inp => "//input[contains(@id,'sa_zip')]";
        public string AlsoMailingAddress_Radio => "//input[contains(@id,'sa_isMailingAddress') and @value='{0}']";
        public string Attention_Drp => "//select[contains(@id,'ma_AttnType')]";
        public string Attention_Inp => "//input[contains(@id,'ma_AttnDetail')]";
        public string MailingAddressLine1_Inp => "//input[contains(@id,'ma_address1')]";
        public string MailingAddressLine2_Inp => "//input[contains(@id,'ma_address2')]";
        public string MailingZipCode_Inp => "//input[contains(@id,'ma_zip')]";
        public string NumberofYears_Drp => "//select[contains(@id,'pa_numberyears')]";
        public string ResidenceType_Radio => "//div[contains(text(),'{0}')]/input[contains(@id,'residenceType')]";
        public string ReplacementCost_Radio => "//input[contains(@id,'useEstimator') and @value='{0}']";
        public string TerritoryOverride_Inp => "//input[contains(@id,'territoryOverride')]";
        public string RealtionToInsured_Drp => "//select[contains(@id,'ci_relationshipToInsured')]";
        public string ManualTerritory_Inp => "//input[contains(@id,'manualTerritory')]";
        public string PolicyLimit_Drp => "//select[contains(@id,'pol_limit')]";
        public string Retention_Drp => "//select[contains(@id,'pol_retention')]";
        public string RegisterMemberPortal_Radio => "//input[contains(@id,'ni_registerPolicyholderaccount') and @value='{0}']";
        public string EmailAddress_Inp => "//input[contains(@id,'ni_email')]";
        public string Phone_Inp => "//input[contains(@id,'ni_phone')]";
        public string UsePolicyAddress_Radio => "//input[contains(@id,'ni_usePolicyAddress') and @value='{0}']";
        public string State_Drp => "//select[contains(@id,'ni_state')]";
        #endregion

    }
}
