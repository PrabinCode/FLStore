USE [FurnitureLandStore]
GO

/****** Object:  Table [dbo].[tbl_static_data]    Script Date: 12/29/2021 12:16:41 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_static_data]') AND type in (N'U'))
DROP TABLE [dbo].[tbl_static_data]
GO

/****** Object:  Table [dbo].[tbl_static_data]    Script Date: 12/29/2021 12:16:41 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_static_data](
	[StaticId] [int] IDENTITY(1,1) NOT NULL,
	[StaticType] [varchar](250) NULL,
	[StaticValue] [varchar](500) NULL,
	[Description] [varchar](500) NULL,
	[Status] [varchar](10) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL
) ON [PRIMARY]
GO


