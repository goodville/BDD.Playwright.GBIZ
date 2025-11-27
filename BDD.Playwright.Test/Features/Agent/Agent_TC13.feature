Feature: Agent_TC13

A short summary of the feature

@tag1
Scenario: Agent_TC13
	Given User logs into GBIZ
	When User Click on Agents or Members
	When User navigates to accounting page
	When User verifies Policies Requiring Payment, Pending Agency Sweep Payments and Transaction History sections are displayed
	When the user clicks on policy number under the Policies Requiring Payment table
    When the Make a Payment page is displayed
    When User navigates to back
    When the user searches Agency Sweep Transaction History by entering SweepStartDate and SweepEndDate, and clicks the Search button
    And clicks on the first sweep history result
    Then the Agency Sweep Transaction History Detail page is displayed
    When User navigates to back
    #When User navigates to makepayment page
    Then the user verifies the menu links on the left part of the Accounting page are working
    When the user enters "test" in the Admin Search box and clicks the Search button
    Then the Home page is displayed
    When User clicks on Privacy, Contact and Term condtions Links
