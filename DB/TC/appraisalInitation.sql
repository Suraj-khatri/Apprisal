CREATE TABLE appraisalInitation(
	appraisalId INT IDENTITY(1,1) PRIMARY KEY CONSTRAINT pk_appInitation NOT NULL,
	employeeId INT NOT NULL,
	currBranchId INT NOT NULL,
	currDeptId INT NOT NULL,
	currentSubUnit INT NULL,
	currPosition INT NOT NULL,
	currFuncTitle INT NOT NULL,
	joiningDate DATE NOT NULL,
	confirmationDate DATE NOT NULL,
	lastPromotionDate DATE NULL,
	lastTransferDate DATE NULL,
	appraisalStartDate DATE NOT NULL,
	appraisalEndDate DATE NOT NULL,
	supervisorId INT NOT NULL,
	reviewerId INT NOT NULL,
	currSubDeptId INT NULL,
	currSubDeptId2 INT NULL,
	[STATUS] VARCHAR(25) NULL,
	createdBy INT NOT NULL,
	createdDate DATETIME NOT NULL,
	modifiedBy INT NULL,
	modifiedDate DATETIME NULL

)



