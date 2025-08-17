ALTER  PROC proc_LevelAppraisalMatrix
    @user VARCHAR(50) = NULL ,
    @flag VARCHAR(50) ,
    @LrowId VARCHAR(50) = NULL ,
    @kraTopic VARCHAR(300) = NULL ,
    @kraWeight DECIMAL(10, 2) = NULL ,
    @kpiTopic VARCHAR(300) = NULL ,
    @kpiWeight DECIMAL(10, 2) = NULL ,
    @rowId VARCHAR(50) = NULL ,
    @deductionScore DECIMAL(10, 2) = NULL ,
    @objectives VARCHAR(100) = NULL ,
    @empId INT = NULL
AS
    SET NOCOUNT ON;
    SET ANSI_NULLS ON;
    SET XACT_ABORT ON;
    BEGIN
        DECLARE @maxNofQtnKpi INT ,
            @ttlWeightKpi DECIMAL(10, 2) ,--total kpi weight at question setup
            @maxNofQtnKra INT ,
            @ttlWeightKra DECIMAL(10, 2) ,--total kra weight at question setup
            @ttlKraWeight DECIMAL(10, 2) ,
            @ttlKpiWeight DECIMAL(10, 2) ,
            @msg VARCHAR(MAX) ,
            @existingQuestionKra INT ,
            @existingQuestionKpi INT ,
            @remainingWeight VARCHAR(50) ,
            @maxNofQtnC INT = NULL ,
            @ttlWeightC DECIMAL(10, 2) = NULL ,
            @ttlCriWeightC DECIMAL(10, 2) = NULL ,
            @msgC VARCHAR(MAX) = NULL ,
            @existingQuestionC INT = NULL;

        IF @flag = 'grid'
            BEGIN
                IF @LrowId IS NOT NULL
                    BEGIN
                        SELECT  rowId ,
                                kraTopic ,
                                kpiTopic ,
                                kraWeightage ,
                                kpiWeightage
                        FROM    LvlAppraisalMatrix WITH ( NOLOCK )
                        WHERE   levelId = @LrowId
                        ORDER BY kraTopic ASC;
                        RETURN;
                    END;
              
            
                ELSE
                    BEGIN
                        EXEC proc_errorHandler 1, 'No record found', NULL;
                        RETURN;
                    END;
               
            END;
           

        IF @flag = 'i'
            BEGIN
                SELECT  @maxNofQtnKpi = maxNoOfQues 
                        --@ttlWeightKpi = TotalWeightage
                FROM    QuestionCntSetup WITH ( NOLOCK )
                WHERE   QuestionGroupId = 'KPI per KRA';
                    
                    
                SELECT  @maxNofQtnKra = maxNoOfQues ,
                        @ttlWeightKra = TotalWeightage
                FROM    QuestionCntSetup WITH ( NOLOCK )
                WHERE   QuestionGroupId = 'KRA';
					
			
                IF EXISTS ( SELECT  'a'
                            FROM    LvlAppraisalMatrix
                            WHERE   levelId = @LrowId
                                    AND kraTopic = @kraTopic
                                    AND kpiTopic = @kpiTopic )
                    BEGIN
                        EXEC proc_errorHandler 1,
                            'You cannot assign same KPI to same KRA twice',
                            NULL;
                        RETURN;
                    END;
				
                IF EXISTS ( SELECT  'a'
                            FROM    LvlAppraisalMatrix
                            WHERE   levelId = @LrowId
                                    AND kraTopic = @kraTopic
                                    AND kraWeightage <> @kraWeight )
                    BEGIN
                        EXEC proc_errorHandler 1, 'Kra Weightage is different',
                            NULL;
                        RETURN;
                    END;
                IF ( @maxNofQtnKpi IS NOT NULL
                     AND @maxNofQtnKra IS NOT NULL
                   )
                    BEGIN
                        SELECT  @ttlKraWeight = SUM(ISNULL(X.kraWeightage, 0))
                        FROM    ( SELECT DISTINCT
                                            kraTopic ,
                                            kraWeightage
                                  FROM      LvlAppraisalMatrix WITH ( NOLOCK )
                                  WHERE     levelId = @LrowId
                                ) X;
	                
                        SELECT  @ttlKpiWeight = SUM(ISNULL(kpiWeightage, 0))
                        FROM    LvlAppraisalMatrix WITH ( NOLOCK )
                        WHERE   levelId = @LrowId
                                AND kraTopic = @kraTopic;

                        SELECT  @existingQuestionKra = COUNT(DISTINCT kraTopic)
                        FROM    LvlAppraisalMatrix WITH ( NOLOCK )
                        WHERE   levelId = @LrowId;
        
                        SELECT  @existingQuestionKpi = COUNT(kpiTopic)
                        FROM    LvlAppraisalMatrix WITH ( NOLOCK )
                        WHERE   levelId = @LrowId
                                AND kraTopic = @kraTopic;

                        IF NOT EXISTS ( SELECT  '1'
                                        FROM    LvlAppraisalMatrix WITH ( NOLOCK )
                                        WHERE   kraTopic = @kraTopic
                                                AND levelId = @LrowId
                                                AND kraWeightage = @kraWeight )
                            BEGIN
                                IF ( ( ISNULL(@ttlKraWeight, 0)
                                       + ISNULL(@kraWeight, 0) ) > ISNULL(@ttlWeightKra,
                                                              100) )
                                    BEGIN
                                        SET @remainingWeight = CAST(ISNULL(( @ttlWeightKra
                                                              - @ttlKraWeight ),
                                                              0) AS VARCHAR(50));
											
                                        SET @msg = CONCAT('You can not exceed KRA weight more than total KRA weight :  ',
                                                          CAST(@ttlWeightKra AS NVARCHAR(50)),
                                                          ' Note: remaining KRA weight:  ',
                                                          @remainingWeight);
                                        SET @remainingWeight = CONCAT(@remainingWeight,
                                                              '|', 'KRA');
                                        EXEC proc_errorHandler 1, @msg,
                                            @remainingWeight;
                                        RETURN;
                                    END; 
            
                                IF ( ( @existingQuestionKra + 1 ) > @maxNofQtnKra )
                                    BEGIN
                                        SET @msg = CONCAT('You can not exceed KRA question than max question :  ',
                                                          CAST(@maxNofQtnKra AS VARCHAR),
                                                          ' Note: remaining KRA question:  ',
                                                          CAST(ISNULL(( @maxNofQtnKra
                                                              - @existingQuestionKra ),
                                                              0) AS VARCHAR));
                                        EXEC proc_errorHandler 1, @msg, NULL;
                                        RETURN;
                                    END;
                            END;
                        ELSE
                            BEGIN
                                IF ( ( ISNULL(@ttlKpiWeight, 0)
                                       + ISNULL(@kpiWeight, 0) ) > ISNULL(@kraWeight,
                                                              100) )
                                    BEGIN
                                        SET @remainingWeight = CAST(ISNULL(( @kraWeight
                                                              - @ttlKpiWeight ),
                                                              0) AS VARCHAR(50));
                                        SET @msg = CONCAT('You can not exceed KPI weight than total weight :  ',
                                                          CAST(@kraWeight AS VARCHAR),
                                                          ' Note: remaining KPI weight:  ',
                                                          @remainingWeight);
                                        SET @remainingWeight = CONCAT(@remainingWeight,
                                                              '|', 'KPI');
                                        EXEC proc_errorHandler 1, @msg,
                                            @remainingWeight;
                                        RETURN;
                                    END;	
                
                
                                IF ( ( @existingQuestionKpi + 1 ) > @maxNofQtnKpi )
                                    BEGIN
                                        SET @msg = CONCAT('You can not exceed KPI question than max question :  ',
                                                          CAST(@maxNofQtnKpi AS VARCHAR),
                                                          '  Note: remaining KPI question:  ',
                                                          CAST(ISNULL(( @maxNofQtnKpi
                                                              - @existingQuestionKpi ),
                                                              0) AS VARCHAR));
                                        EXEC proc_errorHandler 1, @msg, NULL;
                                        RETURN;
                                    END;
                            END;
                                
                        INSERT  INTO dbo.LvlAppraisalMatrix
                                ( levelId ,
                                  kraTopic ,
                                  kpiTopic ,
                                  kraWeightage ,
                                  kpiWeightage ,
                                  createdBy ,
                                  createdDate
			                    )
                                SELECT  @LrowId ,
                                        @kraTopic ,
                                        @kpiTopic ,
                                        @kraWeight ,
                                        @kpiWeight ,
                                        @user ,
                                        GETDATE();
		
                        EXEC proc_errorHandler 0,
                            'Record has been inserted successfully.', NULL;
                        RETURN; 
				    
                    END;
                ELSE
                    BEGIN
                        EXEC proc_errorHandler 1,
                            'Please, setup the question count first', NULL;
                        RETURN;
                    END;
				
               
           
        --ELSE
        --    BEGIN
        --        EXEC proc_errorHandler 1,
        --            'Please, select employee for appraisal first', NULL;
        --    END;  
            END;

        IF @flag = 'u'
            BEGIN
            --    EXEC proc_errorHandler 1,
            --        'Please, select employee for appraisal first', NULL;
            --    RETURN;
           
                DECLARE @kraTopicOld VARCHAR(100) ,
                    @kraWeightOld DECIMAL(10, 2) ,
                    @kpiTopicOld VARCHAR(100) ,
                    @ttl DECIMAL(10, 2) ,
                    @kpiWeightOld DECIMAL(10, 2); 
				
				
                SELECT  @kraTopicOld = kraTopic ,
                        @kraWeightOld = kraWeightage ,
                        @kpiTopicOld = kpiTopic ,
                        @kpiWeightOld = kpiWeightage
                FROM    dbo.LvlAppraisalMatrix WITH ( NOLOCK )
                WHERE   rowId = @rowId; 
                
                SELECT  @maxNofQtnKpi = maxNoOfQues 
                        --@ttlWeightKpi = TotalWeightage
                FROM    QuestionCntSetup WITH ( NOLOCK )
                WHERE   QuestionGroupId = 'KPI per KRA';


                SELECT  @maxNofQtnKra = maxNoOfQues ,
                        @ttlWeightKra = TotalWeightage
                FROM    QuestionCntSetup WITH ( NOLOCK )
                WHERE   QuestionGroupId = 'KRA';

				
                SELECT  @ttlKraWeight = ( SUM(ISNULL(X.kraWeightage, 0))
                                          - ISNULL(@kraWeightOld, 0) )
                FROM    ( SELECT DISTINCT
                                    kraTopic ,
                                    kraWeightage
                          FROM      LvlAppraisalMatrix WITH ( NOLOCK )
                          WHERE     levelId = @LrowId
						 -- AND kraTopic = @kraTopicOld;
                        ) X;
	             
	           
	                
                SELECT  @ttlKpiWeight = ( SUM(ISNULL(kpiWeightage, 0))
                                          - ISNULL(@kpiWeightOld, 0) )
                FROM    LvlAppraisalMatrix WITH ( NOLOCK )
                WHERE   levelId = @LrowId
                        AND kraTopic = @kraTopicOld;
				
                SELECT  @ttl = ( SUM(ISNULL(kpiWeightage, 0))
                                 - ISNULL(@kpiWeightOld, 0) )
                FROM    LvlAppraisalMatrix WITH ( NOLOCK )
                WHERE   levelId = @LrowId
                        AND kraTopic = @kraTopicOld;


                IF ( ISNULL(@ttl, 0) + ISNULL(@kpiWeight, 0) > ISNULL(@kraWeight,
                                                              0) )
                    BEGIN 
                        EXEC proc_errorHandler 1,
                            'KRA Weightage must be greater or equal to total KPI Weightage', NULL;
                        RETURN;
                    END;		  
							            
                IF ( @kraTopicOld <> @kraTopic )
                    BEGIN
                        IF EXISTS ( SELECT  'a'
                                    FROM    LvlAppraisalMatrix WITH ( NOLOCK )
                                    WHERE   levelId = @LrowId
                                            AND kraTopic = @kraTopic )
                            BEGIN
                                EXEC proc_errorHandler 1,
                                    'You cannot assign same KRA twice', NULL;
                                RETURN;
                            END;
                    END;

				
                IF ( @kpiTopicOld <> @kpiTopic )
                    BEGIN
                        IF EXISTS ( SELECT  'a'
                                    FROM    LvlAppraisalMatrix WITH ( NOLOCK )
                                    WHERE   rowId = @rowId
                                            AND kraTopic = @kraTopic
                                            AND kpiTopic = @kpiTopic )
                            BEGIN
                                EXEC proc_errorHandler 1,
                                    'You cannot assign same KPI to same KRA twice',
                                    NULL;
                                RETURN;
                            END;
                    END;

                IF ( @kraWeightOld <> @kraWeight )
                    BEGIN
					--SELECT 'a'
                        IF ( ( ISNULL(@ttlKraWeight, 0) + ISNULL(@kraWeight, 0) ) > ISNULL(@ttlWeightKra,
                                                              100) )
                            BEGIN
								
                                SET @msg = CONCAT('You can not exceed KRA weight than total weight :  ',
                                                  CAST(@ttlWeightKra AS NVARCHAR(50)),
                                                  ' Note: remaining KRA weight:  ',
                                                  CAST(ISNULL(( @ttlWeightKra
                                                              - @ttlKraWeight ),
                                                              0) AS VARCHAR(50)));
                                
                                EXEC proc_errorHandler 1, @msg, NULL;
                                RETURN;
                            END; 
                    END;

                IF ( @kpiWeightOld <> @kpiWeight )
                    BEGIN
                        IF ( ( ISNULL(@ttlKpiWeight, 0) + ISNULL(@kpiWeight, 0) ) > ISNULL(@kraWeight,
                                                              100) )
                            BEGIN
								
                                SET @msg = CONCAT('You can not exceed KPI weight than total weight :  ',
                                                  CAST(@kraWeight AS VARCHAR),
                                                  ' Note: remaining KPI weight:  ',
                                                  CAST(ISNULL(( @kraWeight
                                                              - @ttlKpiWeight ),
                                                              0) AS VARCHAR(50)));
                                EXEC proc_errorHandler 1, @msg, NULL;
                                RETURN;
                            END;	
                    END;

             
                IF ( @kraTopicOld <> @kraTopic
                     OR @kraWeightOld <> @kraWeight
                   )
                    BEGIN
                        UPDATE  LvlAppraisalMatrix
                        SET     kraTopic = @kraTopic ,
                                kraWeightage = @kraWeight ,
                                modifiedBy = @user ,
                                modifiedDate = GETDATE()
                        WHERE   rowId IN (
                                SELECT  rowId
                                FROM    dbo.LvlAppraisalMatrix(NOLOCK)
                                WHERE   kraTopic = @kraTopicOld );
                    END; 
                       
           
                IF ( @kpiTopicOld <> @kpiTopic
                     OR @kpiWeightOld <> @kpiWeight
                   )
                    BEGIN
                        UPDATE  LvlAppraisalMatrix
                        SET     kpiTopic = ISNULL(@kpiTopic, kpiTopic) ,
                                kpiWeightage = ISNULL(@kpiWeight, kpiWeightage) ,
                                modifiedBy = @user ,
                                modifiedDate = GETDATE()
                        WHERE   rowId = @rowId;
                    END;
					
	            
                EXEC proc_errorHandler 0,
                    'Record has been Updated successfully.', NULL;
                RETURN;
            END;

        IF @flag = 'ci'
            BEGIN
                IF @LrowId IS NOT NULL
                    BEGIN
					
                        IF EXISTS ( SELECT  'a'
                                    FROM    LevelCriticalJobs
                                    WHERE   appraisalLevelId = @LrowId
                                            AND Objectives = @objectives )
                            BEGIN
                                EXEC proc_errorHandler 1,
                                    'You cannot assign same Objectives twice',
                                    NULL;
                                RETURN;
                            END;
                        SELECT  @maxNofQtnC = maxNoOfQues ,
                                @ttlWeightC = TotalWeightage
                        FROM    QuestionCntSetup WITH ( NOLOCK )
                        WHERE   QuestionGroupId = 'Critical Jobs';					
                        IF ( @maxNofQtnC IS NOT NULL )
                            BEGIN
                                SELECT  @existingQuestionC = COUNT(*) ,
                                        @ttlCriWeightC = SUM(ISNULL(DeductionScore,
                                                              0))
                                FROM    dbo.LevelCriticalJobs WITH ( NOLOCK )
                                WHERE   appraisalLevelId = @LrowId;						
							--select @ttlCriWeightC
							--return			
                                IF ( ( ISNULL(@ttlCriWeightC, 0)
                                       + ISNULL(@deductionScore, 0) ) > ISNULL(@ttlWeightC,
                                                              100) )
                                    BEGIN
                                        SET @msgC = 'You can not exceed critical jobs weight than total weight :  '
                                            + CAST(ISNULL(@ttlWeightC, 0) AS VARCHAR)
                                            + ' Note: remaining critical jobs weight:  '
                                            + CAST(ISNULL(( @ttlWeightC
                                                            - @ttlCriWeightC ),
                                                          0) AS VARCHAR);
                                        EXEC proc_errorHandler 1, @msgC, NULL;
                                        RETURN;
                                    END;											
                                ELSE
                                    BEGIN 
                                        IF ( @existingQuestionC + 1 > @maxNofQtnC )
                                            BEGIN
                                                SET @msgC = 'You can not exceed question than max question :  '
                                                    + CAST(@maxNofQtnC AS VARCHAR)
                                                    + ' Note: remaining question:  '
                                                    + CAST(( @maxNofQtnC
                                                             - ISNULL(@existingQuestionC,
                                                              0) ) AS VARCHAR);
                                                EXEC proc_errorHandler 1,
                                                    @msgC, NULL;
                                                RETURN;
                                            END;
								--SELECT @objectives,@deductionScore,@user,GETDATE()
                                        INSERT  INTO LevelCriticalJobs
                                                ( Objectives ,
                                                  DeductionScore ,
                                                  createdBy ,
                                                  createdDate ,
                                                  appraisalLevelId
                                                )
                                        VALUES  ( @objectives ,
                                                  @deductionScore ,
                                                  @user ,
                                                  GETDATE() ,
                                                  @LrowId
                                                );

                                        EXEC proc_errorHandler 0,
                                            'Record has been Inserted successfully.',
                                            NULL;
                                        RETURN;	            
                                    END;
                            END;
                        ELSE
                            BEGIN
                                EXEC proc_errorHandler 1,
                                    'Sorry ! No questions setup is initiatied of critical jobs categories.',
                                    NULL;
                                RETURN;
                            END;
                    END;
			--ELSE
   --             BEGIN
   --                 EXEC proc_errorHandler 1,
   --                     'Please, select employee for appraisal first', NULL;
   --             END;
            END;

        IF @flag = 'c_grid'
            BEGIN
                SELECT  ROW_NUMBER() OVER ( ORDER BY rowId ASC ) SNO ,
                        rowId ,
                        objectives = Objectives ,
                        deductionScore = DeductionScore
                FROM    LevelCriticalJobs (NOLOCK)
                WHERE   appraisalLevelId = @LrowId
                ORDER BY objectives ASC;
                RETURN;
            END;

        IF @flag = 'cdel'
            BEGIN
                DELETE  FROM LevelCriticalJobs
                WHERE   rowId = @rowId;

                EXEC proc_errorHandler 0,
                    'Record has been deleted successfully.', @rowId;
                RETURN;	
            END;
        IF @flag = 'cu'
            BEGIN
                IF @LrowId IS NOT NULL
                    BEGIN
                        DECLARE @preScore DECIMAL(10, 2) = NULL;
                        SELECT  @maxNofQtnC = maxNoOfQues ,
                                @ttlWeightC = TotalWeightage
                        FROM    QuestionCntSetup WITH ( NOLOCK )
                        WHERE   QuestionGroupId = 'Critical Jobs';	
					--select @objectives,@deductionScore,@maxNofQtnC,@ttlWeightC
					--	return				
                        IF ( @maxNofQtnC IS NOT NULL )
                            BEGIN
							
                                DECLARE @oldObjectives VARCHAR(100) ,
                                    @oldDeductionScore DECIMAL(10, 2); 
				
				
                                SELECT  @oldObjectives = Objectives ,
                                        @oldDeductionScore = DeductionScore
                                FROM    dbo.LevelCriticalJobs WITH ( NOLOCK )
                                WHERE   rowId = @rowId; 

                                IF ( @oldObjectives <> @objectives )
                                    BEGIN
                                        IF EXISTS ( SELECT  'a'
                                                    FROM    LevelCriticalJobs
                                                            WITH ( NOLOCK )
                                                    WHERE   appraisalLevelId = @LrowId
                                                            AND Objectives = @objectives )
                                            BEGIN
                                                EXEC proc_errorHandler 1,
                                                    'You cannot assign same Objectives twice',
                                                    NULL;
                                                RETURN;
                                            END;
                                    END;

                                SELECT  @preScore = SUM(ISNULL(DeductionScore,
                                                              0))
                                FROM    dbo.LevelCriticalJobs WITH ( NOLOCK )
                                WHERE   rowId = @rowId;

                                UPDATE  LevelCriticalJobs
                                SET     Objectives = @objectives ,
                                        DeductionScore = @deductionScore
                                WHERE   rowId = @rowId;

                                SELECT  @ttlCriWeightC = SUM(ISNULL(DeductionScore,
                                                              0))
                                FROM    dbo.LevelCriticalJobs WITH ( NOLOCK )
                                WHERE   appraisalLevelId = @LrowId;
								--select @ttlCriWeightC
								--return 													
                                IF ( ( ISNULL(@ttlCriWeightC, 0) ) > ISNULL(@ttlWeightC,
                                                              100) )
                                    BEGIN
											
                                        UPDATE  LevelCriticalJobs
                                        SET     Objectives = @objectives ,
                                                DeductionScore = @deductionScore
                                        WHERE   rowId = @rowId;

                                        SET @msgC = 'You can not exceed critical jobs weight than total weight :  '
                                            + CAST(@ttlWeightC AS VARCHAR)
                                            + ' Note: remaining critical jobs weight:  '
                                            + CAST(CASE WHEN CAST(( @ttlWeightC
                                                              - @ttlCriWeightC ) AS FLOAT) < 0
                                                        THEN 0
                                                        ELSE CAST(( @ttlWeightC
                                                              - @ttlCriWeightC ) AS FLOAT)
                                                   END AS VARCHAR);
                                        EXEC proc_errorHandler 1, @msgC, NULL;
                                        RETURN;
                                    END;																								

                                EXEC proc_errorHandler 0,
                                    'Record has been Updated successfully.',
                                    NULL;
                                RETURN;
                            END;
                        ELSE
                            BEGIN
                                EXEC proc_errorHandler 1,
                                    'Sorry ! No questions setup is initiatied of critical jobs categories.',
                                    NULL;
                                RETURN;
                            END;
                    END;
                ELSE
                    BEGIN
                        EXEC proc_errorHandler 1,
                            'Please, select employee for appraisal first',
                            NULL;
                    END;  
            END;
        IF @flag = 'del'
            BEGIN
                DELETE  FROM dbo.LvlAppraisalMatrix
                WHERE   rowId = @rowId;
				
                EXEC proc_errorHandler 0,
                    'Record has been requested successfully.', @rowId;
                RETURN;	
            END;
    END; 
                

      

			 