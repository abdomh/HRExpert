CREATE TABLE [dbo].[Roles]
(
	[Id] int NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] nvarchar(256) NOT NULL,
	[Code] nvarchar(32) not null,
	[Position] int
)
