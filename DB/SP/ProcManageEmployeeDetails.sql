
ALTER  PROC [dbo].[ProcManageEmployeeDetails]
    @flag AS CHAR(50) ,
    @row_id AS INT = NULL ,
    @emp_code AS VARCHAR(200) = NULL ,
    @salutation AS INT = NULL ,
    @first_name AS VARCHAR(200) = NULL ,
    @middle_name AS VARCHAR(200) = NULL ,
    @last_name AS VARCHAR(200) = NULL ,
    @gender AS INT = NULL ,
    @dob AS DATE = NULL ,
    @marital_status AS INT = NULL ,
    @branch_id AS INT = NULL ,
    @dept_id AS INT = NULL ,
    @sub_dept_id AS INT = NULL ,
    @sub_dept_id2 AS INT = NULL ,
    @position_id AS INT = NULL ,
    @blood_group AS INT = NULL ,
    @PAN_number AS VARCHAR(200) = NULL ,
    @doa AS DATE = NULL ,
    @doj AS DATE = NULL ,
    @emp_status AS INT = NULL ,
    @emp_type AS INT = NULL ,
    @temp_country AS INT = NULL ,
    @temp_zone AS INT = NULL ,
    @temp_district AS INT = NULL ,
    @temp_municipality AS VARCHAR(500) = NULL ,
    @temp_ward AS VARCHAR(20) = NULL ,
    @temp_house_no AS VARCHAR(10) = NULL ,
    @temp_street_name AS VARCHAR(500) = NULL ,
    @per_country AS INT = NULL ,
    @per_zone AS INT = NULL ,
    @per_district AS INT = NULL ,
    @per_minicipality AS VARCHAR(500) = NULL ,
    @per_ward AS VARCHAR(200) = NULL ,
    @per_house_no AS VARCHAR(20) = NULL ,
    @per_street_name AS VARCHAR(500) = NULL ,
    @phone_office AS VARCHAR(100) = NULL ,
    @phone_residence AS VARCHAR(100) = NULL ,
    @mobile_office AS VARCHAR(100) = NULL ,
    @mobile_personal AS VARCHAR(100) = NULL ,
    @fax_office AS VARCHAR(100) = NULL ,
    @fax_personal AS VARCHAR(100) = NULL ,
    @email_office AS VARCHAR(200) = NULL ,
    @email_personal AS VARCHAR(200) = NULL ,
    @em_conact_person AS VARCHAR(500) = NULL ,
    @em_address AS VARCHAR(MAX) = NULL ,
    @em_relationship AS INT = NULL ,
    @em_contact1 AS VARCHAR(100) = NULL ,
    @em_contact2 AS VARCHAR(100) = NULL ,
    @em_contact3 AS VARCHAR(100) = NULL ,
    @em_email AS VARCHAR(200) = NULL ,
    @func_title AS INT = NULL ,
    @user AS VARCHAR(10) = NULL ,
    @permanent_date AS VARCHAR(20) = NULL ,
    @Individual_Profile_update AS CHAR(1) = NULL ,
    @C_START_DATE AS VARCHAR(100) = NULL ,
    @C_END_DATE AS VARCHAR(100) = NULL ,
    @CARD_NUMBER AS VARCHAR(100) = NULL ,
    @Gratuity_start_date AS DATE = NULL ,
    @SalaryTitle AS VARCHAR(100) = NULL ,
    @grade_year AS VARCHAR(10) = NULL
