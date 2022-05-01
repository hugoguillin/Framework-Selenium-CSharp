using Framework_Selenium_CSharp.Utils;

namespace Framework_Selenium_CSharp
{
    public class BaseComponent
    {
        protected BaseTest test;
        private const string _validUsername =   "standard_user";
        private const string _validPassword =   "secret_sauce";
        private readonly string _username =     "//input[@data-test='username']";
        private readonly string _password =     "//input[@data-test='password']";
        private readonly string _loginButton =  "//input[@data-test='login-button']";

        public BaseComponent(BaseTest test)
        {
            this.test = test;
        }

        public void Login(string username = _validUsername, string pass = _validPassword)
        {
            FillUsernameField(username);
            FillPasswordField(pass);
            test.ClickButtonByXPath(_loginButton);
        }

        private void FillUsernameField(string username)
        {
            test.FillInputTextByXPath(_username, username);
        }

        private void FillPasswordField(string pass)
        {
            test.FillInputTextByXPath(_password, pass);
        }
    }
}
