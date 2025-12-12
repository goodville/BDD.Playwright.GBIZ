Feature: Agent_TC82_OH1

A short summary of the feature

@tag1
Scenario: Agent_TC82_OH1
	Given User logs into GBIZ
	When User Click on Agents or Members
	When User Click on the Quoting
	When User Click on New Quote and Verify the Correct Page is displayed
	When User select the Farm Owner Option
	When User select the 'I have informed the insured' checkbox and click continue button
	And User enter the mandatory fields in the New Quote Page for the Farm Owner from json "Agent_TC82_OH1"
	When User Click on Next Button
	And User enter the Location details in the Farm Owner page from json "Agent_TC82_OH1"
	When User Click on Next Button
	And User Click on Add Dwelling and enter the fields from json "Agent_TC82_OH1"
	When User Click on Next Button
	When User Navigates to Add Structure page
	And User navigates to coverageFarmOwNer Page from json "Agent_TC82_OH1"
	And user navigates to FarmPropF button
	And User navigates to FarmProperty page from json "Agent_TC82_OH1"
	And User navigates to FarmPropG button
	And User NAvigates to Deduct drpdown
	And User Navigates to Libilty subTAB
	And Navigates to libility subTab Page from json "Agent_TC82_OH1"
	And User navigates to add Optional libility cov dropdown
	And User NAvigates to Summary page
	When User NAvigates to the billing tab
	When User navigates to Binding paGe for farmowner
	And User enter "shoeb.deshmukh@goodville.com" in mail box
	And User Verifies Attched Docs
	And User Navigates to Agree Checkbox
	When User NAvigates to the billing tab
	When User NavIGAtes to Binding Tab
	And User navigates to save and rate button
	And User Navigates to Rate Button
	When User NAvigates to the billing tab
	When User NavIGAtes to Binding Tab
	And User Navigates to producer tab from json "Agent_TC82_OH1"
	And User Navigates to binding pOlicy and ok Button Verification
