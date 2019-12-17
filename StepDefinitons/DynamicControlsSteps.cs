using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using Testing.Challenge.PageObjects;
using Xunit;

namespace Testing.Challenge.StepDefinitons
{
    [Binding]
    public class DynamicControlsSteps
    {
        private IWebDriver _webDriver;
        private DynamicControlsPage _page;
        public DynamicControlsSteps()
        {
            _webDriver = new ChromeDriver();
        }

        [Given(@"the user is on the dynamic controls page")]
        public void GivenTheUserIsOnTheDynamicControlsPage()
        {
            _page = new DynamicControlsPage(_webDriver);
            _page.Navigate();
        }

        [Given(@"the textbox is enabled")]
        public void GivenTheTextboxIsEnabled()
        {
            GivenTheUserIsOnTheDynamicControlsPage();
            WhenTheButtonIsClicked("Enable");
            ThenTheTextboxIs("Enabled");
        }

        [Given(@"the (.*) button is clicked")]
        [When(@"the (.*) button is clicked")]
        public void WhenTheButtonIsClicked(string buttonText)
        {
            _page.ClickButton(buttonText);
        }

        [Then(@"the checkbox button text is (.*)")]
        public void ThenTheCheckboxButtonTextIs(string expectedButtonText)
        {
            var actualButtonText = _page.WaitForCheckboxButtonText(expectedButtonText);
            Assert.Equal(expectedButtonText, actualButtonText);
        }

        [Then(@"the textbox button text is (.*)")]
        public void ThenTheTextboxButtonTextIs(string expectedButtonText)
        {
            var actualButtonText = _page.WaitForTextBoxButtonText(expectedButtonText);
            Assert.Equal(expectedButtonText, actualButtonText);
        }

        [When(@"the textbox is (.*)")]
        [Then(@"the textbox is (.*)")]
        public void ThenTheTextboxIs(string enabledOrDisabled)
        {
            switch (enabledOrDisabled.ToLower())
            {
                case "enabled":
                    Assert.True(_page.TextBoxEnabled(true), "Text box was not enabled");
                    break;
                case "disabled":
                    Assert.False(_page.TextBoxEnabled(false), "Text box was not disabled");
                    break;
                default:
                    throw new Exception("Input should be 'enabled' or 'disabled'");
            }
        }

        [Then(@"a message is displayed saying (.*)")]
        public void ThenAMessageIsDisplayedSayingItSEnabled(string expectedText)
        {
            Assert.Equal(expectedText, _page.Message.Text);
        }


        [Given(@"the checkbox is not visible")]
        public void GivenTheCheckboxIsNotVisible()
        {
            GivenTheUserIsOnTheDynamicControlsPage();
            WhenTheButtonIsClicked("Remove");
        }

        [Then(@"the checkbox is not displayed")]
        public void ThenTheCheckboxIsNotDisplayed()
        {
            //_page.CheckboxVisible(false);
            Assert.False(_page.CheckboxVisible(true));
        }


        [After("web")]
        public void Dispose()
        {
            _webDriver.Quit();
        }
    }
}
