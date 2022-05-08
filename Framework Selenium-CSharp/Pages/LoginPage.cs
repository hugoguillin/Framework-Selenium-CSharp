using Framework_Selenium_CSharp.Framework;
using OpenQA.Selenium;

namespace Framework_Selenium_CSharp.Pages
{
    public class LoginPage : BaseComponent
    {

        public IWebElement ErrorMessage => Base.GetElementByXPath("//h3[@data-test='error']");


        public LoginPage(BaseFramework test) : base(test) { }

        public bool VerifySuccessfulLoginAndNavigationToHomePage()
        {
            return Base.UrlContainsText("/inventory.html");
        }
    }
}
