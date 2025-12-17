Feature: Agent_TC83_KS2

Scenario Outline: Agent_TC83_KS2
	Given User logs into GBIZ
	When User Click on Agents or Members
	When user Clicks on the Quoting Link and Verify Online Quoting text is Displayed
	When user selects the new Quote
	When User select the HomeOwner
	Then verify I have Informed the Insured Checkbox is present.
	Then Verify Continue button exist.
	When User Select I have informed the insured checkbox and click Continue button.
	Then verify Homeowner text is Present
	When User fills the mandatory field in Homeowner Applicant Page and Click continue button for KS1.
	When User fills the mandatory field in Homeowner Property Page and Click continue button.
	When User fills the mandatory field in Homeowner Coverage Page and Click Continue button.
	When User fills the mandatory field in Homeowner Scheduled Page and Click continue button.
	When User Override the checkbox in Homeowner Claims Page and click Continue button.
	Then Verify Homeowner Applicant information displayed on Summary page for KS2.
	Then Verify Homeowner Limits of Insurance information displayed on Summary page for KS2.
	Then Verify Homeowner Total premium amount displayed on Summary page for KS2.

	#When user click on Logout Button