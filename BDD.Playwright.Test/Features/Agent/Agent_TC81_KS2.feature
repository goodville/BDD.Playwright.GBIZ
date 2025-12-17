Feature: Agent_TC81_KS2

Scenario Outline: Agent_TC81_KS2
	Given User logs into GBIZ
	When User Click on Agents or Members
	When user Click quoting Link and verify online Quoting text is displayed
	When user select the new Quote
	When user select 'Dwelling fire' Option 
	Then verify 'I have Informed Insured' Checkbox is present
	Then Verify continue button present
	When user select I have informed Insured Checkbox & Click Continue button
	Then Verify 'Dwelling Fire' Text is present
   When User fills mandatory field in applicant page and click continue button from json "Agent_TC81_KS2"
	And User fills mandatory field in coverages page and click continue button from json "Agent_TC81_KS2"
	And User fills mandatory field in dwelling page and click continue button from json "Agent_TC81_KS2"
	When User click continue to summary Button
    Then Verify Applicant Information displayed on the Summarypage
	Then Verify Limits of insurance information displayed on the Summarypage
	Then Verify Total Premium amount displayed on the Summarypage
     When User Click on Continue to Additional Interest button and click the Mortgageebutton
    And User fills the mandatory field in the Additional information Mortgageepage from json "Agent_TC81_KS2"
	And User fills the mandatory field in the Billing page and Verify the 6Paypayment plans are displayed
	And User fills the mandatory field in the Binding page and click Bind Policybutton from json "Agent_TC81_KS2"
	Then Verify policy Number is generated for the DwellingFire

	#When User clicks on the Logout