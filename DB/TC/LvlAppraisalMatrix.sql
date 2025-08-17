CREATE TABLE LvlAppraisalMatrix
(
	rowId			INT		Primary Key	 IDENTITY(1,1)NOT NULL,
	levelId		    INT	NOT NULL CONSTRAINT fk_lvlAppraisalMatrix REFERENCES dbo.AppraisalLevel(RowId),
	kraTopic		VARCHAR(100)	NOT NULL,
	kpiTopic		VARCHAR(100)	NOT NULL,
	kraWeightage	INT				NOT NULL,
	kpiWeightage	INT				NOT NULL,
	createdBy		INT				NOT NULL,
	createdDate		DATETIME		NOT NULL,
	modifiedBy		INT				NULL,
	modifiedDate	DATETIME		NULL
)
