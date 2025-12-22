Feature: Agent_TC81_IN1

Scenario Outline: Agent_TC81_IN1
	Given User logs into GBIZ
	When User Click on Agents or Members
	When User click Quoting link and verify Online Quoting text is displayed
	When user select new Quote
	When user select Dwelling fire option 
	Then Verify I have informed insured Checkbox is present
	Then Verify continue Button is Present
	When user select I have informed Insured Checkbox and click Continue button
	Then Verify DwellingFire Text is present
   When User fills mandatory field in applicant page and click continue button from json "Agent_TC81_IN1"
	And User fills mandatory field in coverages page and click continue button from json "Agent_TC81_IN1"
	And User fills mandatory field in dwelling page and click continue button from json "Agent_TC81_IN1"
	When user click continue to summary Button
    Then verify applicant information displayed on the SummaryPage
	Then verify limits of Insurance information displayed on the SummaryPage
	Then verify total premium amount displayed on the SummaryPage
   When User Click on Continue to Additional Interest button and click the Mortgageebutton
    And User fills the mandatory field in the Additional information Mortgageepage from json "Agent_TC81_IN1"
	And User fills the mandatory field in the Billing page and Verify the 6Paypayment plans are displayed
	And User fills the mandatory field in the Binding page and click Bind Policybutton from json "Agent_TC81_IN1"
	Then Verify Policy number is generated for the DwellingFire

	#When User clicks on the Logout