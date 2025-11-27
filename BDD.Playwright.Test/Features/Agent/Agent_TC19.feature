Feature: Agent_TC19

A short summary of the feature

@tag1
Scenario: Agent_TC19
	Given User logs into GBIZ
	When User Click on Agents or Members
	And User navigates to search page
    And User performs a search
	And User navigates to policy details page
	And User navigates to policy details billing page
	When User Click on the Make payment button and verify the Make a payment page opens or not
	And User enters mandatory fields for make payment from "Agent_TC19"
	When User click on submit Button
    And User has to select payment method as Credit Card
	Then User selected that the payment method dropdown selected for paymentplan
	When User clicks on Continue button	
	When User has to click on acknowledge Continue button  
	When User has to click on Use Another Payment Method
	And User enters Credit Card details from "Agent_TC19"
	When User clicks on CreditCard Review button
	When User clicks on Pay button
	When User verifies confirmation message for payment
	And User has to enter the Email address and Click on Send Button from "Agent_TC19"
	When User has to Click on DownloadReceipt Button
  