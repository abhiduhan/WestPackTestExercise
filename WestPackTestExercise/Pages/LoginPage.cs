using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace WestPackTestExercise.Pages
{
    public class LoginPage : BasePage
    {
        private By loginField = By.XPath("//input[@placeholder='Login']");
        private By passwordField = By.XPath("//input[@name='password']");
        private By loginButton = By.XPath("//button[@type='submit' and contains(text(), 'Login')]");
        private By logOutButton = By.XPath("//a[contains(text(), 'Logout')]");
        private By greetingBanner = By.XPath("//span[contains(text(), 'Hi')]");

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public void EnterUsername(string username)
        {
            Find(loginField).SendKeys(username);
        }

        public void EnterPassword(string pass)
        {
            Find(passwordField).SendKeys(pass);
        }

        public void ClickLogin()
        {
            Find(loginButton).Click();
        }

        public bool IsLoginSuccess()
        {
            WaitForVisible(logOutButton);
            if(Find(logOutButton).Displayed && Find(greetingBanner).Displayed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
