CREATE TABLE [dbo].[Modules]
(
	[Id] bigint NOT NULL PRIMARY KEY identity(1,1),
	[Name] nvarchar(256),
	[Code] nvarchar(32),
	[Delete] bit not null default(0)
)
