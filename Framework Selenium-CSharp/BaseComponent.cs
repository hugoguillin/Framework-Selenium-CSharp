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

        public BaseComponent(BaseTest test)
        {
            this.test = test;
        }

        public void AccessInitialPageAndLogin()
        {
            test.AccessInitialPage();
            Login();
        }

        public void Login(string username = _validUsername, string pass = _validPassword)
        {
            test.FillInputTextByXPath(_username, username);
            test.FillInputTextByXPath(_password, pass);
            test.GetElementByXPath(_password).Submit();
        }
    }
}
