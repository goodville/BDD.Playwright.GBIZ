Feature: Agent_TC33

@Agent_TC33
Scenario: Agent_TC33
	Given User logs into GBIZ
	When User Click on Agents or Members
	And User navigates to search page
	And User performs a search
	And User navigates to policy details page
	And User Clicks Documents tab and verify the Estimator History documents Opens and clicks PDF
	And User Open the PDF page and verify the Replacement Estimator Cost Results
	When User clicks on sign out	

