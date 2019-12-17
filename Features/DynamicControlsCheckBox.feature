﻿Feature: Dynamic Controls Checkbox
	As a hiring manager
	I want to test the knowledge of candidates
	So that I can make informed hiring decisions


@web
Scenario: Checkbox button text changes to 'Add'
	Given the user is on the dynamic controls page
	When the Remove button is clicked
	Then the checkbox button text is Add


@web
Scenario: Checkbox button text changes to 'Remove'
	Given the checkbox is not visible
	When the Add button is clicked
	Then the checkbox button text is Remove


@web
	Scenario: Checkbox can be removed
	Given the user is on the dynamic controls page
	When the Remove button is clicked
	Then the checkbox is not displayed


@web
Scenario: Checkbox can be disabled
	Given the checkbox is visible
	When the Disable button is clicked
	Then the checkbox is not visible
	

@web
Scenario: Confirmation message when Checkbox added
	Given the user is on the dynamic controls page
	And the Enable button is clicked
	When the checkbox is Enabled
	Then a message is displayed saying It's back!


@web
Scenario: Confirmation message when Checkbox removed
	Given the checkbox is enabled
	And the Disable button is clicked
	When the checkbox is Disabled
	Then a message is displayed saying It's gone!