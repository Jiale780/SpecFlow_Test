Feature: LoginPageFeature
	As a user want to login
	I would like to login into the TurnUp Portal page
	So that I can see the home page successfully

@tmtest @regression
Scenario: 01 Navigate to the Login page with valid records 
	Given I navigate to the login page website
	And I enter valid useranme and password records
	When I click on the login button
	Then The username should be seen on the Dashboard Page