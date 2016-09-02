CREATE TABLE [dbo].[Permissions]
(
	[Id] int NOT NULL PRIMARY KEY identity(1,1),
	[Name] nvarchar(256),
	[Code] nvarchar(256),
	[Position] int
)
