USE [FurnitureLandStore]
GO

/****** Object:  StoredProcedure [dbo].[sproc_registration]    Script Date: 12/28/2021 3:29:08 PM ******/
DROP PROCEDURE [dbo].[sproc_registration]
GO

/****** Object:  StoredProcedure [dbo].[sproc_registration]    Script Date: 12/28/2021 3:29:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sproc_registration] @flag VARCHAR(10)
	,@UserName VARCHAR(512)
	,@FirstName VARCHAR(250)
	,@MiddleName VARCHAR(250)
	,@LastName VARCHAR(250)
	,@CustomerAddress NVARCHAR(1000) = NULL
	,@CustomerEmail NVARCHAR(512) = NULL
	,@CustomerMobileNo VARCHAR(15) = NULL
	,@CustomerFax VARCHAR(50) = NULL
	,@CompanyName VARCHAR(512) = NULL
	,@CompanyAddress NVARCHAR(1000) = NULL
	,@CompanyPhone VARCHAR(15) = NULL
	,@CompanyFax VARCHAR(50) = NULL
	,@PreferedShipMethod VARCHAR(15) = NULL
	,@SchoolName VARCHAR(512) = NULL
	,@ProfileImage VARCHAR(max) = NULL
	,@UserPassword NVARCHAR(512) = NULL
AS
DECLARE @error_message VARCHAR(512)
	,@user_id INT
	,@desc VARCHAR(MAX)

BEGIN
	IF @flag = 'i'
	BEGIN
		IF EXISTS (
				SELECT 'x'
				FROM tbl_user WITH (NOLOCK)
				WHERE UserName = @UserName
				
				UNION
				
				SELECT 'x'
				FROM tbl_customer WITH (NOLOCK)
				WHERE CustomerEmail = @CustomerEmail
					OR CustomerMobileNo = @CustomerMobileNo
				)
		BEGIN
			SELECT '1' Code
				,'Customer information is already used!' Message
				,NULL id;

			RETURN;
		END

		BEGIN TRY
			BEGIN TRANSACTION addUser

			INSERT INTO tbl_user (
				UserRole
				,UserRoleType
				,UserName
				,UserPassword
				,UserStatus
				,IsBlocked
				,CreatedDate
				)
			VALUES (
			'2'
			,'CUSTOMER'
			,@UserName
			,@UserPassword
			,'A'-- A= active B =blocked
			,'A'-- A= active B =blocked
			,GETDATE()
			)

			SET @user_id = SCOPE_IDENTITY();

			INSERT INTO tbl_customer (
				UserId
				,FirstName
				,MiddleName
				,LastName
				,CustomerAddress
				,CustomerEmail
				,CustomerStatus
				,IsDeleted
				,CustomerMobileNo
				,CustomerFax
				,CompanyName
				,CompanyAddress
				,CompanyPhone
				,CompanyFax
				,PreferedShipMethod
				,SchoolName
				,ProfileImage
				,CreatedDate
				)
			VALUES (
			@user_id
			,@FirstName
			,@MiddleName
			,@LastName
			,@CustomerAddress
			,@CustomerEmail
			,'A' -- A= active B =blocked
			,'A' -- A= active B =blocked
			,@CustomerMobileNo
			,@CustomerFax
			,@CompanyName
			,@CompanyAddress
			,@CompanyPhone
			,@CompanyFax
			,@PreferedShipMethod
			,@SchoolName
			,@ProfileImage
			,GETDATE()
			)

			SELECT '0' code
				,'Customer registeration successfull' message
			COMMIT TRANSACTION addUser
		END TRY

		BEGIN CATCH
			IF @@trancount > 0
				ROLLBACK TRANSACTION addUser

			SET @desc = 'sql error found:(' + error_message() + ')'

			INSERT INTO tbl_error_log_sql (
				sql_error_desc
				,sql_error_script
				,sql_query_string
				,sql_error_category
				,sql_error_source
				,sql_error_local_date
				,sql_error_UTC_date
				)
			SELECT @desc
				,'sproc_registration(add user:flag ''i'')'
				,'sql'
				,'sql'
				,'sproc_registration(insert user)'
				,getdate()
				,getutcdate()

			SELECT '1' code
				,'errorid: ' + cast(scope_identity() AS VARCHAR) message
				,NULL id
		END CATCH
	END

	IF @flag = 'u'
	BEGIN

	RETURN;
	END

END
GO


