using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Threading;

namespace Testing.Challenge.PageObjects
{
    public class DynamicControlsPage
    {
        private readonly IWebDriver _webDriver;
        private readonly WebDriverWait _wait;

        public DynamicControlsPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            _wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));

        }


        public IWebElement BtnCheckboxToggle
        {
            get
            {
                return _webDriver.FindElement(By.CssSelector($"#checkbox-example > button"));
            }
        }

        public IWebElement BtnInputToggle
        {
            get
            {
                return _webDriver.FindElement(By.CssSelector($"#input-example > button"));
            }
        }

        public IWebElement TxtInput
        {
            get
            {
                return _webDriver.FindElement(By.XPath("//*[@id=\"input-example\"]/input"));
            }
        }

        public IWebElement Message
        {
            get
            {
                return _webDriver.FindElement(By.Id("message"));
            }
        }


        public void Navigate()
        {
            _webDriver.Navigate().GoToUrl("http://the-internet.herokuapp.com/dynamic_controls");
        }

        public void ClickButtonWithText(string buttonText)
        {
            var buttons = _webDriver.FindElements(By.CssSelector($"button[type='button']"));
            var buttonToClick = buttons.First(x => x.Text == buttonText);
            buttonToClick.Click();
        }

        public string WaitForTextBoxButtonText(string expectedText)
        {
            _wait.Until(ExpectedConditions.TextToBePresentInElement(BtnInputToggle, expectedText));
            return BtnInputToggle.Text;
        }

        public string WaitForCheckboxButtonText(string expectedText)
        {
            _wait.Until(ExpectedConditions.TextToBePresentInElement(BtnCheckboxToggle, expectedText));
            return BtnCheckboxToggle.Text;
        }

        public bool TextBoxEnabled(bool enabled)
        {
            if (enabled)
            {
                _wait.Until(ExpectedConditions.ElementToBeClickable(TxtInput));
            }
            else
            {
                var i = 0;
                do
                {
                    Thread.Sleep(TimeSpan.FromMilliseconds(500));
                    i++;
                } while (TxtInput.Enabled && i < 10);
            }

            return TxtInput.Enabled;
        }

        public bool CheckboxVisible(bool expected)
        {
            bool visible;
            var i = 0;
            do
            {
                visible = IsElementVisible(By.Id("checkbox"));
                i++;
                Thread.Sleep(TimeSpan.FromSeconds(1));
            } while (!expected && i < 5);
            return visible;
        }

        private bool IsElementVisible(By by)
        {
            try
            {
                _webDriver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
