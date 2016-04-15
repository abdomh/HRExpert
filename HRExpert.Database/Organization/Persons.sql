CREATE TABLE [dbo].[Persons]
(
	[Id] bigint NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Code1C] uniqueidentifier,
	[Name] nvarchar(256),
	[AcceptDate] DateTime not null default(getdate()),
	[DismissalDate] DateTime
)
