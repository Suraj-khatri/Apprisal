ALTER PROC proc_assignReviewCommittee
    (
      @flag VARCHAR(20) ,
      @levelName VARCHAR(50) = NULL ,
      @empId VARCHAR(50) = NULL ,
      @sessionId VARCHAR(50) = NULL ,
      @user VARCHAR(50) = NULL ,
      @rowId INT = NULL ,
      @lRowId INT = NULL ,
      @active CHAR(1) = NULL
    )
AS
    SET XACT_ABORT ON;
    SET NOCOUNT ON;
    BEGIN 
        IF @flag = 'sartd'
            BEGIN
			 SELECT  R.RowId ,
                        E.FIRST_NAME+' '+E.MIDDLE_NAME+''+E.LAST_NAME AS EmployeeName,
                        R.AppraisalLevelId ,
                        R.Active ,
                        L.LevelName AS comMatrixName
                FROM    dbo.appReviewerList R ( NOLOCK )
                        INNER JOIN dbo.AppraisalLevel L ON L.RowId = R.AppraisalLevelId
						INNER JOIN dbo.Employee E ON E.EMPLOYEE_ID = R.EmployeeName
                WHERE   R.AppraisalLevelId = @lRowId
                        AND R.Active = 'Y';
            END;

        IF @flag = 'delAssignReview'
            BEGIN
            
                IF EXISTS ( SELECT  '1'
                            FROM    appReviewerList(NOLOCK)
                            WHERE   RowId = @rowId )
                    BEGIN
                        --DELETE  FROM tempAssignReviewerList
                        UPDATE  appReviewerList
                        SET     Active = 'N'
                        WHERE   RowId = @rowId;
                
                        SELECT  '0' AS code ,
                                'User  deactivated successfully' AS msg;
                        RETURN;
                    END;
                SELECT  '1' AS code ,
                        'Opps..Unable to delete' AS msg;
            END;

        IF @flag = 'saveCom'
            BEGIN
                IF EXISTS ( SELECT  'a'
                            FROM    dbo.appReviewerList(NOLOCK)
                            WHERE   AppraisalLevelId = @lRowId
                                    AND EmployeeName = @empId
                                    AND Active = 'N' )
                    BEGIN
                        UPDATE  dbo.appReviewerList
                        SET     Active = 'Y'
                        WHERE   AppraisalLevelId = @lRowId
                                    AND EmployeeName = @empId	
                        SELECT  '3' AS code ,
                                'User Activated Sucessfully ' AS msg;
                        RETURN;
                    END;
                IF EXISTS ( SELECT  'a'
                            FROM    dbo.appReviewerList(NOLOCK)
                            WHERE   AppraisalLevelId = @lRowId
                                    AND EmployeeName = @empId )
                    BEGIN
                        SELECT  '2' AS code ,
                                'Duplicate data cant be added ' AS msg;
                        RETURN;
                    END;

                IF NOT EXISTS ( SELECT  'a'
                                FROM    dbo.appReviewerList(NOLOCK)
                                WHERE   AppraisalLevelId = @lRowId
                                        AND EmployeeName = @empId )
                    BEGIN
                        INSERT  INTO dbo.appReviewerList
                                ( AppraisalLevelId ,
                                  EmployeeName ,
                                  Active ,
                                  createdBy ,
                                  createdDate 
					            )
                        VALUES  ( @lRowId , -- AppraisalLevelId - int
                                  @empId , -- EmployeeName - int
                                  @active , -- Active - char(1)
                                  @user , -- createdBy - int
                                  GETDATE()  -- createdDate - datetime
					            );
                        SELECT  '0' AS code ,
                                'Data saved successfully' AS msg;
                        RETURN;
                    END; 
                SELECT  '1' AS code ,
                        'Insert failed' AS msg;
            END;
			
    END;