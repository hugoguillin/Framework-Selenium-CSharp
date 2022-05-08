using Framework_Selenium_CSharp.Pages;
using Framework_Selenium_CSharp.Framework;
using Xunit;
using Xunit.Abstractions;

namespace Framework_Selenium_CSharp
{
    public class LoginTest : BaseFramework
    {
        private readonly string _invalidUsername =  "invalid_user";
        private readonly LoginPage loginpage;

        public LoginTest(ITestOutputHelper printOutput) : base(printOutput)
        {
            loginpage = new LoginPage(this);
        }

        [Theory]
        [InlineData("standard_user")]
        [InlineData("problem_user")]
        [InlineData("performance_glitch_user")]
        public void Login_GivenValidUsernameAndPass_LoginSuccessful(string username)
        {
            AccessInitialPage();
            loginpage.Login(username);
            Assert.True(loginpage.VerifySuccessfulLoginAndNavigationToHomePage());
        }

        [Theory]
        [InlineData("invalid_user")]
        [InlineData("locked_out_user")]
        public void Login_GivenInvalidUsernameAndValidPass_LoginUnsuccessful(string invalidusername)
        {
            AccessInitialPage();
            loginpage.Login(invalidusername);
            Assert.True(loginpage.ErrorMessage.Displayed);
        }

        [Fact]
        public void Login_GivenValidUsernameAndPassAfterInvalidLoginAttempt_Login_Successful()
        {
            AccessInitialPage();
            loginpage.Login(_invalidUsername);
            loginpage.Login();
            Assert.True(loginpage.VerifySuccessfulLoginAndNavigationToHomePage());
        }
    }
}