CREATE TABLE [dbo].[Positions]
(
	[Id] int NOT NULL PRIMARY KEY identity(1,1),
	[Code1C] uniqueidentifier,
	[Name] nvarchar(256) not null,
	[Rank] int not null default (0),
	[Delete] bit not null default(0)
)
