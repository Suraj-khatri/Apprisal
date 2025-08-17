ALTER PROC proc_PerformanceAppraisalReview
    @user VARCHAR(50) = NULL ,
    @flag VARCHAR(50) ,
    @rowId VARCHAR(50) = NULL ,
    @LrowId INT = NULL ,
    @empId INT = NULL ,
    @appId INT = NULL ,
    @fromDate VARCHAR(20) = NULL ,
    @toDate VARCHAR(20) = NULL ,
    @role VARCHAR(20) = NULL ,
    @chkKRA VARCHAR(MAX) = NULL ,
    @xml XML = NULL ,
    @txtKRA VARCHAR(MAX) = NULL ,
    @an1 VARCHAR(MAX) = NULL ,
    @an2 VARCHAR(MAX) = NULL ,
    @an3 VARCHAR(MAX) = NULL ,
    @an4 VARCHAR(MAX) = NULL ,
    @an5 VARCHAR(MAX) = NULL ,
    @an6 VARCHAR(MAX) = NULL ,
    @an7 VARCHAR(MAX) = NULL ,
    @an8 VARCHAR(MAX) = NULL ,
    @an9 VARCHAR(MAX) = NULL ,
    @an10 VARCHAR(MAX) = NULL ,
    @remarks VARCHAR(MAX) = NULL ,
    @checked VARCHAR(MAX) = NULL ,
    @commenterType VARCHAR(50) = NULL ,
    @chksale INT = NULL ,
    @saleComment VARCHAR(MAX) = NULL ,
    @chkOperation INT = NULL ,
    @chkHR INT = NULL ,
    @chkBackOffice INT = NULL ,
    @chkMarketing INT = NULL ,
    @chkAdminstration INT = NULL ,
    @chkFinance INT = NULL ,
    @chkOthers INT = NULL ,
    @freeze CHAR(1) = NULL ,
    @othersComment VARCHAR(MAX) = NULL,
	@prChkAck CHAR(1) = NULL

