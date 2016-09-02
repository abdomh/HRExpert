CREATE TABLE [dbo].[CredentialTypes]
(
	[Id] int NOT NULL PRIMARY KEY IDENTITY (1,1),
	[Code] nvarchar(32) not null,
	[Position] int,
	[Name] nvarchar(256) NOT NULL,
	[Delete] bit not null default(0)
)
