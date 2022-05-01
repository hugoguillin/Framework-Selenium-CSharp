using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using WebDriverManager.DriverConfigs.Impl;
using Xunit.Abstractions;

namespace Framework_Selenium_CSharp.Utils
{
    public class BaseTest : IDisposable
    {
        private IWebDriver _driver;
        private readonly ITestOutputHelper _printOutput;

        #region Contructor
        public BaseTest()
        {
            InitializeDriver();
        }

        public BaseTest(ITestOutputHelper printOutput) : this() 
        {
            _printOutput = printOutput;
        }
        #endregion

        #region Public Methods
        public IWebElement GetElementByXPath(string xPath)
        {
            WebDriverWait wait = new(_driver, TimeSpan.FromSeconds(20));
            var element = wait.Until(ExpectedConditions.ElementExists(By.XPath(xPath)));
            return element;
        }

        public void FillInputTextByXPath(string xPath, string text)
        {
            var input = GetElementByXPath(xPath);
            input.Clear();
            input.SendKeys(text);
        }

        public void ClickButtonByXPath(string xPath)
        {
            var button = GetElementByXPath(xPath);
            button.Click();
        }

        public bool ErrorOrAlertMessageIsVisible(string xPath)
        {
            WebDriverWait wait = new(_driver, TimeSpan.FromSeconds(3));
            try
            {
                wait.Until(ExpectedConditions.ElementExists(By.XPath(xPath)));
                return true;
            }
            catch (Exception ex)
            {
                _printOutput.WriteLine("The error or alert message was not displayed: {0}", ex.ToString());
            }
            return false;
        }

        public bool UrlContainsText(string text)
        {
            return _driver.Url.Contains(text);
        }

        public void AccessInitialPage()
        {
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        public void WaitForElementToBeDisplayed(string xPath)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xPath)));
        }

        public void WaitForElementToBeHidden(string xPath)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(xPath)));
        }

        public T AccessInitialPageAndLogin<T>(T classPage)
        {
            AccessInitialPage();
            new BaseComponent(this).Login();
            return classPage;
        }

        public void Dispose()
        {
            _driver.Quit();
        }

        #endregion

        #region Private methods
        private IWebDriver InitializeDriver()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("disable-infobars");
            _driver = new ChromeDriver(options);
            _driver.Manage().Window.Maximize();
            return _driver;
        }

        private void ChangeFocusToTab(int tabNumber)
        {
            var tabs = _driver.WindowHandles;
            _driver.SwitchTo().Window(tabs[tabNumber - 1]);
        }

        #endregion


    }
}
