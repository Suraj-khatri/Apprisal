CREATE TABLE ProposedTraining
    (
      RowId INT PRIMARY KEY
                IDENTITY(1, 1)
                NOT NULL ,
      AppraisalId INT
        NOT NULL
        CONSTRAINT fk_pro_appraisalId
        FOREIGN KEY REFERENCES dbo.appraisalInitation ( appraisalId ) ON DELETE CASCADE
        ON UPDATE NO ACTION ,
      ProposedTrainingArea VARCHAR(100) NOT NULL ,
	  PerformanceAfterTraining INT  NULL,
      Criticality INT NOT NULL ,
      ProposedByDate DATE NOT NULL ,
      Remarks VARCHAR(MAX) NULL ,
      CreatedBy INT NOT NULL ,
      CreatedDate DATETIME NOT NULL ,
      ModifiedBy INT NULL ,
      ModifiedDate DATETIME NULL
    );	
--drop table ProposedTraining

	
