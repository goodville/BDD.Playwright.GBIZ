Feature: Public_TC28

A short summary of the feature

@tag1
Scenario: Public_TC28
	Given User logs into GBIZ
	When Verifying the Home Page Title
	When User clicks on Make a Payment option from the toolbar
	When User enters policy details and submit button on Make a Payment page from "MakeAclaimStartTC28"
    When User clicks on submit with index 2
	And User selects payment type and plan then enters payment and banking and insured information then proceeds to review from "MakeAPaymentTC28"
	#When User pays the amount for the policy
   # When User verifies confirmation message for payment
	#When User has to enter the Email address and Click on Send Button
	#When User has to Click on PrintReceipt Button
