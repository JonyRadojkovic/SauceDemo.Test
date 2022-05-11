using OpenQA.Selenium;
using SauceDemo.Test.POMs;
using Xunit;

namespace SauceDemo.Test.Tests
{

    public class UITests : BaseTest
    {
        private const string IdToFind = "add-to-cart-sauce-labs-backpack";
        private readonly LoginPage loginPage;
        private readonly HomePage homePage;
        private readonly Cart cart;
        public UITests()
        {
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
            cart = new Cart(driver);
        }


        [Fact(DisplayName = "Sucesfully login when entering right username and password")]
        public void ShouldSucesfullyLoginWhenEnteringRigtUsernamePasswordCombination()
        {
            Navigate(url);
            loginPage.DisplayedUserName();
            loginPage.UserName.SendKeys("standard_user");

            loginPage.DisplayedPassword();
            loginPage.Password.SendKeys("secret_sauce");

            loginPage.DisplayedLoginButton();
            loginPage.Login();

            element = driver.FindElement(By.Id(IdToFind));

            Assert.True(element.Displayed);

        }

        [Theory(DisplayName ="Login Failed When Enterin wrong password/username combination")]
        [InlineData("locked_out_user", "secret_sauce")]
        [InlineData("locked_out_user", "Nikola89")]
        [InlineData("Klapaucius", "Nikola8912")]
        [InlineData("standard_user", "Nikolas123")]

        public void FailedLoginWhenEnteringWrongUsernamePaswordCombination(string username, string password)
        {
            Navigate(url);
            loginPage.DisplayedUserName();
            loginPage.UserName.SendKeys(username);
            loginPage.DisplayedPassword();
            loginPage.Password.SendKeys(password);
            loginPage.Login();

            Assert.True(loginPage.DisplayedLoginButton());

        }

        [Fact(DisplayName = "Checking if 3 items are succesfully added to the Basket")]

        public void When3ItemsAddedToTheBasket_checkItemsAreAdded()
        {

            ShouldSucesfullyLoginWhenEnteringRigtUsernamePasswordCombination();
            homePage.DisplayedBack();
            homePage.Backpack.Click();
            homePage.DisplayedBikeLight();
            homePage.BikeLight.Click();
            homePage.DisplayedTShirt();
            homePage.TShirt.Click();
            homePage.DisplayedShoppingCardLink();
            homePage.ShoppingCardLink.Click();

            Assert.Equal("3", homePage.ItemCounter.Text);
        }


        [Fact(DisplayName = "Once 3 items are added, remove all items from list, check if basket is empty and continue shopping")]

        public void AfterCheckingItemsAreAdded_RemoveItems_AndCheckIfBasketIsEmpty()
        {

            ShouldSucesfullyLoginWhenEnteringRigtUsernamePasswordCombination();
            homePage.DisplayedBack();
            homePage.Backpack.Click();
            homePage.DisplayedBikeLight();
            homePage.BikeLight.Click();
            homePage.DisplayedTShirt();
            homePage.TShirt.Click();
            homePage.DisplayedShoppingCardLink();
            homePage.ShoppingCardLink.Click();

            Assert.Equal("3", homePage.ItemCounter.Text);

            cart.DisplayedRemoveLabsBike();
            cart.Removesaucelabsbike.Click();
            cart.DisplayedRemoveLabsTshirt();
            cart.Removesaucelabstshirt.Click();
            cart.DisplayedRemoveLabsBackPack();
            cart.Removesaucelabsbackpack.Click();

            Assert.Empty(cart.Shoppingcardcontainer.Text);

            cart.DisplayedContinueShoppingButton();
            cart.ContinueShopping.Click();
        }

    }
}
