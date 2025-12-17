Feature: Agent_TC81_PA2

Scenario Outline: Agent_TC81_PA2
	Given User logs into GBIZ
	When User Click on Agents or Members
	When user click quoting Link and Verify online quoting text is displayed
	When user select new Quote
	When user Select the 'DwellingFire' option 
	Then Verify 'I have Informed insured' checkbox is present
	Then verify continue Button present
	When user select I have Informed insured Checkbox and Click Continue button
	Then Verify Dwelling Fire text Present
   When User fills mandatory field in applicant page and click continue button from json "Agent_TC81_PA2"
	And User fills mandatory field in coverages page and click continue button from json "Agent_TC81_PA2"
	And User fills mandatory field in dwelling page and click continue button from json "Agent_TC81_PA2"
	When user Click 'continue' summary Button
    Then Verify 'Applicant information' Displayed on the summary page
	Then Verify 'Limits of insurance' Information displayed on the summary page
	Then Verify 'Total premium Amount' Displayed on the summary page
  When User Click on Continue to Additional Interest button and click the Mortgageebutton
    And User fills the mandatory field in the Additional information Mortgageepage from json "Agent_TC81_PA2"
	And User fills the mandatory field in the Billing page and Verify the 6Paypayment plans are displayed
	And User fills the mandatory field in the Binding page and click Bind Policybutton from json "Agent_TC81_PA2"
	Then Verify Policy Number is generated For the DwellingFire

	#When User clicks on the Logout