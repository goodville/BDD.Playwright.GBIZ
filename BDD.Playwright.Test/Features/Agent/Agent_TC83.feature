Feature: Agent_TC83

Scenario Outline: Agent_TC83
	Given User logs into GBIZ
	When User Click on Agents or Members
	When user Clicks on the 'Quoting link' and Verify 'Online Quoting' text is displayed
	When user selects the new Quote
	When User select 'Homeowner' 
	Then verify I have informed the Insured checkbox is Present
	Then verify continue button Exist
	When User select I have informed the insured checkbox and click Continue Button
	Then verify Homeowner text is present
	When User fills the mandatory field in the Homeowner Applicant Page and click continue button from json "Agent_TC83"
	And User fills the mandatory field in the Homeowner Property Page and click continue button from json "Agent_TC83"
	And User fills the mandatory field in the Homeowner Coverage Page and click continue button from json "Agent_TC83"
	And User fills the mandatory field in the Homeowner Scheduled Page and click continue button from json "Agent_TC83"
	When User fills the mandatory field in the Homeowner Claims Page and click continue button
	Then Verify Homeowner Applicant information displayed on the Summary Page
	Then Verify Homeowner Limits of Insurance information displayed on the Summary Page
	Then Verify Homeowner Total premium amount displayed on the Summary Page
	When User Click on the Continue to billing on Additional Interest Page
	And User fills mandatory field in the Homeowner Billing page and Verify the 6Pay Payment plans are displayed
	And User fills mandatory field in the Homeowner Binding Page and click Bind Policy Button from json "Agent_TC83"
	Then Verify Policy Number is generated for the HomeOwner Quote

	#When user click on Logout Button