Feature: Public_TC16

A short summary of the feature

@tag1
Scenario: Public_TC16
	Given User logs into GBIZ
	When Verifying the Home Page Title
	When User clicks on report a claim in current policy holders section on home page
	And User enters policy details in policy lookup section from "ReportAclaimTC16"
	When User clicks on submit
	And User verifies report a claim form page and policy information section is loaded from "policyInfoTC16"
	And User enters mandatory fields for auto claim report from "AutoClaimReportTC16"
	When User Submits the Auto Claim Report
