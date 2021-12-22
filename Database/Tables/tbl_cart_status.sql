USE FurnitureLandStore
GO

CREATE TABLE [dbo].tbl_cart_status(
	CartStatusId [int] IDENTITY(1,1) NOT NULL,
	Status bit NULL,
	CreatedDate [datetime] NULL,
	ModifiedDate [datetime] NULL
)
GO
