USE FurnitureLandStore
GO

CREATE TABLE [dbo].tbl_static_data(
	StaticId [int] IDENTITY(1,1) NOT NULL,
	StaticType varchar (250) NULL,
	StaticValue varchar (500) NULL,
	Description varchar (500) NULL,
	Status bit NULL,
	CreatedDate [datetime] NULL,
	ModifiedDate [datetime] NULL
)
GO
