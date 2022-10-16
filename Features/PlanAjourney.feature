Feature: PlanAjourney
As a tfl user, I want to be able to plan a journey using the tfl plan a journey widget on the tfl website.

#### VALID Journey Planner Scenarios ########


@PlanJourney
Scenario: Plan a journey now with valid data

	Given that I am on the tfl plan a journey page
	When I enter location
	| From                                    | To                                               |
	| Abbey Wood (London), Abbey Wood Station | Woolwich, Woolwich Arsenal national rail station |
	And I set the time leaving now 
	And I click on plan my journey tab
	Then I should be taken to the journey result page
	| From                                    | To                                               |
	| Abbey Wood (London), Abbey Wood Station | Woolwich, Woolwich Arsenal national rail station |
	

@PlanJourney
Scenario: Plan a future journey with valid data
 
Given that I am on the tfl plan a journey page
	When I enter location
	| From                                    | To                                               |
	| Abbey Wood (London), Abbey Wood Station | Woolwich, Woolwich Arsenal national rail station |
	And I select the date and time
	| Date       | Time  |
	| Tue 25 Oct | 17:45 |
	And I click on plan my journey tab
	Then I should be taken to the journey result date and time planned
	| DateAndTime             |
	| Tuesday 25th Oct, 17:45 |



@PlanJourney
Scenario:Test that recent plan journey are displayed correctly 
	
	Given that I am on the tfl plan a journey page
	When I enter location
	| From                                    | To                                               |
	| Abbey Wood (London), Abbey Wood Station | Woolwich, Woolwich Arsenal national rail station |
	
	And I select the date and time
	| Date       | Time  |
	| Tue 25 Oct | 17:45 |
	And I click Trun on recent journey
	And I click on plan my journey tab
	
	And I am on the Journey result page
	| DateAndTime             |
	| Tuesday 25th Oct, 17:45 |
	And I navigated back to the tfl plan a journey page 
	 
	Then I can see my journey planned in the Rescent tab 
	| RecentPlan                                                                                  |
	| Abbey Wood (London), Abbey Wood Station to Woolwich, Woolwich Arsenal national rail station |


@PlanJourney
Scenario: Test that a successful planned journey can be edited 
Given that I am on the tfl plan a journey page
	When I enter location
	| From                                    | To                                               |
	| Abbey Wood (London), Abbey Wood Station | Woolwich, Woolwich Arsenal national rail station |
	
	And I select the date and time
	| Date       | Time  |
	| Tue 25 Oct | 17:45 |
	
	And I click on plan my journey tab
	And I am on the Journey result page
	| DateAndTime             |
	| Tuesday 25th Oct, 17:45 |
	
	When I click Edit journey
	And I updated the location
	| From                                                 | To                                               |
	| North Greenwich, North Greenwich Underground Station | Woolwich, Woolwich Arsenal national rail station |
	
	And I click arriving
	And I updated the date and time
	| Date       | Time  |
	| Thu 10 Nov | 14:45 |

	And  I click on update journey tab
	Then I can see my planned journey updated in the Juorney Result Page
	| From                                                 | To                                               | DateAndTime              |
	| North Greenwich, North Greenwich Underground Station | Woolwich, Woolwich Arsenal national rail station | Thursday 10th Nov, 14:45 |
	

##### INVALID Journey Planner Scenarios ########

@PlanJourney
Scenario Outline: Plan a journey with invalid data
	Given that I am on the tfl plan a journey page
	When I enter location  from "<From>" and location to "<To>"
	And I set the date "<Date>" and time "<Time>"
	And I click arriving
	And  I click on plan my journey tab
	Then I should be taken to the journey result page section with location  from "<From>" and location to "<To>"
	And I should get an errorMessage "<ErrorMessage>"
Examples: 
| From                                                 | To                                               | Date       | Time  | ErrorMessage                                          |
| 123.1                                                | 6666                                             | Thu 10 Nov | 14:45 | Sorry, we can't find a journey matching your criteria |
| 333fff6666                                           | 6666hh7                                          | Thu 10 Nov | 14:45 | Sorry, we can't find a journey matching your criteria |
| gggggggggggggggggggggggg                             | zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz              | Thu 10 Nov | 14:45 | Sorry, we can't find a journey matching your criteria |



@PlanJourney
Scenario Outline: Plan a journey when the widget fields From and To are blank 
	Given that I am on the tfl plan a journey page
	When I enter from "<From>" and location to "<To>"
	When I set the date "<Date>" and time "<Time>"
	And I click arriving
	And  I click on plan my journey tab
	Then I should get field error message from "<FieldErrorMessageFrom>" and field error message to "<FieldErrorMessageTo>"
Examples: 
| From | To | Date       | Time  | FieldErrorMessageFrom       | FieldErrorMessageTo       |
|      |    | Thu 10 Nov | 14:45 | The From field is required. | The To field is required. |
