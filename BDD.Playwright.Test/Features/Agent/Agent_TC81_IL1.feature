Feature: Agent_TC81_IL1

Scenario Outline: Agent_TC81_IL1
	Given User logs into GBIZ
	When User Click on Agents or Members
	When User Click quoting link and verify Online quoting text is displayed
	When user select new Quote
	When user select DwellingFire option 
	Then Verify I have informed insured checkbox is Present
	Then Verify continue button is Present
	When user select 'I have informed Insured' checkbox and click continue button
	Then Verify Dwelling Fire text is Present
	When User fills mandatory field in applicant page and click continue button from json "Agent_TC81_IL1"
	And User fills mandatory field in coverages page and click continue button from json "Agent_TC81_IL1"
	And User fills mandatory field in dwelling page and click continue button from json "Agent_TC81_IL1"
	When user Click Continue to summary button
    Then verify Applicant information displayed on the summarypage
	Then verify Limits of Insurance information displayed on the summarypage
	Then verify Total premium amount displayed on the summarypage
    When User Click on Continue to Additional Interest button and click the Mortgageebutton
    And User fills the mandatory field in the Additional information Mortgageepage from json "Agent_TC81_IL1"
	And User fills the mandatory field in the Billing page and Verify the 6Paypayment plans are displayed
	And User fills the mandatory field in the Binding page and click Bind Policybutton from json "Agent_TC81_IL1"
	Then Verify Policy Number is generated For the DwellingFire

	#When User clicks on the Logout