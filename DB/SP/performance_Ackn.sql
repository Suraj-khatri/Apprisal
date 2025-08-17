ALTER  PROC performance_Ackn
    @flag CHAR(10) ,
    @CreatedBy VARCHAR(30) = NULL ,
    @ModifiedBy VARCHAR(30) = NULL ,
    @rowId INT = NULL ,
    @commenterType VARCHAR(50) = NULL ,
    @comment VARCHAR(MAX) = NULL ,
    @checked CHAR(1) = NULL ,
    @user INT = NULL ,
    @empId INT = NULL,
	@appId INT = NULL
AS
    SET NOCOUNT ON;
    SET ANSI_NULLS ON;
    SET XACT_ABORT ON;
    BEGIN
	--DECLARE @appraId INT 
 --       SELECT  @appraId = appraisalId
 --       FROM    dbo.appraisalInitation WITH ( NOLOCK )
 --       WHERE   employeeId = @empId;
        IF @appId IS NULL
            BEGIN
                SELECT  '1' AS errorcode ,
                        'Please Select Employee' AS msg ,
                        NULL;
                RETURN;
            END;
        --IF @flag = 'Appr'
        --    BEGIN
			
        --        INSERT  INTO dbo.agreementComment
        --                ( appraisalId ,
        --                  checked ,
        --                  commentBy ,
        --                  commenterType ,
        --                  comment ,
        --                  createdBy ,
        --                  createdDate 
		      --          )
        --        VALUES  ( @appId ,
        --                  @checked ,
        --                  @user , -- commentBy - int
        --                  @commenterType , -- commenterType - varchar(2)
        --                  @comment , -- comment - varchar(500)
        --                  @user , -- createdBy - int
        --                  GETDATE()  -- createdDate - datetime
		            
		      --          );
        --        SELECT  '0' AS ErrorCode,NULL,NULL;
        --    END;
        --IF @flag = 'Ofcr'
        --    BEGIN
        --        INSERT  INTO dbo.agreementComment
        --                ( appraisalId ,
						  --checked,
        --                  commentBy ,
        --                  commenterType ,
        --                  comment ,
        --                  createdBy ,
        --                  createdDate 
			     --       )
        --        VALUES  ( @appId ,
				    --      @checked ,
        --                  @user , -- commentBy - int
        --                  @commenterType , -- commenterType - varchar(2)
        --                  @comment , -- comment - varchar(500)
        --                  @user , -- createdBy - int
        --                  GETDATE()  -- createdDate - datetime
			     --       );
        --      SELECT  '0' AS ErrorCode,NULL,NULL;
        --    END;
			
        IF @flag = 'HRD'
            BEGIN
                INSERT  INTO dbo.agreementComment
                        ( appraisalId ,
                          checked ,
                          commentBy ,
                          commenterType ,
                          comment ,
                          createdBy ,
                          createdDate
			            )
                VALUES  ( @appId , -- appraisalId - int
                          @checked ,
                          @user , -- commentBy - int
                          @commenterType , -- commenterType - varchar(2)
                          @comment , -- comment - varchar(500)
                          @user , -- createdBy - int
                          GETDATE() -- createdDate - datetime
			            );
                IF ( @commenterType = 'Supervisor' )
                    BEGIN
                        UPDATE  appraisalInitation
                        SET     STATUS = 'Processed'
                        WHERE   appraisalId = @appId;
                    END;
                IF ( @commenterType = 'Appraise' )
                    BEGIN
                        UPDATE  appraisalInitation
                        SET     STATUS = 'Agreed'
                        WHERE   appraisalId = @appId;
                    END;
                IF ( @commenterType = 'Reviewer' )
                    BEGIN
                        UPDATE  appraisalInitation
                        SET     STATUS = 'Reviewed'
                        WHERE   appraisalId = @appId;
                    END;
                IF ( @commenterType = 'HRD' )
                    BEGIN
                        UPDATE  appraisalInitation
                        SET     STATUS = 'Acknowledged'
                        WHERE   appraisalId = @appId;
                    END;

                SELECT  '0' AS ErrorCode ,
                        NULL ,
                        NULL;
            END;
        IF @flag = 'AckData'
            BEGIN
                SELECT  appraisalId ,
                        checked ,
                        commentBy ,
                        commenterType ,
                        comment ,
                        createdBy ,
                        createdDate
                FROM    dbo.agreementComment
                WHERE   appraisalId = @appId;
            END;
    END;
        