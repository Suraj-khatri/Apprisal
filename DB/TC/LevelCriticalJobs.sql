CREATE TABLE [dbo].[LevelCriticalJobs]
(
[rowId] [int] NOT NULL IDENTITY(1, 1),
[appraisalLevelId] [int] NULL,
[Objectives] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DeductionScore] [int] NULL,
[createdBy] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[createdDate] [datetime] NULL,
[modifiedBy] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[modifiedDate] [datetime] NULL
) ON [PRIMARY]
GO


