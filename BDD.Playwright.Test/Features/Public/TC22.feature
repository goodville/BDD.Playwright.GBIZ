Feature: Public_TC22

@Public_TC22
Scenario: Public_TC22
	Given User logs into GBIZ
	When Verifying the Home Page Title
	When User clicks on report a claim in current policy holders section on home page
	And User enters policy details in policy lookup section from "ReportAclaimTC22"
	When User clicks on submit
	And User verifies report a claim form page and policy information section is loaded from "policyInfoTC22"
	And User enters mandatory all fields for auto claim report from "AutoClaimReportTC22"
	And User enters mandatory fields for Homeowner claim report from "HomeOwnerClaimReportTC22"
	When User Submits the Homeowner Claim Report