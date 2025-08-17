
CREATE TABLE AppraisalLevel				
(
[RowId] INT  NOT NULL PRIMARY KEY IDENTITY(1, 1),
LevelName VARCHAR(50) NOT NULL,
Active CHAR(1) NOT NULL,
SessionId VARCHAR(50) NOT NULL,
[createdBy] INT  NOT NULL,
[createdDate] [DATETIME] NOT NULL,
[modifiedBy] [int]  NULL,
[modifiedDate] [datetime] NULL

) ON [PRIMARY]
GO






