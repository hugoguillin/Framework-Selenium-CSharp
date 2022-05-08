using Framework_Selenium_CSharp.Framework;

namespace Framework_Selenium_CSharp
{
    public class BaseComponent
    {
        private const string _validUsername =   "standard_user";
        private const string _validPassword =   "secret_sauce";
        private readonly string _username =     "//input[@data-test='username']";
        private readonly string _password =     "//input[@data-test='password']";

        public BaseFramework Base { get; private set; }

        public BaseComponent(BaseFramework baseFramework)
        {
            Base = baseFramework;
        }

        public void AccessInitialPageAndLogin()
        {
            Base.AccessInitialPage();
            Login();
        }

        public void Login(string username = _validUsername, string pass = _validPassword)
        {
            Base.FillInputTextByXPath(_username, username);
            Base.FillInputTextByXPath(_password, pass);
            Base.GetElementByXPath(_password).Submit();
        }
    }
}
