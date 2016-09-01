CREATE TABLE [dbo].[Persons_1C]
(
	[Id] uniqueidentifier not null,
	[Name] nvarchar(max),
	[Organization] uniqueidentifier,
	[Department] uniqueidentifier,
	[Position] uniqueidentifier,
	[PostCount] float,
	[Email] nvarchar(max),
	[AcceptDate] DateTime,
	[DismissalDate] DateTime
)
