CREATE TABLE [dbo].competencyMatrix				
(
[RowId] INT  NOT NULL PRIMARY KEY IDENTITY(1, 1),
[AppraisalLevelId] [int] NOT NULL  CONSTRAINT fk_appraisalLvlId REFERENCES  AppraisalLevel(RowId),
CompetencyID VARCHAR(50) NOT NULL,
CompetencyWeight INT NOT NULL,
CompetencyKeyID VARCHAR(50) NOT NULL,
CompetencyKeyWeight INT NOT NULL,
[createdBy] [int] NOT NULL,
[createdDate] [datetime] NOT NULL,
[modifiedBy] [int] NULL,
[modifiedDate] [datetime] NULL
) ON [PRIMARY]
GO

