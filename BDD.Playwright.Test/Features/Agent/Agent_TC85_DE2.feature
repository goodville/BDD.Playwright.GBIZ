Feature: Agent_TC85_DE2

Scenario Outline: Agent_TC85_DE2
    Given User logs into GBIZ
	When User Click on Agents or Members
	When User Click on the Quoting
	When User Click on New Quote and Verify the Correct Page is displayed
	When User select the Tradesman Cover Option
	When User enters required fields in the Quote Information page from json "Agent_TC85_DE2"
	When User enter the required fields in the Add Location Page from json "Agent_TC85_DE2"
	When User enter the required fields in the Add Buildings Page from json "Agent_TC85_DE2"
	When User clicks on Limits sub tab and enters the required fields from json "Agent_TC85_DE2"
	When User clicks on RatingsInfo Sub tab and enters the required fields from json "Agent_TC85_DE2"
	When User clicks on Coverages Tab and enters the required fields from json "Agent_TC85_DE2"
	When User clicks on Enhancement sub tab and enters the required fields from json "Agent_TC85_DE2"
	When User clicks on Summary Tab and Validate the Estimated Premium Value has displayed or not

	
