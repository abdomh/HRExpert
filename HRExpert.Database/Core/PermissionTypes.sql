CREATE TABLE [dbo].[PermissionTypes]
(
	[Id] bigint NOT NULL PRIMARY KEY,
	[Name] nvarchar(256),
	[Code] nvarchar(32),
	[Delete] bit not null default(0)
)
