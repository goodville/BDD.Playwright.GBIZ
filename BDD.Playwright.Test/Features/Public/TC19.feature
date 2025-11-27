Feature: Public_TC19

@Public_TC19
Scenario: Public_TC19
	Given User logs into GBIZ
	When Verifying the Home Page Title
	When User click on report a claim and click submits and verifies the date of loss error message
	When User enters value for policyNumber, zipcode and submits and verifies the date error message
	When User enters value for policyNumber, date and submits and verifies the zipcode error message
	When User Enters value for date, zipcode and submits and verifies the policy number error message