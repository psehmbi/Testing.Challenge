Feature: Dynamic Controls Checkbox
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
	Given the checkbox is not displayed
	When the Add button is clicked
	Then the checkbox button text is Remove


@web
	Scenario: Checkbox can be removed
	Given the user is on the dynamic controls page
	When the Remove button is clicked
	Then the checkbox is not displayed


@web
Scenario: Checkbox can be added
	Given the checkbox is not displayed
	When the Add button is clicked
	Then the checkbox is displayed
	

@web
Scenario: Confirmation message when Checkbox added
	Given the checkbox is not displayed
	And the Add button is clicked
	When the checkbox is displayed
	Then a message is displayed saying It's back!


@web
Scenario: Confirmation message when Checkbox removed
	Given the checkbox is displayed
	And the Remove button is clicked
	When the checkbox is not displayed
	Then a message is displayed saying It's gone!