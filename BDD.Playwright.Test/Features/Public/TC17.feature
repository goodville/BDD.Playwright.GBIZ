Feature: Public_TC17

@Public_TC17
Scenario: Public_TC17
	Given User logs into GBIZ
	When Verifying the Home Page Title
	When User clicks on report a claim in current policy holders section on home page
	When User enters policy details in policy lookup section from "ReportAclaimTC17"
	When User clicks on submit
	When User verifies report a claim form page and policy information section is loaded from "policyInfoTC17"
	And User enters mandatory all fields for auto claim report from "AutoClaimReportTC17"
	And User enters mandatory fields for Homeowner claim report from "HomeOwnerClaimReportTC17"
	When User Submits the Homeowner Claim Report