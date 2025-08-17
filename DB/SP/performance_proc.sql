ALTER PROC performance_proc
    @flag CHAR(10) ,
    @KraQuestionNo INT = NULL ,
    @KraTotalWeightAge INT = NULL ,
    @KraRatingCeiling INT = NULL ,
    @KpiPerKraQuestionNo INT = NULL ,
    @KpiPerKraTotalWeightAge INT = NULL ,
    @KpiPerKraRatingCeiling INT = NULL ,
    @CriticalJobsQuestionNo INT = NULL ,
    @CriticalJobsTotalWeightAge INT = NULL ,
    @CriticalJobsRatingCeiling INT = NULL ,
    @TrainingAssesQuestionNo INT = NULL ,
    @TrainingAssesTotalWeightAge INT = NULL ,
    @TrainingAssesRatingCeiling INT = NULL ,
    @CreatedBy VARCHAR(30) = NULL ,
    @ModifiedBy VARCHAR(30) = NULL ,
    @Kra FLOAT = NULL ,
    @Competencies FLOAT = NULL ,
    @KraAchiveScore VARCHAR(100) = NULL ,
    @PerformLblRating VARCHAR(100) = NULL ,
    @PercentIncrement FLOAT = NULL ,
    @rowId INT = NULL ,
    @levelName VARCHAR(30) = NULL
AS
    SET NOCOUNT ON;
    SET ANSI_NULLS ON;
    SET XACT_ABORT ON;
    BEGIN
        IF @flag = 'qsn'
            BEGIN
                INSERT  INTO PerformanceQuestionCnt
                        ( KraQuestionNo ,
                          KraTotalWeightAge ,
                          KraRatingCeiling ,
                          KpiPerKraQuestionNo ,
                          KpiPerKraTotalWeightAge ,
                          KpiPerKraRatingCeiling ,
                          CriticalJobsQuestionNo ,
                          CriticalJobsTotalWeightAge ,
                          CriticalJobsRatingCeiling ,
                          TrainingAssesQuestionNo ,
                          TrainingAssesTotalWeightAge ,
                          TrainingAssesRatingCeiling ,
                          CreatedBy ,
                          CreatedDate
                        )
                        SELECT  @KraQuestionNo ,
                                @KraTotalWeightAge ,
                                @KraRatingCeiling ,
                                @KpiPerKraQuestionNo ,
                                @KpiPerKraTotalWeightAge ,
                                @KpiPerKraRatingCeiling ,
                                @CriticalJobsQuestionNo ,
                                @CriticalJobsTotalWeightAge ,
                                @CriticalJobsRatingCeiling ,
                                @TrainingAssesQuestionNo ,
                                @TrainingAssesTotalWeightAge ,
                                @TrainingAssesRatingCeiling ,
                                @CreatedBy ,
                                GETDATE();	
												
                SELECT  'SUCCESS' AS msg;						
												
            END;

        IF @flag = 'wAge'
            BEGIN
                IF NOT EXISTS ( SELECT  '1'
                                FROM    weightageDefination(NOLOCK)
                                WHERE   AppraisalLevelId = @rowId )
                    BEGIN 
                        INSERT  INTO weightageDefination
                                ( AppraisalLevelId ,
                                  Kra ,
                                  Competencies ,
                                  createdBy ,
                                  createdDate	
												
                                )
                                SELECT  ( SELECT    RowId
                                          FROM      dbo.AppraisalLevel
                                          WHERE     RowId = @rowId
                                        ) ,
                                        @Kra ,
                                        @Competencies ,
                                        @CreatedBy ,
                                        GETDATE();

                        SELECT  'SUCCESS' AS msg;
                    END;
                ELSE
                    BEGIN
                        SELECT  '1' AS code ,
                                LevelName + ' is already at the list' AS msg
                        FROM    AppraisalLevel  (NOLOCK)
                        WHERE   RowId = @rowId;
                    END;
            END;

        IF @flag = 'UpdatewAge'
            BEGIN
				
                UPDATE  dbo.weightageDefination
                SET     Kra = @Kra ,
                        Competencies = @Competencies ,
                        createdBy = @CreatedBy ,
                        createdDate = GETDATE()
                WHERE   AppraisalLevelId = @rowId;
                SELECT  'SUCCESS' AS msg;
            END;
        IF @flag = 'rating'
            BEGIN
                INSERT  INTO PerformanceRatingRef
                        ( KraAchiveScore ,
                          PerformLblRating ,
                          PercentIncrement ,
                          CreatedBy ,
                          CreatedDate		
												
                        )
                        SELECT  @KraAchiveScore ,
                                @PerformLblRating ,
                                @PercentIncrement ,
                                @CreatedBy ,
                                GETDATE();

                SELECT  'SUCCESS' AS msg;
            END;

        IF @flag = 'update'
            BEGIN
				
                UPDATE  dbo.PerformanceRatingRef
                SET     KraAchiveScore = @KraAchiveScore ,
                        PerformLblRating = @PerformLblRating ,
                        PercentIncrement = @PercentIncrement ,
                        ModifiedBy = @ModifiedBy ,
                        ModifiedDate = GETDATE()
                WHERE   RowId = @rowId;
                SELECT  'SUCCESS' AS msg;
            END;

        IF @flag = 'grid'
            BEGIN
                SELECT  RowId ,
                        KraAchiveScore ,
                        PerformLblRating ,
                        PercentIncrement
                FROM    PerformanceRatingRef;
            END;

        IF @flag = 'del'
            BEGIN
                DELETE  FROM PerformanceRatingRef
                WHERE   RowId = @rowId;
            END;

    END;
