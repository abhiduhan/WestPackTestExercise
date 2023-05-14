using NUnit.Framework;
using TechTalk.SpecFlow;
using WestPackTestExercise.Drivers;
using WestPackTestExercise.Pages;

namespace WestPackTestExercise.Steps
{
    [Binding]
    public sealed class LoginScenarioStepDef
    {
        private readonly LoginPage _loginPage;

        public LoginScenarioStepDef()
        {
            _loginPage = new LoginPage(WebDriverManager.Driver);
        }

        [Given(@"user enter credentials as below")]
        public void GivenUserEnterCredentialsAsBelow(Table table)
        {
            var row = table.Rows[0];
            var username = row["Login"];
            var password = row["Password"];
            _loginPage.EnterUsername(username);
            _loginPage.EnterPassword(password);
        }

        [When(@"user press login button")]
        public void WhenUserPressLoginButton()
        {
            _loginPage.ClickLogin();
        }

        [Then(@"user is successfully login")]
        public void ThenUserIsSuccessfullyLogin()
        {
            var result = _loginPage.IsLoginSuccess();
            Assert.IsTrue(result, "Login was not a success.");
        }

    }
}
