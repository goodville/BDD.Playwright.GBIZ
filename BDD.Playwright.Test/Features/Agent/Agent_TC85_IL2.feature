Feature: Agent_TC85_IL2

Scenario Outline: Agent_TC85_IL2
    Given User logs into GBIZ
	When User Click on Agents or Members
	When User Click on the Quoting
	When User Click on New Quote and Verify the Correct Page is displayed
	When User select the Tradesman Cover Option
	When User enters required fields in the Quote Information page from json "Agent_TC85_IL2"
	And User clicks on Coverages Tab and enters the required fields from json "Agent_TC85_IL2"
	And User clicks on Enhancement sub tab and enters the required fields from json "Agent_TC85_IL2"
	And User clicks on Tools Equipment sub tab and enters the required fields from json "Agent_TC85_IL2"
	When User clicks on Summary Tab and Validate the Estimated Premium Value has displayed or not
	
	
