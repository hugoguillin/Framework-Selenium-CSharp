using Framework_Selenium_CSharp.Utils;
using OpenQA.Selenium;
using System;

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

        public IWebElement SideMenu => test.GetElementByXPath(_sideMenu);
        public IWebElement AddToCartButton => test.GetElementByXPath(_tShirtAddToCartButton);
        public IWebElement BacktoProductButton => test.GetElementByXPath(_backToProductsListButton);
        public IWebElement CartIcon => test.GetElementByXPath(_cartIcon);

        public HomePage(BaseTest test) : base(test) { }

        public void OpenSideMenu()
        {
            test.ClickButtonByXPath(_openSideMenuButton);
            test.WaitForElementToBeDisplayed(_closeSideMenuButton);
        }

        public void CloseSideMenu()
        {
            test.ClickButtonByXPath(_closeSideMenuButton);
            test.WaitForElementToBeHidden(_closeSideMenuButton);
        }

        public void NavigateToProductPage()
        {
            test.ClickButtonByXPath(_linkToTShirtPage);
        }

        public void AddProductToCart()
        {
            test.ClickButtonByXPath(_tShirtAddToCartButton);
        }

        public void GoToCart()
        {
            test.ClickButtonByXPath(_cartIcon);
        }

    }
}
