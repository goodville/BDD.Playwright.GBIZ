Feature: Public_TC4

@TC4
Scenario: Public_TC4
	Given User logs into GBIZ
	When Verifying the Home Page Title
	When User Click on the About Us and Verify the Ward 50 Link
	#And User Click on the Company History and Verify the AM Best Link
	And User Click on Insurance Fraud Link and Verify the Title
	And User Click on President Message Link and Verify the Title
	And User Click on Become an Goodville Agent and Verify the Title
	#And User Click On Annual Report and in that 2024 Annual Report and Verify the Title
	And User Click on Credit History and Verify the Text
	And User Click on Careers and Verify the Title