Feature: Agent_TC81_PA1

Scenario Outline: Agent_TC81_PA1
	Given User logs into GBIZ
	When User Click on Agents or Members
	When user click quoting Link & verify online quoting text is displayed
	When user Selects new quote
	When user Select the DwellingFire Option 
	Then Verify 'I have Informed insured' Checkbox is Present
	Then verify continue button Present
	When user select 'I have Informed Insured' Checkbox and Click Continue button
	Then Verify 'Dwelling Fire' text present
   When User fills mandatory field in applicant page and click continue button from json "Agent_TC81_PA1"
	And User fills mandatory field in coverages page and click continue button from json "Agent_TC81_PA1"
	And User fills mandatory field in dwelling page and click continue button from json "Agent_TC81_PA1"
	When user click 'continue' summary Button
    Then Verify 'Applicant Information' displayed on the summary page
	Then Verify 'Limits of insurance' Information Displayed on the summary page
	Then Verify 'Total Premium amount' displayed on the summary page
  When User Click on Continue to Additional Interest button and click the Mortgageebutton
    And User fills the mandatory field in the Additional information Mortgageepage from json "Agent_TC81_PA1"
	And User fills the mandatory field in the Billing page and Verify the 6Paypayment plans are displayed
	And User fills the mandatory field in the Binding page and click Bind Policybutton from json "Agent_TC81_PA1"
	Then Verify Policy Number is generated For the DwellingFire

	#When User clicks on the Logout