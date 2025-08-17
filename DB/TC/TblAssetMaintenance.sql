CREATE TABLE TblAssetMaintenance
(
	RowID INT IDENTITY(1,1),
	Asset_id INT ,
	RequestingBranch INT,
	RequestingDepartment INT,
	RequestingUser INT,
	ForwardedToBranch INT,
	ForwardedToDepartment INT,
	ForwardedToUser INT,
	ProcessStatus VARCHAR(15),
	Vendor INT,
	NewVendorName VARCHAR(50),
	RequestedDate DATETIME ,
	RepairCost MONEY,
	Narration VARCHAR(MAX),
	ReceivedDate DATETIME,
	ApproxReturnDate DATETIME,
	CreatedBY VARCHAR(50),
	CreatedDate DATETIME ,
	ModifiedBy VARCHAR(50),
	ModifiedDate DATETIME	
)

--DROP TABLE TblAssetMaintenance