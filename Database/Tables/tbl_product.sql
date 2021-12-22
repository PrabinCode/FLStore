USE FurnitureLandStore
GO

CREATE TABLE [dbo].tbl_customer(
	CustomerId [int] IDENTITY(1,1) NOT NULL,
	CustomerAddress varchar (500) NULL,
	CustomerEmail varchar (500) NULL,
	CustomerStatus bit NULL,
	IsDeleted bit NULL,
	CustomerMobileNo varchar (10) NULL,
	CustomerFax varchar (20) NULL,
	CompanyName varchar (500) NULL,
	CompanyAddress varchar (20) NULL,
	CompanyPhone varchar (20) NULL,
	CompanyFax varchar (20) NULL,
	PreferedShipMethod varchar (20) NULL,
	SchoolName varchar (20) NULL,
	ProfileImage varchar (20) NULL,


	CreatedDate [datetime] NULL,
	ModifiedDate [datetime] NULL
)
GO
