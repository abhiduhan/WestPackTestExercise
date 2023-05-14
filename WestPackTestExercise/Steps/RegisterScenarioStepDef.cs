using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using WestPackTestExercise.Drivers;
using WestPackTestExercise.Pages;

namespace WestPackTestExercise.Steps
{
    [Binding]
    public sealed class BuggyCarsStepDef
    {

        private readonly RegisterPage _registerPage;

        public BuggyCarsStepDef()
        {
            _registerPage = new RegisterPage(WebDriverManager.Driver);
        }

        [Given(@"user select the Register button")]
        public void GivenUserSelectTheRegisterButton()
        {
            _registerPage.ClickRegisterButton();
        }

        [Given(@"Complete form with following details")]
        public void GivenCompleteFormWithFollowingDetails(Table table)
        {
            var row = table.Rows[0];
            var login = row["Login"]+Guid.NewGuid();
            var firstName = row["First Name"];
            var lastName = row["Last Name"];
            var password = row["Password"];

            _registerPage.FillLoginField(login);
            _registerPage.FillFirstNameField(firstName);
            _registerPage.FillLastNameField(lastName);
            _registerPage.FillPasswordField(password);
            _registerPage.FillConfirmPasswordField(password);

        }

        [When(@"user submit registration")]
        public void WhenUserClickRegisterButton()
        {
            _registerPage.SubmitRegistration();
        }

        [Then(@"newly account is created and success message display")]
        public void ThenNewlyAccountIsCreatedAndSuccessMessageDisplay()
        {
            var result = _registerPage.GetRegistrationResult();
            Assert.AreEqual("Registration is successful", result);
        }

    }
}
