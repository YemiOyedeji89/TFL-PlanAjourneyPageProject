# PlanAjourneyPageProject
This is a Test Automation Framework to test the UI functionalities of the TFL Website-Journey Planner Widget.
## What is the Purpose of the Journey Planner Widget?
This allows TFL customers to plan their Journey for "Now" or "Future" Journeys as required. It also as the capability of saving recent successful journeys planned to be easily accessed and edited if needed.
## How Does It Work?
* This works by setting a valid From and To place
* Setting to Leaving Now or Change Time, the arrival and depature time can be added as required.
* A successful planned journey will be displayed with fastest route options.
## Decisions made in the process of Development
* I decided to use Page Object Model to help reduce code duplication and enhancing test maintainace.
* The Plan a journey widget is accessed by navigating from the TFL homepage to the Plan a journey page where UI test will be carried out.
* I have added Hooks class to Help before each scenario to initialise the chrome driver, navigate to the TFL website and also to quit and dispose of the driver so that the browser closes correctly after each Scenario.
