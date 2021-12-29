USE FurnitureLandStore
GO

/****** Object:  StoredProcedure [dbo].[GetBySearch]    Script Date: 12/29/2021 3:04:43 AM ******/
DROP PROCEDURE [dbo].[GetBySearch]
GO

/****** Object:  StoredProcedure [dbo].[GetBySearch]    Script Date: 12/29/2021 3:04:43 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetBySearch]
	@search nvarchar(max)=null
AS
BEGIN
	SELECT *from [dbo].tbl_product P 
	left join [dbo].tbl_static_data C on p.CategoryId=c.StaticType
	where 
	P.ProductName LIKE CASE WHEN @search is not null then  '%'+@search+'%' else P.ProductName end
	OR 
	C.StaticValue LIKE CASE WHEN @search is not null then  '%'+@search+'%' else C.StaticValue end
END

GO


