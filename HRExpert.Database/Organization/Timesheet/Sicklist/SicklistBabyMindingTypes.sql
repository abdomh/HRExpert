﻿CREATE TABLE [dbo].[SicklistBabyMindingTypes]
(
	[Id] bigint NOT NULL PRIMARY KEY identity (1,1),
	[Name] nvarchar(256) not null, 
    [Code] NVARCHAR(32) NULL
)
