using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;
using WestPackTestExercise.Drivers;

namespace WestPackTestExercise.Pages
{
    public class RegisterPage : BasePage
    {
        private By registerButton = By.XPath("//a[contains(text(), 'Register')]");
        private By loginField = By.Id("username");
        private By firstNameField = By.Id("firstName");
        private By lastNameField = By.Id("lastName");
        private By passwordField = By.Id("password");
        private By confirmPasswordField = By.Id("confirmPassword");
        private By submitRegisteration = By.XPath("//button[contains(text(), 'Register') and @type='submit']");
        private By registrationResultElement = By.XPath("//div[contains(@class, 'result')]");

        public RegisterPage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickRegisterButton()
        {
            Find(registerButton).Click();
        }

        public void FillLoginField(string input)
        {
            Find(loginField).SendKeys(input);
        }

        public void FillFirstNameField(string input)
        {
            Find(firstNameField).SendKeys(input);
        }

        public void FillLastNameField(string input)
        {
            Find(lastNameField).SendKeys(input);
        }

        public void FillPasswordField(string input)
        {
            Find(passwordField).SendKeys(input);
        }

        public void FillConfirmPasswordField(string input)
        {
            Find(confirmPasswordField).SendKeys(input);
        }

        public void SubmitRegistration()
        {
            WaitForVisible(submitRegisteration);
            Find(submitRegisteration).Click();
        }

        public string GetRegistrationResult()
        {
            WaitForVisible(registrationResultElement);
            return Find(registrationResultElement).Text;
        }
    }
}
