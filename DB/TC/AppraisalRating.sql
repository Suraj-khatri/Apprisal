--drop TABLE AppraisalRating
CREATE TABLE AppraisalRating				
(
RowId INT  NOT NULL PRIMARY KEY IDENTITY(1, 1),
MatrixType VARCHAR(3) NOT NULL,
MatrixId INT NOT NULL ,
AppraisalId INT NOT NULL,
Score FLOAT  NULL,
Remarks VARCHAR(200)  NULL,
Status VARCHAR(5) NOT NULL,
Ratingby INT NOT NULL,
RatingDate DATETIME NOT NULL,
)



