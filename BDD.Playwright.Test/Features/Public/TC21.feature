Feature: Public_TC21

@Public_TC21
Scenario: Public_TC21
	Given User logs into GBIZ
	When Verifying the Home Page Title
	When User clicks on report a claim in current policy holders section on home page
	And User enters policy details in policy lookup section from "ReportAclaimTC21"
	When User clicks on submit
	And User verifies report a claim form page and policy information section is loaded from "policyInfoTC21"
	And User enters mandatory fields for auto claim report from "AutoClaimReportTC21"
	When User Submits the Auto Claim Report
	When User Verify the Loss Message, Policy Information, Agent Information and Goodville Mutual Information