USE [FurnitureLandStore]
GO

/****** Object:  Table [dbo].[tbl_user]    Script Date: 12/28/2021 3:47:44 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_user]') AND type in (N'U'))
DROP TABLE [dbo].[tbl_user]
GO

/****** Object:  Table [dbo].[tbl_user]    Script Date: 12/28/2021 3:47:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_user](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserRole] [varchar](10) NULL,
	[UserRoleType] [varchar](20) NULL,
	[UserName] [varchar](250) NULL,
	[UserPassword] [varchar](500) NULL,
	[UserStatus] [varchar](3) NULL,
	[IsBlocked] [varchar](3) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL
) ON [PRIMARY]
GO


