CREATE TABLE [dbo].[Positions]
(
	[Id] bigint NOT NULL PRIMARY KEY identity(1,1),
	[Code] nvarchar(32),
	[Code1C] uniqueidentifier,
	[Name] nvarchar(256) not null,
	[Rank] int not null default (0)
)
