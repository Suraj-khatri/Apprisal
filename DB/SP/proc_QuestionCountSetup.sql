ALTER PROC proc_QuestionCountSetup
	@flag							CHAR(10) = NULL,
	@QstnType						VARCHAR(50) = NULL,
	@NoOfQstn						INT = NULL,
	@TotalWeightage					FLOAT = NULL, 
	@RatingCeiling					FLOAT  = NULL, 
	@CreatedBy						VARCHAR(MAX) = NULL,
	@ModifiedBy						VARCHAR(MAX)=NULL,
	@rowId							INT = NULL

	AS 
SET NOCOUNT ON;
SET ANSI_NULLS ON;
SET XACT_ABORT ON;
BEGIN
	  IF	@flag = 'qsnCount'
	  BEGIN
			IF EXISTS ( SELECT    'A'
						FROM      dbo.QuestionCntSetup
						WHERE     QuestionGroupId = @QstnType )
			BEGIN
				SELECT  'Duplicate' AS msg;
				RETURN;
			END; 
			ELSE
			BEGIN
				INSERT  INTO QuestionCntSetup
						( QuestionGroupId ,
							maxNoOfQues ,
							TotalWeightage ,
							RatingCeiling ,
							createdBy ,
							createdDate
										
						)
						SELECT  @QstnType ,
								@NoOfQstn ,
								@TotalWeightage ,
								@RatingCeiling ,
								@CreatedBy ,
								GETDATE();	
												
				SELECT  'SUCCESS' AS msg;						
												
			END;
	  END
      

			IF @flag = 'update'
			BEGIN
				
				UPDATE dbo.QuestionCntSetup SET
												 maxNoOfQues	=	@NoOfQstn		
												,TotalWeightage	=	@TotalWeightage
												,RatingCeiling	=	@RatingCeiling	
												,@ModifiedBy    =   @ModifiedBy
												,createdDate	=	GETDATE()	
													WHERE RowId = @rowId
				SELECT 'SUCCESS' AS msg
			END

			IF @flag = 'grid'
				BEGIN
				    SELECT RowId, QuestionGroupId, maxNoOfQues, TotalWeightage, RatingCeiling FROM QuestionCntSetup
				END

			IF @flag = 'del'
				BEGIN
				    DELETE FROM QuestionCntSetup WHERE RowId = @rowId
				END
END