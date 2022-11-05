@setup_feature
Feature: Login
	
Scenario: Login locked out user
	Given open login page
	And type <username> and <password>
	When click login
	Then the result should contain Epic sadface: Sorry, this user has been locked out.

	Examples: 
	| username      | password     |
	| locked_out_user | secret_sauce |