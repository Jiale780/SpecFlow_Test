Feature: EmployeeFeature
	As a TurnUp Portal admin
	I would like to create, edit and delete employee records
	So that I manage employee record successfully

@tmtest @regression
Scenario: 01 create employee record with valid details 
	Given I logged into turn up portal of employee page successfully
	And I navigate to employee page
	When I create employee record
	Then the employee record should be created successfully

@tmtest @regression
Scenario Outline: 02 edit employee record with valid details 
	Given I logged into turn up portal of employee page successfully
	And I navigate to employee page
	When I update '<Name>', '<UserName>' on an time and material record
	Then the record should have the updated '<Name>', '<UserName>' successfully

	Examples: 
	| Name      | UserName |
	| Fay Adios | Fay      |
	| Fin Adios | Fin      |

@tmtest @regression
Scenario: 03 delete employee record with valid details 
	Given I logged into turn up portal of employee page successfully
	And I navigate to employee page
	When I delete on an employee record
	Then the employee record should be deleted successfully