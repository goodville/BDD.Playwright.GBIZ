Feature: Agent_TC84
 
Scenario Outline: Agent_TC84
	Given User logs into GBIZ
	When User Click on Agents or Members	
	When User clicks on the Quoting links and confirms Online Quoting is visible
	When User selects the Start New Quote tab option
	When User chooses the Personal Auto lob product option
	Then The page should display PersonalAutomobile heading
	When User completes all required fields on the Personal Auto quote initiation page from json "Agent_TC84"
	When User clicks the Order Prefill Data button
	Then The PersonalAutomobile heading should still be visible after data is prefetched
	When User enters mandatory details on the Applicant page and proceeds from json "Agent_TC84"
	And User provides required information on the Drivers page and continues from json "Agent_TC84"
	And User inputs necessary data on the Vehicles page and clicks continue from json "Agent_TC84"
	When User fills in the required fields on the PA Coverages page and proceeds
	When The PASummary page should show the Applicant's information
	Then The PASummary page should display the calculated Total Premium
	When User fill the mandatory fields in the PABilling page
	When User fill the mandatory fields in the PABinding page
	Then Verify the policy whether it is bound successfully


	


	#vehicle
	#coverage



	#Then Verify Business cover text is present
	#When user fills the mandatory field in Business cover new quote page
	#When user clicks on the order prefil data button
	#Then Verify Personal Automobile text is present after prefill data
	#When user Clicks on the Logout Button