Feature: RatingPopularModel
	Test cases to provide rating fo rpopular models

Background: 
	Given register and login as a new user 

@HappyPath
Scenario: Post a successful vote
	Given select the popular model widget
	When enter unique comment message
	And click vote button
	Then vote should be successfully posted and user is no longer able to vote again