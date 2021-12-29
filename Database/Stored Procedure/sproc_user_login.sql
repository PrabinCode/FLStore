USE [FurnitureLandStore]
GO

/****** Object:  StoredProcedure [dbo].[sproc_user_login]    Script Date: 12/28/2021 3:29:37 PM ******/
DROP PROCEDURE [dbo].[sproc_user_login]
GO

/****** Object:  StoredProcedure [dbo].[sproc_user_login]    Script Date: 12/28/2021 3:29:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sproc_user_login] @flag VARCHAR(10)
	,@user_name VARCHAR(512)
	,@password VARCHAR(512)
	,@browser_info NVARCHAR(512) = NULL
	,@session_id NVARCHAR(512) = NULL
AS
BEGIN
	DECLARE @full_name VARCHAR(512)
		,@user_id INT

	IF @flag = 'login'
	BEGIN
		IF EXISTS (
				SELECT 'x'
				FROM tbl_user u WITH (NOLOCK)
				left JOIN tbl_customer c WITH (NOLOCK) ON c.UserId = u.UserId
				WHERE (
						UserName = @user_name
						OR c.CustomerEmail = @user_name
						OR c.CustomerMobileNo = @user_name
						)
					AND UserPassword = @password
					AND isnull(UserStatus, 'N') = 'A'
					AND ISNULL(IsBlocked, 'N') = 'A'
				)
		BEGIN
			--select  @full_name = ISNULL(FirstName, '') + ' ' + ISNULL(MiddleName + ' ', '') + ISNULL(LastName, '') 
			--from tbl_customer where
			--UserId = @user_id
			SELECT 0 code
				,message = 'success'
				,u.UserId UserId
				,u.UserRole RoleId
				,u.UserName UserName
				,ISNULL(FirstName, '') + ' ' + ISNULL(MiddleName + ' ', '') + ISNULL(LastName, '') FullName
				,RoleType UserType
				,r.RoleName RoleName
				,ProfileImage ProfileImage
			FROM tbl_user u WITH (NOLOCK)
			LEFT JOIN tbl_customer c WITH (NOLOCK) ON c.UserId = u.UserId
			LEFT JOIN tbl_roles r WITH (NOLOCK) ON r.RoleId = u.UserRole

			WHERE (
					UserName = @user_name
					OR c.CustomerEmail = @user_name
					OR c.CustomerMobileNo = @user_name
					)
				AND UserPassword = @password
				AND isnull(UserStatus, 'N') = 'A'
				AND ISNULL(IsBlocked, 'N') = 'A'

			RETURN
		END
		ELSE
		BEGIN
			SELECT 1 code
				,'failed' message

			RETURN
		END
	END
END
GO


