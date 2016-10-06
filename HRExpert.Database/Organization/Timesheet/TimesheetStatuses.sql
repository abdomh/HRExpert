CREATE TABLE [dbo].[TimesheetStatuses]
(
	[Id] int NOT NULL PRIMARY KEY identity (1,1),
	[Name] nvarchar(256) not null,
	[ShortName] nvarchar(32) not null,
	[Code] nvarchar(256)
)
