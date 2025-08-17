--SELECT * FROM dbo.user_function WHERE menu_group LIKE 'ass_mgmt%'
--SELECT MAX(dis_order)+1 FROM dbo.user_function where menu_group LIKE 'ass_mgmt%'

INSERT INTO dbo.user_function
        ( sno ,
          function_name,
          Description ,
          link_file ,
          main_menu ,
          dis_order ,
          menu_group
        )
VALUES  ( (SELECT MAX(sno)+1 FROM dbo.user_function) , -- sno - int
          'Maintenance Request' , -- function_name - varchar(50)
          'Maintenance Request' , -- Description - varchar(50)
          '/AssetManagement/AssetMaintainenceStatus/List.aspx' , -- link_file - varchar(250)
          'AM' , -- main_menu - varchar(50)
			(SELECT MAX(dis_order)+1 FROM dbo.user_function where menu_group LIKE 'ass_mgmt%') , -- dis_order - int
          'ass_mgmt'  -- menu_group - varchar(10)
        )
        
        
        INSERT INTO dbo.user_function
        ( sno ,
          function_name,
          Description ,
          link_file ,
          main_menu ,
          dis_order ,
          menu_group
        )
VALUES  ( (SELECT MAX(sno)+1 FROM dbo.user_function) , -- sno - int
          'Maintenance Approve' , -- function_name - varchar(50)
          'Maintenance Approve' , -- Description - varchar(50)
          '/AssetManagement/AssetMaintainenceStatus/ListApprove.aspx' , -- link_file - varchar(250)
          'AM' , -- main_menu - varchar(50)
			(SELECT MAX(dis_order)+1 FROM dbo.user_function where menu_group LIKE 'ass_mgmt%') , -- dis_order - int
          'ass_mgmt'  -- menu_group - varchar(10)
        )
        
