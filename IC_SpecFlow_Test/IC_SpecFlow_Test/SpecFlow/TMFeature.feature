Feature: TMFeature
	As a TurnUp Portal admin
	I would like to create, edit and delete time and material records
	So that I manage employee time and materials successfully

@tmtest @regression
Scenario: 01 create time and material record with valid details 
	Given I logged into turn up portal successfully
	And I navigate to time and material page
	When I create time and material record
	Then the record should be created successfully

@tmtest @regression
Scenario Outline: 02 edit time and material record with valid details 
	Given I logged into turn up portal successfully
	And I navigate to time and material page
	When I update '<Code>', '<TypeCode>', '<Description>', '<Price>' on an time and material record
	Then the record should have the updated '<Code>', '<TypeCode>', '<Description>', '<Price>' successfully

	Examples: 
	| Code             | TypeCode | Description                 | Price  |
	| AutomatedScript  | T        | AutomatedScript             | 37.00  |
	| Automated Script | M        | Automated Script is changed | 170.00 |

@tmtest @regression
Scenario: 03 delete time and material record with valid details 
	Given I logged into turn up portal successfully
	And I navigate to time and material page
	When I delete on an time and material record
	Then the record should have the deleted successfully