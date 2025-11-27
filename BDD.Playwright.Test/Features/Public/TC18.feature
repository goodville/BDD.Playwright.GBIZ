Feature: Public_TC18

@Public_TC18
Scenario: Public_TC18
	Given User logs into GBIZ
	When Verifying the Home Page Title
	When User clicks on report a claim in current policy holders section on home page
	When User enters policy details in policy lookup section from "ReportAclaimTC18"
	When User clicks on submit
	When User verifies report a claim form page and policy information section is loaded from "policyInfoTC18"
	And User enters mandatory all fields for auto claim report from "AutoClaimReportTC18"
	And User enters mandatory fields for Homeowner claim report from "HomeOwnerClaimReportTC18"
	When User Submits the Homeowner Claim Report