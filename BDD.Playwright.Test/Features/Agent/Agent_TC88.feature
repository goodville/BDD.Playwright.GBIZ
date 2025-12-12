Feature: Agent_TC88

Scenario Outline: Agent_TC88
	Given User logs into GBIZ
	When User Click on Agents or Members
	When user navigates to the Quoting panel and verifies Online Quoting text is displayed
	When user selects the New Quote tab for Business Cover
	When user chooses the Business Cover option
	Then Business Cover page is displayed with correct header
	When user enters required applicant details in Business Cover new quote page from json "Agent_TC88"
	And user enters mandatory location details for Business Cover from json "Agent_TC88"
	When user enters building information on the Building page and proceeds from json "Agent_TC88"
	When user enters coverage details on the Business Cover coverage page and proceeds from json "Agent_TC88"
	Then Applicant information is displayed on the Summary page for Business Cover
	Then Limits of Insurance are displayed on the Business Cover Summary page
	Then Total premium amount is displayed on the Business Cover Summary page
	When user completes the Billing page for Business Cover
	And user completes the Binding page for Business Cover from json "Agent_TC88"
	Then user should see whether the policy is bound successfully or not
	#When User clicks on the Logout
	#When user clicks on the order prefil data button

	#Then Verify Personal Automobile text is present after prefill data
	#When user Clicks on the Logout Button