CREATE TABLE [dbo].[Organizations]
(
	[Id] int NOT NULL PRIMARY KEY Identity(1,1),
	[Code1C] uniqueidentifier,
	[Name] nvarchar(256)	,
	[Delete] bit not null default(0)
)
