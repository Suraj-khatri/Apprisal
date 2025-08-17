CREATE TABLE [dbo].AppraisalPosition				
(
[RowId] INT  NOT NULL PRIMARY KEY IDENTITY(1, 1),
[AppraisalLevelId] [int] NOT NULL  CONSTRAINT fk_appraisalId REFERENCES  AppraisalLevel(RowId),
PositionId INT NOT NULL CONSTRAINT fk_posId REFERENCES dbo.StaticDataDetail(ROWID),
[createdBy] [int] NOT NULL,
[createdDate] [datetime] NOT NULL,
[modifiedBy] [int] NULL,
[modifiedDate] [datetime] NULL
) ON [PRIMARY]
GO

