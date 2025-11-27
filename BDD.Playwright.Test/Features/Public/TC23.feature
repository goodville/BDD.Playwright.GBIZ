Feature: Public_TC23

@Public_TC23
Scenario: Public_TC23
	Given User logs into GBIZ
	When Verifying the Home Page Title
	When User clicks on report a claim in current policy holders section on home page
	And User enters policy details in policy lookup section from "ReportAclaimTC23"
	When User clicks on submit
	And User verifies report a claim form page and policy information section is loaded from "policyInfoTC23"
	And User enters mandatory fields for auto claim report from "AutoClaimReportTC23"
	When User Submits the Auto Claim Report