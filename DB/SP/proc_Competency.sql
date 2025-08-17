ALTER PROC proc_Competency
    (
      @flag VARCHAR(20) ,
      @comMatrixName VARCHAR(50) = NULL ,
      @position VARCHAR(10) = NULL ,
      @sessionId VARCHAR(50) = NULL ,
      @user VARCHAR(50) = NULL ,
      @rowId VARCHAR(20) = NULL ,
	  @LrowId INT =NULL,
      @active CHAR(1) = NULL
    )
AS
    SET XACT_ABORT ON;
    SET NOCOUNT ON;
    BEGIN
        IF OBJECT_ID('dbo.tempCompetency') IS NULL
            BEGIN
                CREATE TABLE tempCompetency
                    (
                      id INT IDENTITY(1, 1) ,
                      comMatrixName VARCHAR(50) ,
                      position VARCHAR(10) ,
                      sessionID VARCHAR(50)
                    );
            END;
   IF @flag = 'addCom'
            BEGIN
                IF NOT EXISTS ( SELECT  'a'
                                FROM    dbo.tempCompetency(NOLOCK)
                                WHERE   position = @position
                                        AND sessionID = @sessionId AND comMatrixName=@comMatrixName)
                    BEGIN
						IF	NOT EXISTS(SELECT 'a' FROM AppraisalPosition(NOLOCK) WHERE PositionId = @position)
						BEGIN
						    INSERT  INTO tempCompetency
                                ( comMatrixName ,
                                  position ,
                                  sessionID ,
                                  status
                                )
							VALUES  ( @comMatrixName ,
									  @position , -- @position - varchar(10)
									  @sessionId ,
									  @active
									); 
							SELECT  '0' AS code ,
									'Position added successfully' AS msg;
							RETURN;
						END
                         SELECT  '1' AS code ,
                        'Position already added to another level' AS msg;
						RETURN;
                    END;
                SELECT  '1' AS code ,
                        'Position already added' AS msg;
                RETURN;
               
            END;
            
       IF @flag = 'sud'
            BEGIN
                SELECT  t.id ,
                        t.comMatrixName ,
                        s.DETAIL_TITLE ,
                        t.status
                FROM    tempCompetency t ( NOLOCK )
                        INNER JOIN StaticDataDetail s ( NOLOCK ) ON t.position = s.ROWID
                WHERE   t.sessionID = @sessionId AND t.comMatrixName = @comMatrixName
            END;
            
        IF @flag = 'saveCom'
            BEGIN
                IF NOT EXISTS ( SELECT  'a'
                                FROM    dbo.AppraisalLevel(NOLOCK)
                                WHERE   LevelName = @comMatrixName )
                    BEGIN
                        IF ( ( SELECT   COUNT(*)
                               FROM     dbo.tempCompetency WITH ( NOLOCK )
                             ) <> 0 )
                            BEGIN
                                DECLARE @NewID INT;
                                INSERT  INTO AppraisalLevel
                                        ( LevelName ,
                                          Active ,
                                          SessionId ,
                                          createdBy ,
                                          createdDate
                                        )
                                        SELECT  @comMatrixName ,
                                                @active ,
                                                @sessionId ,
                                                @user ,
                                                GETDATE();
                                        --FROM    dbo.tempCompetency(NOLOCK)
                                        --WHERE   sessionID = @sessionId; 
                                SELECT  @NewID = SCOPE_IDENTITY();
                                INSERT  INTO AppraisalPosition
                                        ( AppraisalLevelId ,
                                          PositionId ,
                                          createdBy ,
                                          createdDate
										)
                                        SELECT  @NewID ,
                                                position ,
                                                @user ,
                                                GETDATE()
                                        FROM    dbo.tempCompetency(NOLOCK)
                                        WHERE   sessionID = @sessionId
                                                AND comMatrixName = @comMatrixName;
				
                                SELECT  '0' AS code ,
                                        'Data saved successfully' AS msg;
                            END;
                        --ELSE
                        --    BEGIN
                        --        SELECT  '2' AS code ,
                        --                'Please add Position into Matrix' AS msg;
                        --    END;
                    END;
                ELSE
                    BEGIN     
                        SELECT  '1' AS code ,
                                'Duplicate Competency Matrix Name is not allowed' AS msg;
                    END;
                
               
            END;
            
        --IF @flag = 'updateCom'
        --    BEGIN
        --        IF EXISTS ( SELECT  'a'
        --                    FROM    dbo.AppraisalLevel(NOLOCK)
        --                    WHERE   LevelName = @comMatrixName )
        --            BEGIN
        --                DECLARE @NewwID INT;
        --        DELETE  FROM dbo.AppraisalPosition
        --        WHERE   AppraisalLevelId = @rowId;

        --        UPDATE  dbo.AppraisalLevel
        --        SET     Active = @active ,
        --                modifiedBy = @user ,
        --                modifiedDate = GETDATE()
        --        WHERE   RowId = @rowId;
								
                                
        --                SELECT  @NewID = SCOPE_IDENTITY();
                       
        --        INSERT  INTO AppraisalPosition
        --                ( AppraisalLevelId ,
        --                  PositionId ,
        --                  createdBy ,
        --                  createdDate
										
        --                )
        --                SELECT  @NewID ,
        --                        position ,
        --                        @user ,
        --                        GETDATE()
        --                FROM    dbo.tempCompetency(NOLOCK)
        --                WHERE   sessionID = @sessionId
        --                        AND comMatrixName = @comMatrixName;
        --        SELECT  '0' AS code ,
        --                'Record updated successfully' AS msg;
        --        RETURN;
        --    END;
        --ELSE
        --    BEGIN
        --        SELECT  '1' AS code ,
        --                ' is already at the list' AS msg;
                             
                   
        --    END;

      IF @flag = 'delCom'
            BEGIN
            
                IF EXISTS ( SELECT  '1'
                            FROM    tempCompetency(NOLOCK)
                            WHERE   id = @position )
                    BEGIN
                        DELETE  FROM tempCompetency
                        WHERE   id = @position;
                
                        SELECT  '0' AS code ,
                                'Record deleted successfully' AS msg;
                        RETURN;
                    END;
                SELECT  '1' AS code ,
                        'Opps..Unable to delete' AS msg;
               
            END;

			 IF @flag = 'delPosition'
            BEGIN
            
                IF EXISTS ( SELECT  '1'
                            FROM    dbo.AppraisalPosition(NOLOCK)
                            WHERE   RowId = @rowId )
                    BEGIN
                        DELETE  FROM AppraisalPosition
                        WHERE   RowId = @rowId;
                
                        SELECT  '0' AS code ,
                                'Record deleted successfully' AS msg;
                        RETURN;
                    END;
                SELECT  '1' AS code ,
                        'Opps..Unable to delete' AS msg;
               
            END;
        IF @flag = 'editCom'
                    BEGIN
                        IF NOT EXISTS ( SELECT  '1'
                                        FROM    dbo.AppraisalPosition(NOLOCK)
                                        WHERE   PositionId = @position
                                                AND AppraisalLevelId = @rowId )
                            BEGIN
								
                                IF NOT EXISTS ( SELECT  'a'
                                                FROM    AppraisalPosition(NOLOCK)
                                                WHERE   PositionId = @position )
                                    BEGIN
                                        INSERT  INTO dbo.AppraisalPosition
                                                ( AppraisalLevelId ,
                                                  PositionId ,
                                                  createdBy ,
                                                  createdDate 
                                                )
                                        VALUES  ( @rowId , -- AppraisalLevelId - int
                                                  @position , -- PositionId - int
                                                  @user , -- createdBy - int
                                                  GETDATE()  -- createdDate - datetime
                                                );  
                                        SELECT  '0' AS code ,
                                                'Record updated successfully' AS msg;
                                        RETURN;
                                    END;
                                ELSE
                                    BEGIN
                                        SELECT  '1' AS code ,
                                                'Position already added to another level' AS msg;
                                        RETURN;
                                    END;
                            END;
                        ELSE
                            BEGIN
                                SELECT  '1' AS code ,
                                        DETAIL_TITLE
                                        + ' is already at the list' AS msg
                                FROM    StaticDataDetail  (NOLOCK)
                                WHERE   ROWID = @position;
                            END;
                       
                SELECT  '1' AS code ,
                        'Opps..Unable to update' AS msg;
               
            END;
        IF @flag = 'editSelect'

		     IF( ( SELECT COUNT(*) FROM AppraisalPosition  WHERE AppraisalLevelId = @rowId) > 0)
					 BEGIN
					SELECT  P.RowId AS id,
							P.AppraisalLevelId ,
							P.PositionId ,
							L.LevelName AS comMatrixName ,
							L.Active AS status ,
							s.DETAIL_TITLE

					FROM    dbo.AppraisalPosition P
							INNER JOIN dbo.AppraisalLevel L ( NOLOCK ) ON P.AppraisalLevelId = L.RowId
							INNER JOIN StaticDataDetail s ( NOLOCK ) ON P.PositionId = s.ROWID
					WHERE   P.AppraisalLevelId = @rowId;
                
            END;
				ELSE
				BEGIN
				   SELECT LevelName  AS comMatrixName,RowId AS rowId
				    FROM dbo.AppraisalLevel (NOLOCK)
					WHERE RowId =@rowId;

				END
           

        IF @flag = 'loadLevelname'
            BEGIN
                SELECT  RowId ,
                        LevelName
                FROM    dbo.AppraisalLevel(NOLOCK)
                WHERE   RowId = @rowId;
            END;

        IF @flag = 'LoadWeightageDetails'
            BEGIN
                SELECT  A.RowId ,
                        A.LevelName ,
                        W.Kra ,
                        W.Competencies
                FROM    dbo.AppraisalLevel A ( NOLOCK )
                        INNER JOIN dbo.weightageDefination W ON A.RowId = W.AppraisalLevelId
                WHERE   A.RowId = @rowId;
            END;
            
        IF @flag = 'getComData'
            BEGIN
                SELECT  position
                FROM    dbo.tempCompetency(NOLOCK)
                WHERE   id = @rowId;
            END;
    END;

--truncate table tempCompetency drop table tempCompetency

