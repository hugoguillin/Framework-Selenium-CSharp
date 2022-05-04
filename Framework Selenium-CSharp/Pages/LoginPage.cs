using Framework_Selenium_CSharp.Utils;
using OpenQA.Selenium;

namespace Framework_Selenium_CSharp.Pages
{
    public class LoginPage : BaseComponent
    {

        public IWebElement ErrorMessage => test.GetElementByXPath("//h3[@data-test='error']");


        public LoginPage(BaseTest test) : base(test) { }

        public bool VerifySuccessfulLoginAndNavigationToHomePage()
        {
            return test.UrlContainsText("/inventory.html");
        }
    }
}
