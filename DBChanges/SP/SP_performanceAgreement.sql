ALTER PROC sp_performanceAgreement
    @user VARCHAR(50) = NULL ,
    @flag VARCHAR(50) ,
    @rowId VARCHAR(50) = NULL ,
    @empId INT = NULL ,
    @appId INT = NULL ,
    @session_id VARCHAR(100) = NULL ,
    @currentBranch VARCHAR(100) = NULL ,
    @currentDepartment VARCHAR(100) = NULL ,
    @currentSubDepartment VARCHAR(20) = NULL ,
    @currentSubDepartment2 VARCHAR(20) = NULL ,
    @currentFunctionalTitle VARCHAR(100) = NULL ,
    @currentPosition VARCHAR(100) = NULL ,
    @dateOfJoining VARCHAR(100) = NULL ,
    @Supervisor VARCHAR(100) = NULL ,
    @ReviewingOfficer VARCHAR(100) = NULL ,
    @paEffectiveFrom VARCHAR(100) = NULL ,
    @paEffectiveTo VARCHAR(100) = NULL ,
    @lastPromotedDate VARCHAR(100) = NULL ,
    @kraTopic VARCHAR(300) = NULL ,
    @kraWeight DECIMAL(10, 2) = NULL ,
    @kpiTopic VARCHAR(300) = NULL ,
    @kpiWeight DECIMAL(10, 2) = NULL ,
    @objectives VARCHAR(100) = NULL ,
    @deductionScore VARCHAR(100) = NULL ,
    @proposedArea VARCHAR(100) = NULL ,
    @criticality VARCHAR(100) = NULL ,
    @pRDate VARCHAR(100) = NULL ,
    @remarks VARCHAR(MAX) = NULL ,
    @fromDate VARCHAR(20) = NULL ,
    @toDate VARCHAR(20) = NULL ,
    @role VARCHAR(20) = NULL
