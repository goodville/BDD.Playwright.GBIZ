Feature: Agent_TC81_IL2

Scenario Outline: Agent_TC81_IL2
	Given User logs into GBIZ
	When User Click on Agents or Members
	When User Click quoting link and verify Online Quoting text is displayed
	When user select New quote
	When user select Dwellingfire option 
	Then Verify 'I have informed insured' checkbox is present
	Then Verify Continue button is Present
	When user select 'I have informed Insured' checkbox and click Continue button
	Then Verify Dwellingfire text is Present
   When User fills mandatory field in applicant page and click continue button from json "Agent_TC81_IL2"
	And User fills mandatory field in coverages page and click continue button from json "Agent_TC81_IL2"
	And User fills mandatory field in dwelling page and click continue button from json "Agent_TC81_IL2"
	When user Click Continue to summary Button
    Then verify Applicant information displayed on the SummaryPage
	Then verify Limits of Insurance information displayed on the SummaryPage
	Then verify Total premium amount displayed on the SummaryPage
    When User Click on Continue to Additional Interest button and click the Mortgageebutton
    And User fills the mandatory field in the Additional information Mortgageepage from json "Agent_TC81_IL2"
	And User fills the mandatory field in the Billing page and Verify the 6Paypayment plans are displayed
	And User fills the mandatory field in the Binding page and click Bind Policybutton from json "Agent_TC81_IL2"
	Then Verify Policy Number is Generated for the DwellingFire

	#When User clicks on the Logout