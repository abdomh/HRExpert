CREATE TABLE [dbo].[BaseClasses]
(
	[Id] bigint NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] nvarchar(256) NOT NULL,
	[Code] nvarchar(32),
	[Delete] bit not null default(0)
)
