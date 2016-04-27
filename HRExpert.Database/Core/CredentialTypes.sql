CREATE TABLE [dbo].[CredentialTypes]
(
	[Id] bigint NOT NULL PRIMARY KEY IDENTITY (1,1),
	[Name] nvarchar(256) NOT NULL,
	[Delete] bit not null default(0)
)
