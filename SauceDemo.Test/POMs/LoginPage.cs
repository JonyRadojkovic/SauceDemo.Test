using OpenQA.Selenium;

namespace SauceDemo.Test.POMs
{
    public class LoginPage
    {
        private IWebDriver driver { get; }
        public IWebElement UserName => driver.FindElement(By.Id("user-name"));
        public IWebElement Password => driver.FindElement(By.Id("password"));
        public IWebElement LoginButton => driver.FindElement(By.Id("login-button"));

        public LoginPage(IWebDriver _driver)
        {
            driver = _driver;
        }

        public void Login() => LoginButton.Click();

        public bool DisplayedUserName() => UserName.Displayed;
        public bool DisplayedPassword() => Password.Displayed;

        public bool DisplayedLoginButton() => LoginButton.Displayed;
    }
}
