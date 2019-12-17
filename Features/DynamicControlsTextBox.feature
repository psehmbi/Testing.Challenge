Feature: Dynamic Controls Text Box
	As a hiring manager
	I want to test the knowledge of candidates
	So that I can make informed hiring decisions


@web
Scenario: Textbox button text changes to 'Disable'
	Given the user is on the dynamic controls page
	When the Enable button is clicked
	Then the textbox button text is Disable


@web
Scenario: Textbox button text changes to 'Enable'
	Given the textbox is enabled
	When the Disable button is clicked
	Then the textbox button text is Enable


@web
Scenario: Textbox can be enabled
	Given the user is on the dynamic controls page
	When the Enable button is clicked
	Then the textbox is Enabled


@web
Scenario: Textbox can be disabled
	Given the textbox is enabled
	When the Disable button is clicked
	Then the textbox is Disabled
	

@web
Scenario: Confirmation message when text box enabled
	Given the user is on the dynamic controls page
	And the Enable button is clicked
	When the textbox is Enabled
	Then a message is displayed saying It's enabled!


@web
Scenario: Confirmation message when text box disabled
	Given the textbox is enabled
	And the Disable button is clicked
	When the textbox is Disabled
	Then a message is displayed saying It's disabled!