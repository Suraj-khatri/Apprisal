--SELECT * FROM dbo.user_function WHERE main_menu='HR' AND menu_group = 'e' ORDER BY sno Desc	

--SELECT * FROM dbo.user_function ORDER BY sno DESC

--SELECT MAX(sno) FROM dbo.user_function

INSERT INTO dbo.user_function
        ( sno ,
          function_name ,
          Description ,
          link_file ,
          main_menu ,
          dis_order ,
          menu_group
        )
VALUES  ( 1117 , -- sno - int
          'Assign Job' , -- function_name - varchar(50)
          'Manage Job Description' , -- Description - varchar(50)
          '/Company/EmployeeWeb/JobDescription/JobDescription.aspx' , -- link_file - varchar(250)
          'HR' , -- main_menu - varchar(50)
          9 , -- dis_order - int
          'e'  -- menu_group - varchar(10)
        )

		INSERT INTO dbo.user_function
        ( sno ,
          function_name ,
          Description ,
          link_file ,
          main_menu ,
          dis_order ,
          menu_group
        )
VALUES  ( 1118 , -- sno - int
          'Approve/Assign Job' , -- function_name - varchar(50)
          'Manage Job Description' , -- Description - varchar(50)
          '/Company/EmployeeWeb/JobDescription/List.aspx' , -- link_file - varchar(250)
          'HR' , -- main_menu - varchar(50)
          10, -- dis_order - int
          'e'  -- menu_group - varchar(10)
        )
		UPDATE dbo.user_function SET function_name = 'Accept/Assign Job' WHERE function_name = 'Approve/Assign Job' AND sno = 1118