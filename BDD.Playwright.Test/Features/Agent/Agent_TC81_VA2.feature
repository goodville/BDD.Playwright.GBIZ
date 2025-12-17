Feature: Agent_TC81_VA2

Scenario Outline: Agent_TC81_VA2
	Given User logs into GBIZ
	When User Click on Agents or Members
	When user click quoting Link and Verify online quoting Text is Displayed
	When User select new Quote
	When user Select 'DwellingFire' Option 
	Then verify I have Informed Insured checkbox present
	Then verify Continue Button present
	When user select 'I have Informed insured' Checkbox & Click Continue button
	Then Verify 'Dwelling fire' text Present
    When User fills mandatory field in applicant page and click continue button from json "Agent_TC81_VA2"
	And User fills mandatory field in coverages page and click continue button from json "Agent_TC81_VA2"
	And User fills mandatory field in dwelling page and click continue button from json "Agent_TC81_VA2"
	When user Click 'continue' on Summary Button
    Then verify 'Applicant information' Displayed on summary page
	Then verify 'Limits of insurance' Information displayed on summary page
	Then verify 'Total premium Amount' Displayed on summary page
    When User Click on Continue to Additional Interest button and click the Mortgageebutton
    And User fills the mandatory field in the Additional information Mortgageepage from json "Agent_TC81_VA2"
	And User fills the mandatory field in the Billing page and Verify the 6Paypayment plans are displayed
	And User fills the mandatory field in the Binding page and click Bind Policybutton from json "Agent_TC81_VA2"
	Then Verify Policy Number is generated For the DwellingFire

	#When User clicks on the Logout