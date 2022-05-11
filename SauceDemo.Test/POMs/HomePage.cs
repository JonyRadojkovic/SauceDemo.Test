using OpenQA.Selenium;

namespace SauceDemo.Test.POMs
{
    public class HomePage
    {
        private IWebDriver driver { get; }

        public IWebElement Backpack => driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
        public IWebElement BikeLight => driver.FindElement(By.Id("add-to-cart-sauce-labs-bike-light"));
        public IWebElement TShirt => driver.FindElement(By.Id("add-to-cart-sauce-labs-bolt-t-shirt"));

        public IWebElement ShoppingCardLink => driver.FindElement(By.ClassName("shopping_cart_link"));
        public IWebElement ItemCounter => driver.FindElement(By.XPath("//div[@id='shopping_cart_container']/a/span"));

        public HomePage(IWebDriver idriver)
        {
            driver = idriver;
        }

        public bool DisplayedBack() => Backpack.Displayed;
        public bool DisplayedBikeLight() => BikeLight.Displayed;
        public bool DisplayedTShirt() => TShirt.Displayed;
        public bool DisplayedShoppingCardLink() => ShoppingCardLink.Displayed;
        public bool DisplayedItemCounter() => ItemCounter.Displayed;
    }
}
