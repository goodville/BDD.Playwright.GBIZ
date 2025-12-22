Feature: Agent_TC81_IN2

Scenario Outline: Agent_TC81_IN2
	Given User logs into GBIZ
	When User Click on Agents or Members
	When User click Quoting Link and verify Online Quoting text is displayed
	When user select New Quote
	When User Select Dwelling fire Option 
	Then Verify I have informed Insured Checkbox is present
	Then Verify Continue button is present
	When User Select I have informed Insured Checkbox and Click Continue button
	Then verify DwellingFire Text is present
	When User fills mandatory field in applicant page and click continue button from json "Agent_TC81_IN2"
	And User fills mandatory field in coverages page and click continue button from json "Agent_TC81_IN2"
	And User fills mandatory field in dwelling page and click continue button from json "Agent_TC81_IN2"
	When user click continue to summary button
    Then verify Applicant Information displayed on the SummaryPage
	Then verify Limits of insurance information displayed on the SummaryPage
	Then verify Total Premium amount displayed on the SummaryPage
     When User Click on Continue to Additional Interest button and click the Mortgageebutton
    And User fills the mandatory field in the Additional information Mortgageepage from json "Agent_TC81_IN2"
	And User fills the mandatory field in the Billing page and Verify the 6Paypayment plans are displayed
	And User fills the mandatory field in the Binding page and click Bind Policybutton from json "Agent_TC81_IN2"
	Then verify Policy Number is generated for the DwellingFire

	#When User clicks on the Logout