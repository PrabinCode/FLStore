USE FurnitureLandStore
GO

CREATE TABLE [dbo].tbl_slide_images(
	SlideId [int] IDENTITY(1,1) NOT NULL,
	SlideTitle varchar (250) NULL,
	SlideImage varchar (500) NULL,
	SlideDescription varchar (500) NULL,
	Status bit NULL,
	CreatedDate [datetime] NULL,
	ModifiedDate [datetime] NULL
)
GO
