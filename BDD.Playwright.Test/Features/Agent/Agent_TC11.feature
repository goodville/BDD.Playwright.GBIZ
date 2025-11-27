Feature: Agent_TC11

A short summary of the feature

@tag1
Scenario: Agent_TC11
	Given User logs into GBIZ
	When User Click on Agents or Members using json
	And User navigates to search page
	And User performs a search
	And User navigates to policy details page
	And User navigates to policy details billing page
	And User navigates to recurringEFT page and adds a policy wallet with account details
	And User clicks on submit
	And User clicks on close
	Then User verifies that policy wallet is added "xxxx-xxxx-7890"
	And User removes the policy wallet
	And User verifies that policy wallet is removed