AS
    SET NOCOUNT ON;  
    SET XACT_ABORT ON;  
    DECLARE @rowId AS INT ,
        @userName AS VARCHAR(500) ,
        @USER_ID AS INT;  
    DECLARE @FROM_DATE VARCHAR(20) ,
        @TO_DATE VARCHAR(20) ,
        @JOIN_NPL_YEAR AS VARCHAR(20) ,
        @CURRENT_DATE AS DATE= GETDATE() ,
        @CURRENT_FY AS VARCHAR(20);  
  
    DECLARE @LASTPROMOTED VARCHAR(20);  
    DECLARE @LastTransfer VARCHAR(20);  
  
    SET @userName = @emp_code;  
    IF @middle_name IS NULL
        SET @middle_name = '';  
  
    IF @flag = 'i'
        BEGIN  
      
  --BEGIN TRANSACTION  
    
            INSERT  INTO Employee
                    ( EMP_CODE ,
                      SALUTATION ,
                      FIRST_NAME ,
                      MIDDLE_NAME ,
                      LAST_NAME ,
                      GENDER ,
                      BRANCH_ID ,
                      DEPARTMENT_ID ,
                      POSITION_ID ,
                      BIRTH_DATE ,
                      JOINED_DATE ,
                      MERITAL_STATUS ,
                      PAN_NUMBER ,
                      BLOOD_GROUP ,
                      EMP_STATUS ,
                      EMP_TYPE ,
                      APPOINTMENT_DATE ,
                      OFFICE_PHONE ,
                      HOME_PHONE ,
                      OFFICE_MOBILE ,
                      PERSONAL_MOBILE ,
                      OFFICE_FAX ,
                      PERSONAL_FAX ,
                      OFFICIAL_EMAIL ,
                      PERSONAL_EMAIL ,
                      TEMP_COUNTRY ,
                      TEMP_ZONE ,
                      TEMP_DISTRICT ,
                      TEMP_MUNICIPALITY_VDC ,
                      TEMP_WARD_NO ,
                      TEMP_HOUSE_NO ,
                      TEMP_STREET_NAME ,
                      PER_COUNTRY ,
                      PER_ZONE ,
                      PER_DISTRICT ,
                      PER_MUNICIPALITY_VDC ,
                      PER_WARD_NO ,
                      PER_HOUSE_NO ,
                      PER_STREET_NAME ,
                      EM_NAME ,
                      EM_ADDRESS ,
                      EM_RELATIONSHIP ,
                      EM_CONTACTNO1 ,
                      EM_CONTACTNO2 ,
                      EM_CONTACTNO3 ,
                      EM_EMAIL ,
                      CREATED_BY ,
                      CREATED_DATE ,
                      FUNCTIONAL_TITLE ,
                      PERMANENT_DATE ,
                      Individual_Profile_update ,
                      CARD_NUMBER ,
                      GRATUITY_EFFECTIVE_DATE ,
                      Salary_Title ,
                      GRADE ,
                      SUB_DEPARTMENT,
                      SUB_DEPARTMENT2
                    )
            VALUES  ( @emp_code ,
                      @salutation ,
                      @first_name ,
                      @middle_name ,
                      @last_name ,
                      @gender ,
                      @branch_id ,
                      @dept_id ,
                      @position_id ,
                      @dob ,
                      @doj ,
                      @marital_status ,
                      @PAN_number ,
                      @blood_group ,
                      @emp_status ,
                      @emp_type ,
                      @doa ,
                      @phone_office ,
                      @phone_residence ,
                      @mobile_office ,
                      @mobile_personal ,
                      @fax_office ,
                      @fax_personal ,
                      @email_office ,
                      @email_personal ,
                      @temp_country ,
                      @temp_zone ,
                      @temp_district ,
                      @temp_municipality ,
                      @temp_ward ,
                      @temp_house_no ,
                      @temp_street_name ,
                      @per_country ,
                      @per_zone ,
                      @per_district ,
                      @per_minicipality ,
                      @per_ward ,
                      @per_house_no ,
                      @per_street_name ,
                      @em_conact_person ,
                      @em_address ,
                      @em_relationship ,
                      @em_contact1 ,
                      @em_contact2 ,
                      @em_contact3 ,
                      @em_email ,
                      @user ,
                      GETDATE() ,
                      @func_title ,
                      @permanent_date ,
                      @Individual_Profile_update ,
                      @CARD_NUMBER ,
                      @Gratuity_start_date ,
                      @SalaryTitle ,
                      @grade_year ,
                      @sub_dept_id,
					  @sub_dept_id2
                    );  
  
            SET @rowId = @@IDENTITY;   
    
      
            INSERT  INTO Employee_Contract
                    ( EMPLOYEE_ID ,
                      Cont_DateFrm ,
                      Cont_DateTo ,
                      Created_By ,
                      Created_Date ,
                      branch_id ,
                      dept_id ,
                      position_id ,
                      emp_type
                    )
                    SELECT  @rowId ,
                            @C_START_DATE ,
                            @C_END_DATE ,
                            @user ,
                            GETDATE() ,
                            @branch_id ,
                            @dept_id ,
                            @position_id ,
                            @emp_type;  
    
  --## INSERTING APPOINTMENT HISTORY AS A SERVICE HISTORY  
            INSERT  INTO emp_log
                    ( emp_id ,
                      effective_date ,
                      branch_id ,
                      dept_id ,
                      position_id ,
                      emp_type ,
                      created_by ,
                      created_date ,
                      flag
                    )
                    SELECT  @rowId ,
                            @doj ,
                            @branch_id ,
                            @dept_id ,
                            @position_id ,
                            @emp_type ,
                            @user ,
                            GETDATE() ,
                            'a';   
    
  --## INSERTING CONFIRMATION/PERMANENT HISTORY AS A SERVICE HISTORY  
            IF @emp_type = '185'
                BEGIN   
                    INSERT  INTO emp_log
                            ( emp_id ,
                              effective_date ,
                              branch_id ,
                              dept_id ,
                              position_id ,
                              emp_type ,
                              created_by ,
                              created_date ,
                              flag
                            )
                            SELECT  @rowId ,
                                    @permanent_date ,
                                    @branch_id ,
                                    @dept_id ,
                                    @position_id ,
                                    @emp_type ,
                                    @user ,
                                    GETDATE() ,
                                    'c';   
                END;  
    
            INSERT  INTO Admins
                    ( UserName ,
                      UserPassword ,
                      Name ,
                      status ,
                      created_by ,
                      created_date
                    )
            VALUES  ( @userName ,
                      dbo.encryptDb('siddhartha') ,
                      @rowId ,
                      'Y' ,
                      @user ,
                      GETDATE()
                    );  
    
            SET @USER_ID = @@IDENTITY;  
    
            INSERT  INTO dbo.user_role
                    ( user_id, role_id )
            VALUES  ( @USER_ID, '202' );--BASIC USER ROLE    
    
  -- ### START AUTO ASSIGNMENT OF LEAVE   
         
            IF EXISTS ( SELECT TOP 1
                                *
                        FROM    GlobalLeaveSetup
                        WHERE   emp_typeId = @emp_type )
                BEGIN  
                    IF @emp_type = '185'
                        BEGIN       
    --### FOR PERMANENT EMPLOYEE  
      
                            SELECT  @JOIN_NPL_YEAR = SUBSTRING(dbo.[GetNepaliDate](@permanent_date),
                                                              7, 4);  
                            SELECT  @TO_DATE = dbo.[GetEngDateChaitraEnd](@rowId);   
      
                            SELECT  @CURRENT_FY = SUBSTRING(dbo.[GetNepaliDate](@CURRENT_DATE),
                                                            7, 4);  
                            IF @CURRENT_FY = @JOIN_NPL_YEAR
                                BEGIN  
                                    INSERT  INTO leaveAssignment
                                            ( EMPLOYEE_ID ,
                                              LEAVE_TYPE_ID ,
                                              NO_OF_DAYS_ACTUAL ,
                                              FORCE_LEAVE_DEDUCT ,
                                              IS_DISABLED ,
                                              IS_SATURDAY ,
                                              IS_HALFDAY ,
                                              CREATED_BY ,
                                              CREATED_DATE ,
                                              IS_LFA ,
                                              IS_CASHABLE ,
                                              IS_UNLIMITED ,
                                              IS_SUBSTITUTED ,
                                              RELIEVING ,
                                              FromDate ,
                                              ToDate
                                            )
                                            SELECT  @rowId ,
                                                    leave_typeId ,
                                                    dbo.GetLeaveActualAssignDays(leave_typeId,
                                                              @rowId, A.id) ,
                                                    dbo.GetLeaveLFADays(leave_typeId,
                                                              @rowId) ,
                                                    IS_ACTIVE ,
                                                    IS_SATURDAY ,
                                                    IS_HOURLY ,
                                                    @rowId ,
                                                    GETDATE() ,
                                                    IS_LFA ,
                                                    IS_CASHABLE ,
                                                    IS_UNLIMITED ,
                                                    IS_SUBSTITUTED ,
                                                    RELIEVING ,
                                                    @permanent_date ,
                                                    @TO_DATE
                                            FROM    GlobalLeaveSetup A
                                                    INNER JOIN LeaveTypes B ON A.leave_typeId = B.ID
                                            WHERE   emp_typeId = @emp_type
                                                    AND flag = 'y'
                                                    AND leave_typeId NOT IN (
                                                    SELECT  LEAVE_TYPE_ID
                                                    FROM    leaveAssignment
                                                    WHERE   EMPLOYEE_ID = @rowId );  
                                END;  
      
                        END;  
                    ELSE
                        BEGIN  
    --### FOR OTHER THAN PERMANENT EMPLOYEE  
      
                            IF EXISTS ( SELECT TOP 1
                                                *
                                        FROM    Employee_Contract
                                        WHERE   EMPLOYEE_ID = @rowId
                                        ORDER BY RowID DESC )
                                BEGIN  
                                    SELECT TOP 1
                                            @FROM_DATE = CONVERT(VARCHAR, Cont_DateFrm, 101) ,
                                            @TO_DATE = CONVERT(VARCHAR, Cont_DateTo, 101)
                                    FROM    Employee_Contract
                                    WHERE   EMPLOYEE_ID = @rowId
                                    ORDER BY RowID DESC;  
       
       
                                    SELECT  @JOIN_NPL_YEAR = SUBSTRING(dbo.[GetNepaliDate](@FROM_DATE),
                                                              7, 4);  
                                    SELECT  @CURRENT_FY = SUBSTRING(dbo.[GetNepaliDate](@CURRENT_DATE),
                                                              7, 4);  
                                    IF @CURRENT_FY = @JOIN_NPL_YEAR
                                        BEGIN  
                                            INSERT  INTO leaveAssignment
                                                    ( EMPLOYEE_ID ,
                                                      LEAVE_TYPE_ID ,
                                                      NO_OF_DAYS_ACTUAL ,
                                                      FORCE_LEAVE_DEDUCT ,
                                                      IS_DISABLED ,
                                                      IS_SATURDAY ,
                                                      IS_HALFDAY ,
                                                      CREATED_BY ,
                                                      CREATED_DATE ,
                                                      IS_LFA ,
                                                      IS_CASHABLE ,
                                                      IS_UNLIMITED ,
                                                      IS_SUBSTITUTED ,
                                                      RELIEVING ,
                                                      FromDate ,
                                                      ToDate
                                                    )
                                                    SELECT  @rowId ,
                                                            leave_typeId ,
                                                            dbo.GetLeaveActualAssignDays(leave_typeId,
                                                              @rowId, A.id) ,
                                                            0 ,
                                                            IS_ACTIVE ,
                                                            IS_SATURDAY ,
                                                            IS_HOURLY ,
                                                            @user ,
                                                            GETDATE() ,
                                                            IS_LFA ,
                                                            IS_CASHABLE ,
                                                            IS_UNLIMITED ,
                                                            IS_SUBSTITUTED ,
                                                            RELIEVING ,
                                                            @FROM_DATE ,
                                                            @TO_DATE
                                                    FROM    GlobalLeaveSetup A
                                                            INNER JOIN LeaveTypes B ON A.leave_typeId = B.ID
                                                    WHERE   emp_typeId = @emp_type
                                                            AND flag = 'y'
                                                            AND leave_typeId NOT IN (
                                                            SELECT
                                                              LEAVE_TYPE_ID
                                                            FROM
                                                              leaveAssignment
                                                            WHERE
                                                              EMPLOYEE_ID = @rowId );  
                                        END;  
                                END;  
                        END;  
                END;  
            EXEC [procProfilePayable] @doj, @position_id, @rowId, @user;  
     
  -- ### END AUTO ASSIGNMENT OF LEAVE  
        END;  
    IF @flag = 'u'
        BEGIN  
   
 --BEGIN TRY  
 --BEGIN TRANSACTION  
   
            DECLARE @per_date AS DATE ,
                @CONT_FROM AS DATE ,
                @CONT_TO AS DATE ,
                @DATE_OF_JOIN AS DATE;  
            SELECT  @per_date = ISNULL(PERMANENT_DATE, '1990-01-01') ,
                    @DATE_OF_JOIN = JOINED_DATE
            FROM    Employee
            WHERE   EMPLOYEE_ID = @row_id;  
   
            IF NOT EXISTS ( SELECT  *
                            FROM    Employee_Contract
                            WHERE   EMPLOYEE_ID = @row_id )
                BEGIN  
                    SELECT  @CONT_FROM = CONVERT(VARCHAR, '1990-01-01', 101) ,
                            @CONT_TO = CONVERT(VARCHAR, '1990-01-01', 101);   
                END;  
            ELSE
                BEGIN  
                    SELECT TOP 1
                            @CONT_FROM = CONVERT(VARCHAR, Cont_DateFrm, 101) ,
                            @CONT_TO = CONVERT(VARCHAR, Cont_DateTo, 101)
                    FROM    Employee_Contract
                    WHERE   EMPLOYEE_ID = @row_id
                    ORDER BY RowID DESC;  
                END;  
      
            UPDATE  Employee
            SET     EMP_CODE = @emp_code ,
                    SALUTATION = @salutation ,
                    FIRST_NAME = @first_name ,
                    MIDDLE_NAME = @middle_name ,
                    LAST_NAME = @last_name ,
                    GENDER = @gender ,
                    BRANCH_ID = @branch_id ,
                    DEPARTMENT_ID = @dept_id ,
                    POSITION_ID = @position_id ,
                    BIRTH_DATE = @dob ,
                    JOINED_DATE = @doj ,
                    MERITAL_STATUS = @marital_status ,
                    PAN_NUMBER = @PAN_number ,
                    BLOOD_GROUP = @blood_group ,
                    EMP_STATUS = @emp_status ,
                    EMP_TYPE = @emp_type ,
                    APPOINTMENT_DATE = @doa ,
                    OFFICE_PHONE = @phone_office ,
                    HOME_PHONE = @phone_residence ,
                    OFFICE_MOBILE = @mobile_office ,
                    PERSONAL_MOBILE = @mobile_personal ,
                    OFFICE_FAX = @fax_office ,
                    PERSONAL_FAX = @fax_personal ,
                    OFFICIAL_EMAIL = @email_office ,
                    PERSONAL_EMAIL = @email_personal ,
                    TEMP_COUNTRY = @temp_country ,
                    TEMP_ZONE = @temp_zone ,
                    TEMP_DISTRICT = @temp_district ,
                    TEMP_MUNICIPALITY_VDC = @temp_municipality ,
                    TEMP_WARD_NO = @temp_ward ,
                    TEMP_HOUSE_NO = @temp_house_no ,
                    TEMP_STREET_NAME = @temp_street_name ,
                    PER_COUNTRY = @per_country ,
                    PER_ZONE = @per_zone ,
                    PER_DISTRICT = @per_district ,
                    PER_MUNICIPALITY_VDC = @per_minicipality ,
                    PER_WARD_NO = @per_ward ,
                    PER_HOUSE_NO = @per_house_no ,
                    PER_STREET_NAME = @per_street_name ,
                    EM_NAME = @em_conact_person ,
                    EM_ADDRESS = @em_address ,
                    EM_RELATIONSHIP = @em_relationship ,
                    EM_CONTACTNO1 = @em_contact1 ,
                    EM_CONTACTNO2 = @em_contact2 ,
                    EM_CONTACTNO3 = @em_contact3 ,
                    EM_EMAIL = @em_email ,
                    CREATED_BY = @user ,
                    CREATED_DATE = GETDATE() ,
                    FUNCTIONAL_TITLE = @func_title ,
                    PERMANENT_DATE = @permanent_date ,
                    Individual_Profile_update = @Individual_Profile_update ,
                    MODIFIED_BY = @user ,
                    MODIFIED_DATE = GETDATE() ,
                    CARD_NUMBER = @CARD_NUMBER ,
                    GRATUITY_EFFECTIVE_DATE = @Gratuity_start_date ,
                    Salary_Title = @SalaryTitle ,
                    GRADE = @grade_year ,
                    SUB_DEPARTMENT = @sub_dept_id,
                    SUB_DEPARTMENT2 = @sub_dept_id2
            WHERE   EMPLOYEE_ID = @row_id;  
   
  
            INSERT  INTO Employee_Contract
                    ( EMPLOYEE_ID ,
                      Cont_DateFrm ,
                      Cont_DateTo ,
                      Created_By ,
                      Created_Date ,
                      branch_id ,
                      dept_id ,
                      position_id ,
                      emp_type ,
                      flag
                    )
                    SELECT  @row_id ,
                            @C_START_DATE ,
                            @C_END_DATE ,
                            @user ,
                            GETDATE() ,
                            @branch_id ,
                            @dept_id ,
                            @position_id ,
                            @emp_type ,
                            'Service Status Extension';  
   
 -- ## INSERTING APPOINTMENT HISTORY AS A SERVICE HISTORY  
            IF CONVERT(VARCHAR, @DATE_OF_JOIN, 102) <> CONVERT(VARCHAR, @doj, 102)
                BEGIN  
                    UPDATE  emp_log
                    SET     effective_date = @doj ,
                            branch_id = @branch_id ,
                            dept_id = @dept_id ,
                            position_id = @position_id ,
                            emp_type = @emp_type ,
                            modified_by = @user ,
                            modified_date = GETDATE()
                    WHERE   emp_id = @row_id;  
                END;  
 --- ## INSERTING CONFIRMATION/PERMANENT HISTORY AS A SERVICE HISTORY  
            IF CONVERT(VARCHAR, @permanent_date, 102) <> CONVERT(VARCHAR, @per_date, 102)
                BEGIN   
                    UPDATE  emp_log
                    SET     effective_date = @permanent_date ,
                            branch_id = @branch_id ,
                            dept_id = @dept_id ,
                            position_id = @position_id ,
                            emp_type = @emp_type ,
                            modified_by = @user ,
                            modified_date = GETDATE()
                    WHERE   emp_id = @row_id;  
                END;  
  
            IF @dept_id IN ( SELECT DEPARTMENT_ID
                             FROM   Departments
                             WHERE  STATIC_ID = 1310 )
                BEGIN  
                    UPDATE  Branches
                    SET     CONTACT_PERSON = ( SELECT   FIRST_NAME
                                                        + ISNULL(' '
                                                              + MIDDLE_NAME
                                                              + ' ', ' ')
                                                        + LAST_NAME
                                               FROM     Employee
                                               WHERE    EMPLOYEE_ID = @row_id
                                             )
                    WHERE   BRANCH_ID = @branch_id;  
                END;  
  
