using Framework_Selenium_CSharp.Utils;
using System;

namespace Framework_Selenium_CSharp.Pages
{
    public class HomePage : BaseComponent
    {
        private readonly string _openSideMenuButton =           "//button[@id='react-burger-menu-btn']";
        private readonly string _closeSideMenuButton =          "//button[@id='react-burger-cross-btn']";
        private readonly string _allItemsLink =                 "//a[@id='inventory_sidebar_link']";
        private readonly string _firtProductLinkLinkToPage =    "(//div[@class='inventory_item_label'])[1]/a";
        private readonly string _firstProductButtonAddToCart =  "(//div[@class='inventory_item'])[1]//button";
        private readonly string _backToProductsListButton =     "//button[@data-test='back-to-products']";

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
            test.ClickButtonByXPath(_firtProductLinkLinkToPage);
        }

        public bool IsSideMenuOpen()
        {
            try
            {
                test.WaitForElementToBeDisplayed(_allItemsLink);
                return test.GetElementByXPath(_allItemsLink).Displayed;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

    }
}
