Feature: Agent_TC81_OK2

Scenario Outline: Agent_TC81_OK2
	Given User logs into GBIZ
	When User Click on Agents or Members
	When user click quoting Link & verify online quoting text is Displayed
	When user Select new quote
	When user Selects DwellingFire Option 
	Then verify 'I have Informed Insured' Checkbox is Present
	Then verify continue Button Present
	When user select 'I have informed Insured' Checkbox and Click Continue button
	Then Verify 'Dwelling Fire' Text present
    When User fills mandatory field in applicant page and click continue button from json "Agent_TC81_OK2"
	And User fills mandatory field in coverages page and click continue button from json "Agent_TC81_OK2"
	And User fills mandatory field in dwelling page and click continue button from json "Agent_TC81_OK2"
	When user click continue summary button
    Then Verify 'Applicant Information' Displayed on the summary page
	Then Verify 'Limits of insurance' information Displayed on the summary page
	Then Verify 'Total Premium amount' Displayed on the summary page
    When User Click on Continue to Additional Interest button and click the Mortgageebutton
    And User fills the mandatory field in the Additional information Mortgageepage from json "Agent_TC81_OK2"
	And User fills the mandatory field in the Billing page and Verify the 6Paypayment plans are displayed
	And User fills the mandatory field in the Binding page and click Bind Policybutton from json "Agent_TC81_OK2"
	Then Verify Policy Number is generated For the DwellingFire
	#When User clicks on the Logout