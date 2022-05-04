using Framework_Selenium_CSharp.Pages;
using Framework_Selenium_CSharp.Utils;
using Xunit;
using Xunit.Abstractions;

namespace Framework_Selenium_CSharp.Tests
{
    public class OrderTests : BaseTest
    {
        private readonly OrderPage _orderPage;
        private readonly HomePage _homePage;

        public OrderTests(ITestOutputHelper printOutput) : base(printOutput)
        {
            _homePage = new HomePage(this);
            _orderPage = new OrderPage(this);
            _orderPage.AccessInitialPageAndLogin();
        }

        [Fact]
        public void Order_GivenAProductIsInTheCartAndValidDataProvided_CheckoutProccessCompletesCorrectly()
        {
            _orderPage.CreateSuccessFulOrder();
            _orderPage.ConfirmOrder();
            Assert.True(_orderPage.OrderCompletedBanner.Displayed);
            Assert.Equal("Checkout: Complete!", _orderPage.OrderCompletedBanner.Text, true);
        }

        [Fact]
        public void Order_GivenAOrderIsCanceledInTheLastStep_NavigateToHomePageAndProductIsStillInTheCart()
        {
            _orderPage.CreateSuccessFulOrder();
            _orderPage.CancelOrder();
            Assert.Equal("Remove", _homePage.AddToCartButton.Text, true);
        }
    }
}
