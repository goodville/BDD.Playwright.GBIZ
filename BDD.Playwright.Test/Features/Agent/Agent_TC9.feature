Feature: Agent_TC9

@Agent_TC9
Scenario: Agent_TC9
	Given User logs into GBIZ
	When User Click on Agents or Members
	When User navigates to accounting page
	And User navigates to makepayment page
	And User enters mandatory fields for make payment from "Agent_TC9"
	When User click on submit Button
    And User has to select payment method as Credit Card
	Then User selected that the payment method dropdown selected for paymentplan
	When User clicks on Continue button	
	When User has to click on acknowledge Continue button  
	When User has to click on Use Another Payment Method
	And User enters Credit Card details from "Agent_TC9"
	#When User clicks on CreditCard Review button
	#When User clicks on Pay button
	#When User verifies confirmation message for payment
	#When User has to enter the Email address and Click on Send Button
	#When User has to Click on DownloadReceipt Button
  