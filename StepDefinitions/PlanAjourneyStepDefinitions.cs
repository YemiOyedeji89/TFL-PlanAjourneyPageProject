using BoDi;
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
        public PlanAjourneyStepDefinitions(IWebDriver? _driver)
        {
            this.driver = _driver;

        }
       // PlanAJourneyHomePage planAJourney = new PlanAJourneyHomePage();
     

        [Given(@"that I am on the tfl plan a journey page")]
        public void GivenThatIAmOnTheTflPlanAJourneyPage()
        {
            Tfl_HomePage TflHomepg = new Tfl_HomePage(driver);
            TflHomepg.PlanAjourneyPage();
        }

        [When(@"I enter location")]
        [Obsolete]
        public void WhenIEnterLocation(Table table)
        {
            PlanAJourneyWidget SearchFromToTxtBox = new PlanAJourneyWidget(driver);

            SearchFromToTxtBox.SearchBoxFromTo(table.Rows[0]["From"], table.Rows[0]["To"]);
        }

        [When(@"I select the date and time")]
       
        public void WhenISelectTheDate(Table table)
        {
            PlanAJourneyWidget DateTimeSelected = new PlanAJourneyWidget(driver);
            DateTimeSelected.SelectDateAndTime(table.Rows[0]["Date"], table.Rows[0]["Time"]);
        }

        [When(@"I click Trun on recent journey")]
        public void WhenIHaveClickTrunOnRecentJourney()
        {
            PlanAJourneyHomePage planAJourney = new PlanAJourneyHomePage(driver);
            planAJourney.TurnOnRecentJourney();
        }

        [When(@"I set the time leaving now")]
        public void WhenISetTheTimeLeavingNow()
        {
            PlanAJourneyWidget SelectLeavingNow = new PlanAJourneyWidget(driver);
            SelectLeavingNow.LeavingNow();
        }

        [When(@"I click on plan my journey tab")]
        public void WhenIClickOnPlanMyJourneyTab()
        {
            PlanAJourneyWidget PlanJourneyTab = new PlanAJourneyWidget(driver);
            PlanJourneyTab.PlanMyJourneyTab();
        }

        [Then(@"I should be taken to the journey result page")]
        [Obsolete]
        public void ThenIShouldBeTakenToTheJourneyResultPage(Table table)
        {
            JourneyResultPage JourneyResultPageSection = new JourneyResultPage(driver);
            JourneyResultPageSection.JourneyResultPagePlan(table.Rows[0]["From"],table.Rows[0]["To"]);
        }

        [Then(@"I should be taken to the journey result date and time planned")]
        [Obsolete]
        public void ThenIShouldBeTakenToTheJourneyResultDateAndTimePlanned(Table table)
        {
            JourneyResultPage JourneyResultTimePlanned = new JourneyResultPage(driver);
            JourneyResultTimePlanned.JourneyTimePlanned(table.Rows[0]["DateAndTime"]);
        }

        [When(@"I am on the Journey result page")]
        [Obsolete]
        public void WhenIAmOnTheJourneyResultPage(Table table)
        {
            JourneyResultPage JourneyTime = new JourneyResultPage(driver);
            JourneyTime.JourneyTimePlanned(table.Rows[0]["DateAndTime"]);
        }

        [When(@"I navigated back to the tfl plan a journey page")]
        [Obsolete]
        public void WhenINavigatedBackToTheTflPlanAJourneyPage()
        {
            JourneyResultPage NavigateToJourneyPlanPg = new JourneyResultPage(driver);
            NavigateToJourneyPlanPg.NavigateBackToJourneyPlannerPage();
        }

        [Then(@"I can see my journey planned in the Rescent tab")]
        [Obsolete]
        public void ThenIAnSeeMyJourneyPlannedInTheRescentTab(Table table)
        {
            PlanAJourneyHomePage planAJourney = new PlanAJourneyHomePage(driver);
            planAJourney.RecentJourneyTabDisplayed(table.Rows[0]["RecentPlan"]);
        }

        [When(@"I click Edit journey")]
        [Obsolete]
        public void WhenIClickEditJourney()
        {
            JourneyResultPage EditJourneyLink = new JourneyResultPage(driver);
            EditJourneyLink.EditJourney();
        }

        [When(@"I updated the location")]
        public void WhenIUpdatedTheLocation(Table table)
        {
            EditJourneyPage EditLocationPage = new EditJourneyPage(driver);
            EditLocationPage.EditLocation(table.Rows[0]["From"], table.Rows[0]["To"]);
        }

        [When(@"I click arriving")]
        public void WhenIClickArriving()
        {
            EditJourneyPage SelectArriving = new EditJourneyPage(driver);
            SelectArriving.ArrivingBox();
        }

        [When(@"I updated the date and time")]
        public void WhenIUpdatedTheDateAndTime(Table table)
        {
            EditJourneyPage UpdateDateTime = new EditJourneyPage(driver);
            UpdateDateTime.UpdatedTheDateAndTime(table.Rows[0]["Date"], table.Rows[0]["Time"]);
        }

        [When(@"I click on update journey tab")]
        public void WhenIClickOnUpdateJourneyTab()
        {
            EditJourneyPage UpdatejourneyBtn = new EditJourneyPage(driver);
            UpdatejourneyBtn.ClickUpdateJourneyButton();
        }
        
        [Then(@"I can see my planned journey updated in the Juorney Result Page")]
        [Obsolete]
        public void ThenICanSeeMyPlannedJourneyUpdatedInTheJuorneyResultPage(Table table)
        {
            JourneyResultPage UpdateResult = new JourneyResultPage(driver);
            UpdateResult.UpdatedJourneyResultPage(table.Rows[0]["From"], table.Rows[0]["To"], table.Rows[0]["DateAndTime"]);
        }
         
        [When(@"I enter location  from ""([^""]*)"" and location to ""([^""]*)""")]
        [Obsolete]
        public void WhenIEnterLocationFromAndLocationTo(string From, string To)
        {
            PlanAJourneyWidget FromToFields = new PlanAJourneyWidget(driver);
            FromToFields.SearchBoxFromTo(From, To);
        }

        [When(@"I set the date ""([^""]*)"" and time ""([^""]*)""")]
        public void WhenISetTheDateAndTime(string Date, string Time)
        {
            PlanAJourneyWidget DateTimeSelect = new PlanAJourneyWidget(driver);
            DateTimeSelect.SelectDateAndTime(Date, Time);
        }

        [Then(@"I should be taken to the journey result page section with location  from ""([^""]*)"" and location to ""([^""]*)""")]
        public void ThenIShouldBeTakenToTheJourneyResultPageSectionWithLocationFromAndLocationTo(string From, string To)
        {
            JourneyResultPage ResultPageSection = new JourneyResultPage(driver);
            ResultPageSection.JourneyResulPageSection(From, To);
        }

        [Then(@"I should get an errorMessage ""([^""]*)""")]
        public void ThenIShouldGetAnErrorMessage(string ErrorMessage)
        {
            PlanAJourneyWidget ErrorMessages = new PlanAJourneyWidget(driver);
            ErrorMessages.ErrorMessageDisplayed(ErrorMessage);
        }

        [When(@"I enter from ""([^""]*)"" and location to ""([^""]*)""")]
        public void WhenIEnterFromAndLocationTo(string To, string From)
        {
            PlanAJourneyWidget BlankFields = new PlanAJourneyWidget(driver);
            BlankFields.BlankFromAndTo(From,To);
        }

        [Then(@"I should get field error message from ""([^""]*)"" and field error message to ""([^""]*)""")]
        public void ThenIShouldGetFieldErrorMessageFromAndFieldErrorMessageTo(string FieldErrorMessageFrom, string FieldErrorMessageTo)
        {
            PlanAJourneyWidget FieldValidationError = new PlanAJourneyWidget(driver);
            FieldValidationError.FromToFieldValidationError(FieldErrorMessageFrom, FieldErrorMessageTo);
        }

    }
}

