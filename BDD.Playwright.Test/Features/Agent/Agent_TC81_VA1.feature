Feature: Agent_TC81_VA1

Scenario Outline: Agent_TC81_VA1
	Given User logs into GBIZ
	When User Click on Agents or Members
	When user click quoting Link & Verify online quoting Text is Displayed
	When User select new quote
	When user Select DwellingFire Option 
	Then verify 'I have Informed Insured' checkbox is present
	Then Verify Continue button Present
	When user select I have Informed insured Checkbox & Click Continue button
	Then Verify 'Dwelling Fire' text present
   When User fills mandatory field in applicant page and click continue button from json "Agent_TC81_VA1"
	And User fills mandatory field in coverages page and click continue button from json "Agent_TC81_VA1"
	And User fills mandatory field in dwelling page and click continue button from json "Agent_TC81_VA1"
	When user Click 'continue' on summary Button
    Then Verify 'Applicant information' Displayed on summary page
	Then Verify 'Limits of insurance' Information displayed on summary page
	Then Verify 'Total premium Amount' Displayed on summary page
 When User Click on Continue to Additional Interest button and click the Mortgageebutton
    And User fills the mandatory field in the Additional information Mortgageepage from json "Agent_TC81_VA1"
	And User fills the mandatory field in the Billing page and Verify the 6Paypayment plans are displayed
	And User fills the mandatory field in the Binding page and click Bind Policybutton from json "Agent_TC81_VA1"
	Then Verify Policy Number is generated For the DwellingFire
	#Then Verify Policy Number is generated for the DwellingFire

	#When User clicks on the Logout