Feature: Number Calculator
	Users can add / subtract / multiply / delete two numbers using the Calculator Web app:
	https://js-calculator.nakov.repl.co, from the [Number Calculator] tab.

Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120

Scenario: Subtract two numbers
	Given the first number is 150
	And the second number is 70
	When the two numbers are subtracted
	Then the result should be 80

Scenario: Multiply two numbers
	Given the first number is 5
	And the second number is 7
	When the two numbers are multiplied
	Then the result should be 35

Scenario: Divide two numbers
	Given the first number is 15
	And the second number is 3
	When the two numbers are divided
	Then the result should be 5

Scenario: Invalid input
	Given the first number is asfd
	And the second number is ddfg
	When the two numbers are added
	Then the result should be invalid input