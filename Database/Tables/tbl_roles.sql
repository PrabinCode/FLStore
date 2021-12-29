USE [FurnitureLandStore]
GO

/****** Object:  Table [dbo].[tbl_roles]    Script Date: 12/28/2021 3:49:15 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_roles]') AND type in (N'U'))
DROP TABLE [dbo].[tbl_roles]
GO

/****** Object:  Table [dbo].[tbl_roles]    Script Date: 12/28/2021 3:49:15 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](250) NULL,
	[RoleDescription] [varchar](500) NULL,
	[RoleType] [varchar](500) NULL,
	[RoleStatus] [varchar](3) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL
) ON [PRIMARY]
GO


