Feature: Agent_TC7

A short summary of the feature

@tag1
Scenario: Agent_TC7
	Given User logs into GBIZ
	When User Click on Agents or Members
	When User navigates to accounting page
	And user navigates to makepayment page
	And user enters policy data for make a payment from "Agent_TC7"
	When User clicks on submit 
	And user has to select payment method As AgencySweep
	Then User selected that the payment method dropdown selected for paymentplan
	When user clicks on Continue button	
	When user has to click on AddnewPayment Method
	And user enters payment details for make a payment from "Agent_TC7"
	When user clicks on savings button
	And User click on default checkbox
	When User clicks on submit for agent accounting payment page
	When User clicks on Review buttton
	When user Click on Pay ten dollar for agent accounting payment page



	#Then User verifies that the payment is successful
	#Then User verifies that the payment method is selected as credit card
	#When user clicks on submit button
	#Then User verifies that the payment is successful

