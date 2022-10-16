using Docker.DotNet.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using PlanAjourneyPageProject.Pages;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace PlanAjourneyPageProject.StepDefinitions
{
    [Binding]
    public class PlanAjourneyStepDefinitions 
    {
        IWebDriver? driver;

        PlanAJourneyHomePage planAJourney = new PlanAJourneyHomePage();


        [Given(@"that I am on the tfl plan a journey page")]
        public void GivenThatIAmOnTheTflPlanAJourneyPage()
        {
            planAJourney.PlanAjourneyPage();
        }

        [When(@"I enter location")]
        [Obsolete]
        public void WhenIEnterLocation(Table table)
        {
            planAJourney.SearchBoxFromTo(table.Rows[0]["From"], table.Rows[0]["To"]);
        }

        [When(@"I select the date and time")]
       
        public void WhenISelectTheDate(Table table)
        {
            planAJourney.SelectDateAndTime(table.Rows[0]["Date"], table.Rows[0]["Time"]);
        }

        [When(@"I click Trun on recent journey")]
        public void WhenIHaveClickTrunOnRecentJourney()
        {
            planAJourney.TurnOnRecentJourney();
        }

        [When(@"I set the time leaving now")]
        public void WhenISetTheTimeLeavingNow()
        {
            planAJourney.LeavingNow();
        }

        [When(@"I click on plan my journey tab")]
        public void WhenIClickOnPlanMyJourneyTab()
        {
            planAJourney.PlanMyJourneyTab();
        }

        [Then(@"I should be taken to the journey result page")]
        [Obsolete]
        public void ThenIShouldBeTakenToTheJourneyResultPage(Table table)
        {
            planAJourney.JourneyResultPage(table.Rows[0]["From"],table.Rows[0]["To"]);
        }

        [Then(@"I should be taken to the journey result date and time planned")]
        [Obsolete]
        public void ThenIShouldBeTakenToTheJourneyResultDateAndTimePlanned(Table table)
        {
            planAJourney.JourneyTimePlanned(table.Rows[0]["DateAndTime"]);
        }

        [When(@"I am on the Journey result page")]
        [Obsolete]
        public void WhenIAmOnTheJourneyResultPage(Table table)
        {
            planAJourney.JourneyTimePlanned(table.Rows[0]["DateAndTime"]);
        }

        [When(@"I navigated back to the tfl plan a journey page")]
        public void WhenINavigatedBackToTheTflPlanAJourneyPage()
        {
            planAJourney.NavigateBackToJourneyPlannerPage();
        }

        [Then(@"I can see my journey planned in the Rescent tab")]
        public void ThenIAnSeeMyJourneyPlannedInTheRescentTab(Table table)
        {
            planAJourney.RecentJourneyTabDisplayed(table.Rows[0]["RecentPlan"]);
        }

        [When(@"I click Edit journey")]
        [Obsolete]
        public void WhenIClickEditJourney()
        {
            planAJourney.EditJourney();
        }

        [When(@"I updated the location")]
        public void WhenIUpdatedTheLocation(Table table)
        {
            planAJourney.EditLocation(table.Rows[0]["From"], table.Rows[0]["To"]);
        }

        [When(@"I click arriving")]
        public void WhenIClickArriving()
        {
            planAJourney.ArrivingBox();
        }

        [When(@"I updated the date and time")]
        public void WhenIUpdatedTheDateAndTime(Table table)
        {
            planAJourney.UpdatedTheDateAndTime(table.Rows[0]["Date"], table.Rows[0]["Time"]);
        }

        [When(@"I click on update journey tab")]
        public void WhenIClickOnUpdateJourneyTab()
        {
            planAJourney.ClickUpdateJourneyButton();
        }
        
        [Then(@"I can see my planned journey updated in the Juorney Result Page")]
        public void ThenICanSeeMyPlannedJourneyUpdatedInTheJuorneyResultPage(Table table)
        {
            planAJourney.UpdatedJourneyResultPage(table.Rows[0]["From"], table.Rows[0]["To"], table.Rows[0]["DateAndTime"]);
        }

        [When(@"I enter location  from ""([^""]*)"" and location to ""([^""]*)""")]
        [Obsolete]
        public void WhenIEnterLocationFromAndLocationTo(string From, string To)
        {
            planAJourney.SearchBoxFromTo(From, To);
        }

        [When(@"I set the date ""([^""]*)"" and time ""([^""]*)""")]
        public void WhenISetTheDateAndTime(string Date, string Time)
        {
            planAJourney.SelectDateAndTime(Date, Time);
        }

        [Then(@"I should be taken to the journey result page section with location  from ""([^""]*)"" and location to ""([^""]*)""")]
        public void ThenIShouldBeTakenToTheJourneyResultPageSectionWithLocationFromAndLocationTo(string From, string To)
        {
            planAJourney.JourneyResulPageSection(From, To);
        }

        [Then(@"I should get an errorMessage ""([^""]*)""")]
        public void ThenIShouldGetAnErrorMessage(string ErrorMessage)
        {
            planAJourney.ErrorMessageDisplayed(ErrorMessage);
        }

        [When(@"I enter from ""([^""]*)"" and location to ""([^""]*)""")]
        public void WhenIEnterFromAndLocationTo(string To, string From)
        {
            planAJourney.BlankFromAndTo(From,To);
        }

        [Then(@"I should get field error message from ""([^""]*)"" and field error message to ""([^""]*)""")]
        public void ThenIShouldGetFieldErrorMessageFromAndFieldErrorMessageTo(string FieldErrorMessageFrom, string FieldErrorMessageTo)
        {
            planAJourney.FromToFieldValidationError(FieldErrorMessageFrom, FieldErrorMessageTo);
        }

    }
}

