Feature: Agent_TC81_DE2

Scenario Outline: Agent_TC81_DE2
	Given User logs into GBIZ
	When User Click on Agents or Members
	When User Click on Quoting link and verify Online Quoting text is displayed
	When User select the new quote
	When User select DwellingFire Option 
	Then verify 'I have informed insured' checkbox is present
	Then verify continue button is present
	When User selects 'I have informed insured' checkbox and click continue button
	Then verify 'Dwelling Fire' text is present
	When User fills mandatory field in applicant page and click continue button from json "Agent_TC81_DE2"
	And User fills mandatory field in coverages page and click continue button from json "Agent_TC81_DE2"
	And User fills mandatory field in dwelling page and click continue button from json "Agent_TC81_DE2"
	When User Click Continue to Summary button
    Then Verify Applicant information displayed on the Summarypage
	Then Verify Limits of Insurance information displayed on the Summarypage
	Then Verify Total premium amount displayed on the Summarypage
   When User Click on Continue to Additional Interest button and click the Mortgageebutton
	And User fills the mandatory field in the Additional information Mortgageepage from json "Agent_TC81_DE2"
	And User fills the mandatory field in the Billing page and Verify the 6Paypayment plans are displayed
	And User fills the mandatory field in the Binding page and click Bind Policybutton from json "Agent_TC81_DE2"
	Then Verify Policy Number is generated for the DwellingFire

	#When User clicks on the Logout