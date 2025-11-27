Feature: Public_TC30

A short summary of the feature

@tag1
Scenario: Public_TC30
	Given User logs into GBIZ
	When Verifying the Home Page Title
    When User clicks on Make a Payment option from the toolbar
    Then User verifies Make a Payment page is displayed
	When User enters policy details and submit button on Make a Payment page from "MakeAclaimStartTC30"
    When User clicks on submit with index 2
    When User validates the payment paid message
