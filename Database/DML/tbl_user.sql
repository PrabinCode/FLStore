USE [FurnitureLandStore]
GO

INSERT INTO [dbo].[tbl_user]
           ([UserRole]
           ,[UserRoleType]
           ,[UserName]
           ,[UserPassword]
           ,[UserStatus]
           ,[IsBlocked]
           ,[CreatedDate])
     VALUES
           ('1'
           ,'ADMIN'
           ,'admin'
           ,'UGEkJHcwcmQhUEAkJHcwcmQ=' --Pa$$w0rd!
           ,'A'
           ,'A'
           ,GETDATE())
GO


