Feature: Agent_TC81_OH2

Scenario Outline: Agent_TC81_OH2
	Given User logs into GBIZ
	When User Click on Agents or Members
	When user click quoting link and verify online quoting text is Displayed
	When User Select New quote
	When user select Dwelling Fire option 
	Then verify I have Informed Insured checkbox is Present
	Then Verify Continue Button Present
	When user select I have informed Insured Checkbox & Click Continue button
	Then Verify 'Dwelling Fire' Text is present
   When User fills mandatory field in applicant page and click continue button from json "Agent_TC81_OH2"
	And User fills mandatory field in coverages page and click continue button from json "Agent_TC81_OH2"
	And User fills mandatory field in dwelling page and click continue button from json "Agent_TC81_OH2"
	When User click continue summary button
    Then Verify Applicant Information Displayed on the summarypage
	Then Verify Limits of insurance information Displayed on the summarypage
	Then Verify Total Premium amount Displayed on the summarypage
  When User Click on Continue to Additional Interest button and click the Mortgageebutton
    And User fills the mandatory field in the Additional information Mortgageepage from json "Agent_TC81_OH2"
	And User fills the mandatory field in the Billing page and Verify the 6Paypayment plans are displayed
	And User fills the mandatory field in the Binding page and click Bind Policybutton from json "Agent_TC81_OH2"
	Then Verify Policy Number is generated For the Dwelling Fire

	#When User clicks on the Logout