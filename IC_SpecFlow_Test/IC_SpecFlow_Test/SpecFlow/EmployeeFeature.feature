Feature: EmployeeFeature
	As a TurnUp Portal admin
	I would like to create, edit and delete employee records
	So that I manage employee record successfully

@tmtest @regression
Scenario Outline: 1. create employee record with valid details 
	Given I logged into turn up portal of employee page successfully
	And I navigate to employee page
	When I create '<Name>', '<UserName>' on an employee record
	Then the employee record should be created '<Name>', '<UserName>'

	Examples: 
	| Name      | UserName |
	| Fay Adios | Fay      |

@tmtest @regression
Scenario Outline: 2. edit employee record with valid details 
	Given I logged into turn up portal of employee page successfully
	And I navigate to employee page
	When I update '<Name>', '<UserName>' on an employee record
	Then the employee record should have the updated '<Name>', '<UserName>'

	Examples: 
	| Name      | UserName |
	| Fin Adios | Fin      |

@tmtest @regression
Scenario Outline: 3. delete employee record with valid details 
	Given I logged into turn up portal of employee page successfully
	And I navigate to employee page
	When I delete on an employee record
	Then the employee record should be deleted successfully