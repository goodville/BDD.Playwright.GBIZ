Feature: Public_TC20

@Public_TC20
Scenario: Public_TC20
	Given User logs into GBIZ
	When Verifying the Home Page Title
	When User clicks on report a claim in current policy holders section on home page
	When User enters policy details in policy lookup section from "ReportAclaimTC20"
	When User clicks on submit
	And User verifies report a claim form page and policy information section is loaded from "policyInfoTC20"
	And User enters mandatory fields for auto claim report from "AutoClaimReportTC20"
	When User Submits the Auto Claim Report