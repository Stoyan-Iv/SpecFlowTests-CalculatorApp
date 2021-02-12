Feature: Metric Calculator
	Users can convert between metrics using the Calculator Web app:
	https://js-calculator.nakov.repl.co, from the [Metric Calculator] tab
	(e.g. conver 5.3 meters to centimeters).

Scenario: Convert meters to centimeters
	Given the  number is 10
	And the first metric is meters
	And the second metric is centimeters
	When the metrics are converted
	Then the result should be 1000


Scenario: Convert kilemeters to meters
	Given the  number is 15
	And the first metric is kilometers
	And the second metric is meters
	When the metrics are converted
	Then the result should be 15000


Scenario: Convert centimeters to milimeters
	Given the  number is 1
	And the first metric is centimeters
	And the second metric is milimeters
	When the metrics are converted
	Then the result should be 10


Scenario: Convert milimeters to meters
	Given the  number is 1000
	And the first metric is milimeters
	And the second metric is meters
	When the metrics are converted
	Then the result should be 1

Scenario: Invalid input
	Given the  number is fdsf
	And the first metric is meters
	And the second metric is centimeters
	When the metrics are converted
	Then the result should be invalid input