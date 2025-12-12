Feature: Agent_TC17

A short summary of the feature

@tag1
Scenario: Agent_TC17
	Given User logs into GBIZ
	When User Click on Agents or Members
	When User navigates to Documents page
	And User Navigates to PennsylvaniaSate Drpdown
	And User enter "cov" in PAbusiness cover documents search page
	And User Click on PASearch Submit buTton
	And User verifies the displayed pennsylvania docuements for cov
	And User navigates to Delaware state dropdown
	And User Verifies the displayed Delaware docs
	And User navigates to illinois state dropdown
	And User Verifies the displayed Illinois docs
	And User navigates to Indiana state dropdown
	And User Verifies the displayed Indiana docs
	And User navigates to Kansas state dropdown
	And User Verifies the displayed KanSas docs
	And User navigates to Ohio state dropdown
	And User Verifies the displayed Ohio docs
	And User navigates to Ohio Transition state dropdown
	And User Verifies the displayed Ohio Transition docs
	And User navigates to Oklahoma state dropdown
	And User Verifies the displayed Oklahoma docs
	And User navigates to Verginia state dropdown
	And User Verifies the displayed Verginia docs
	When User clicks on Privacy Policy link and verify page title
	When User clicks on Contact us link and verify page title
	When User clicks on Terms & Conditions link and verify page title
	When User logout from Agent Account
