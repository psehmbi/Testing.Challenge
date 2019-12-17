Feature: Dummy decisions
	As a hiring manager
	I want to test the knowledge of candidates
	So that I can make informed hiring decisions


Scenario Outline: All fields are required
	Given an applicant with the following data
		| firstName   | lastName   | dateOfBirth   |
		| <FirstName> | <LastName> | <DateOfBirth> |
	When the appication is submitted
	Then the response is BadRequest

	Examples: Applicants with missing data
		| FirstName | LastName | DateOfBirth |
		|           | Smith    | 1970-01-01  |
		| John      |          | 1970-01-01  |
		| John      | Smith    |             |


Scenario: Applicant is accepted
	Given an applicant with the following data
		| firstName | lastName | dateOfBirth |
		| John      | Smith    | 1970-01-01  |
	When the appication is submitted
	Then the decision is Accepted


Scenario: Applicant is declined
	Given an applicant with the following data
		| firstName | lastName | dateOfBirth |
		| John      | Smith    | 1970-01-01  |
	When the appication is submitted
	Then the decision is Declined
