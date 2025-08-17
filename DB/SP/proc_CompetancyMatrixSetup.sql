ALTER PROCEDURE proc_CompetancyMatrixSetup
    @flag CHAR(20) = NULL ,
    @competency VARCHAR(50) = NULL ,
    @competencyWeight DECIMAL(10,2) = NULL ,
    @competencyKey VARCHAR(50) = NULL ,
    @competencyKeyWeight DECIMAL(10,2) = NULL ,
    @CreatedBy VARCHAR(MAX) = NULL ,
    @ModifiedBy VARCHAR(MAX) = NULL ,
    @TxtWeight DECIMAL(10,2) = NULL ,
    @TxtWeight1 DECIMAL(10,2) = NULL ,
    @LrowId INT = NULL ,
    @rowId INT = NULL
AS
    SET NOCOUNT ON;
    SET ANSI_NULLS ON;
    SET XACT_ABORT ON;
    BEGIN


        IF @flag = 'compMatrixSetup'
            BEGIN 
                IF EXISTS ( SELECT  'A'
                            FROM    dbo.competencyMatrix
                            WHERE   CompetencyID = @competency
                                    AND CompetencyKeyID = @competencyKey
                                    AND AppraisalLevelId = @rowId )
                    BEGIN
                        SELECT  'Duplicate' AS msg;
                        RETURN;
                    END;

                IF EXISTS ( SELECT  1
                            FROM    dbo.competencyMatrix
                            WHERE   AppraisalLevelId = @rowId
                                    AND CompetencyID = @competency )
                    BEGIN
                        IF ( ( SELECT  DISTINCT
                                        CompetencyWeight
                               FROM     dbo.competencyMatrix
                               WHERE    CompetencyID = @competency
                                        AND AppraisalLevelId = @rowId
                             ) <> @competencyWeight )
                            BEGIN
                                SELECT  'CompetencyWeight value is different' AS msg;
                                RETURN;
                            END;
                         
                    END;

                IF NOT EXISTS ( SELECT  1
                                FROM    dbo.competencyMatrix
                                WHERE   AppraisalLevelId = @rowId
                                        AND CompetencyID = @competency )
                    BEGIN
                        DECLARE @sum DECIMAL(10,2),
                            @tblsum DECIMAL(10,2);

                        SELECT  @tblsum = SUM(ISNULL(X.CompetencyWeight, 0))
                        FROM    ( SELECT DISTINCT
                                            CompetencyID ,
                                            CompetencyWeight
                                  FROM      dbo.competencyMatrix WITH ( NOLOCK )
                                  WHERE     AppraisalLevelId = @rowId
                                ) X;

                                
                        SET @sum = ( ISNULL(@tblsum, 0) )
                            + ( ISNULL(@competencyWeight, 0) );

							--SELECT @sum
							--RETURN;
                        IF ( @sum > 100 )
                            BEGIN
                                SELECT  'Competency Weight sum must not exceed 100' AS msg;
                                RETURN;
                            END;
                    END;

                DECLARE @sum2 DECIMAL(10,2) ,
                    @tblWeight DECIMAL(10,2);

                SELECT  @tblWeight = SUM(ISNULL(CompetencyKeyWeight, 0))
                FROM    dbo.competencyMatrix WITH ( NOLOCK )
                WHERE   CompetencyID = @competency
                        AND AppraisalLevelId = @rowId;
                                 
                SET @sum2 = @tblWeight + @competencyKeyWeight; 

				--SELECT sum2 =@sum2
				--,tblWeight =@tblWeight
				--,competencyKeyWeight=@competencyKeyWeight
				--,competencyWeight=@competencyWeight

                IF ( @sum2 > @competencyWeight )
                    BEGIN
                        SELECT  'Competency Key Weight sum must not exceed Competency Weight' AS msg;
                        RETURN;
                    END;
				--RETURN
                INSERT  INTO dbo.competencyMatrix
                        ( AppraisalLevelId ,
                          CompetencyID ,
                          CompetencyWeight ,
                          CompetencyKeyID ,
                          CompetencyKeyWeight ,
                          createdBy ,
                          createdDate
		                )
                        SELECT  @rowId ,
                                @competency ,
                                @competencyWeight ,
                                @competencyKey ,
                                @competencyKeyWeight ,
                                @CreatedBy ,
                                GETDATE();
                SELECT  'SUCCESS' AS msg;	
            END;	
        IF @flag = 'update'
            BEGIN
			
                DECLARE @summ DECIMAL(10,2) ,
                    @tblsumm DECIMAL(10,2) ,
                    @oldCompName VARCHAR(50) ,
                    @oldCompWeight DECIMAL(10,2) ,
                    @oldKeyName VARCHAR(50) ,
                    @oldKeyWeight DECIMAL(10,2); 

								
                SELECT  @oldCompName = CompetencyID ,
                        @oldCompWeight = CompetencyWeight ,
                        @oldKeyName = CompetencyKeyID ,
                        @oldKeyWeight = CompetencyKeyWeight
                FROM    dbo.competencyMatrix (NOLOCK)
                WHERE   RowId = @rowId;

                SELECT  @tblsumm = SUM(ISNULL(X.CompetencyWeight, 0)) - ISNULL(@oldCompWeight, 0)
                FROM    ( SELECT DISTINCT
                                    CompetencyID ,
                                    CompetencyWeight
                          FROM      dbo.competencyMatrix WITH ( NOLOCK )
						  WHERE     AppraisalLevelId = @LrowId
                        ) X;
                                
                SET @summ = ( ISNULL(@tblsumm, 0) ) + ( ISNULL(@TxtWeight, 0) );

	--SELECT  oldCompName = @oldCompName,
 --                       oldCompWeight =@oldCompWeight,
 --                       oldKeyName = @oldKeyName ,
 --                       oldKeyWeight = @oldKeyWeight,
	--					summ = @summ
	--					RETURN;


                IF ( @summ > 100 )
                    BEGIN
                        SELECT  'Competency Weight sum must not exceed 100' AS msg;
                        RETURN;
                    END;

                DECLARE @summ1 DECIMAL(10,2) ,
                    @tblWeight1 DECIMAL(10,2);

                SELECT  @tblWeight1 = SUM(ISNULL(Y.CompetencyKeyWeight, 0))
                        - ISNULL(@oldKeyWeight, 0)
                FROM    ( SELECT    CompetencyKeyWeight
                          FROM      dbo.competencyMatrix WITH ( NOLOCK )
                          WHERE     CompetencyID = @competency
                                    AND AppraisalLevelId = @LrowId
                        ) Y;
                                 
                SET @summ1 = @tblWeight1 + @TxtWeight1; 
                IF ( @summ1 > @TxtWeight )
                    BEGIN
                        SELECT  'Competency Key Weight sum must not exceed Competency Weight' AS msg;
                        RETURN;
                    END;

                UPDATE  competencyMatrix
                SET     CompetencyWeight = @TxtWeight
                WHERE   AppraisalLevelId = @LrowId
                        AND CompetencyID = @competency;

                UPDATE  dbo.competencyMatrix
                SET     CompetencyKeyWeight = @TxtWeight1 ,
                        modifiedBy = @ModifiedBy ,
                        createdDate = GETDATE()
                WHERE   CompetencyID = @competency
                        AND CompetencyKeyID = @competencyKey
						AND AppraisalLevelId = @LrowId;
												
                SELECT  'SUCCESS' AS msg;
            END;
        IF @flag = 'grid'
            BEGIN
                SELECT  RowId ,
                        CompetencyID ,
                        CompetencyWeight ,
                        CompetencyKeyID ,
                        CompetencyKeyWeight
                FROM    competencyMatrix
                WHERE   AppraisalLevelId = @LrowId
                ORDER BY CompetencyID;
            END;
        IF @flag = 'del'
            BEGIN
                DELETE  FROM competencyMatrix
                WHERE   RowId = @rowId;
            END;
    END;	
