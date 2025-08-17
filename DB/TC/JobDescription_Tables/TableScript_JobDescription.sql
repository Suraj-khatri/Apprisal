CREATE TABLE jobDescription(
 rowId INT PRIMARY KEY IDENTITY(1,1)
,empId INT
,branchId INT
,functionId INT
,positionId INT
,supervisorId INT
,startDate DATE
,endDate DATE
,functionalObjectives VARCHAR(MAX)
,generalJD VARCHAR(MAX)
,servicesJD VARCHAR(MAX)
,keyCompetence VARCHAR(MAX)
,flag CHAR(2)
,createdBy INT
,createdDate DATE
)

CREATE TABLE jdDirectReports(
 rowId INT PRIMARY KEY IDENTITY(1,1)
,jdId INT
,drEmpId INT
,active Char(1)
,createdBy INT
,createdDate DATE)


CREATE TABLE temp_jobDesc(
ID INT PRIMARY KEY IDENTITY(1,1)
,rptStaffId INT
,createdBy INT)









