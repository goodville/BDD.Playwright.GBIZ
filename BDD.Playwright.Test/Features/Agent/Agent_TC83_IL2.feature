Feature: Agent_TC83_IL2

Scenario Outline: Agent_TC83_IL2
	Given User logs into GBIZ
	When User Click on Agents or Members
	When user Clicks on the Quoting Link and Verify Online Quoting text is Displayed for IL2
	When user selects the new Quote for IL2
	When User select the HomeOwner for IL2
	Then verify I have Informed the Insured Checkbox is present for IL2
	Then Verify Continue button exist for IL2
	When User Select I have informed the insured checkbox and click Continue button for IL2
	Then verify Homeowner text is Present for IL2
	When User fills the mandatory field in Homeowner Applicant Page and Click continue button for IL2
	When User fills the mandatory field in Homeowner Property Page and Click continue button for IL2
	When User fills the mandatory field in Homeowner Coverage Page and Click continue button for IL2
	When User fills the mandatory field in Homeowner Scheduled Page and Click continue button for IL2
	When User Override the checkbox in Homeowner Claims Page and click Continue button for IL2
	Then Verify Homeowner Applicant information displayed on Summary page for IL2TC
	Then Verify Homeowner Limits of Insurance information displayed on Summary page for IL2TC
	Then Verify Homeowner Total premium amount displayed on Summary page for IL2TC
	#When User Click on Continue to billing on Additional Interest page for IL2
	#And User fills mandatory field in the Homeowner Billing page and Verify the 6Pay Payment Plans are displayed for IL2
	#When User fills mandatory field in the Homeowner Binding Page and Click Bind Policy Button for IL2
	#Then Verify Policy Number is generated for the HomeOwner quote for IL2

	#When user click on Logout Button