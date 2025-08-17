CREATE TABLE [dbo].[weightageDefination]
(
[RowId] INT  NOT NULL PRIMARY KEY IDENTITY(1, 1),
[AppraisalLevelId] [int] NOT NULL  CONSTRAINT fk_appraisalLevelId REFERENCES  AppraisalLevel(RowId),
[Kra] [int] NOT NULL,
[Competencies] [int] NOT NULL,
[createdBy] [int] NOT NULL,
[createdDate] [datetime] NOT NULL,
[modifiedBy] [int] NULL,
[modifiedDate] [datetime] NULL
) ON [PRIMARY]
GO

