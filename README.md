# DotNetBootcamp.EF.LabExercise2

## Input: Employee Code
1. If employee found
  - Employee Code
  - First Name
  - Last Name
  - Position (Textual Description)
  - List
    - Annual Salary
    - Monthly Salary
    - Skill
2. If employee not found
  - Display employee not found
```
SELECT 
	cEmployeeCode,
	vFirstName, 
	vLastName,
	dBirthDate,
	cCurrentPosition
FROM 
	Employee
WHERE 
	cEmployeeCode = '000001';
```
```
SELECT TOP 1 vDescription 
FROM Position 
WHERE cPositionCode = '0001';

SELECT
	mAnnualSalary,
	siYear
FROM
	AnnualSalary
WHERE
	cEmployeeCode = '000001';
```
```
SELECT
	mMonthlySalary,
	dPayDate,
	mReferralBonus
FROM
	MonthlySalary
WHERE
	cEmployeeCode = '000001';
```
```
SELECT
	es.cEmployeeCode,
	s.vSkill
FROM
	EmployeeSkill es
		JOIN Skill s ON es.cSkillCode = s.cSkillCode
WHERE
	cEmployeeCode = '000001';
```


