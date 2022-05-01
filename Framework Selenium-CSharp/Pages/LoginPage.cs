using Framework_Selenium_CSharp.Utils;

namespace Framework_Selenium_CSharp.Pages
{
    public class LoginPage : BaseComponent
    {
        
        private readonly string _errorMessage = "//h3[@data-test='error']";


        public LoginPage(BaseTest test) : base(test) { }

        public bool ErrorMessageIsVisible()
        {
            return test.ErrorOrAlertMessageIsVisible(_errorMessage);
        }

        public bool VerifySuccessfulLoginAndNavigationToHomePage()
        {
            return test.UrlContainsText("/inventory.html");
        }
    }
}
