Feature: Agent_TC2

A short summary of the feature

@tag1
Scenario: Agent_TC2
	Given User logs into GBIZ
		When User Click on Agent page
		When User Navigates to forgot password button
		When User enter "Test_qa2@goodville.com" in emailAddress field
		And User Navigates to EmailAddress Continu Button
		When user navigates to webmail using new tab