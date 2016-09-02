CREATE TABLE [dbo].[SicklistTypes]
(
	[Id] int NOT NULL PRIMARY KEY identity(1,1),
	[Code] nvarchar(32),
	[Name] nvarchar(256) not null
)
