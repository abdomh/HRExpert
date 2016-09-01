CREATE TABLE [dbo].[Department_1C]
(
	[Id] uniqueidentifier not null,
	[Name] nvarchar(max),
	[Organization] uniqueidentifier,
	[Parent] uniqueidentifier
)
