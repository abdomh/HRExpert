CREATE TABLE [dbo].[DataSources]
(
	[Id] bigint NOT NULL PRIMARY KEY,
	[Name] nvarchar(256) NOT NULL,
	[Code] nvarchar(32),
	[Delete] bit not null default(0)
)
