Feature: Public_TC12

A short summary of the feature

@tag1
Scenario: Public_TC12
	Given User logs into GBIZ
	When Verifying the Home Page Title
	When User clicks on report a claim in current policy holders section on home page
	When User enters policy details in policy lookup section from "ReportAclaimTC12"
	When User clicks on submit
	And User verifies report a claim form page and policy information section is loaded from "policyInfoTC12"

