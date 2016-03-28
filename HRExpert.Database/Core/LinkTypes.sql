CREATE TABLE [dbo].[LinkTypes]
(
	[Id] bigint NOT NULL PRIMARY KEY Identity(1,1),
	[Name] nvarchar(256) NOT NULL,
	[Code] nvarchar(32),
	[Delete] bit not null default(0)
)
