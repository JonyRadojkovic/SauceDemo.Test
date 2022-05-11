using OpenQA.Selenium;

namespace SauceDemo.Test.POMs
{
    public class Cart
    {

        private IWebDriver driver { get; }

        public IWebElement Removesaucelabsbike => driver.FindElement(By.Id("remove-sauce-labs-bike-light"));
        public IWebElement Removesaucelabstshirt => driver.FindElement(By.Id("remove-sauce-labs-bolt-t-shirt"));

        public IWebElement Removesaucelabsbackpack => driver.FindElement(By.Id("remove-sauce-labs-backpack"));

        public IWebElement Shoppingcardcontainer => driver.FindElement(By.XPath("//div[@id='shopping_cart_container']/a"));

        public IWebElement ContinueShopping => driver.FindElement(By.Id("continue-shopping"));
        public Cart(IWebDriver bDriver)
        {
            driver = bDriver;
        }

        public bool DisplayedRemoveLabsBike() => Removesaucelabsbike.Displayed;
        public bool DisplayedRemoveLabsTshirt() => Removesaucelabstshirt.Displayed;
        public bool DisplayedRemoveLabsBackPack() => Removesaucelabsbackpack.Displayed;
        public bool DisplayedShoppingCardContainer() => Shoppingcardcontainer.Displayed;
        public bool DisplayedContinueShoppingButton() => ContinueShopping.Displayed;


    }
}
