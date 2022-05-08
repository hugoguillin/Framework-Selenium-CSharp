using Framework_Selenium_CSharp.Framework;
using OpenQA.Selenium;

namespace Framework_Selenium_CSharp.Pages
{
    public class OrderPage : BaseComponent
    {
        private readonly string _checkoutButton =         "//button[@data-test='checkout']";
        private readonly string _firstNameField =         "//input[@data-test='firstName']";
        private readonly string _lastNameField =          "//input[@data-test='lastName']";
        private readonly string _zipCodeField =           "//input[@data-test='postalCode']";
        private readonly string _sumaryInfoSection =      "//div[@class='summary_info']";
        private readonly string _finishOrderButton =      "//button[@data-test='finish']";
        private readonly string _checkoutCompleteBanner = "//div[@class='header_secondary_container']";
        private readonly string _backToHomeButton =       "//button[@data-test='back-to-products']";
        private readonly string _cancelOrderButton =      "//button[@data-test='cancel']";

        private readonly HomePage _homePage;
        

        public IWebElement SumaryInfo => Base.GetElementByXPath(_sumaryInfoSection);
        public IWebElement OrderCompletedBanner => Base.GetElementByXPath(_checkoutCompleteBanner);

        public OrderPage(BaseFramework test) : base(test)
        {
            _homePage = new HomePage(test);
        }

        public void CreateSuccessFulOrder()
        {
            StartCheckout();
            FillUserData();
        }

        public void StartCheckout()
        {
            _homePage.AddProductToCart();
            _homePage.GoToCart();
            Base.ClickButtonByXPath(_checkoutButton);
        }

        public void FillUserData()
        {
            Base.FillInputTextByXPath(_firstNameField, "random-name");
            Base.FillInputTextByXPath(_lastNameField, "random-last-name");
            Base.FillInputTextByXPath(_zipCodeField, "99999").Submit();
        }

        public void ConfirmOrder()
        {
            Base.ClickButtonByXPath(_finishOrderButton);
        }

        public void CancelOrder()
        {
            Base.ClickButtonByXPath(_cancelOrderButton);
        }

        public void GoToMainPage()
        {
            Base.ClickButtonByXPath(_backToHomeButton);
        }

    }
}
