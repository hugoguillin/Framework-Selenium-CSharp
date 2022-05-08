using Framework_Selenium_CSharp.Framework;
using OpenQA.Selenium;

namespace Framework_Selenium_CSharp.Pages
{
    public class HomePage : BaseComponent
    {
        private readonly string _openSideMenuButton =       "//button[@id='react-burger-menu-btn']";
        private readonly string _closeSideMenuButton =      "//button[@id='react-burger-cross-btn']";
        private readonly string _linkToTShirtPage =         "//div[contains(text(), 'Sauce Labs Bolt T-Shirt')]/ancestor::div[@class='inventory_item_label']//a";
        private readonly string _tShirtAddToCartButton =    "//div[contains(text(), 'Sauce Labs Bolt T-Shirt')]/ancestor::div[@class='inventory_item_description']//button";
        private readonly string _backToProductsListButton = "//button[@data-test='back-to-products']";
        private readonly string _sideMenu =                 "//div[@class='bm-menu-wrap']";
        private readonly string _cartIcon =                 "//a[@class='shopping_cart_link']";

        public IWebElement SideMenu => Base.GetElementByXPath(_sideMenu);
        public IWebElement AddToCartButton => Base.GetElementByXPath(_tShirtAddToCartButton);
        public IWebElement BacktoProductButton => Base.GetElementByXPath(_backToProductsListButton);
        public IWebElement CartIcon => Base.GetElementByXPath(_cartIcon);

        public HomePage(BaseFramework test) : base(test) { }

        public void OpenSideMenu()
        {
            Base.ClickButtonByXPath(_openSideMenuButton);
            Base.WaitForElementToBeDisplayed(_closeSideMenuButton);
        }

        public void CloseSideMenu()
        {
            Base.ClickButtonByXPath(_closeSideMenuButton);
            Base.WaitForElementToBeHidden(_closeSideMenuButton);
        }

        public void NavigateToProductPage()
        {
            Base.ClickButtonByXPath(_linkToTShirtPage);
        }

        public void AddProductToCart()
        {
            Base.ClickButtonByXPath(_tShirtAddToCartButton);
        }

        public void GoToCart()
        {
            Base.ClickButtonByXPath(_cartIcon);
        }

    }
}
