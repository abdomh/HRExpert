﻿CREATE TABLE [dbo].[Users]
(
	[Id] bigint PRIMARY KEY IDENTITY(1,1),	
	[Name] nvarchar(256),
	[Delete] bit not null default(0)
)
