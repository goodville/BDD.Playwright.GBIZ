Feature: Agent_TC12

A short summary of the feature

@tag1
Scenario: Agent_TC12
	Given User logs into GBIZ
	When User Click on Agents or Members
	When User navigates to accounting page
	When User navigates to ManageSweepPayments page
	When User clicks on Manage button 
	When User has to click on acknowledge Continue button  
	When User has to click on Add New Payment Method
	Then User has to select that the payment method is Bank Account type
	When User enters Account and Routing details from "Agent_TC12"
	#And User click on default checkbox
	When User clicks on submit Button 
	When User has to select the latest paymethod and clicks on Remove Button.
	Then User has to click on Close button and Navigates to Manage page
	And User has to verify that the paymethod is removed Successfully
	
	
	
	