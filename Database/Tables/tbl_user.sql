USE FurnitureLandStore
GO

CREATE TABLE [dbo].tbl_user(
	UserId [int] IDENTITY(1,1) NOT NULL,
	UserRole varchar (10) NULL,
	UserRoleType varchar (20) NULL,
	UserName varchar (250) NULL,
	UserPassword [varchar](500) NULL,
	UserStatus bit NULL,
	IsBlocked bit NULL,
	CreatedDate [datetime] NULL,
	ModifiedDate [datetime] NULL
)
GO
