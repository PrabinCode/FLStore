USE FurnitureLandStore
GO

CREATE TABLE [dbo].tbl_roles(
	RoleId [int] IDENTITY(1,1) NOT NULL,
	RoleName varchar (250) NULL,
	RoleDescription varchar (500) NULL,
	RoleType varchar (500) NULL,
	RoleStatus bit NULL,
	CreatedDate [datetime] NULL,
	ModifiedDate [datetime] NULL
)
GO
