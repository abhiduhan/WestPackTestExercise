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
    public sealed class VotingStepDef
    {
        private string uniqueMessage = Guid.NewGuid().ToString();
        private PopularModelPage _popularModelPage;
        public VotingStepDef()
        {
            _popularModelPage = new PopularModelPage(WebDriverManager.Driver);
        }

        

        [Given(@"select the popular model widget")]
        public void GivenSelectThePopularModelWidget()
        {
            _popularModelPage.ClickHomePage();
            _popularModelPage.ClickPopularModelLink();
        }

        [When(@"enter unique comment message")]
        public void WhenEnterUniqueCommentMessage()
        {
            _popularModelPage.EnterComment(uniqueMessage);
        }

        [When(@"click vote button")]
        public void WhenClickVoteButton()
        {
            _popularModelPage.ClickVote();
        }

        [Then(@"vote should be successfully posted and user is no longer able to vote again")]
        public void ThenVoteShouldBeSuccessfullyPostedAndUserIsNoLongerAbleToVoteAgain()
        {
            var result = _popularModelPage.IsCommented(uniqueMessage);
            Assert.IsTrue(result, "Comment is not posted successfully.");
        }

    }
}
