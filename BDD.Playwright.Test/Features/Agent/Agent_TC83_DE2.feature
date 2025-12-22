Feature: Agent_TC83_DE2

Scenario Outline: Agent_TC83_DE2
	Given User logs into GBIZ
	When User Click on Agents or Members
	When user Clicks on the Quoting Link and verify Online Quoting text is Displayed.
	When User selects the new Quote.
	When User select HomeOwner.
	Then verify I have Informed the Insured checkbox is present.
	Then Verify continue button exist.
	When User Select I have informed the insured checkbox and click continue Button.
	Then verify HomeOwner text is present.
	When User fills the mandatory field in the Homeowner Applicant Page and click continue button from json "Agent_TC83_DE2"
	And User fills the mandatory field in the Homeowner Property Page and click continue button from json "Agent_TC83_DE2"
	And User fills the mandatory field in the Homeowner Coverage Page and click continue button from json "Agent_TC83_DE2"
	And User fills the mandatory field in the Homeowner Scheduled Page and click continue button from json "Agent_TC83_DE2"
	When User Override checkbox in Homeowner Claims Page and click continue button
	When user Override the checkbox in Homeowner Claims Page and click continue button.
	Then Verify Homeowner Applicant Information displayed on Summary Page.
	Then Verify Homeowner Limits of insurance information displayed on Summary Page.
	Then Verify Homeowner Total Premium Amount displayed on Summary Page.
	When User Click on Continue to Billing on Additional Interest Page
	And User fills mandatory field in Homeowner Billing page and Verify the 6Pay Payment Plans are Displayed
	And User fills mandatory field in the Homeowner Binding Page and click Bind Policy Button from json "Agent_TC83_DE2"
	Then Verify Policy Number is generated for HomeOwner Quote

	#When user click on Logout Button