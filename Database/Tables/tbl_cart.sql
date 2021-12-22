USE FurnitureLandStore
GO

CREATE TABLE [dbo].tbl_cart(
	CartId [int] IDENTITY(1,1) NOT NULL,
	ProductId int NULL,
	CustomerId int NULL,
	CartStatusId int NULL,
	
	CreatedDate [datetime] NULL,
	ModifiedDate [datetime] NULL
)
GO
