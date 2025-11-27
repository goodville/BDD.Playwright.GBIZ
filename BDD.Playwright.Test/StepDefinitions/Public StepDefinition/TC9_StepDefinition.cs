using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD.Playwright.Test.StepDefinitions.Public_StepDefinition
{
    [Binding]
    public class TC9_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public CommonXpath _commonXpath;
        public TC9_StepDefinition(ScenarioContext scenarioContext, CommonXpath commonXpath) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _commonXpath = commonXpath;
        }

        public async Task NextPageTitleVerifyMethodAsync(string RequiredXpath, string ExpectedPageTitle)
        {
            var popup = await page.RunAndWaitForPopupAsync(async () =>
            {
                await TextLink.ClickTextLinkAsync(RequiredXpath, true, 1);
            });
            await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await page.WaitForTimeoutAsync(2000);
            var ActualPageTitle = await popup.TitleAsync();
            if (ActualPageTitle == ExpectedPageTitle)
            {
                logger.WriteLine(ExpectedPageTitle);
            }
            else
            {
                throw new Exception("About Us page Title is not Matching it is displaying " + ActualPageTitle);
            }

            await popup.CloseAsync();
            await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        }
        public async Task SamePageTitleVerifyMethodAsync(string RequiredXpath, string ExpectedPageTitle, string ReturnToPage)
        {
            await TextLink.ClickTextLinkAsync(RequiredXpath, true, 1);
            await page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
            await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await page.WaitForTimeoutAsync(2000);
            var ActualPageTitle = await page.TitleAsync();
            if (ActualPageTitle == ExpectedPageTitle)
            {
                logger.WriteLine(ExpectedPageTitle);
            }
            else
            {
                throw new Exception("About Us page Title is not Matching it is displaying " + ActualPageTitle);
            }

            if (ReturnToPage == "Back")
            {
                await page.GoBackAsync();
                logger.WriteLine("Back clicked");
            }
            else
            {
                await TextLink.ClickTextLinkAsync(ReturnToPage, true, 1);
            }

            await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        }

        [When(@"User clicks on Learn How button and verifies page title")]
        public async Task WhenUserClicksOnLearnHowButtonAndVerifiesPageTitleAsync()
        {
            await SamePageTitleVerifyMethodAsync(_commonXpath.LearnHow_Link, "Goodville Mutual Casualty Company - About Us", _commonXpath.HomePage_Link);
        }

        [When(@"User clicks on A\.M\. Best logo and verifies page title")]
        public async Task WhenUserClicksOnA_M_BestLogoAndVerifiesPageTitleAsync()
        {
            await NextPageTitleVerifyMethodAsync(_commonXpath.AMBest_Icon, "Goodville Mutual Casualty Company - Company Profile - Best's Credit Rating Center");
        }

        [When(@"User clicks on Ward's (.*) logo and verifies page title")]
        public async Task WhenUserClicksOnWardsLogoAndVerifiesPageTitleAsync(int index)
        {
            var wardLogoLocator = string.Format(_commonXpath.Ward50_Icon, index);
            await NextPageTitleVerifyMethodAsync(wardLogoLocator, "Benchmarking Solutions for Insurers | Aon");
        }

        [When(@"User clicks on Auto logo and verifies page title")]
        public async Task WhenUserClicksOnAutoLogoAndVerifiesPageTitleAsync()
        {
            await SamePageTitleVerifyMethodAsync(_commonXpath.Auto_Icon, "Goodville Mutual Casualty Company - Auto", _commonXpath.HomePage_Link);
        }

        [When(@"User clicks on Home logo and verifies page title")]
        public async Task WhenUserClicksOnHomeLogoAndVerifiesPageTitleAsync()
        {
            await SamePageTitleVerifyMethodAsync(_commonXpath.Home_Icon, "Goodville Mutual Casualty Company - Homeowners", _commonXpath.HomePage_Link);
        }

        [When(@"User clicks on Business logo and verifies page title")]
        public async Task WhenUserClicksOnBusinessLogoAndVerifiesPageTitleAsync()
        {
            await SamePageTitleVerifyMethodAsync(_commonXpath.Business_Icon, "Goodville Mutual Casualty Company - Business", _commonXpath.HomePage_Link);
        }

        [When(@"User clicks on Church logo and verifies page title")]
        public async Task WhenUserClicksOnChurchLogoAndVerifiesPageTitleAsync()
        {
            await SamePageTitleVerifyMethodAsync(_commonXpath.Church_Icon, "Goodville Mutual Casualty Company - Church", _commonXpath.HomePage_Link);
        }

        [When(@"User clicks on Umbrella logo and verifies page title")]
        public async Task WhenUserClicksOnUmbrellaLogoAndVerifiesPageTitleAsync()
        {
            await SamePageTitleVerifyMethodAsync(_commonXpath.Umbrella_Icon, "Goodville Mutual Casualty Company - Umbrella", _commonXpath.HomePage_Link);
        }

        [When(@"User clicks on Farm logo and verifies page title")]
        public async Task WhenUserClicksOnFarmLogoAndVerifiesPageTitleAsync()
        {
            await SamePageTitleVerifyMethodAsync(_commonXpath.Farm_Icon, "Goodville Mutual Casualty Company - Farm", _commonXpath.HomePage_Link);
        }

        [When(@"User clicks on Make a Payment link and verifies page title")]
        public async Task WhenUserClicksOnMakeAPaymentLinkAndVerifiesPageTitleAsync()
        {
            await SamePageTitleVerifyMethodAsync(_commonXpath.PolicyHolderMakeaPayment_Link, "Goodville Mutual Casualty Company - Make A Payment", _commonXpath.HomePage_Link);
        }

        [When(@"User clicks on Change Payment Plan link and verifies page title")]
        public async Task WhenUserClicksOnChangePaymentPlanLinkAndVerifiesPageTitleAsync()
        {
            await SamePageTitleVerifyMethodAsync(_commonXpath.PolicyHolderChangePaymentPlan_Link, "Goodville Mutual Casualty Company - Make A Payment", _commonXpath.HomePage_Link);
        }

        [When(@"User clicks on Report a Claim link and verifies page title")]
        public async Task WhenUserClicksOnReportAClaimLinkAndVerifiesPageTitleAsync()
        {
            await SamePageTitleVerifyMethodAsync(_commonXpath.ReportaClaim_Link, "Goodville Mutual Casualty Company - Report A Claim", _commonXpath.HomePage_Link);
        }

        [When(@"User clicks on Policy Information link and verifies page title")]
        public async Task WhenUserClicksOnPolicyInformationLinkAndVerifiesPageTitleAsync()
        {
            await SamePageTitleVerifyMethodAsync(_commonXpath.PolicyHolderPolicyInformation_Link, "Goodville Mutual - Policyholders", _commonXpath.HomePage_Link);
        }

        [When(@"User clicks on Get an ID Card link and verifies page title")]
        public async Task WhenUserClicksOnGetAnIDCardLinkAndVerifiesPageTitleAsync()
        {
            await SamePageTitleVerifyMethodAsync(_commonXpath.PolicyHolderGetanIDCard_Link, "Goodville Mutual Casualty Company", _commonXpath.HomePage_Link);
        }

        [When(@"User clicks on Find an Agent link and verifies page title")]
        public async Task WhenUserClicksOnFindAnAgentLinkAndVerifiesPageTitleAsync()
        {
            await SamePageTitleVerifyMethodAsync(_commonXpath.NewGMFindanAgent_Link, "Goodville Mutual Casualty Company - Find An Agent", _commonXpath.HomePage_Link);
        }

        [When(@"User clicks on Why do I Need an Agent link and verifies page title")]
        public async Task WhenUserClicksOnWhyDoINeedAnAgentLinkAndVerifiesPageTitleAsync()
        {
           await SamePageTitleVerifyMethodAsync(_commonXpath.NewGMWhyDoINeedanAgent_Link, "Goodville Mutual Casualty Company - Find An Agent", _commonXpath.HomePage_Link);
        }

        [When(@"User clicks on About Goodville link and verifies page title")]
        public async Task WhenUserClicksOnAboutGoodvilleLinkAndVerifiesPageTitleAsync()
        {
            await SamePageTitleVerifyMethodAsync(_commonXpath.NewGMAboutGoodVille_Link, "Goodville Mutual Casualty Company - About Us", _commonXpath.HomePage_Link);
        }

        [When(@"User clicks on See What Others Have to Say and verifies page title")]
        public async Task WhenUserClicksOnSeeWhatOthersHaveToSayAndVerifiesPageTitleAsync()
        {
           await SamePageTitleVerifyMethodAsync(_commonXpath.SeeWhatOthersHaveToSay_Link, "Goodville Mutual Casualty Company - Policyholder Quotes", _commonXpath.HomePage_Link);
        }

        [When(@"User clicks on View More Safety Tips link and verifies page title")]
        public async Task WhenUserClicksOnViewMoreSafetyTipsLinkAndVerifiesPageTitleAsync()
        {
            await SamePageTitleVerifyMethodAsync(_commonXpath.ViewMoreSafetyTips_Link, "Goodville Mutual Casualty Company - Safety Tips", _commonXpath.HomePage_Link);
        }

        [When(@"User clicks on Visit Us on Facebook link and verifies page title")]
        public async Task WhenUserClicksOnVisitUsOnFacebookLinkAndVerifiesPageTitleAsync()
        {
            await SamePageTitleVerifyMethodAsync(_commonXpath.VisitUsOnFacebook_Link, "Goodville Mutual Casualty Company | New Holland PA | Facebook", "Back");
        }

        [When(@"User clicks on Secure Email link and verifies page title")]
        public async Task WhenUserClicksOnSecureEmailLinkAndVerifiesPageTitleAsync()
        {
           await NextPageTitleVerifyMethodAsync(_commonXpath.SendSecureEmail_Link, "Encrypted Email Login");
        }

        [When(@"User clicks on Agent Secure Email link and verifies page title")]
        public async Task WhenUserClicksOnAgentSecureEmailLinkAndVerifiesPageTitleAsync()
        {
            await NextPageTitleVerifyMethodAsync(_commonXpath.AgentSendSecureEmail_Link, "Encrypted Email Login");
        }

        [When(@"User clicks on Contact Us link and verifies page title")]
        public async Task WhenUserClicksOnContactUsLinkAndVerifiesPageTitleAsync()
        {
            await SamePageTitleVerifyMethodAsync(_commonXpath.TalkWithUsContactUs_Link, "Goodville Mutual Casualty Company - Contact Us", _commonXpath.HomePage_Link);
        }

        [When(@"User clicks on Auto link and verifies page title")]
        public async Task WhenUserClicksOnAutoLinkAndVerifiesPageTitleAsync()
        {
            await SamePageTitleVerifyMethodAsync(_commonXpath.FooterAuto_Link, "Goodville Mutual Casualty Company - Auto", _commonXpath.HomePage_Link);
        }

        [When(@"User clicks on Home link and verifies page title")]
        public async Task WhenUserClicksOnHomeLinkAndVerifiesPageTitleAsync()
        {
            await SamePageTitleVerifyMethodAsync(_commonXpath.FooterHome_Link, "Goodville Mutual Casualty Company - Homeowners", _commonXpath.HomePage_Link);
        }

        [When(@"User clicks on Business link and verifies page title")]
        public async Task WhenUserClicksOnBusinessLinkAndVerifiesPageTitleAsync()
        {
            await SamePageTitleVerifyMethodAsync(_commonXpath.FooterBusiness_Link, "Goodville Mutual Casualty Company - Business", _commonXpath.HomePage_Link);
        }

        [When(@"User clicks on Church link and verifies page title")]
        public async Task WhenUserClicksOnChurchLinkAndVerifiesPageTitleAsync()
        {
            await SamePageTitleVerifyMethodAsync(_commonXpath.FooterChurch_Link, "Goodville Mutual Casualty Company - Church", _commonXpath.HomePage_Link);
        }

        [When(@"User clicks on Umbrella link and verifies page title")]
        public async Task WhenUserClicksOnUmbrellaLinkAndVerifiesPageTitleAsync()
        {
            //SamePageTitleVerifyMethodAsync(_commonXpath.FooterFarm_Link, "Goodville Mutual Casualty Company - Farm", _commonXpath.HomePage_Link);
            await SamePageTitleVerifyMethodAsync(_commonXpath.FooterUmbrella_Link, "Goodville Mutual Casualty Company - Umbrella", _commonXpath.HomePage_Link);
        }

        [When(@"User clicks on About Us link and verifies page title")]
        public async Task WhenUserClicksOnAboutUsLinkAndVerifiesPageTitleAsync()
        {
            await SamePageTitleVerifyMethodAsync(_commonXpath.FooterAboutUs_Link, "Goodville Mutual Casualty Company - About Us", _commonXpath.HomePage_Link);
        }

        [When(@"User clicks on Careers link and verifies page title")]
        public async Task WhenUserClicksOnCareersLinkAndVerifiesPageTitleAsync()
        {
            await SamePageTitleVerifyMethodAsync(_commonXpath.FooterCareers_Link, "Goodville Mutual Casualty Company - Careers", _commonXpath.HomePage_Link);
        }

        [When(@"User clicks on Safety Tips link and verifies page title")]
        public async Task WhenUserClicksOnSafetyTipsLinkAndVerifiesPageTitleAsync()
        {
            await SamePageTitleVerifyMethodAsync(_commonXpath.FooterSafetyTips_Link, "Goodville Mutual Casualty Company - Safety Tips", _commonXpath.HomePage_Link);
        }

        [When(@"User clicks on Terms & Conditions link and verifies page title")]
        public async Task WhenUserClicksOnTermsConditionsLinkAndVerifiesPageTitleAsync()
        {
            await SamePageTitleVerifyMethodAsync(_commonXpath.FooterTermsConditions_Link, "Goodville Mutual Casualty Company - Terms & Conditions", _commonXpath.HomePage_Link);
        }

        [When(@"User clicks on Privacy Policy link and verifies page title")]
        public async Task WhenUserClicksOnPrivacyPolicyLinkAndVerifiesPageTitleAsync()
        {
            await SamePageTitleVerifyMethodAsync(_commonXpath.FooterPrivacyPolicy_Link, "Goodville Mutual Casualty Company - Privacy Policy", _commonXpath.HomePage_Link);
        }

        [When(@"User clicks on Feedback link and verifies page title")]
        public async Task WhenUserClicksOnFeedbackLinkAndVerifiesPageTitleAsync()
        {
            await SamePageTitleVerifyMethodAsync(_commonXpath.FooterFeedback_Link, "Goodville Mutual Casualty Company - Contact Us", _commonXpath.HomePage_Link);
            /*SamePageTitleVerifyMethodAsync(_commonXpath.FooterTransparencyCompliance_Link, "Goodville Mutual Casualty Company - Transparency & Compliance", _commonXpath.HomePage_Link);
            SamePageTitleVerifyMethodAsync(_commonXpath.FooterFindAnAgent_Link, "Goodville Mutual Casualty Company - Find an Agent", _commonXpath.HomePage_Link);
            SamePageTitleVerifyMethodAsync(_commonXpath.FooterMakeAPayment_Link, "Goodville Mutual Casualty Company - Make a Payment", _commonXpath.HomePage_Link);
            SamePageTitleVerifyMethodAsync(_commonXpath.FooterReportAClaim_Link, "Goodville Mutual Casualty Company - Report a Claim", _commonXpath.HomePage_Link);*/
        }

        [When(@"User clicks on Facebook logo and verifies page title")]
        public async Task WhenUserClicksOnFacebookLogoAndVerifiesPageTitleAsync()
        {
            await SamePageTitleVerifyMethodAsync(_commonXpath.FooterFacebook_Link, "Goodville Mutual Casualty Company | New Holland PA | Facebook", "Back");
        }

        [When(@"User clicks on LinkedIn logo and verifies page title")]
        public async Task WhenUserClicksOnLinkedInLogoAndVerifiesPageTitleAsync()
        {
            await SamePageTitleVerifyMethodAsync(_commonXpath.FooterLinkedin_Link, "Sign Up | LinkedIn", "Back");
        }

        [When(@"User clicks on Download Mobile App link and verifies page title")]
        public async Task WhenUserClicksOnDownloadMobileAppLinkAndVerifiesPageTitleAsync()
        {
            await SamePageTitleVerifyMethodAsync(_commonXpath.FooterMobileApp_Link, "Goodville Mutual - Policyholders", _commonXpath.HomePage_Link);
        }

        [When(@"User clicks on footer A\.M\. Best logo and verifies page title")]
        public async Task WhenUserClicksOnFooterA_M_BestLogoAndVerifiesPageTitleAsync()
        {
            await SamePageTitleVerifyMethodAsync(_commonXpath.FooterAMBest_Link, "Goodville Mutual Casualty Company - Company Profile - Best's Credit Rating Center", _commonXpath.HomePage_Link);
        }

        [When(@"User clicks on Best Places to Work logo and verifies page title")]
        public async Task WhenUserClicksOnBestPlacesToWorkLogoAndVerifiesPageTitleAsync()
        {
            //await NextPageTitleVerifyMethodAsyncd(_commonXpath.Ward50_Icon, "Benchmarking Solutions for Insurers | Aon");
        }

        [When(@"User verifies Locations section is displayed in the footer")]
        public async Task WhenUserVerifiesLocationsSectionIsDisplayedInTheFooterAsync()
        {
            await Label.VerifyTextAsync("//h2[text()='LOCATIONS']", "LOCATIONS", true, 1);
            await Label.VerifyTextAsync("//address[@class='officeLocations']", "Headquarters\r\nNew Holland, PA\r\nGreat Lakes Branch Office\r\nNapoleon, OH", true, 1);
        }

        [When(@"User verifies Contact Us section is displayed in the footer")]
        public async Task WhenUserVerifiesContactUsSectionIsDisplayedInTheFooterAsync()
        {
            await Label.VerifyTextAsync("//h2[text()='CONTACT US']", "CONTACT US", true, 1);
            await Label.VerifyTextAsync("//div[text()=' Mon - Fri 8am to 4:30pm ET ']", "Mon - Fri 8am to 4:30pm ET", true, 1);
            await Label.VerifyTextAsync("//div[@class='phoneFax']", "Phone (717) 354-4921\r\nToll Free (800) 448-4622\r\nFax (717) 354-5158", true, 1);
        }

        [When(@"User verifies Claims section is displayed in the footer")]
        public async Task WhenUserVerifiesClaimsSectionIsDisplayedInTheFooterAsync()
        {
            await Label.VerifyTextAsync("//div[@class='oneThird claimsSection']", "FOR ALL CLAIMS\r\n(877) 445-5780", true, 1);
        }
    }
}
