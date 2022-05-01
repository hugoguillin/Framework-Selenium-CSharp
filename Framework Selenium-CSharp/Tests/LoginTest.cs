using Framework_Selenium_CSharp.Pages;
using Framework_Selenium_CSharp.Utils;
using Xunit;
using Xunit.Abstractions;

namespace Framework_Selenium_CSharp
{
    public class LoginTest : BaseTest
    {
        private readonly string _invalidUsername =  "invalid_user";

        public LoginTest(ITestOutputHelper printOutput) : base(printOutput) { }

        [Fact]
        public void Login_GivenValidUsernameAndPass_LoginSuccessful()
        {
            var loginPage = new LoginPage(this);
            this.AccessInitialPage();
            loginPage.Login();
            Assert.True(loginPage.VerifySuccessfulLoginAndNavigationToHomePage());
        }

        [Fact]
        public void Login_GivenInvalidUsernameAndValidPass_LoginUnsuccessful()
        {
            var loginPage = new LoginPage(this);
            this.AccessInitialPage();
            loginPage.Login(_invalidUsername);
            Assert.True(loginPage.ErrorMessageIsVisible());
        }

        [Fact]
        public void Login_GivenValidUsernameAndPassAfterInvalidLoginAttempt_Login_Successful()
        {
            var loginPage = new LoginPage(this);
            this.AccessInitialPage();
            loginPage.Login(_invalidUsername);
            loginPage.Login();
            Assert.True(loginPage.VerifySuccessfulLoginAndNavigationToHomePage());
        }
    }
}