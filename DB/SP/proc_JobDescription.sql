ALTER PROCEDURE proc_JobDescription
    @flag VARCHAR(50) ,
    @employeeId INT = NULL ,
    @branchId INT = NULL ,
    @funcId INT = NULL ,
    @positionId INT = NULL ,
    @superVisor INT = NULL ,
    @startDate DATE = NULL ,
    @endDate DATE = NULL ,
    @funcobj VARCHAR(MAX) = NULL ,
    @directRpt INT = NULL ,
    @user INT = NULL ,
    @generalJD VARCHAR(MAX) = NULL ,
    @servicesJD VARCHAR(MAX) = NULL ,
    @keyCompetent VARCHAR(MAX) = NULL ,
    @rowId INT = NULL
AS
    IF @flag = 'getEmpDetails'
        BEGIN
            SELECT  E.BRANCH_ID ,
                    dbo.GetBranchName(E.BRANCH_ID) AS branch ,
                    E.FUNCTIONAL_TITLE ,
                    E.POSITION_ID ,
                    sd.DETAIL_TITLE AS functional ,
                    sdd.DETAIL_TITLE AS position ,
                    sup.SUPERVISOR ,
                    dbo.GetEmployeeFullNameOfId(sup.SUPERVISOR) SupName
            FROM    dbo.Employee E ( NOLOCK )
                    LEFT JOIN dbo.SuperVisroAssignment sup ( NOLOCK ) ON E.EMPLOYEE_ID = sup.EMP
                    LEFT JOIN dbo.StaticDataDetail sd ( NOLOCK ) ON E.FUNCTIONAL_TITLE = sd.ROWID
                    LEFT JOIN dbo.StaticDataDetail sdd ( NOLOCK ) ON E.POSITION_ID = sdd.ROWID
            WHERE   E.EMPLOYEE_ID = @employeeId;
        END;

    IF @flag = 'ti'
        BEGIN
            INSERT  INTO temp_jobDesc
                    ( rptStaffId, createdBy )
                    SELECT  @employeeId ,
                            @user;  	 
            SELECT  'SUCCESS' AS MSG;
        END;

    IF @flag = 'getRpt'
        BEGIN
            SELECT  ID ,
                    dbo.GetEmployeeFullNameOfId(rptStaffId) AS name
            FROM    temp_jobDesc	(NOLOCK);
        END;

    IF @flag = 'del'
        BEGIN
            DELETE  FROM temp_jobDesc
            WHERE   ID = @rowId;
            SELECT  'SUCCESS' AS MSG;
        END;

    IF @flag = 'insert'
        BEGIN	
            BEGIN TRY	
                DECLARE @tempid INT;
                BEGIN TRANSACTION;
                INSERT  INTO dbo.jobDescription
                        ( empId ,
                          branchId ,
                          functionId ,
                          positionId ,
                          supervisorId ,
                          startDate ,
                          endDate ,
                          functionalObjectives ,
                          generalJD ,
                          servicesJD ,
                          keyCompetence ,
                          flag ,
                          createdBy ,
                          createdDate
			            )
                        SELECT  @employeeId ,
                                @branchId ,
                                @funcId ,
                                @positionId ,
                                @superVisor ,
                                @startDate ,
                                @endDate ,
                                @funcobj ,
                                @generalJD ,
                                @servicesJD ,
                                @keyCompetent ,
                                'N' ,
                                @user ,
                                GETDATE();

                SET @tempid = SCOPE_IDENTITY();

                INSERT  INTO dbo.jdDirectReports
                        ( jdId ,
                          drEmpId ,
                          active ,
                          createdBy ,
                          createdDate
				        )
                        SELECT  @tempid ,
                                rptStaffId ,
                                'N' ,
                                @user ,
                                GETDATE()
                        FROM    temp_jobDesc;
                TRUNCATE TABLE temp_jobDesc;
                SELECT  'SUCCESS' AS MSG;
                COMMIT TRANSACTION;
            END TRY
            BEGIN CATCH
                ROLLBACK TRANSACTION;
                SELECT  'ERROR' AS MSG;
            END CATCH;
        END;

    IF @flag = 'trunc'
        BEGIN
            IF EXISTS ( SELECT  *
                        FROM    temp_jobDesc
                        WHERE   createdBy = @user )
                BEGIN 
                    TRUNCATE TABLE temp_jobDesc; 
                END;
        END;

    IF @flag = 'getData'
        BEGIN
            SELECT  dbo.GetEmployeeFullNameOfId(j.empId) AS Employee ,
                    dbo.GetBranchName(j.branchId) AS Branch ,
                    dbo.GetPosOfId(j.positionId) AS Position ,
                    dbo.GetFuncTitleOfId(j.functionId) AS Functional ,
                    dbo.GetEmployeeFullNameOfId(j.supervisorId) AS Supervisor ,
					j.startDate,
					j.endDate,
                    j.functionalObjectives ,
                    j.servicesJD ,
                    j.generalJD ,
                    j.keyCompetence
            FROM    dbo.jobDescription j ( NOLOCK )
            WHERE   j.rowId = @rowId;

            SELECT  dbo.GetEmployeeFullNameOfId(jd.drEmpId) AS RptStaff
            FROM    dbo.jdDirectReports jd ( NOLOCK )
            WHERE   jd.jdId = @rowId;
        END;
	 
    IF @flag = 'accept'
        BEGIN
            UPDATE  dbo.jobDescription
            SET     flag = 'Y'
            WHERE   rowId = @rowId;
            SELECT  'Job has been Accepted' AS MSG;
        END;
	 
    IF @flag = 'approve'
        BEGIN		
            BEGIN TRY	
                BEGIN TRANSACTION;
                UPDATE  dbo.jobDescription
                SET     flag = 'A'
                WHERE   rowId = @rowId;

                UPDATE  dbo.jdDirectReports
                SET     active = 'Y'
                WHERE   jdId = @rowId;
                SELECT  'Job has been Approved' AS MSG;
                COMMIT TRANSACTION;
            END TRY
            BEGIN CATCH
                ROLLBACK TRANSACTION;
                SELECT  'ERROR' AS MSG;
            END CATCH;
        END;	
	 
    IF @flag = 'chkstaff'
        BEGIN
            SELECT  *
            FROM    dbo.temp_jobDesc (NOLOCK);
        END;

			
