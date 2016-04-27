CREATE TABLE [dbo].[Sections]
(
	[Id] bigint NOT NULL PRIMARY KEY identity(1,1),
	[Name] nvarchar(256),
	[Delete] bit not null default(0)
)
