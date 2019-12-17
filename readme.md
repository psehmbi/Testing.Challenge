* If you want Gherkin syntax highlighing, you will need to install the SpecFlow or Deveroom extension in Visual Studio
* You need to have chrome installed to run the selenium tests
* Build the solution
* Open the test explorer
* Click 'Run All Tests'
* If debugging tests, in the event of a failure or exception, please do not stop the session. Use continue to make sure that any webdrivers are disposed.

Assumptions

* The dummy decision endpoint intentionally has no authentication 
* Invalid requests should return 400
** A declined decision is returned


Issues:

* On the dynamic controls page, using the Id to find the message element will not work if both controls are being tested together. Either the developer should use a unique id or the test can use Xpath.


Todo:

* Replace the obsolete Selenium 'ExpectedConditions'
* Separate step definitons into their own classes and use context injection
* Add some logging