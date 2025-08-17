CREATE TABLE [dbo].[QuestionCntSetup]
(
[RowId] [bigint] NOT NULL PRIMARY KEY IDENTITY(1, 1),
[QuestionGroupId] VARCHAR(50) NOT NULL,
[maxNoOfQues] [int] NOT NULL,
[TotalWeightage ] [int] NULL,
[RatingCeiling] [float] NULL,
[createdBy] VARCHAR(MAX) NOT NULL,
[createdDate] [DATETIME] NOT NULL,
[modifiedBy] [int]  NULL,
[modifiedDate] [datetime] NULL

) 



