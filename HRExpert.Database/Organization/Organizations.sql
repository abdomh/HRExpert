CREATE TABLE [dbo].[Organizations]
(
	[Id] bigint NOT NULL PRIMARY KEY Identity(1,1),
	[Code] nvarchar(32),
	[Code1C] uniqueidentifier,
	[Name] nvarchar(256)	,
	[Delete] bit not null default(0)
)
