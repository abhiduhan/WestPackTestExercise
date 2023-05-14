Feature: RegisterAndLogin
	Test cases to validate login and register workflow

@HappyPath
Scenario: Register a new account
	Given user select the Register button
	And Complete form with following details
	| Login    | First Name | Last Name | Password   |
	| testUser | AutoBot    | Selenium  | Password1@ |
	When user submit registration
	Then newly account is created and success message display

@HappyPath
Scenario: Successfully login
	Given user enter credentials as below
	| Login                                        | Password   |
	| testUser352440dc-65cf-4d3f-87b6-27e1f0d745e6 | Password1@ |
	When user press login button
	Then user is successfully login