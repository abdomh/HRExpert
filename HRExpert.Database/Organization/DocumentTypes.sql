CREATE TABLE [dbo].[DocumentTypes]
(
	[Id] int NOT NULL PRIMARY KEY identity(1,1),
	[Code] nvarchar(256),
	[Name] nvarchar(256) not null
)
