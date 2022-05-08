using Framework_Selenium_CSharp.Pages;
using Framework_Selenium_CSharp.Framework;
using Xunit;
using Xunit.Abstractions;

namespace Framework_Selenium_CSharp.Tests
{
    public class HomeTests : BaseFramework
    {
        private readonly HomePage _homePage;

        public HomeTests(ITestOutputHelper printOutput) : base(printOutput)
        {
            _homePage = new HomePage(this);
            _homePage.AccessInitialPageAndLogin();
        }

        [Fact]
        public void SideMenu_GivenOpenSideMenuButtonIsClicked_SideMenuOpens()
        {
            
            _homePage.OpenSideMenu();
            Assert.True(_homePage.SideMenu.Displayed, "The side menu was not displayed");
        }

        [Fact]
        public void SideMenu_GivenCloseSideMenuButtonIsClicked_SideMenuCloses()
        {
            _homePage.OpenSideMenu();
            _homePage.CloseSideMenu();
            Assert.False(_homePage.SideMenu.Displayed, "The side menu was still displayed");
        }

        [Fact]
        public void Products_GivenProductIsClicked_NavigateToProductPage()
        {
            _homePage.NavigateToProductPage();
            Assert.True(_homePage.BacktoProductButton.Displayed, "The product page was not open");
        }

        [Fact]
        public void Products_GivenProductIsAddedToCart_TextGetsUpdatedInButtonAndCartIcon()
        {
            _homePage.AddProductToCart();
            Assert.Equal("REMOVE", _homePage.AddToCartButton.Text);
            Assert.Equal("1", _homePage.CartIcon.Text);
        }
    }
}
