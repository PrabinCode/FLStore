USE [FurnitureLandStore]
GO

/****** Object:  Table [dbo].[tbl_customer]    Script Date: 12/29/2021 4:29:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_customer]') AND type in (N'U'))
DROP TABLE [dbo].[tbl_customer]
GO

/****** Object:  Table [dbo].[tbl_customer]    Script Date: 12/29/2021 4:29:52 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_customer](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[FirstName] [varchar](50) NULL,
	[MiddleName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[CustomerAddress] [varchar](500) NULL,
	[CustomerEmail] [varchar](500) NULL,
	[CustomerStatus] [varchar](3) NULL,
	[IsDeleted] [varchar](3) NULL,
	[CustomerMobileNo] [varchar](10) NULL,
	[CustomerFax] [varchar](20) NULL,
	[CompanyName] [varchar](500) NULL,
	[CompanyAddress] [varchar](512) NULL,
	[CompanyPhone] [varchar](20) NULL,
	[CompanyFax] [varchar](20) NULL,
	[PreferedShipMethod] [varchar](100) NULL,
	[SchoolName] [varchar](1000) NULL,
	[ProfileImage] [varchar](Max) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL
) ON [PRIMARY]
GO


