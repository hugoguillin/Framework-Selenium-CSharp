using Framework_Selenium_CSharp.Pages;
using Framework_Selenium_CSharp.Utils;
using System.Threading;
using Xunit;
using Xunit.Abstractions;

namespace Framework_Selenium_CSharp.Tests
{
    public class HomeTests : BaseTest
    {

        public HomeTests(ITestOutputHelper printOutput) : base(printOutput) { }

        [Fact]
        public void SideMenu_GivenOpenSideMenuButtonIsClicked_SideMenuOpens()
        {
            var homePage = AccessInitialPageAndLogin(new HomePage(this));
            homePage.OpenSideMenu();
            Assert.True(homePage.IsSideMenuOpen());
        }

        [Fact]
        public void SideMenu_GivenCloseSideMenuButtonIsClicked_SideMenuCloses()
        {
            var homePage = AccessInitialPageAndLogin(new HomePage(this));
            homePage.OpenSideMenu();
            homePage.CloseSideMenu();
            Assert.False(homePage.IsSideMenuOpen());
        }

        [Fact]
        public void Products_GivenProductIsClicked_NavigateToProductPage()
        {

        }
    }
}
