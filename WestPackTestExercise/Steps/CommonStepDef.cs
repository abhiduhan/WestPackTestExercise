using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using WestPackTestExercise.Drivers;
using WestPackTestExercise.Pages;

namespace WestPackTestExercise.Steps
{
    [Binding]
    public sealed class CommonStepDef
    {
        private RegisterPage _registerPage;
        private LoginPage _loginPage;
        public CommonStepDef()
        {
            _registerPage = new RegisterPage(WebDriverManager.Driver);
            _loginPage = new LoginPage(WebDriverManager.Driver);
        }

        [Given(@"register and login as a new user")]
        public void GivenRegisterAndLoginAsANewUser()
        {
            var userName = Guid.NewGuid().ToString();
            var password = "Password1@";
            var firstName = Guid.NewGuid().ToString("N").Substring(0, 5);
            var lastName = Guid.NewGuid().ToString("N").Substring(0, 5);


            _registerPage.ClickRegisterButton();
            _registerPage.FillLoginField(userName);
            _registerPage.FillFirstNameField(firstName);
            _registerPage.FillLastNameField(lastName);
            _registerPage.FillPasswordField(password);
            _registerPage.FillConfirmPasswordField(password);
            _registerPage.SubmitRegistration();
            var result = _registerPage.GetRegistrationResult();
            Assert.AreEqual("Registration is successful", result, "Registration failed.");

            _loginPage.EnterUsername(userName);
            _loginPage.EnterPassword(password);
            _loginPage.ClickLogin();

        }
    }
}
