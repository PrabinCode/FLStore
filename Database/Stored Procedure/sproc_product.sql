USE [FurnitureLandStore]
GO

/****** Object:  StoredProcedure [dbo].[sproc_user_login]    Script Date: 12/28/2021 3:29:37 PM ******/
DROP PROCEDURE [dbo].[sproc_product]
GO

/****** Object:  StoredProcedure [dbo].[sproc_user_login]    Script Date: 12/28/2021 3:29:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sproc_product] @flag VARCHAR(10)
	,@ProductId VARCHAR(512) = NULL
	,@ProductName VARCHAR(512) = NULL
	,@CategoryId VARCHAR(512) = NULL
	,@ProductStatus VARCHAR(3) = NULL
	,@IsDeleted VARCHAR(3) = NULL
	,@ProductImage VARCHAR(max) = NULL
	,@AvailableQuantity VARCHAR(512) = NULL
	,@AvailabelColor VARCHAR(100) = NULL
	,@IsFeatured VARCHAR(10) = NULL
	,@ProductSize VARCHAR(20) = NULL
	,@ProductWeight DECIMAL(18, 2) = NULL
	,@ProductPrice DECIMAL(18, 2) = NULL
	,@ProductShipTime DATETIME = NULL
	,@CreatedDate DATETIME = NULL
	,@ModifiedDate DATETIME = NULL
AS
BEGIN
	IF @flag = 'list'
	BEGIN
		SELECT *
		FROM tbl_product;

		RETURN
	END

	IF @flag = 'v'
	BEGIN
		SELECT *
		FROM tbl_product
		WHERE ProductId = @ProductId
	END

	IF @flag = 'i'
	BEGIN
		INSERT INTO tbl_product (
			ProductName
			,CategoryId
			,ProductStatus
			,IsDeleted
			,ProductImage
			,AvailableQuantity
			,AvailabelColor
			,IsFeatured
			,ProductSize
			,ProductWeight
			,ProductPrice
			,ProductShipTime
			,CreatedDate
			)
		VALUES (
			@ProductName
			,@CategoryId
			,@ProductStatus
			,@IsDeleted
			,@ProductImage
			,@AvailableQuantity
			,@AvailabelColor
			,@IsFeatured
			,@ProductSize
			,@ProductWeight
			,@ProductPrice
			,@ProductShipTime
			,GETDATE() --@CreatedDate
			)

		SELECT '0' code
			,'Product Added Successfully!' message

		RETURN;
	END

	IF @flag = 'u'
	BEGIN
		UPDATE tbl_product
		SET ProductName = @ProductName
			,CategoryId = @CategoryId
			,ProductStatus = @ProductStatus
			,IsDeleted = @IsDeleted
			,ProductImage = @ProductImage
			,AvailableQuantity = @AvailableQuantity
			,AvailabelColor = @AvailabelColor
			,IsFeatured = @IsFeatured
			,ProductSize = @ProductSize
			,ProductWeight = @ProductWeight
			,ProductPrice = @ProductPrice
			,ProductShipTime = @ProductShipTime
			,ModifiedDate = GETDATE()
		WHERE ProductId = @ProductId

		SELECT '0' code
			,'Product updated Successfully!' message

		RETURN
	END

	IF @flag = 'bu'
	BEGIN
		UPDATE tbl_product
		SET ProductStatus = @ProductStatus
			,ModifiedDate = GETDATE()
		WHERE ProductId = @ProductId

		SELECT '0' code
			,'Product status updated Successfully!' message

		RETURN
	END
END
GO


