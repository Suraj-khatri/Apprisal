CREATE TABLE [dbo].appReviewerList				
(
[RowId] INT  NOT NULL PRIMARY KEY IDENTITY(1, 1),
[AppraisalLevelId] [int] NOT NULL  CONSTRAINT fk_apprsieId REFERENCES  AppraisalLevel(RowId),
EmployeeName INT NOT NULL,
Active CHAR(1) NOT NULL,
[createdBy] [int] NOT NULL,
[createdDate] [datetime] NOT NULL,
[modifiedBy] [int] NULL,
[modifiedDate] [datetime] NULL
) ON [PRIMARY]
GO

