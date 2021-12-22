USE FurnitureLandStore
GO

CREATE TABLE [dbo].tbl_shipping_detail(
	ShippingDetailId [int] IDENTITY(1,1) NOT NULL,
	CustomerId int NULL,
	OrderId varchar (250) NULL,
	Address varchar (500) NULL,
	City varchar (250) NULL,
	State varchar (250) NULL,
	Country varchar (250) NULL,
	ZipCode varchar (250) NULL,
	AmountPaid varchar (250) NULL,
	PaymentType varchar (250) NULL,
	CreatedDate [datetime] NULL,
	ModifiedDate [datetime] NULL
)
GO
