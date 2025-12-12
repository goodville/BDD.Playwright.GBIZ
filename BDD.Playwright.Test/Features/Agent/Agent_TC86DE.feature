Feature: Agent_TC86DE

A short summary of the feature

@tag1
Scenario: Agent_TC86DE
	Given User logs into GBIZ
	When User Click on Agents or Members
	When User Clicks on Quoting link and verify Online Quoting text is displayed
	When User selects the new quote
	When User clicks on Workers Comp Button
	Then Verify Workers Compensation text is present
	When User fills the mandatory field in the application info in applicant page for Workers Comp from json "Agent_TC86DE"
	When User fills the mandatory field in the underwriting info in applicant page for Workers Comp from json "Agent_TC86DE"
	When User fills the mandatory field in the locations page for Workers Comp from json "Agent_TC86DE"
	When User fills the mandatory field in the coverages page for Workers Comp from json "Agent_TC86DE"
	When User fills the mandatory field in the prior carriers page for Workers Comp from json "Agent_TC86DE"
	