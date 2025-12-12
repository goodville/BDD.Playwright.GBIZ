Feature: Agent_TC16

@Agent_TC16
Scenario: Agent_TC16
	Given User logs into GBIZ
	When User Click on Agents or Members
	When User clicks on claims
	And User Clicks on Report Loss and Verify Page is Loaded or Not from "AgentTC_16"
	And User Clicks on Service and Verify Page is Loaded or Not from "AgentTC_16"
	And User Clicks on DirectPay and Verify Page is Loaded or Not from "AgentTC_16"
	#When User Clicks on YTDLoss and Verify Page is Loaded or Not
	And User Clicks on Payments and Verify Page is Loaded or Not from "AgentTC_16"
	And User Clicks on Search and Verify Page is Loaded or Not from "AgentTC_16"
	And User enter the Invalid claim number and verify the no data has known
	When User clicks on Privacy, Contact and Term condtions Links

