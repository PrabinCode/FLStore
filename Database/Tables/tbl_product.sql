USE [FurnitureLandStore]
GO

/****** Object:  Table [dbo].[tbl_product]    Script Date: 12/29/2021 6:05:54 AM ******/
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'[dbo].[tbl_product]')
			AND type IN (N'U')
		)
	DROP TABLE [dbo].[tbl_product]
GO

/****** Object:  Table [dbo].[tbl_product]    Script Date: 12/29/2021 6:05:54 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_product] (
	[ProductId] [int] IDENTITY(1, 1) NOT NULL
	,[ProductName] [varchar](500) NULL
	,[CategoryId] [varchar](500) NULL
	,[ProductStatus] VARCHAR(3) NULL
	,[IsDeleted] VARCHAR(3) NULL
	,[ProductImage] [varchar](500) NULL
	,[AvailableQuantity] [varchar](10) NULL
	,[AvailabelColor] [varchar](100) NULL
	,[IsFeatured] [varchar](10) NULL
	,[ProductSize] [varchar](20) NULL
	,[ProductWeight] [decimal](18, 2) NULL
	,[ProductPrice] [decimal](18, 2) NULL
	,[ProductShipTime] [datetime] NULL
	,[CreatedDate] [datetime] NULL
	,[ModifiedDate] [datetime] NULL
	) ON [PRIMARY]
GO


