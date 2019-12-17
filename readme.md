# How to run
## Pre-conditions
* For Gherkin syntax highlighing, install the SpecFlow or Deveroom extension in Visual Studio (optional)
* You need to have chrome installed to run the selenium tests
## Running the tests
* Download / Unzip / Clone the repo
* Build the solution
* Open the test explorer
* Click 'Run All Tests'
  * The browser tests should all pass
  * The API tests give different results each time
* If debugging tests, in the event of a failure or exception, please do not stop the session. Use 'continue' to make sure that any webdrivers are disposed at the end of the test.

# Assumptions

* The dummy decision endpoint intentionally has no authentication 
* Invalid requests to the dummy decision endpoint should return 400
  * A declined decision is currently returned. The tests can easily be changed to reflect this if it is the intended behaviour


# Issues:

* On the dynamic controls page, using the Id to find the message element will not work if both controls are being tested together. Either the developer should use a unique id or the test can use Xpath.


# Todo:

* Replace the obsolete Selenium 'ExpectedConditions'
* Separate step definitons into their own classes and use context injection
* Add tests for the waiting indicator on dynamic controls
* Add some logging