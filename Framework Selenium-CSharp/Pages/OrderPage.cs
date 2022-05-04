using Framework_Selenium_CSharp.Utils;
using OpenQA.Selenium;

namespace Framework_Selenium_CSharp.Pages
{
    public class OrderPage : BaseComponent
    {
        private readonly string _removeFromCartButton =   "//button[@data-test='remove-sauce-labs-bolt-t-shirt']";
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
        

        public IWebElement SumaryInfo => test.GetElementByXPath(_sumaryInfoSection);
        public IWebElement OrderCompletedBanner => test.GetElementByXPath(_checkoutCompleteBanner);

        public OrderPage(BaseTest test) : base(test)
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
            test.ClickButtonByXPath(_checkoutButton);
        }

        public void FillUserData()
        {
            test.FillInputTextByXPath(_firstNameField, "random-name");
            test.FillInputTextByXPath(_lastNameField, "random-last-name");
            test.FillInputTextByXPath(_zipCodeField, "99999").Submit();
        }

        public void ConfirmOrder()
        {
            test.ClickButtonByXPath(_finishOrderButton);
        }

        public void CancelOrder()
        {
            test.ClickButtonByXPath(_cancelOrderButton);
        }

        public void GoToMainPage()
        {
            test.ClickButtonByXPath(_backToHomeButton);
        }

    }
}