AS
    SET NOCOUNT ON;
    SET ANSI_NULLS ON;
    SET XACT_ABORT ON;
    BEGIN
        DECLARE @AppraId INT ,
            @postion VARCHAR(20);

        SELECT  @AppraId = appraisalId
        FROM    dbo.appraisalInitation WITH ( NOLOCK )
        WHERE   employeeId = @empId;

        SELECT  @postion = POSITION_ID
        FROM    dbo.Employee(NOLOCK)
        WHERE   EMPLOYEE_ID = @empId;

        SELECT  @LrowId = AppraisalLevelId
        FROM    dbo.AppraisalPosition(NOLOCK)
        WHERE   PositionId = @postion;

        IF @flag = 'appEmpList'
            BEGIN

                SELECT  e.EMPLOYEE_ID ,
                        e.EMP_CODE ,
                        dbo.GetEmployeeFullNameOfId(e.EMPLOYEE_ID) AS EMPNAME
                FROM    dbo.appraisalInitation a ( NOLOCK )
                        INNER JOIN dbo.Employee e ( NOLOCK ) ON a.employeeId = e.EMPLOYEE_ID
                WHERE   a.appraisalStartDate BETWEEN @fromDate
                                             AND     @toDate
                        AND a.appraisalEndDate BETWEEN @fromDate AND @toDate
                        AND a.supervisorId = @empId
                UNION
                SELECT  e.EMPLOYEE_ID ,
                        e.EMP_CODE ,
                        dbo.GetEmployeeFullNameOfId(e.EMPLOYEE_ID) AS EMPNAME
                FROM    dbo.appraisalInitation a ( NOLOCK )
                        INNER JOIN dbo.Employee e ( NOLOCK ) ON a.employeeId = e.EMPLOYEE_ID
                WHERE   a.appraisalStartDate BETWEEN @fromDate
                                             AND     @toDate
                        AND a.appraisalEndDate BETWEEN @fromDate AND @toDate
                        AND a.reviewerId = @empId
                UNION
                SELECT  e.EMPLOYEE_ID ,
                        e.EMP_CODE ,
                        dbo.GetEmployeeFullNameOfId(e.EMPLOYEE_ID) AS EMPNAME
                FROM    dbo.appraisalInitation a ( NOLOCK )
                        INNER JOIN dbo.Employee e ( NOLOCK ) ON a.employeeId = e.EMPLOYEE_ID
                WHERE   a.appraisalStartDate BETWEEN @fromDate
                                             AND     @toDate
                        AND a.appraisalEndDate BETWEEN @fromDate AND @toDate
                        AND a.employeeId = @empId
                UNION
                SELECT  ASP.EMPLOYEE_ID ,
                        ASP.EMP_CODE ,
                        ASP.EMPNAME 
                        --ASP.POSITION_ID ,
                        -- ASP.AppraisalLevelId
                FROM    ( SELECT    e.EMPLOYEE_ID ,
                                    e.EMP_CODE ,
                                    dbo.GetEmployeeFullNameOfId(e.EMPLOYEE_ID) AS EMPNAME ,
                                    e.POSITION_ID ,
                                    ap.AppraisalLevelId
                          FROM      dbo.Employee e
                                    INNER JOIN dbo.appraisalInitation A ( NOLOCK ) ON e.EMPLOYEE_ID = A.employeeId
                                    INNER JOIN dbo.AppraisalPosition ap ( NOLOCK ) ON ap.PositionId = e.POSITION_ID
                          WHERE     A.appraisalStartDate BETWEEN @fromDate
                                                         AND  @toDate
                                    AND A.appraisalEndDate BETWEEN @fromDate AND @toDate
                        ) AS ASP
                        INNER JOIN ( SELECT ar.EmployeeName ,
                                            ar.AppraisalLevelId
                                     FROM   appReviewerList ar ( NOLOCK )
                                     --WHERE  ar.AppraisalLevelId = @LrowId
                                     WHERE  ar.EmployeeName = @empId
                                   ) AS al ON al.AppraisalLevelId = ASP.AppraisalLevelId;


      --          SELECT  e.EMPLOYEE_ID ,
      --                  e.EMP_CODE ,
      --                  dbo.GetEmployeeFullNameOfId(e.EMPLOYEE_ID) AS EMPNAME
      --          FROM    dbo.appraisalInitation a ( NOLOCK )
      --                  INNER JOIN dbo.Employee e ( NOLOCK ) ON a.employeeId = e.EMPLOYEE_ID
						--INNER JOIN appReviewerList ar (NOLOCK) ON ar.EmployeeName = a.employeeId
      --          WHERE   a.appraisalStartDate BETWEEN @fromDate
      --                                       AND     @toDate
      --                  AND a.appraisalEndDate BETWEEN @fromDate AND @toDate
      --                  AND ar.EmployeeName = @empId
						--AND ar.AppraisalLevelId = @LrowId;
                RETURN;
            END;

        IF @flag = 'pas'
            BEGIN
                SELECT  empName ,
                        BRANCH_NAME ,
                        DEPARTMENT_NAME ,
                        SUBDEPARTMENT_NAME ,
                        CURRPOSITION ,
                        CONVERT(VARCHAR, joiningDate, 101) AS joiningDate ,
                        confirmationDate ,
                        lastPromotionDate ,
                        lastTransferDate ,
                        reviewerId ,
                        supervisorId ,
                        CONVERT(VARCHAR, appraisalStartDate, 101) AS appraisalStartDate ,
                        CONVERT(VARCHAR, appraisalEndDate, 101) AS appraisalEndDate ,
                        supervisorName ,
                        reviewerName ,
                        CASE WHEN Promo.PROMOTION_DATE IS NULL
                             THEN ABS(DATEDIFF(DAY, joiningDate, GETDATE()))
                             ELSE ABS(DATEDIFF(DAY, Promo.PROMOTION_DATE,
                                               GETDATE()))
                        END timeSpentOnCurrPosition ,
                        CASE WHEN trans.EFFECTIVE_DATE IS NULL
                             THEN ABS(DATEDIFF(DAY, joiningDate, GETDATE()))
                             ELSE ABS(DATEDIFF(DAY, trans.EFFECTIVE_DATE,
                                               GETDATE()))
                        END timeSpentOnCurrBranch
                FROM    ( SELECT    e.EMPLOYEE_ID AS empId ,
                                    emp.EMP_CODE + ' | ' + emp.FIRST_NAME
                                    + ' ' + emp.MIDDLE_NAME + ' '
                                    + emp.LAST_NAME AS empName ,
                                    b.BRANCH_NAME ,
                                    d.DEPARTMENT_NAME ,
                                    sd.DEPARTMENT_NAME AS SUBDEPARTMENT_NAME ,
                                    p.DETAIL_DESC AS CURRPOSITION ,
                                    a.joiningDate ,
                                    a.confirmationDate ,
                                    a.lastPromotionDate ,
                                    a.lastTransferDate ,
                                    a.appraisalStartDate ,
                                    a.appraisalEndDate ,
                                    dbo.GetEmployeeFullNameOfId(a.supervisorId) AS supervisorName ,
                                    dbo.GetEmployeeFullNameOfId(a.reviewerId) AS reviewerName ,
                                    a.reviewerId ,
                                    a.supervisorId
                          FROM      appraisalInitation a ( NOLOCK )
                                    INNER JOIN dbo.Branches b ( NOLOCK ) ON a.currBranchId = b.BRANCH_ID
                                    INNER JOIN Departments d ( NOLOCK ) ON d.DEPARTMENT_ID = a.currDeptId
                                    LEFT JOIN Departments sd ( NOLOCK ) ON sd.DEPARTMENT_ID = a.currSubDeptId
                                    INNER JOIN dbo.StaticDataDetail p ( NOLOCK ) ON p.ROWID = a.currPosition
                                    INNER JOIN dbo.Employee e ( NOLOCK ) ON e.EMPLOYEE_ID = a.supervisorId
                                    INNER JOIN dbo.Employee em ( NOLOCK ) ON em.EMPLOYEE_ID = a.reviewerId
                                    INNER JOIN dbo.Employee emp ( NOLOCK ) ON emp.EMPLOYEE_ID = a.employeeId
                          WHERE     a.employeeId = @empId
                                    AND a.appraisalId = @appId
                        ) main
                        LEFT JOIN ( SELECT  EMP_ID ,
                                            POSITION_ID AS lastpromtedPosition ,
                                            MAX(PROMOTION_DATE) PROMOTION_DATE
                                    FROM    Promotion (NOLOCK)
                                    WHERE   EMP_ID = @empId
                                    GROUP BY EMP_ID ,
                                            POSITION_ID
                                  ) Promo ON main.empId = Promo.EMP_ID
                        LEFT JOIN ( SELECT  STAFF_ID AS emp_Id ,
                                            WHICH_BRANCH AS lasttransfedBranch ,
                                            MAX(EFFECTIVE_DATE) EFFECTIVE_DATE
                                    FROM    ExternalTransferPlan (NOLOCK)
                                    WHERE   STAFF_ID = @empId
                                    GROUP BY STAFF_ID ,
                                            WHICH_BRANCH
                                  ) trans ON main.empId = trans.emp_Id;
            END;

        IF @flag = 'krakpigrid'
            BEGIN
                DECLARE @sum FLOAT ,
                    @RatingCeiling FLOAT ,
                    @sts VARCHAR(25); 
                SET @sum = ( SELECT SUM(Score)
                             FROM   dbo.AppraisalRating(NOLOCK)
                             WHERE  MatrixType = 'kpi'
                             GROUP BY AppraisalId
                             HAVING AppraisalId = @appId
                           );
                SELECT  @sts = [STATUS]
                FROM    dbo.appraisalInitation(NOLOCK)
                WHERE   appraisalId = @appId;
                SET @RatingCeiling = ( SELECT   RatingCeiling
                                       FROM     QuestionCntSetup(NOLOCK)
                                       WHERE    QuestionGroupId = 'KRA'
                                     );
                IF EXISTS ( SELECT  'a'
                            FROM    dbo.AppraisalMatrix WITH ( NOLOCK )
                            WHERE   appraisalId = @appId )
                    BEGIN
                        SELECT  am.rowId ,
                                am.kraTopic ,
                                am.kpiTopic ,
                                am.kraWeightage ,
                                am.kpiWeightage ,
                                am.performanceAchievement ,
                                am.performanceRemarks ,
                                am.variance ,
                                @RatingCeiling AS Rating ,
                                ar.Score AS performanceScore ,
                                ISNULL(@sum, 0) AS Total ,
                                @sts AS [Status]
                        FROM    AppraisalMatrix am WITH ( NOLOCK )
                                LEFT JOIN ( SELECT  MatrixId ,
                                                    Score
                                            FROM    dbo.AppraisalRating(NOLOCK)
                                            WHERE   MatrixType = 'kpi'
                                          ) ar ON ar.MatrixId = am.rowId
                        WHERE   am.appraisalId = @appId
                        ORDER BY kraTopic ASC;

                        RETURN;
                    END;
                
                ELSE
                    BEGIN
                        EXEC proc_errorHandler 1, 'No record found', NULL;
                        RETURN;
                    END;
            END;
        IF @flag = 'c_grid'
            BEGIN
                IF EXISTS ( SELECT  'a'
                            FROM    dbo.AppraisalMatrix WITH ( NOLOCK )
                            WHERE   appraisalId = @appId )
                    BEGIN
                        SELECT  ROW_NUMBER() OVER ( ORDER BY c.rowId ASC ) SNO ,
                                c.rowId ,
                                objectives = c.Objectives ,
                                deductionScore = c.DeductionScore ,
                                ar.Score
                        FROM    criticalJobs c ( NOLOCK )
                                LEFT JOIN ( SELECT  MatrixId ,
                                                    Score
                                            FROM    dbo.AppraisalRating(NOLOCK)
                                            WHERE   MatrixType = 'CJR'
                                          ) ar ON ar.MatrixId = c.rowId
                        WHERE   c.appraisalId = @appId
                        ORDER BY objectives ASC;
                        RETURN;
                    END;
                ELSE
                    BEGIN
                        EXEC proc_errorHandler 1, 'No record found', NULL;
                        RETURN;
                    END;
            END;
        IF @flag = 'pr_pt_grid'
            BEGIN
                IF @appId IS NOT NULL
                    BEGIN
                        SELECT  ISNULL([status],'N') AS ACK
                        FROM    dbo.AppraisalIndexTable(NOLOCK)
                        WHERE   appId = @appId
                                AND title = 'Performance Rating Ack';
						
                        SELECT  RowId ,
                                ProposedTrainingArea ,
                                CONVERT(VARCHAR, ProposedByDate, 101) AS ProposedByDate ,
                                PerformanceAfterTraining AS PAT
                        FROM    dbo.ProposedTraining WITH ( NOLOCK )
                        WHERE   AppraisalId = @appId;

                    END;
                ELSE
                    BEGIN
                        EXEC proc_errorHandler 1,
                            'Please, select employee for appraisal first',
                            NULL;
                    END;
            END;
        IF @flag = 'pr_grid'
            BEGIN
					--DECLARE @ttlKraScore INT;
					--SELECT @ttlKraScore = SUM(Score)
     --                    FROM   dbo.AppraisalRating(NOLOCK)
     --                    WHERE  MatrixType = 'kpi'
     --                    GROUP BY AppraisalId
     --                    HAVING AppraisalId = @appId;

                SELECT  RowId ,
                        ISNULL(KraAchiveScore, 0) AS KraAchiveScore ,
                        ISNULL(PerformLblRating, 0) AS PerformLblRating ,
                        ISNULL(PercentIncrement, 0) AS PercentIncrement
                FROM    PerformanceRatingRef (NOLOCK);
                RETURN;
            END;
        IF @flag = 'score_grid'
            BEGIN

                SELECT  am.kraTopic ,
                        am.kraWeightage ,
                        SUM(ar.Score) AS Score
                FROM    AppraisalMatrix am ( NOLOCK )
                        INNER JOIN AppraisalRating ar ( NOLOCK ) ON ar.MatrixId = am.rowId
                WHERE   ar.MatrixType = 'kpi'
                        AND ar.AppraisalId = @appId
                GROUP BY am.kraTopic ,
                        am.kraWeightage
                UNION ALL
                SELECT  'Critical Jobs' AS kraTopic ,
                        ( SELECT    SUM(ISNULL(Score, 0))
                          FROM      dbo.AppraisalRating
                          WHERE     MatrixType = 'CJR'
                                    AND AppraisalId = @appId
                        ) AS kraWeightage ,
                        ( SELECT    SUM(ISNULL(DeductionScore, 0))
                          FROM      criticalJobs (NOLOCK)
                          WHERE     appraisalId = @appId
                        ) AS Score;

                SELECT  cm.CompetencyID ,
                        cm.CompetencyWeight ,
                        SUM(ar.Score) AS Score
                FROM    dbo.competencyMatrix cm ( NOLOCK )
                        INNER JOIN AppraisalRating ar ( NOLOCK ) ON ar.MatrixId = cm.RowId
                WHERE   ar.MatrixType = 'com'
                        AND ar.AppraisalId = @appId
                GROUP BY cm.CompetencyID ,
                        cm.CompetencyWeight;

                SELECT  wd.Kra ,
                        wd.Competencies
                FROM    dbo.AppraisalLevel al ( NOLOCK )
                        INNER JOIN weightageDefination wd ( NOLOCK ) ON al.RowId = wd.AppraisalLevelId
                WHERE   al.RowId = @LrowId;

                RETURN;
            END;
        IF @flag = 'comp_grid'
            BEGIN
                SELECT  cm.RowId ,
                        cm.CompetencyID ,
                        cm.CompetencyWeight ,
                        cm.CompetencyKeyID ,
                        cm.CompetencyKeyWeight ,
                        al.LevelName ,
                        ar.Score
                FROM    competencyMatrix cm ( NOLOCK )
                        INNER JOIN AppraisalLevel al ( NOLOCK ) ON cm.AppraisalLevelId = al.RowId
                        LEFT JOIN ( SELECT  MatrixId ,
                                            Score
                                    FROM    dbo.AppraisalRating (NOLOCK)
                                    WHERE   MatrixType = 'com'
                                            AND AppraisalId = @appId
                                  ) ar ON cm.RowId = ar.MatrixId
                WHERE   cm.AppraisalLevelId = @LrowId
                ORDER BY cm.CompetencyID;

                

            END;

		IF	@flag = 'chkPrAck'
		BEGIN
			SELECT  ISNULL([status],'N') [status]
            FROM    dbo.AppraisalIndexTable (NOLOCK)
            WHERE   appId = @appId
                    AND title = 'Performance Rating Ack'; 
		END

        IF @flag = 'SaveCompetency'
            BEGIN

                IF NOT EXISTS ( SELECT  'a'
                            FROM    dbo.AppraisalIndexTable (NOLOCK)
                            WHERE   appId = @appId
                                    AND title = 'Performance Rating Ack' AND [status] = 'Y')
                    BEGIN
                        EXEC proc_errorHandler 1,
                            'Please acknowledge performance rating first',
                            NULL;
                        RETURN;	
                    END;

                SELECT  rowId = p.value('@id', 'int') ,
                        value = p.value('@value', 'varchar(200)')
                INTO    #temp2
                FROM    @xml.nodes('/root/row') AS tmp ( p );

                DELETE  FROM #temp2
                WHERE   value IS NULL
                        OR value = ''; 

                IF NOT EXISTS ( SELECT  Score
                                FROM    AppraisalRating
                                WHERE   AppraisalId = @appId
                                        AND MatrixType = 'com'
                                        AND Score IS NOT NULL )
                    BEGIN
                        INSERT  INTO dbo.AppraisalRating
                                ( MatrixType , --kpi/cj/com
                                  MatrixId ,
                                  AppraisalId ,
                                  Score ,
                                  Remarks ,
                                  Status ,
                                  Ratingby ,
                                  RatingDate 
				                )
                                SELECT  'com' ,
                                        rowId ,
                                        @appId ,
                                        value ,
                                        NULL ,
                                        'Null' ,
                                        @user ,
                                        GETDATE()
                                FROM    #temp2 (NOLOCK);

                        EXEC proc_errorHandler 0,
                            'Record has been saved successfully.', NULL;
                        RETURN;	
                    END;
                ELSE
                    BEGIN
                        UPDATE  dbo.AppraisalRating
                        SET     Score = value ,
                                Ratingby = @user ,
                                RatingDate = GETDATE()
                        FROM    #temp2 t ( NOLOCK )
                        WHERE   AppraisalId = @appId
                                AND MatrixType = 'com'
                                AND MatrixId = t.rowId;
                        EXEC proc_errorHandler 2,
                            'Record has been Updated successfully.', NULL;
                        RETURN;
                    END;
            
            END;
        IF @flag = 'SavePR'
            BEGIN 
                SELECT  rowId = p.value('@id', 'int') ,
                        value = p.value('@value', 'varchar(200)')
                INTO    #temp
                FROM    @xml.nodes('/root/row') AS tmp ( p );

                DELETE  FROM #temp
                WHERE   value IS NULL
                        OR value = '';
	
                UPDATE  p
                SET     PerformanceAfterTraining = t.value
                FROM    ProposedTraining p
                        INNER JOIN #temp t ON t.rowId = p.RowId
                WHERE   t.rowId = p.RowId;


				INSERT INTO dbo.AppraisalIndexTable
				        ( appId, title, status )
				VALUES  ( @appId, -- appId - varchar(10)
				          'Performance Rating Ack', -- title - varchar(50)
				          @prChkAck  -- status - varchar(5)
				        )

                --UPDATE  PerformanceRatingRef
                --SET     chkPR = 'Y'
                --WHERE   RowId IN ( SELECT   name
                --                   FROM     dbo.split(@chkKRA, ',') );
                --UPDATE  dbo.ProposedTraining
                --SET     PerformanceAfterTraining = ( SELECT name
                --                   FROM   dbo.split(@txtKRA,','));
                EXEC proc_errorHandler 0,
                    'Record has been saved successfully.', NULL;
                RETURN;		
            END;

        IF @flag = 'SaveKRAKPI'
            BEGIN
                SELECT  rowId = p.value('@id', 'int') ,
                        value1 = p.value('@PA', 'varchar(200)') ,
                        value2 = p.value('@R', 'varchar(200)') ,
                        value3 = p.value('@V', 'varchar(200)') ,
                        value4 = p.value('@PS', 'varchar(200)')
                INTO    #temp1
                FROM    @xml.nodes('/root/row') AS tmp ( p );

                UPDATE  A
                SET     performanceAchievement = t.value1 ,
                        performanceRemarks = t.value2 ,
                        variance = value3 
                        --performanceScore = value4
                FROM    AppraisalMatrix A
                        INNER JOIN #temp1 t ON t.rowId = A.rowId
                WHERE   t.rowId = A.rowId;
                IF NOT EXISTS ( SELECT  AppraisalId
                                FROM    AppraisalRating
                                WHERE   AppraisalId = @appId )
                    BEGIN
                        INSERT  INTO dbo.AppraisalRating
                                ( MatrixType , --kpi/cj/com
                                  MatrixId ,
                                  AppraisalId ,
                                  Score ,
                                  Remarks ,
                                  Status ,
                                  Ratingby ,
                                  RatingDate 
				                )
                                SELECT  'kpi' ,
                                        rowId ,
                                        @appId ,
                                        value4 ,
                                        NULL ,
                                        'Null' ,
                                        @user ,
                                        GETDATE()
                                FROM    #temp1 (NOLOCK);

                        EXEC proc_errorHandler 0,
                            'Record has been requested successfully.', NULL;
                        RETURN;		
                    END;
                UPDATE  dbo.AppraisalRating
                SET     --MatrixType ='kpi' , --kpi/cj/com
                          --AppraisalId=@appId ,
                        Score = value4 ,
                        Remarks = NULL ,
                        Status = 'Null' ,
                        Ratingby = @user ,
                        RatingDate = GETDATE()
                FROM    #temp1 (NOLOCK) t
                WHERE   AppraisalId = @appId
                        AND MatrixId = t.rowId
                        AND MatrixType = 'kpi';
                EXEC proc_errorHandler 2,
                    'Record has been Updated successfully.', NULL;
                RETURN;		
            END;

        IF @flag = 'SaveCJR'
            BEGIN
                SELECT  rowId = p.value('@id', 'int') ,
                        value1 = p.value('@CJR', 'varchar(200)')
                INTO    #temp4
                FROM    @xml.nodes('/root/row') AS tmp ( p );

                --UPDATE  A
                --SET     performanceAchievement = t.value1 ,
                --        performanceRemarks = t.value2 ,
                --        variance = value3 
                --        --performanceScore = value4
                --FROM    AppraisalMatrix A
                --        INNER JOIN #temp1 t ON t.rowId = A.rowId
                --WHERE   t.rowId = A.rowId;
                IF NOT EXISTS ( SELECT  AppraisalId
                                FROM    AppraisalRating
                                WHERE   AppraisalId = @appId
                                        AND MatrixType = 'CJR' )
                    BEGIN
                        INSERT  INTO dbo.AppraisalRating
                                ( MatrixType , --kpi/cj/com/CJR
                                  MatrixId ,
                                  AppraisalId ,
                                  Score ,
                                  Remarks ,
                                  Status ,
                                  Ratingby ,
                                  RatingDate 
				                )
                                SELECT  'CJR' ,
                                        rowId ,
                                        @appId ,
                                        value1 ,
                                        NULL ,
                                        'Null' ,
                                        @user ,
                                        GETDATE()
                                FROM    #temp4 (NOLOCK);

                        EXEC proc_errorHandler 0,
                            'Record has been Added successfully.', NULL;
                        RETURN;		
                    END;
                UPDATE  dbo.AppraisalRating
                SET     --MatrixType ='kpi' , --kpi/cj/com
                          --AppraisalId=@appId ,
                        Score = value1 ,
                        Remarks = NULL ,
                        Status = 'Null' ,
                        Ratingby = @user ,
                        RatingDate = GETDATE()
                FROM    #temp4 (NOLOCK) t
                WHERE   AppraisalId = @appId
                        AND MatrixId = t.rowId
                        AND MatrixType = 'CJR';
                EXEC proc_errorHandler 2,
                    'Record has been Updated successfully.', NULL;
                RETURN;		
            END;

        IF @flag = 'SaveSupervisorComment'
            BEGIN
                IF EXISTS ( SELECT  'X'
                            FROM    appraisalcomment c WITH ( NOLOCK )
                                    INNER JOIN appraisalInitation a WITH ( NOLOCK ) ON a.appraisalId = c.appraisalId
                            WHERE   c.appraisalId = @appId )
                    BEGIN
                        DELETE  FROM appraisalcomment
                        WHERE   questionId IN (
                                SELECT  c.questionId
                                FROM    appraisalcomment c WITH ( NOLOCK )
                                        INNER JOIN appraisalInitation a WITH ( NOLOCK ) ON a.appraisalId = c.appraisalId
                                WHERE   c.appraisalId = @appId );
                    END;
                INSERT  INTO dbo.appraisalcomment
                        ( appraisalId, questionId, comment, commentBy,
                          commenterType, createdDate, Remarks )
                VALUES  ( @appId, 1, -- questionId - int
                          @an1, -- comment - varchar(500)
                          @user, -- commentBy - int
                          @commenterType, -- commenterType - varchar(50)
                          GETDATE(),  -- createdDate - datetime
                          @remarks ),
                        ( @appId, 2, -- questionId - int
                          @an2, -- comment - varchar(500)
                          @user, -- commentBy - int
                          @commenterType, -- commenterType - varchar(50)
                          GETDATE(),  -- createdDate - datetime
                          @remarks ),
                        ( @appId, 3, -- questionId - int
                          @an3, -- comment - varchar(500)
                          @user, -- commentBy - int
                          @commenterType, -- commenterType - varchar(50)
                          GETDATE(),  -- createdDate - datetime
                          @remarks )	,
                        ( @appId, 4, -- questionId - int
                          @an4, -- comment - varchar(500)
                          @user, -- commentBy - int
                          @commenterType, -- commenterType - varchar(50)
                          GETDATE(),  -- createdDate - datetime
                          @remarks )	,
                        ( @appId, 5, -- questionId - int
                          @an5, -- comment - varchar(500)
                          @user, -- commentBy - int
                          @commenterType, -- commenterType - varchar(50)
                          GETDATE(),  -- createdDate - datetime
                          @remarks );	

                UPDATE  dbo.appraisalInitation
                SET     [STATUS] = 'Reviewed by Supervisor' ,
                        modifiedBy = @user ,
                        modifiedDate = GETDATE()
                WHERE   employeeId = @empId
                        AND appraisalId = @appId;

                EXEC proc_errorHandler 0,
                    'Record has been added successfully.', NULL;
                RETURN;					
						
            END;
        IF @flag = 'getSupervisorComment'
            BEGIN
                SELECT  c.* ,
                        a.STATUS
                FROM    appraisalcomment c WITH ( NOLOCK )
                        INNER JOIN appraisalInitation a WITH ( NOLOCK ) ON a.appraisalId = c.appraisalId
                WHERE   c.appraisalId = @appId;
            END;

        IF @flag = 'getReviewerType'
            BEGIN
                DECLARE @reviewerType VARCHAR(20);
                SET @reviewerType = NULL;
                IF EXISTS ( SELECT  'a'
                            FROM    dbo.appraisalInitation WITH ( NOLOCK )
                            WHERE   supervisorId = @user
                                    AND appraisalId = @appId )
                    BEGIN
                        SET @reviewerType = 'S';
                    END;
                IF EXISTS ( SELECT  'a'
                            FROM    dbo.appraisalInitation WITH ( NOLOCK )
                            WHERE   reviewerId = @user
                                    AND appraisalId = @appId )
                    BEGIN
                        IF EXISTS ( SELECT  'b'
                                    FROM    dbo.appraisalcomment
                                    WHERE   appraisalId = @appId
                                            AND commenterType = 'Supervisor' )
                            BEGIN
                                IF @reviewerType IS NOT NULL
                                    SET @reviewerType += 'R';
                                ELSE
                                    SET @reviewerType = 'R';
                            END;
                       
                    END;
                IF EXISTS ( SELECT  'a'
                            FROM    dbo.appReviewerList
                            WHERE   Active = 'Y'
                                    AND AppraisalLevelId = @LrowId
                                    AND EmployeeName = @user )
                    BEGIN
                        IF EXISTS ( SELECT  'b'
                                    FROM    dbo.appraisalcomment
                                    WHERE   appraisalId = @appId
                                            AND commenterType = 'Reviewer' )
                            BEGIN
                                IF @reviewerType IS NOT NULL
                                    SET @reviewerType += 'C';
                                ELSE
                                    SET @reviewerType = 'C';
                            END;
                    END;

                IF ( ( SELECT   s.DETAIL_TITLE
                       FROM     dbo.Employee e ( NOLOCK )
                                INNER JOIN dbo.StaticDataDetail s ( NOLOCK ) ON e.POSITION_ID = s.ROWID
                       WHERE    e.EMPLOYEE_ID = @user
                     ) = 'CEO' )
                    BEGIN
                        IF @reviewerType IS NOT NULL
                            SET @reviewerType += 'O';
                        ELSE
                            SET @reviewerType = 'O';
                    END;


                SELECT  @reviewerType;
            END;

        IF @flag = 'disagreeComment'
            BEGIN
                UPDATE  dbo.appraisalInitation
                SET     [STATUS] = 'Disagreed By Reviewer' ,
                        modifiedBy = @user ,
                        modifiedDate = GETDATE()
                WHERE   employeeId = @empId
                        AND appraisalId = @appId;
                EXEC proc_errorHandler 0,
                    'Record has been updated successfully.', NULL;
                RETURN;	
            END;
        IF @flag = 'SaveRevComment'
            BEGIN
                IF EXISTS ( SELECT  'a'
                            FROM    dbo.appraisalcomment WITH ( NOLOCK )
                            WHERE   appraisalId = @appId
                                    AND questionId = '6' )
                    BEGIN
                        DELETE  FROM dbo.appraisalcomment
                        WHERE   appraisalId = @appId
                                AND questionId IN ( '6', '7' );
                    END;
                SELECT  deptId = p.value('@id', 'int') ,
                        comment = p.value('@comment', 'varchar(200)') ,
                        appraisalId = @appId
                INTO    #temp3
                FROM    @xml.nodes('/root/row') AS tmp ( p );

                DELETE  FROM #temp3
                WHERE   deptId IS NULL
                        OR deptId = '';
											
                INSERT  INTO dbo.AppraisalSuitDept
                        ( AppraisalId ,
                          DeptId ,
                          Remarks
                        )
                        SELECT  @appId ,
                                deptId ,
                                comment
                        FROM    #temp3 WITH ( NOLOCK );
                --SELECT  *
                --FROM    #temp3;
							 --SELECT @AppraId1 = scope_identity();
                INSERT  INTO dbo.appraisalcomment
                        ( appraisalId, questionId, comment, commentBy,
                          commenterType, createdDate, Remarks )
                VALUES  ( @appId, -- appraisalId - int
                          '6', -- questionId - int
                          @an6, -- comment - varchar(500)
                          @user, -- commentBy - int
                          'Reviewer', -- commenterType - varchar(50)
                          GETDATE(), -- createdDate - datetime
                          @remarks  -- Remarks - varchar(max)
                          ),
                        ( @appId, -- appraisalId - int
                          '7', -- questionId - int
                          @an7, -- comment - varchar(500)
                          @user, -- commentBy - int
                          'Reviewer', -- commenterType - varchar(50)
                          GETDATE(), -- createdDate - datetime
                          @remarks  -- Remarks - varchar(max)
                          );
                UPDATE  dbo.appraisalInitation
                SET     [STATUS] = 'Agreed by Reviewer' ,
                        modifiedBy = @user ,
                        modifiedDate = GETDATE()
                WHERE   employeeId = @empId
                        AND appraisalId = @appId;

                EXEC proc_errorHandler 0,
                    'Record has been Saved successfully.', NULL;
                RETURN;	
				
            --END;
			--ELSE
			--	BEGIN
			--	    EXEC proc_errorHandler 1,
   --                 'Record has not been Saved.', NULL;
   --             RETURN;	
			--	END
            END;
				
        IF @flag = 'getReviewerComment'
            BEGIN
			--SELECT 
			--a.DeptId,a.Remarks,c.questionId,c.comment,c.Remarks
			--FROM dbo.AppraisalSuitDept a WITH (NOLOCK) 
			--INNER  JOIN appraisalcomment c WITH (NOLOCK) ON a.AppraisalId=c.appraisalId
			--WHERE c.commenterType = 'Reviewer' AND a.AppraisalId = @appId


                SELECT  *
                FROM    dbo.AppraisalSuitDept
                WHERE   AppraisalId = @appId;
                SELECT  *
                FROM    dbo.appraisalcomment
                WHERE   appraisalId = @appId
                        AND commenterType = 'Reviewer';
            END;
        IF @flag = 'getComMemberComment'
            BEGIN
                SELECT  *
                FROM    dbo.appraisalcomment WITH ( NOLOCK )
                WHERE   appraisalId = @appId
                        AND commenterType = 'Committee';
                SELECT  *
                FROM    dbo.appraisalcomment WITH ( NOLOCK )
                WHERE   appraisalId = @appId
                        AND commenterType = 'CEO';
            END;
        IF @flag = 'SaveComMemberComment'
            IF NOT EXISTS ( SELECT  'a'
                            FROM    dbo.appraisalcomment WITH ( NOLOCK )
                            WHERE   appraisalId = @appId
                                    AND questionId = '9' )
                BEGIN
                    INSERT  INTO dbo.appraisalcomment
                            ( appraisalId, questionId, comment, commentBy,
                              commenterType, createdDate, Remarks, Freeze )
                    VALUES  ( @appId, -- appraisalId - int
                              '9', -- questionId - int
                              @an9, -- comment - varchar(500)
                              @user, -- commentBy - int
                              'Committee', -- commenterType - varchar(50)
                              GETDATE(), -- createdDate - datetime
                              @remarks,  -- Remarks - varchar(max)
                              @freeze ),
                            ( @appId, -- appraisalId - int
                              '10', -- questionId - int
                              @an10, -- comment - varchar(500)
                              @user, -- commentBy - int
                              'Committee', -- commenterType - varchar(50)
                              GETDATE(), -- createdDate - datetime
                              @remarks,  -- Remarks - varchar(max)
                              @freeze );
                    UPDATE  dbo.appraisalInitation
                    SET     [STATUS] = 'Reviewed by Committee members' ,
                            modifiedBy = @user ,
                            modifiedDate = GETDATE()
                    WHERE   employeeId = @empId
                            AND appraisalId = @appId;

                    EXEC proc_errorHandler 0,
                        'Record has been Saved successfully.', NULL;
                    RETURN;	
                END;
        IF @flag = 'SaveCEOComment'
            IF NOT EXISTS ( SELECT  'a'
                            FROM    dbo.appraisalcomment WITH ( NOLOCK )
                            WHERE   appraisalId = @appId
                                    AND questionId = '8' )
                BEGIN
                    INSERT  INTO dbo.appraisalcomment
                            ( appraisalId ,
                              questionId ,
                              comment ,
                              commentBy ,
                              commenterType ,
                              createdDate ,
                              Remarks
			                )
                    VALUES  ( @appId , -- appraisalId - int
                              '8' , -- questionId - int
                              @an8 , -- comment - varchar(500)
                              @user , -- commentBy - int
                              'CEO' , -- commenterType - varchar(50)
                              GETDATE() , -- createdDate - datetime
                              @remarks  -- Remarks - varchar(max)
			                );
                    EXEC proc_errorHandler 0,
                        'Record has been Saved successfully.', NULL;
                    RETURN;	
                END;
        IF @flag = 'UpdateComMemberComment'
            BEGIN
                UPDATE  dbo.appraisalcomment
                SET     comment = @an9 ,
                        Remarks = @remarks ,
                        Freeze = @freeze
                WHERE   questionId = '9'
                        AND appraisalId = @appId;
                UPDATE  dbo.appraisalcomment
                SET     comment = @an10 ,
                        Remarks = @remarks ,
                        Freeze = @freeze
                WHERE   questionId = '10'
                        AND appraisalId = @appId;
			    
                EXEC proc_errorHandler 0,
                    'Record has been updated successfully.', NULL;
                RETURN;	
            END;
        IF @flag = 'getCommitteeMembers'
            BEGIN
                SELECT  R.RowId ,
                        E.FIRST_NAME + ' ' + E.MIDDLE_NAME + '' + E.LAST_NAME AS EmployeeName ,
                        R.AppraisalLevelId ,
                        R.Active ,
                        dbo.GetPosOfId(E.POSITION_ID) AS comMatrixName
                FROM    dbo.appReviewerList R ( NOLOCK )
                        INNER JOIN dbo.AppraisalLevel L ( NOLOCK ) ON L.RowId = R.AppraisalLevelId
                        INNER JOIN dbo.Employee E ON E.EMPLOYEE_ID = R.EmployeeName
                WHERE   R.AppraisalLevelId = @LrowId
                        AND R.Active = 'Y';
            END;
        IF @flag = 'DisagreeMail'
            BEGIN
                DECLARE @msgContent VARCHAR(MAX) ,
                    @appraisalStartDate VARCHAR(50) ,
                    @appraisalEndDate VARCHAR(50) ,
                    @empname VARCHAR(50) ,
                    @approver VARCHAR(50) ,
                    @Supervisor VARCHAR(50) ,
                    @recipient VARCHAR(200);
                SELECT  @appraisalStartDate = appraisalStartDate ,
                        @appraisalEndDate = appraisalEndDate ,
                        @Supervisor = supervisorId
                FROM    appraisalInitation (NOLOCK)
                WHERE   appraisalId = @appId;

                SELECT  @empname = dbo.GetEmployeeFullNameOfId(@empId) ,
                        @approver = dbo.GetEmployeeFullNameOfId(@user);

				
				
                SET @msgContent = 'Dear Sir/Madam

					It is notified to you that appraisal for ' + ISNULL(@empname, '')
										+ ' between '
										+ CONVERT(VARCHAR, ISNULL(@appraisalStartDate, GETDATE()), 107)
										+ ' and ' + CONVERT(VARCHAR, ISNULL(@appraisalEndDate,
																			GETDATE()), 107)
										+ ' has disagreed by ' + ISNULL(@approver, '') + '.
					Please review for the details.

					click here to go in system : 

					Thanks & Regards
					Siddhartha Bank Limited (HR Department)';


                SELECT  @recipient = OFFICIAL_EMAIL
                FROM    Employee (NOLOCK)
                WHERE   EMPLOYEE_ID = @Supervisor;
			
                EXEC [PROC_MAIL_SEND] @recipient = @recipient,
                    @subject_text = 'Appraisal Disagree',
                    @msg_text = @msgContent;
                EXEC proc_errorHandler 0, 'Mail Queued Successfully.', NULL;
            END;
    END;