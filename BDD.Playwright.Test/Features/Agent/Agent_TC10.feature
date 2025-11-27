Feature: Agent_TC10

@Agent_TC10
Scenario: Agent_TC10
	Given User logs into GBIZ
	When User Click on Agents or Members
	When User navigates to accounting page
	And User navigates to makepayment page
	And User enters mandatory fields for make payment from "Agent_TC10"
	When User click on submit Button
	And User has to select payment method as EFT One Time
	When User clicks on Continue button	
	When User clicks on Review button
	And User enters Account and Routing details from "Agent_TC10"
	When User clicks on EFTsavings button
	When User clicks on EFT Review button
	When User clicks on Pay button
	When User verifies confirmation message for payment
	And User has to enter the Email address and Click on Send Button from "Agent_TC10"
	When User has to Click on DownloadReceipt Button
	#When User has to click on Close Button

	