﻿CREATE TABLE [dbo].[Statuses]
(
	[Id] int NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Code] nvarchar(32),
	[Name] nvarchar(256) not null,
)
