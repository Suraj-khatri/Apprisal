CREATE TABLE agreementComment				
(
[RowId] INT  NOT NULL PRIMARY KEY IDENTITY(1, 1),
appraisalId INT NOT NULL,
checked CHAR (1) NOT NULL,
commentBy INT NOT NULL,
commenterType VARCHAR(50)  NULL,
comment VARCHAR(500)  NULL,
createdBy INT NOT NULL,
[createdDate] [DATETIME] NOT NULL,
[modifiedBy] [int]  NULL,
[modifiedDate] [datetime] NULL

) ON [PRIMARY]
GO




