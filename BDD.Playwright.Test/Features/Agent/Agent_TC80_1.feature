Feature: Agent_TC80_1

Scenario Outline: Agent_TC80_1
	Given User logs into GBIZ
	When User Click on Agents or Members
	When user opens the Quoting link and checks if Online Quoting text appears
	When user taps on the new quote tab
	When user chooses the Business cover option
	Then confirm that Business cover text appears
	When user completes the mandatory fields in the Business cover new quote page from "Agent_TC80_1"
	When user completes the mandatory fields in the Business cover location page from "Agent_TC80_1"
	When user completes the mandatory fields in the Building page and presses next from "Agent_TC80_1"
	When user completes the mandatory fields in the Business cover coverage page and presses next from "Agent_TC80_1"
	Then user checks if Applicant information is shown on the Summary page
	Then user checks if Limits of Insurance information is shown on the Summary page
	Then user checks if Total premium amount is shown on the Summary page
	When user completes the required fields on the BC Billing page
	When user completes the required fields on the BC Binding page from "Agent_TC80_1"
	Then user should see whether the policy is bound successfully
	#When User clicks on the Logout
	#When user clicks on the order prefil data button

	#Then Verify Personal Automobile text is present after prefill data
	#When user Clicks on the Logout Button