/*   
 if @row_id<>1000  
 begin  
 UPDATE Admins SET UserName=@userName WHERE Name=CAST(@row_id AS VARCHAR)  
 end     
  -- ### START UPDATE AUTO ASSIGNMENT OF LEAVE   
  IF EXISTS(SELECT TOP 1 * FROM GLOBALLEAVESETUP WHERE EMP_TYPEID=@EMP_TYPE)  
  BEGIN  
     
   IF @EMP_TYPE='185' AND CONVERT(VARCHAR,@permanent_date,102)<>CONVERT(VARCHAR,@per_date,102)  
   BEGIN      
  
    --### FOR PERMANENT EMPLOYEE    
    if not exists(select top 1 * from LeaveRequest where leaveAssignId in (SELECT id FROM leaveAssignment where EMPLOYEE_ID=@row_id) and   
       LEAVE_STATUS='Approved')  
    begin   
      
     delete from LeaveRequest where leaveAssignId in (SELECT id FROM leaveAssignment where EMPLOYEE_ID=@row_id)  
          
     UPDATE leaveAssignment SET IS_DISABLED='FALSE' WHERE EMPLOYEE_ID= @row_id   
      
     SELECT @JOIN_NPL_YEAR=SUBSTRING(dbo.[GetNepaliDate](@permanent_date),7,4)  
     SELECT @TO_DATE=dbo.[GetEngDateChaitraEnd](@row_id)  
       
     SELECT @CURRENT_FY=SUBSTRING(dbo.[GetNepaliDate](@CURRENT_DATE),7,4)  
     select @CURRENT_FY=@JOIN_NPL_YEAR  
     
     BEGIN  
        
      INSERT INTO leaveAssignment(EMPLOYEE_ID,LEAVE_TYPE_ID,NO_OF_DAYS_ACTUAL,FORCE_LEAVE_DEDUCT,  
             IS_DISABLED,IS_SATURDAY,IS_HALFDAY,  
             CREATED_BY,CREATED_DATE,IS_LFA,IS_CASHABLE,  
             IS_UNLIMITED,IS_SUBSTITUTED,RELIEVING,FROMDATE,TODATE)  
            
      SELECT @row_id,LEAVE_TYPEID,DBO.GetLeaveActualAssignDays(LEAVE_TYPEID,@row_id,A.ID),DBO.GetLeaveLFADays(LEAVE_TYPEID,@row_id)  
      ,IS_ACTIVE,IS_SATURDAY,IS_HOURLY,@user,GETDATE(),IS_LFA,IS_CASHABLE,IS_UNLIMITED,IS_SUBSTITUTED,RELIEVING,@permanent_date,@TO_DATE  
      FROM GLOBALLEAVESETUP A INNER JOIN LeaveTypes B ON A.LEAVE_TYPEID=B.ID  
      WHERE EMP_TYPEID=@emp_type AND FLAG='y'   
     END  
    end  
   END  
   IF @EMP_TYPE<>'185' AND (CONVERT(VARCHAR,@CONT_FROM,102)<>CONVERT(VARCHAR,@C_START_DATE,102) OR   
      CONVERT(VARCHAR,@CONT_TO,102)<>CONVERT(VARCHAR,@C_END_DATE,102))   
   BEGIN  
     
    if not exists(select top 1 * from LeaveRequest where leaveAssignId in   
     (SELECT id FROM leaveAssignment where EMPLOYEE_ID=@row_id) and   
      LEAVE_STATUS='Approved')  
    begin  
      
     UPDATE leaveAssignment SET IS_DISABLED='FALSE' WHERE EMPLOYEE_ID= @row_id   
     --### FOR OTHER THAN PERMANENT EMPLOYEE  
     SELECT TOP 1 @FROM_DATE=convert(varchar,Cont_DateFrm,101),@TO_DATE=convert(varchar,Cont_DateTo,101)    
     FROM Employee_Contract   
     WHERE EMPLOYEE_ID = @row_id  
     ORDER BY RowID DESC  
       
     SELECT @JOIN_NPL_YEAR=SUBSTRING(dbo.[GetNepaliDate](@FROM_DATE),7,4)  
     SELECT @CURRENT_FY=SUBSTRING(dbo.[GetNepaliDate](@CURRENT_DATE),7,4)  
     IF @CURRENT_FY=@JOIN_NPL_YEAR  
     BEGIN  
      INSERT INTO leaveAssignment(EMPLOYEE_ID,LEAVE_TYPE_ID,NO_OF_DAYS_ACTUAL,FORCE_LEAVE_DEDUCT,  
             IS_DISABLED,IS_SATURDAY,IS_HALFDAY,  
             CREATED_BY,CREATED_DATE,IS_LFA,IS_CASHABLE,  
             IS_UNLIMITED,IS_SUBSTITUTED,RELIEVING,FROMDATE,TODATE)  
            
      SELECT @row_id,  
       LEAVE_TYPEID,  
       DBO.GetLeaveActualAssignDays(LEAVE_TYPEID,@row_id,A.ID),  
       0,  
       IS_ACTIVE,  
       IS_SATURDAY,  
       IS_HOURLY,  
       @row_id,  
       GETDATE(),  
       IS_LFA,  
       IS_CASHABLE,  
       IS_UNLIMITED,  
       IS_SUBSTITUTED,  
       RELIEVING,  
       @FROM_DATE,  
       @TO_DATE  
      FROM GLOBALLEAVESETUP A INNER JOIN LeaveTypes B ON A.LEAVE_TYPEID=B.ID  
      WHERE EMP_TYPEID=@emp_type   
       AND FLAG='y'   
     END  
    end  
   END  
  END  
  --COMMIT TRANSACTION  
  
  -- ### END AUTO ASSIGNMENT OF LEAVE  
*/  
        END;  
  
    IF @flag = 's'
        BEGIN  
  
            SELECT TOP 1
                    @LASTPROMOTED = CONVERT(VARCHAR, CAST(PROMOTION_DATE AS DATE), 101)
            FROM    Promotion
            WHERE   EMP_ID = @row_id
            ORDER BY PROMOTION_DATE DESC;   
            SELECT TOP 1
                    @LastTransfer = CONVERT(VARCHAR, CAST(EFFECTIVE_DATE AS DATE), 101)
            FROM    ExternalTransferPlan
            WHERE   STAFF_ID = @row_id
            ORDER BY EFFECTIVE_DATE DESC;  
  
            SELECT  EMP_CODE ,
                    EMPLOYEE_ID ,
                    SALUTATION ,
                    FIRST_NAME ,
                    MIDDLE_NAME ,
                    LAST_NAME ,
                    OFFICE_PHONE ,
                    HOME_PHONE ,
                    OFFICE_MOBILE ,
                    PERSONAL_MOBILE ,
                    OFFICE_FAX ,
                    PERSONAL_FAX ,
                    OFFICIAL_EMAIL ,
                    PERSONAL_EMAIL ,
                    GENDER ,
                    DEPARTMENT_ID ,
                    BRANCH_ID ,
                    POSITION_ID ,
                    BLOOD_GROUP ,
                    CONVERT(VARCHAR, BIRTH_DATE, 101) AS BIRTH_DATE ,
                    CONVERT(VARCHAR, JOINED_DATE, 101) AS JOINED_DATE ,
                    MERITAL_STATUS ,
                    PAN_NUMBER ,
                    TEMP_STREET_NAME ,
                    TEMP_WARD_NO ,
                    TEMP_HOUSE_NO ,
                    TEMP_MUNICIPALITY_VDC ,
                    TEMP_DISTRICT ,
                    TEMP_ZONE ,
                    TEMP_COUNTRY ,
                    PER_STREET_NAME ,
                    PER_WARD_NO ,
                    PER_HOUSE_NO ,
                    PER_MUNICIPALITY_VDC ,
                    PER_DISTRICT ,
                    PER_ZONE ,
                    PER_COUNTRY ,
                    EMP_STATUS ,
                    EMP_TYPE ,
                    CONVERT(VARCHAR, APPOINTMENT_DATE, 101) AS APPOINTMENT_DATE ,
                    EM_NAME ,
                    EM_ADDRESS ,
                    EM_RELATIONSHIP ,
                    EM_CONTACTNO1 ,
                    EM_CONTACTNO2 ,
                    EM_CONTACTNO3 ,
                    EM_EMAIL ,
                    FUNCTIONAL_TITLE ,
                    CONVERT(VARCHAR, PERMANENT_DATE, 101) AS PERMANENT_DATE ,
                    Individual_Profile_update ,
                    SUB_DEPARTMENT ,
                    SUB_DEPARTMENT2 ,
                    CONVERT(VARCHAR, PERMANENT_DATE, 101) PERMANENT_DATE ,
                    CARD_NUMBER ,
                    CONVERT(VARCHAR, GRATUITY_EFFECTIVE_DATE, 101) AS GRATUITY_EFFECTIVE_DATE ,
                    Salary_Title ,
                    GRADE ,
                    @LASTPROMOTED LASTPROMOTED ,
                    @LastTransfer LastTransfer
            FROM    Employee
            WHERE   EMPLOYEE_ID = @row_id;  
        END;  
  
    IF @flag = 'a'   ---FINDING SERVICE PERIODS  
        BEGIN  
            SELECT TOP 1
                    CONVERT(VARCHAR, Cont_DateFrm, 101) Cont_DateFrm ,
                    CONVERT(VARCHAR, Cont_DateTo, 101) Cont_DateTo
            FROM    Employee_Contract
            WHERE   EMPLOYEE_ID = @row_id
            ORDER BY RowID DESC;  
        END;

		  IF @flag = 'getSubDepart'   ---FINDING SERVICE PERIODS  
        BEGIN  
           declare @branchNodeid int
                            ,@deptnode INT

                            select @branchNodeid=nodeID from OrgChart 
                            where parentNodeId is null
                            and nodeType='B' and nodeText=@branch_id

                            select @deptnode=nodeID from OrgChart
                            where groupId=@branchNodeid
                            and nodeType='D' 
                            and nodeText=@dept_id

                            select nodeText as DEPARTMENT_ID ,d.DEPARTMENT_NAME from Departments d
                            inner join OrgChart o on d.DEPARTMENT_ID=o.nodeText
                            where nodeType='D' 
                            and parentNodeId=@deptnode
        END;


