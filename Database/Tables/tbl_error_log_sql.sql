
CREATE TABLE [dbo].[tbl_error_log_sql](
	[sql_error_id] [bigint] IDENTITY(1,1) NOT NULL,
	[sql_error_desc] [varchar](500) NULL,
	[sql_error_script] [varchar](500) NULL,
	[sql_query_string] [varchar](500) NULL,
	[sql_error_category] [varchar](500) NULL,
	[sql_error_source] [varchar](500) NULL,
	[sql_error_UTC_date] [datetime] NULL,
	[sql_error_local_date] [datetime] NULL
)
GO


