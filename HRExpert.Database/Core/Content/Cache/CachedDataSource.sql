CREATE TABLE [dbo].[CachedDataSources]
(
	DataSourceId int,
	Code nvarchar(32),
	CSharpClassName nvarchar(1024),
	Parameters nvarchar(max),
	Constraint FK_CachedDataSources_DataSource Foreign Key (DataSourceId) References DataSources(Id)
)
