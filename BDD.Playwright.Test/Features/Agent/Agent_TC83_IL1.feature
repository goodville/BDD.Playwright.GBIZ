Feature: Agent_TC83_IL1

Scenario Outline: Agent_TC83_IL1
	Given User logs into GBIZ
	When User Click on Agents or Members
	When user Clicks on the 'Quoting link' and Verify 'Online Quoting' text is displayed
	When user selects the new Quote.
	When User select the HomeOwner
	Then verify I have Informed the Insured Checkbox is present.
	Then Verify Continue button exist.
	When User Select I have informed the insured checkbox and click Continue button.
	Then verify Homeowner text is Present.
	When User fills the mandatory field in the Homeowner Applicant Page and click continue button from json "Agent_TC83_IL1"
	And User fills the mandatory field in the Homeowner Property Page and click continue button from json "Agent_TC83_IL1"
	And User fills the mandatory field in the Homeowner Coverage Page and click continue button from json "Agent_TC83_IL1"
	And User fills the mandatory field in the Homeowner Scheduled Page and click continue button from json "Agent_TC83_IL1"
	When User Override the checkbox in Homeowner Claims Page and click Continue button.
	Then Verify Homeowner Applicant information displayed on Summary page.
	Then Verify Homeowner Limits of Insurance information displayed on Summary page.
	Then Verify Homeowner Total premium amount displayed on Summary page.
	#When User Click on Continue to billing on Additional Interest page.
	#And User fills mandatory field in the Homeowner Billing page and Verify the 6Pay Payment Plans are displayed.
	#When User fills mandatory field in the Homeowner Binding Page and Click Bind Policy Button.
	#Then Verify Policy Number is generated for the HomeOwner quote.

	#When user click on Logout Button