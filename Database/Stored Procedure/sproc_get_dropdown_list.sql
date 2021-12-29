USE [FurnitureLandStore]
GO

/****** Object:  StoredProcedure [dbo].[sproc_user_login]    Script Date: 12/28/2021 3:29:37 PM ******/
DROP PROCEDURE [dbo].[sproc_get_dropdown_list]
GO

/****** Object:  StoredProcedure [dbo].[sproc_user_login]    Script Date: 12/28/2021 3:29:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sproc_get_dropdown_list] @flag VARCHAR(20) = NULL
	,@search_field1 VARCHAR(100) = NULL
	,@search_field2 VARCHAR(100) = NULL
	,@search_field3 VARCHAR(100) = NULL
	,@search_field4 VARCHAR(100) = NULL
	,@search_field5 VARCHAR(100) = NULL
	,@category_id VARCHAR(100) = NULL
AS
BEGIN
	CREATE TABLE #temp (
		value NVARCHAR(200)
		,[text] NVARCHAR(200)
		,additional_value NVARCHAR(200)
		,additional_text NVARCHAR(200)
		,additional_value2 NVARCHAR(200)
		,additional_text2 NVARCHAR(200)
		,dropdown_data NVARCHAR(max)
		);

	DECLARE @sql NVARCHAR(max) = '';

	IF @flag = 'roletype'
	BEGIN
		INSERT INTO #temp (
			value
			,TEXT
			)
		SELECT RoleId AS [value]
			,RoleName AS [text]
		FROM tbl_roles
		WHERE isnull(RoleStatus, 'N') = 'N'
			--SELECT '0' code
			--	,RoleId AS [value]
			--	,RoleName AS TEXT
			--	,RoleType additional_value
			--	,'' additional_text
			--	,'' additional_value2
			--	,'' additional_text2
			--	,'' dropdown_data
			--FROM tbl_roles;
	END;

	IF @flag = 'cust_type' --customer type
	BEGIN
		INSERT INTO #temp (
			value
			,TEXT
			)
		SELECT StaticValue AS [value]
			,Description AS [text]
		FROM tbl_static_data
		WHERE StaticType = 'CustomerType'
			AND STATUS = 'A'
	END;

	IF @flag = 'prod_cat' --product category
	BEGIN
		INSERT INTO #temp (
			value
			,TEXT
			)
		SELECT StaticValue AS [value]
			,Description + ' - ' + StaticValue AS [text]
		FROM tbl_static_data
		WHERE StaticType = 'ProductCategory'
			AND STATUS = 'A'
	END;

	IF @flag = 'shipment' --shipment methods
	BEGIN
		INSERT INTO #temp (
			value
			,TEXT
			)
		SELECT StaticValue AS [value]
			,Description AS [text]
		FROM tbl_static_data
		WHERE StaticType = 'ShipmentMethod'
			AND STATUS = 'A'
	END;

	IF EXISTS (
			SELECT *
			FROM #temp
			)
	BEGIN
		SELECT '0' code
			,*
		FROM #temp;
	END
	ELSE
	BEGIN
		RETURN;
	END;

	DROP TABLE #temp;
END
GO


