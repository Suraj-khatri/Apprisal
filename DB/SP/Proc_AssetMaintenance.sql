

alter PROC [dbo].[Proc_AssetMaintenance]
    @flag CHAR(10) ,
    @id INT = NULL ,
    @Asset_id INT = NULL ,
    @RequestingBranch INT = NULL ,
    @RequestingDepartment INT = NULL ,
    @RequestingUser INT = NULL ,
    @ForwardedToBranch INT = NULL ,
    @ForwardedToDepartment INT = NULL ,
    @ForwardedToUser INT = NULL ,
    @ProcessStatus VARCHAR(15) = NULL ,
    @Vendor INT = NULL ,
    @NewVendorName VARCHAR(50) = NULL ,
    @RequestedDate DATETIME = NULL ,
    @ApproxReturnDate DATETIME = NULL ,
    @RepairCost MONEY = NULL ,
    @Narration VARCHAR(MAX) = NULL ,
    @ReceivedDate DATETIME = NULL ,
    @User VARCHAR(50) = NULL
AS
    SET NOCOUNT ON;

    BEGIN

        DECLARE @Asset_id_temp INT;



        IF EXISTS ( SELECT  'X'
                    FROM    TblAssetMaintenance
                    WHERE   Asset_id = @Asset_id
                            AND ProcessStatus <> 'ACK' )
            BEGIN

                SELECT  '1' AS error_code ,
                        'This Asset was already requested, but not Acknowledged!!' AS msg ,
                        NULL AS ID;

                RETURN;

            END;

        ELSE
            BEGIN

                IF @flag = 'i'
                    BEGIN

                        INSERT  INTO TblAssetMaintenance
                                ( Asset_id ,
                                  RequestingBranch ,
                                  RequestingDepartment ,
                                  RequestingUser ,
                                  ForwardedToBranch ,
                                  ForwardedToDepartment ,
                                  ForwardedToUser ,
                                  ProcessStatus ,
                                  Vendor ,
                                  NewVendorName ,
                                  RequestedDate ,
                                  RepairCost ,
                                  Narration ,
                                  CreatedBY ,
                                  CreatedDate ,
                                  ApproxReturnDate		

                                )
                                SELECT  @Asset_id ,
                                        @RequestingBranch ,
                                        @RequestingDepartment ,
                                        @RequestingUser ,
                                        @ForwardedToBranch ,
                                        @ForwardedToDepartment ,
                                        @ForwardedToUser ,
                                        @ProcessStatus ,
                                        @Vendor ,
                                        @NewVendorName ,
                                        @RequestedDate ,
                                        @RepairCost ,
                                        @Narration ,
                                        @User ,
                                        GETDATE() ,
                                        @ApproxReturnDate; 

                        SELECT  '0' AS error_code ,
                                'SUCCESS' AS msg ,
                                NULL AS ID;

                    END;

        

            END;

            

        IF @flag = 'd'
            BEGIN
			
                DECLARE @assetId INT;

                DECLARE @VEN INT;

                SELECT  @assetId = Asset_id ,
                        @VEN = Vendor
                FROM    TblAssetMaintenance
                WHERE   RowID = @id;

                IF @VEN IS NULL
                    BEGIN

                        SELECT  RowID ,
								ProcessStatus,
                                NewVendorName AS Vendor_Name ,
                                'New' AS VendorType,
                                Asset_id ,
                                RequestingBranch ,
                                RequestingDepartment ,
                                RequestingUser ,
                                ForwardedToBranch ,
                                ForwardedToDepartment ,
                                ForwardedToUser ,
                                CONVERT(VARCHAR,ApproxReturnDate,101) AS ApproxReturnDate,
                                RepairCost ,
                                Narration ,
                                CONVERT(VARCHAR,ReceivedDate,101) AS ReceivedDate
                        FROM    TblAssetMaintenance WITH ( NOLOCK )
                        WHERE   RowID = @id;

                    END;

                ELSE
                    BEGIN

                        SELECT  AM.RowID ,
								AM.ProcessStatus AS ProcessStatus,
                                ( C.CustomerName ) AS Vendor_Name ,
                                'Existing' AS VendorType,
                                AM.Vendor AS VendorId,
                                AM.Asset_id ,
                                AM.RequestingBranch ,
                                AM.RequestingDepartment ,
                                AM.RequestingUser ,
                                AM.ForwardedToBranch ,
                                AM.ForwardedToDepartment ,
                                AM.ForwardedToUser ,
                                CONVERT(VARCHAR,AM.ApproxReturnDate,101) AS ApproxReturnDate,
                                AM.RepairCost ,
                                AM.Narration ,
                                 CONVERT(VARCHAR,AM.ReceivedDate,101) AS ReceivedDate
                        FROM    TblAssetMaintenance AM WITH ( NOLOCK )
                                INNER JOIN dbo.Customer C WITH ( NOLOCK ) ON AM.Vendor = C.ID
                        WHERE   RowID = @id;

                    END;
                    
                SELECT  asset_number + '|' + CONVERT(VARCHAR, id) AS 'Asset_id' ,
                        ( purchase_value - acc_depriciation ) AS book_value ,
                        purchase_value ,
                        ( narration ) AS AssetNarration ,
                        next_maintenance_date
                FROM    ASSET_INVENTORY WITH ( NOLOCK )
                WHERE   id = @assetId;

            END;

			

        IF @flag = 'u'
            BEGIN

                UPDATE  dbo.TblAssetMaintenance
                SET     ProcessStatus = COALESCE(@ProcessStatus, ProcessStatus) ,
                        ReceivedDate = @ReceivedDate ,
                        ModifiedBy = @User ,
                        ModifiedDate = GETDATE() ,
                        Vendor = COALESCE(@Vendor, Vendor) ,
                        NewVendorName = COALESCE(@NewVendorName, NewVendorName) ,
                        ApproxReturnDate = COALESCE(@ApproxReturnDate,
                                                    ApproxReturnDate) ,
                        RepairCost = COALESCE(@RepairCost, RepairCost) ,
                        Narration = COALESCE(@Narration, Narration)
                WHERE   RowID = @id;

                

                SELECT  '0' AS error_code ,
                        'SUCCESS' AS msg ,
                        NULL AS ID;

            END;

	

	

    END;






	