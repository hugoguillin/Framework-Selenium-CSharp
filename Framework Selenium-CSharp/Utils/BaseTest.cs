using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using WebDriverManager;
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
            WebDriverWait wait = new(_driver, TimeSpan.FromSeconds(7));
            var element = wait.Until(ExpectedConditions.ElementExists(By.XPath(xPath)));
            return element;
        }

        public IWebElement FillInputTextByXPath(string xPath, string text)
        {
            _printOutput.WriteLine($"Filling the input field '{xPath}' with the text '{text}'");
            var input = GetElementByXPath(xPath);
            input.Clear();
            input.SendKeys(text);
            return input;
        }

        public void ClickButtonByXPath(string xPath)
        {
            _printOutput.WriteLine($"Clicking the element '{xPath}'");
            var button = GetElementByXPath(xPath);
            button.Click();
        }

        public bool UrlContainsText(string text)
        {
            _printOutput.WriteLine($"Checking if the url contains the text '{text}'");
            return _driver.Url.Contains(text);
        }

        public void AccessInitialPage()
        {
            _printOutput.WriteLine("Navigating to the login page of the website");
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        public void WaitForElementToBeDisplayed(string xPath)
        {
            _printOutput.WriteLine($"Waiting for element '{xPath}' to be displayed");
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xPath)));
        }

        public void WaitForElementToBeHidden(string xPath)
        {
            _printOutput.WriteLine($"Waiting for element '{xPath}' to be hidden");
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(xPath)));
        }

        public void Dispose()
        {
            _driver.Quit();
        }

        #endregion

        #region Private methods
        private IWebDriver InitializeDriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
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
