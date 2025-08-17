--DROP TABLE AppraisalMatrix

CREATE TABLE AppraisalMatrix
(
	rowId					INT		Primary Key	 IDENTITY(1,1)NOT NULL,
	appraisalId				INT						NOT NULL CONSTRAINT fk_appraisalInitation REFERENCES dbo.appraisalInitation(appraisalId)  ON DELETE CASCADE
																	ON UPDATE  NO ACTION,
	kraTopic				VARCHAR(100)			NOT NULL,
	kpiTopic				VARCHAR(100)			NOT NULL,
	kraWeightage			INT						NOT NULL,
	kpiWeightage			INT						NOT NULL,
	performanceAchievement	DECIMAL(10, 4)			NULL,
	performanceRemarks		VARCHAR(200)			NULL,
	variance				DECIMAL(10, 4) 			NULL,
	createdBy				INT						NOT NULL,
	createdDate				DATETIME				NOT NULL,
	modifiedBy				INT						NULL,
	modifiedDate			DATETIME				NULL
)



