Feature: Agent_TC83_DE1

Scenario Outline: Agent_TC83_DE1
	Given User logs into GBIZ
	When User Click on Agents or Members
	When user Clicks on the Quoting Link and Verify Online Quoting text is Displayed
	When User Selects New Quote
	When user select Homeowner
	Then verify 'I have Informed the Insured' checkbox is Present
	Then Verify Continue Button Exist
	When User Select 'I have informed the insured checkbox' and click Continue Button
	Then Verify HomeOwner text is Present
	When User fills the mandatory field in the Homeowner Applicant Page and click continue button from json "Agent_TC83_DE1"
	And User fills the mandatory field in the Homeowner Property Page and click continue button from json "Agent_TC83_DE1"
	And User fills the mandatory field in the Homeowner Coverage Page and click continue button from json "Agent_TC83_DE1"
	And User fills the mandatory field in the Homeowner Scheduled Page and click continue button from json "Agent_TC83_DE1"
	When User Override checkbox in Homeowner Claims Page and click continue button
	Then Verify HomeOwner Applicant information displayed on Summary Page
	Then Verify HomeOwner Limits of Insurance information displayed on Summary Page
	Then Verify HomeOwner Total premium amount displayed on Summary Page
	When User Click on Continue to billing on Additional Interest page
	And User fills mandatory field in the Homeowner Billing page and Verify the 6Pay Payment Plans are displayed
	And User fills mandatory field in the Homeowner Binding Page and click Bind Policy Button from json "Agent_TC83_DE1"
	Then Verify Policy Number is generated for the HomeOwner quote

	#When user click on Logout Button