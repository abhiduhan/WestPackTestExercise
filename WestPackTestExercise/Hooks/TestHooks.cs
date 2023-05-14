using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using WestPackTestExercise.Drivers;

namespace WestPackTestExercise.Hooks
{
    [Binding]
    public sealed class TestHooks
    {
       
        [BeforeScenario]
        public void BeforeScenario()
        {
            WebDriverManager.Driver.Navigate().GoToUrl("https://buggy.justtestit.org/");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            WebDriverManager.QuitDriver();
        }
    }
}
