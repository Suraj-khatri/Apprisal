SELECT * FROM StaticDataDetail WHERE TYPE_ID=108
SELECT * FROM staticdatatype

UPDATE dbo.StaticDataDetail SET DETAIL_DESC='KRA' WHERE ROWID=3140

INSERT INTO dbo.StaticDataType
        ( TYPE_TITLE, TYPE_DESC )
VALUES  ( 'Question Group', -- TYPE_TITLE - varchar(200)
          'Question Group from Static'  -- TYPE_DESC - varchar(500)
          )

INSERT INTO dbo.StaticDataDetail
        ( TYPE_ID ,
          DETAIL_TITLE ,
          DETAIL_DESC ,
          CREATED_BY ,
          CREATED_DATE 
        )
VALUES  ( 108 , -- TYPE_ID - int
          'KRA' , -- DETAIL_TITLE - varchar(max)
          'KPI per KRA' , -- DETAIL_DESC - varchar(max)
          'admin' , -- CREATED_BY - varchar(50)
          GETDATE()  -- CREATED_DATE - datetime
        ),
		( 108 , -- TYPE_ID - int
          'KPI per KRA' , -- DETAIL_TITLE - varchar(max)
          'KPI per KRA' , -- DETAIL_DESC - varchar(max)
          'admin' , -- CREATED_BY - varchar(50)
          GETDATE()  -- CREATED_DATE - datetime
        ),
		( 108 , -- TYPE_ID - int
          'Critical Jobs' , -- DETAIL_TITLE - varchar(max)
          'Critical Jobs' , -- DETAIL_DESC - varchar(max)
          'admin' , -- CREATED_BY - varchar(50)
          GETDATE()  -- CREATED_DATE - datetime
        )
