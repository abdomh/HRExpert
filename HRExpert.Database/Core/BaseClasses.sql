CREATE TABLE [dbo].[BaseClasses]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[GUID] uniqueidentifier,
	[Name] nvarchar(256) NOT NULL,
)