AS
    SET NOCOUNT ON;
    SET ANSI_NULLS ON;
    SET XACT_ABORT ON;
    BEGIN
        DECLARE @AppraId INT ,
            @maxNofQtnKpi INT ,
            @ttlWeightKpi DECIMAL(10, 2) ,--total kpi weight at question setup
            @maxNofQtnKra INT ,
            @ttlWeightKra DECIMAL(10, 2) ,--total kra weight at question setup
            @ttlKraWeight DECIMAL(10, 2) ,
            @ttlKpiWeight DECIMAL(10, 2) ,
            @msg VARCHAR(MAX) ,
            @existingQuestionKra INT ,
            @existingQuestionKpi INT ,
            @remainingWeight VARCHAR(50);
        DECLARE @maxNofQtnC INT = NULL ,
            @ttlWeightC DECIMAL(10, 2) = NULL ,
            @ttlCriWeightC DECIMAL(10, 2) = NULL ,
            @msgC VARCHAR(MAX) = NULL ,
            @existingQuestionC INT = NULL;
        SELECT  @AppraId = appraisalId
        FROM    dbo.appraisalInitation WITH ( NOLOCK )
        WHERE   employeeId = @empId;
        IF @flag = 'ri'
            BEGIN
                DECLARE @depart VARCHAR(20) ,
                    @hrHead VARCHAR(20);

                SELECT  @depart = d.DEPARTMENT_SHORT_NAME
                FROM    dbo.Employee e
                        INNER JOIN dbo.Departments d ON e.DEPARTMENT_ID = d.DEPARTMENT_ID
                WHERE   e.EMPLOYEE_ID = @user;

                SET @hrHead = ( SELECT DISTINCT
                                        'A'
                                FROM    dbo.user_role r
                                        INNER JOIN dbo.StaticDataDetail s ON r.role_id = s.ROWID
                                        INNER JOIN dbo.Admins a ON a.AdminID = r.user_id
                                WHERE   s.TYPE_ID = '25'
                                        AND s.DETAIL_TITLE = 'Head HR'
                                        AND a.Name = @user
                              );

                IF ( ( @user = @empId )
                     OR ( ( SELECT  'a'
                            FROM    ( SELECT    SUPERVISOR
                                      FROM      SuperVisroAssignment (NOLOCK)
                                      WHERE     EMP = @empId
                                                AND record_status = 'y'
                                    ) x
                            WHERE   x.SUPERVISOR IN ( @user )
                          ) = 'a' )
                     OR ( @depart = 'Human Resource' )
                     OR ( @hrHead = 'A' )
                   )
                    BEGIN

				--SELECT @depart AS Depart ,@hrHead AS HrHead,@user AS [USER] , @empId AS Appraisee
                        IF EXISTS ( SELECT  'A'
                                    FROM    appraisalInitation WITH ( NOLOCK )
                                    WHERE   employeeId = @empId
                                            AND appraisalEndDate >= @paEffectiveFrom )
                            BEGIN
                                EXEC proc_errorHandler 1,
                                    'You cannot choose same employee for appraisal twice.',
                                    NULL;
                                RETURN;	
                            END;
                        INSERT  INTO appraisalInitation
                                ( employeeId ,
                                  currBranchId ,
                                  currDeptId ,
                                  currentSubUnit ,
                                  currPosition ,
                                  currFuncTitle ,
                                  joiningDate ,
                                  confirmationDate ,
                                  lastPromotionDate ,
                                  lastTransferDate ,
                                  appraisalStartDate ,
                                  appraisalEndDate ,
                                  supervisorId ,
                                  reviewerId ,
                                  createdBy ,
                                  createdDate ,
                                  currSubDeptId ,
                                  [STATUS] ,
                                  currSubDeptId2	
		                        )
                                SELECT  @empId ,
                                        @currentBranch ,
                                        @currentDepartment ,
                                        '' ,
                                        @currentPosition ,
                                        @currentFunctionalTitle ,
                                        @dateOfJoining ,
                                        '' ,
                                        @lastPromotedDate ,
                                        '' ,
                                        @paEffectiveFrom ,
                                        @paEffectiveTo ,
                                        @Supervisor ,
                                        @ReviewingOfficer ,
                                        @user ,
                                        GETDATE() ,
                                        @currentSubDepartment ,
                                        'Initiated' ,
                                        @currentSubDepartment2;
                                				
                        EXEC proc_errorHandler 0,
                            'Record has been saved successfully.', NULL;
                        RETURN;	
                    END;
                ELSE
                    BEGIN
				--SELECT @depart AS Depart ,@hrHead AS HrHead,@user AS [USER] , @empId AS Appraisee
                        EXEC proc_errorHandler 1,
                            'You are not authorized for this operation', NULL;
                        RETURN;	
                    END;
                														
            END;

        IF @flag = 'ri_update'
            BEGIN
			--select @appId
			--return
                UPDATE  dbo.appraisalInitation
                SET     appraisalStartDate = @paEffectiveFrom ,
                        appraisalEndDate = @paEffectiveTo ,
                        supervisorId = @Supervisor ,
                        reviewerId = @ReviewingOfficer
                WHERE   employeeId = @empId
                        AND appraisalId = @appId;

                EXEC proc_errorHandler 0,
                    'Record has been updated successfully.', NULL;
                RETURN;	
            END;
        IF @flag = 'delAppIniRecord'
            BEGIN
                DELETE  FROM dbo.appraisalInitation
                WHERE   employeeId = @empId
                        AND appraisalId = @appId;
                EXEC proc_errorHandler 0,
                    'Record has been deleted successfully.', NULL;
                RETURN;	
            END;
        IF @flag = 'a'
            BEGIN
                SELECT  empId ,
                        curBranch ,
                        currBranchId ,
                        curDept ,
                        curDeptId ,
                        curSubDept ,
                        curSubDeptId ,
                        curSubDept2 ,
                        curSubDeptId2 ,
                        currPosition ,
                        currpositionId ,
                        CONVERT(VARCHAR, joiningDate, 101) AS joiningDate ,
                        lastPromotedDate ,
                        CASE WHEN Promo.PROMOTION_DATE IS NULL
                             THEN ABS(DATEDIFF(DAY, joiningDate, GETDATE()))
                             ELSE ABS(DATEDIFF(DAY, PROMOTION_DATE, GETDATE()))
                        END timeSpentOnCurrPosition ,
                        dbo.GetDetailTitle(ISNULL(lastpromtedPosition, '')) lastpromtedPosition ,
                        lastpromtedPosition [oldpositionId] ,
                        CASE WHEN EFFECTIVE_DATE IS NULL
                             THEN ABS(DATEDIFF(DAY, joiningDate, GETDATE()))
                             ELSE ABS(DATEDIFF(DAY, EFFECTIVE_DATE, GETDATE()))
                        END timeSpentOnCurrBranch ,
                        dbo.GetBranchName(ISNULL(lasttransfedBranch, '')) lasttransfedBranch ,
                        lasttransfedBranch [oldBranchID]
                FROM    ( SELECT    e.EMPLOYEE_ID AS empId ,
                                    b.BRANCH_NAME AS curBranch ,
                                    b.BRANCH_ID AS currBranchId ,
                                    d.DEPARTMENT_NAME AS curDept ,
                                    d.DEPARTMENT_ID AS curDeptId ,
                                    sd.DEPARTMENT_NAME AS curSubDept ,
                                    sd.DEPARTMENT_ID AS curSubDeptId ,
                                    ssd.DEPARTMENT_NAME AS curSubDept2 ,
                                    ssd.DEPARTMENT_ID AS curSubDeptId2 ,
                                    p.DETAIL_DESC AS currPosition ,
                                    p.ROWID AS currpositionId ,
                                    e.JOINED_DATE AS joiningDate ,
                                    e.LASTPROMOTED AS lastPromotedDate
                          FROM      Employee e ( NOLOCK )
                                    INNER JOIN Branches b ( NOLOCK ) ON e.BRANCH_ID = b.BRANCH_ID
                                    INNER JOIN Departments d ( NOLOCK ) ON e.DEPARTMENT_ID = d.DEPARTMENT_ID
                                    LEFT JOIN Departments sd ( NOLOCK ) ON sd.DEPARTMENT_ID = e.SUB_DEPARTMENT
                                    LEFT JOIN Departments ssd ( NOLOCK ) ON ssd.DEPARTMENT_ID = e.SUB_DEPARTMENT2
                                    INNER JOIN dbo.StaticDataDetail p ( NOLOCK ) ON p.ROWID = e.POSITION_ID
                          WHERE     e.EMPLOYEE_ID = @empId
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
            
        IF @flag = 'pas'
            BEGIN
                SELECT  empName ,
                        BRANCH_NAME ,
                        DEPARTMENT_NAME ,
                        SUBDEPARTMENT_NAME ,
                        SUBDEPARTMENT_NAME2 ,
                        CURRPOSITION ,
                        CONVERT(VARCHAR, joiningDate, 101) AS joiningDate ,
                        confirmationDate ,
                        lastPromotionDate ,
                        lastTransferDate ,
                        reviewerId ,
                        main.supervisorId ,
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
                                    sdd.DEPARTMENT_NAME AS SUBDEPARTMENT_NAME2 ,
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
                                    LEFT JOIN Departments sdd ( NOLOCK ) ON sdd.DEPARTMENT_ID = a.currSubDeptId2
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
            
        IF @flag = 'u'
            BEGIN
                IF @appId IS NULL
                    BEGIN
                        EXEC proc_errorHandler 1,
                            'Please, select employee for appraisal first',
                            NULL;
                        RETURN;
                    END;
                DECLARE @kraTopicOld VARCHAR(100) ,
                    @kraWeightOld DECIMAL(10, 2) ,
                    @kpiTopicOld VARCHAR(100) ,
                    @kpiWeightOld DECIMAL(10, 2); 
				
				
                SELECT  @kraTopicOld = kraTopic ,
                        @kraWeightOld = kraWeightage ,
                        @kpiTopicOld = kpiTopic ,
                        @kpiWeightOld = kpiWeightage
                FROM    dbo.AppraisalMatrix WITH ( NOLOCK )
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
                          FROM      AppraisalMatrix WITH ( NOLOCK )
                          WHERE     appraisalId = @appId
                        ) X;
	             
	           
	                
                SELECT  @ttlKpiWeight = ( SUM(ISNULL(kpiWeightage, 0))
                                          - ISNULL(@kpiWeightOld, 0) )
                FROM    AppraisalMatrix WITH ( NOLOCK )
                WHERE   appraisalId = @appId
                        AND kraTopic = @kraTopicOld;

                IF ( ISNULL(@ttlKpiWeight, 0) + ISNULL(@kpiWeight, 0) > ISNULL(@kraWeight,
                                                              0) )
                    BEGIN 
                        EXEC proc_errorHandler 1,
                            'KRA Weightage must be greater or equal to total KPI Weightage', NULL;
                        RETURN;
                    END;
                
                IF ( @kraTopicOld <> @kraTopic )
                    BEGIN
                        IF EXISTS ( SELECT  'a'
                                    FROM    AppraisalMatrix WITH ( NOLOCK )
                                    WHERE   appraisalId = @appId
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
                                    FROM    AppraisalMatrix WITH ( NOLOCK )
                                    WHERE   appraisalId = @appId
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
					--SELECT   'a'
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
                        UPDATE  AppraisalMatrix
                        SET     kraTopic = @kraTopic ,
                                kraWeightage = @kraWeight ,
                                modifiedBy = @user ,
                                modifiedDate = GETDATE()
                        WHERE   rowId IN (
                                SELECT  rowId
                                FROM    dbo.AppraisalMatrix(NOLOCK)
                                WHERE   kraTopic = @kraTopicOld );
                    END; 
                       
           
                IF ( @kpiTopicOld <> @kpiTopic
                     OR @kpiWeightOld <> @kpiWeight
                   )
                    BEGIN
                        UPDATE  AppraisalMatrix
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
        IF @flag = 'grid'
            BEGIN
                IF EXISTS ( SELECT  'a'
                            FROM    dbo.AppraisalMatrix WITH ( NOLOCK )
                            WHERE   appraisalId = @appId )
                    BEGIN
                        SELECT  rowId ,
                                kraTopic ,
                                kpiTopic ,
                                kraWeightage ,
                                kpiWeightage
                        FROM    AppraisalMatrix WITH ( NOLOCK )
                        WHERE   appraisalId = @appId
                        ORDER BY kraTopic ASC;
                        RETURN;
                    END;
                ELSE
                    BEGIN
                        DECLARE @positionId INT ,
                            @lvlId INT; 
                        SELECT  @positionId = POSITION_ID
                        FROM    dbo.Employee WITH ( NOLOCK )
                        WHERE   EMPLOYEE_ID = @empId; 


                        SELECT  @lvlId = AppraisalLevelId
                        FROM    AppraisalPosition WITH ( NOLOCK )
                        WHERE   PositionId = @positionId;
                        
                        IF EXISTS ( SELECT  'a'
                                    FROM    AppraisalPosition WITH ( NOLOCK )
                                    WHERE   PositionId = @positionId )
                            BEGIN
                                INSERT  INTO dbo.AppraisalMatrix
                                        ( appraisalId ,
                                          kraTopic ,
                                          kpiTopic ,
                                          kraWeightage ,
                                          kpiWeightage ,
                                          createdBy ,
                                          createdDate ,
                                          modifiedBy ,
                                          modifiedDate
					                    )
                                        SELECT  @appId , -- appraisalId - int
                                                la.kraTopic , -- kraTopic - varchar(100)
                                                la.kpiTopic , -- kpiTopic - varchar(100)
                                                la.kraWeightage , -- kraWeightage - float
                                                la.kpiWeightage , -- kpiWeightage - float
                                                0 , -- createdBy - int
                                                GETDATE() , -- createdDate - datetime
                                                0 , -- modifiedBy - int
                                                GETDATE()  -- modifiedDate - datetime
                                        FROM    LvlAppraisalMatrix la WITH ( NOLOCK )
                                        WHERE   levelId = @lvlId;

                                SELECT  rowId ,
                                        kraTopic ,
                                        kpiTopic ,
                                        kraWeightage ,
                                        kpiWeightage
                                FROM    AppraisalMatrix WITH ( NOLOCK )
                                WHERE   appraisalId = @appId
                                ORDER BY kraTopic ASC;
                                RETURN;
                            END;
                        ELSE
                            BEGIN
                                EXEC proc_errorHandler 1, 'No record found',
                                    NULL;
                                RETURN;
                            END;
				  
                    END;
				
            END;
        IF @flag = 'del'
            BEGIN
                DELETE  FROM AppraisalMatrix
                WHERE   rowId = @rowId;
				
                EXEC proc_errorHandler 0,
                    'Record has been requested successfully.', @rowId;
                RETURN;	
            END;

        IF @flag = 'ci'
            BEGIN
                IF @appId IS NOT NULL
                    BEGIN
                        SELECT  @maxNofQtnC = maxNoOfQues ,
                                @ttlWeightC = TotalWeightage
                        FROM    QuestionCntSetup WITH ( NOLOCK )
                        WHERE   QuestionGroupId = 'Critical Jobs';					
                        IF ( @maxNofQtnC IS NOT NULL )
                            BEGIN
                                SELECT  @existingQuestionC = COUNT(*) ,
                                        @ttlCriWeightC = SUM(CAST(ISNULL(DeductionScore,
                                                              0) AS FLOAT))
                                FROM    dbo.criticalJobs WITH ( NOLOCK )
                                WHERE   appraisalId = @appId;						
							--select @ttlCriWeightC
							--return			
                                IF ( ( ISNULL(@ttlCriWeightC, 0)
                                       + ISNULL(CAST(@deductionScore AS FLOAT),
                                                0) ) > ISNULL(@ttlWeightC, 100) )
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
                                        INSERT  INTO criticalJobs
                                                ( Objectives ,
                                                  DeductionScore ,
                                                  createdBy ,
                                                  createdDate ,
                                                  appraisalId
                                                )
                                        VALUES  ( @objectives ,
                                                  @deductionScore ,
                                                  @user ,
                                                  GETDATE() ,
                                                  @appId
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
                ELSE
                    BEGIN
                        EXEC proc_errorHandler 1,
                            'Please, select employee for appraisal first',
                            NULL;
                    END;
            END;

        IF @flag = 'cu'
            BEGIN
                IF @appId IS NOT NULL
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
                                SELECT  @preScore = SUM(ISNULL(DeductionScore,
                                                              0))
                                FROM    dbo.criticalJobs WITH ( NOLOCK )
                                WHERE   rowId = @rowId;

                                UPDATE  criticalJobs
                                SET     Objectives = @objectives ,
                                        DeductionScore = @deductionScore
                                WHERE   rowId = @rowId;

                                SELECT  @ttlCriWeightC = SUM(ISNULL(DeductionScore,
                                                              0))
                                FROM    dbo.criticalJobs WITH ( NOLOCK )
                                WHERE   appraisalId = @appId;
								--select @ttlCriWeightC
								--return 													
                                IF ( ( ISNULL(@ttlCriWeightC, 0) ) > ISNULL(@ttlWeightC,
                                                              100) )
                                    BEGIN
											
                                        UPDATE  criticalJobs
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
        IF @flag = 'c_grid'
            BEGIN
                IF NOT EXISTS ( SELECT  'a'
                                FROM    dbo.criticalJobs(NOLOCK)
                                WHERE   appraisalId = @appId )
                    BEGIN
						
                        DECLARE @delStatus VARCHAR(5) = NULL;
                        SELECT  @delStatus = [status]
                        FROM    dbo.AppraisalIndexTable (NOLOCK)
                        WHERE   appId = @appId
                                AND title = 'CJ';

                        IF @delStatus IS NULL
                            BEGIN
                                DECLARE @posId INT ,
                                    @IdLvl INT; 

                                SELECT  @posId = POSITION_ID
                                FROM    dbo.Employee WITH ( NOLOCK )
                                WHERE   EMPLOYEE_ID = @empId; 
                        
                                SELECT  @IdLvl = AppraisalLevelId
                                FROM    AppraisalPosition WITH ( NOLOCK )
                                WHERE   PositionId = @posId;

                                INSERT  INTO dbo.criticalJobs
                                        ( appraisalId ,
                                          Objectives ,
                                          DeductionScore ,
                                          createdBy ,
                                          createdDate 
									    )
                                        SELECT  @appId ,
                                                Objectives ,
                                                DeductionScore ,
                                                'system' ,
                                                GETDATE()
                                        FROM    LevelCriticalJobs (NOLOCK)
                                        WHERE   appraisalLevelId = @IdLvl;

                                INSERT  INTO dbo.AppraisalIndexTable
                                        ( appId, title, [status] )
                                VALUES  ( @appId, -- appId - varchar(10)
                                          'CJ', -- title - varchar(50)
                                          'init'  -- status - varchar(5)
                                          );
                            END;		
                        
                    END;
                
                SELECT  rowId ,
                        objectives = Objectives ,
                        deductionScore = DeductionScore
                FROM    criticalJobs (NOLOCK)
                WHERE   appraisalId = @appId
                ORDER BY objectives ASC;

            END;
        IF @flag = 'cdel'
            BEGIN
                DELETE  FROM criticalJobs
                WHERE   rowId = @rowId;

                EXEC proc_errorHandler 0,
                    'Record has been deleted successfully.', @rowId;
                RETURN;	
            END;
        
        IF @flag = 'pr_pt_grid'
            BEGIN
                IF @appId IS NOT NULL
                    BEGIN
                        SELECT  p.RowId ,
                                p.ProposedTrainingArea ,
                                s.DETAIL_TITLE AS Criticality ,
                                CONVERT(VARCHAR, p.ProposedByDate, 101) AS ProposedByDate ,
                                ISNULL(p.Remarks, 'N/A') AS Remarks
                        FROM    dbo.ProposedTraining p WITH ( NOLOCK )
                                INNER JOIN dbo.StaticDataDetail s ON s.ROWID = p.Criticality
                        WHERE   p.AppraisalId = @appId;
                    END;
                ELSE
                    BEGIN
                        EXEC proc_errorHandler 1,
                            'Please, select employee for appraisal first',
                            NULL;
                    END;
            END;

        IF @flag = 'pri'
            BEGIN
                IF @appId IS NULL
                    BEGIN
                        EXEC proc_errorHandler 1,
                            'Please, select employee for appraisal first.',
                            NULL;
                    END;  

                IF EXISTS ( SELECT  'A'
                            FROM    dbo.ProposedTraining WITH ( NOLOCK )
                            WHERE   AppraisalId = @appId
                                    AND ProposedTrainingArea = @proposedArea )
                    BEGIN
                        EXEC proc_errorHandler 1,
                            'You cannot insert dublicate proposed training area.',
                            NULL;
                        RETURN;
                    END;
                
            --IF((SELECT COUNT(*)+1 FROM dbo.ProposedTraining WHERE AppraisalId=@appId) > 3)
            --    BEGIN
            --        EXEC proc_errorHandler 1,
            --            'More than 3 trainings need to be justified.',
            --            NULL;
            --        RETURN;
            --    END
        
                INSERT  INTO dbo.ProposedTraining
                        ( AppraisalId ,
                          ProposedTrainingArea ,
                          Criticality ,
                          ProposedByDate ,
                          Remarks ,
                          CreatedBy ,
                          CreatedDate 
		                )
                VALUES  ( @appId , -- AppraisalId - int
                          @proposedArea , -- ProposedTrainingArea - varchar(100)
                          @criticality , -- Criticality - int
                          @pRDate , -- ProposedByDate - date
                          @remarks ,--Remarks - varchar(max)
                          @user , -- CreatedBy - int
                          GETDATE() -- CreatedDate - datetime
		                );
                EXEC proc_errorHandler 0,
                    'Record has been Inserted successfully.', NULL;
                RETURN;	
               
            END;
        IF @flag = 'pru'
            BEGIN
                IF @appId IS NULL
                    BEGIN
                        EXEC proc_errorHandler 1,
                            'Please, select employee for appraisal first.',
                            NULL;
                        RETURN;
                    END;
                DECLARE @type_id INT;
            
                SELECT  @type_id = ROWID
                FROM    dbo.StaticDataType (NOLOCK)
                WHERE   TYPE_TITLE = 'Training Criticality';
            
                SELECT  @criticality = ROWID
                FROM    dbo.StaticDataDetail (NOLOCK)
                WHERE   TYPE_ID = @type_id
                        AND DETAIL_TITLE = @criticality;
                    
                
                IF ( ( SELECT   ProposedTrainingArea
                       FROM     dbo.ProposedTraining(NOLOCK)
                       WHERE    RowId = @rowId
                                AND AppraisalId = @appId
                     ) = @proposedArea )
                    BEGIN
                        UPDATE  dbo.ProposedTraining
                        SET     ProposedTrainingArea = @proposedArea ,
                                Criticality = @criticality ,
                                ProposedByDate = @pRDate ,
                                ModifiedBy = @user ,
                                ModifiedDate = GETDATE()
                        WHERE   RowId = @rowId;
                    END;	
                ELSE
                    BEGIN
                        IF EXISTS ( SELECT  '1'
                                    FROM    dbo.ProposedTraining(NOLOCK)
                                    WHERE   ProposedTrainingArea = @proposedArea
                                            AND AppraisalId = @appId )
                            BEGIN
                                EXEC proc_errorHandler 1,
                                    'You cannot insert dublicate proposed training area.',
                                    NULL;
                                RETURN;
                            END;
                        ELSE
                            BEGIN
                                UPDATE  dbo.ProposedTraining
                                SET     ProposedTrainingArea = @proposedArea ,
                                        Criticality = @criticality ,
                                        ProposedByDate = @pRDate ,
                                        ModifiedBy = @user ,
                                        ModifiedDate = GETDATE()
                                WHERE   RowId = @rowId;
                            END;
                    END;
                EXEC proc_errorHandler 0,
                    'Record has been Updated successfully.', NULL;
                RETURN;
            END;
        IF @flag = 'pr_ViewData'
            BEGIN
                SELECT  ProposedTrainingArea ,
                        CONVERT(VARCHAR, ProposedByDate, 101) AS ProposedByDate ,
                        Remarks ,
                        Criticality
                FROM    ProposedTraining (NOLOCK)
                WHERE   AppraisalId = @appId
                        AND RowId = @rowId;
                RETURN;
            END;
        IF @flag = 'pr_grid'
            BEGIN
                SELECT  RowId ,
                        ISNULL(KraAchiveScore, 0) AS KraAchiveScore ,
                        ISNULL(PerformLblRating, 0) AS PerformLblRating ,
                        ISNULL(PercentIncrement, 0) AS PercentIncrement
                FROM    PerformanceRatingRef (NOLOCK);
                RETURN;
            END;
        IF @flag = 'prdel'
            BEGIN
                DELETE  FROM dbo.ProposedTraining
                WHERE   RowId = @rowId;
			
                EXEC proc_errorHandler 0,
                    'Record has been requested successfully.', @rowId;
                RETURN;	
            END;
    
        IF @flag = 'appEmpList'
            BEGIN
                DECLARE @roleName VARCHAR(20);
				 --@AdminId VARCHAR(20); 

                SELECT  @roleName = DETAIL_TITLE
                FROM    dbo.StaticDataDetail (NOLOCK)
                WHERE   ROWID = @role;


                IF ( @roleName = 'Review Committee' )
                    BEGIN
                        SELECT  AI.employeeId AS EMPLOYEE_ID ,
                                dbo.GetEmployeeFullNameOfId(AI.employeeId) AS EMPNAME ,
                                E.EMP_CODE
                        FROM    dbo.appraisalInitation AI WITH ( NOLOCK )
                                INNER JOIN dbo.AppraisalPosition AP WITH ( NOLOCK ) ON AI.currPosition = AP.PositionId
                                INNER JOIN dbo.Employee E WITH ( NOLOCK ) ON AI.employeeId = E.EMPLOYEE_ID
                        WHERE   AP.AppraisalLevelId IN (
                                SELECT  AppraisalLevelId
                                FROM    dbo.appReviewerList
                                WHERE   EmployeeName = @user );

                        RETURN;
                    END;

                IF ( ( ( ( SELECT   d.DEPARTMENT_SHORT_NAME
                           FROM     dbo.Employee e
                                    INNER JOIN dbo.Departments d ON d.DEPARTMENT_ID = e.DEPARTMENT_ID
                           WHERE    e.EMPLOYEE_ID = @user
                         ) = 'Human Resource' )
                       AND ( @roleName = 'HR Department' )
                     )
                     OR ( ( SELECT DISTINCT
                                    'A'
                            FROM    dbo.Admins a
                                    INNER JOIN ( SELECT user_id
                                                 FROM   dbo.user_role
                                                 WHERE  role_id IN (
                                                        SELECT
                                                              ROWID
                                                        FROM  dbo.StaticDataDetail
                                                        WHERE TYPE_ID = 25
                                                              AND DETAIL_TITLE = 'Head HR' )
                                               ) x ON x.user_id = a.AdminID
                            WHERE   a.Name = @user
                          ) = 'A' )
                   )
                    BEGIN
					
                        SELECT  e.EMPLOYEE_ID ,
                                e.EMP_CODE ,
                                dbo.GetEmployeeFullNameOfId(e.EMPLOYEE_ID) AS EMPNAME
                        FROM    dbo.appraisalInitation a ( NOLOCK )
                                INNER JOIN dbo.Employee e ( NOLOCK ) ON a.employeeId = e.EMPLOYEE_ID
                        WHERE   a.appraisalStartDate BETWEEN @fromDate
                                                     AND     @toDate
                                AND a.appraisalEndDate BETWEEN @fromDate AND @toDate;
							
			
                        RETURN;
                    END;
                ELSE
                    BEGIN
                        SELECT  e.EMPLOYEE_ID ,
                                e.EMP_CODE ,
                                dbo.GetEmployeeFullNameOfId(e.EMPLOYEE_ID) AS AppraiseeName
                        FROM    dbo.appraisalInitation a ( NOLOCK )
                                INNER JOIN dbo.Employee e ( NOLOCK ) ON a.employeeId = e.EMPLOYEE_ID
                        WHERE   a.appraisalStartDate BETWEEN @fromDate
                                                     AND     @toDate
                                AND a.appraisalEndDate BETWEEN @fromDate AND @toDate
                                AND ( CASE WHEN @roleName = 'Appraisee'
                                           THEN a.employeeId
                                           WHEN @roleName = 'Appraiser'
                                           THEN a.supervisorId
                                           WHEN @roleName = 'Reviewer'
                                           THEN a.reviewerId
                                           ELSE NULL
                                      END ) = @user;
                        RETURN;
                    END;
           
            END;
    
        IF @flag = 'i'
            BEGIN
                IF @appId IS NOT NULL
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
                                    FROM    AppraisalMatrix
                                    WHERE   appraisalId = @appId
                                            AND kraTopic = @kraTopic
                                            AND kpiTopic = @kpiTopic )
                            BEGIN
                                EXEC proc_errorHandler 1,
                                    'You cannot assign same KPI to same KRA twice',
                                    NULL;
                                RETURN;
                            END;
				
                        IF ( @maxNofQtnKpi IS NOT NULL
                             AND @maxNofQtnKra IS NOT NULL
                           )
                            BEGIN
                                SELECT  @ttlKraWeight = SUM(ISNULL(X.kraWeightage,
                                                              0))
                                FROM    ( SELECT DISTINCT
                                                    kraTopic ,
                                                    kraWeightage
                                          FROM      AppraisalMatrix WITH ( NOLOCK )
                                          WHERE     appraisalId = @appId
                                        ) X;
	                
                                SELECT  @ttlKpiWeight = SUM(ISNULL(kpiWeightage,
                                                              0))
                                FROM    AppraisalMatrix WITH ( NOLOCK )
                                WHERE   appraisalId = @appId
                                        AND kraTopic = @kraTopic;

                                SELECT  @existingQuestionKra = COUNT(DISTINCT kraTopic)
                                FROM    AppraisalMatrix WITH ( NOLOCK )
                                WHERE   appraisalId = @appId;
        
                                SELECT  @existingQuestionKpi = COUNT(kpiTopic)
                                FROM    AppraisalMatrix WITH ( NOLOCK )
                                WHERE   appraisalId = @appId
                                        AND kraTopic = @kraTopic;

                                IF NOT EXISTS ( SELECT  '1'
                                                FROM    AppraisalMatrix WITH ( NOLOCK )
                                                WHERE   kraTopic = @kraTopic
                                                        AND appraisalId = @appId
                                                        AND kraWeightage = @kraWeight )
                                    BEGIN
                                        IF ( ( ISNULL(@ttlKraWeight, 0)
                                               + ISNULL(@kraWeight, 0) ) > ISNULL(@ttlWeightKra,
                                                              100) )
                                            BEGIN
                                                SET @remainingWeight = CAST(ISNULL(( @ttlWeightKra
                                                              - @ttlKraWeight ),
                                                              0) AS VARCHAR(50));
											
                                                SET @msg = CONCAT('You can not exceed KRA weight than total weight :  ',
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
                                                EXEC proc_errorHandler 1, @msg,
                                                    NULL;
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
                                                EXEC proc_errorHandler 1, @msg,
                                                    NULL;
                                                RETURN;
                                            END;
                                    END;
                                
                                INSERT  INTO dbo.AppraisalMatrix
                                        ( appraisalId ,
                                          kraTopic ,
                                          kpiTopic ,
                                          kraWeightage ,
                                          kpiWeightage ,
                                          createdBy ,
                                          createdDate
			                            )
                                        SELECT  @appId ,
                                                @kraTopic ,
                                                @kpiTopic ,
                                                @kraWeight ,
                                                @kpiWeight ,
                                                @user ,
                                                GETDATE();
		
                                EXEC proc_errorHandler 0,
                                    'Record has been inserted successfully.',
                                    NULL;
                                RETURN; 
				    
                            END;
                        ELSE
                            BEGIN
                                EXEC proc_errorHandler 1,
                                    'Please, setup the question count first',
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
        IF @flag = 'getStatus'
            BEGIN
                SELECT  STATUS
                FROM    appraisalInitation WITH ( NOLOCK )
                WHERE   appraisalId = @appId;
                RETURN;
            END;

    END;