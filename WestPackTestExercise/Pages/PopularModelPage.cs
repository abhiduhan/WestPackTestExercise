using OpenQA.Selenium;

namespace WestPackTestExercise.Pages
{
    public class PopularModelPage : BasePage
    {
        private By homePage = By.XPath("//a[contains(text(), 'Buggy Rating')]");
        private By popularModelLink = By.XPath("//img[@title='Guilia Quadrifoglio']/parent::a");
        private By commentSection = By.Id("comment");
        private By voteButton = By.XPath("//button[contains(text(), 'Vote!')]");

        public PopularModelPage(IWebDriver driver) : base(driver)
        {
        }

        public void EnterComment(string comment)
        {
            WaitForVisible(commentSection);
            Find(commentSection).SendKeys(comment);
        }

        public void ClickVote()
        {
            Find(voteButton).Click();
        }

        public bool IsCommented(string comment)
        {
            WaitForVisible(By.XPath($"//table//td[contains(text(), '{comment}')]"));
            return Find(By.XPath($"//table//td[contains(text(), '{comment}')]")).Displayed;
        }

        public void ClickHomePage()
        {
            Find(homePage).Click();
        }

        public void ClickPopularModelLink()
        {
            WaitForVisible(popularModelLink);
            Find(popularModelLink).Click();
        }


    }
}
