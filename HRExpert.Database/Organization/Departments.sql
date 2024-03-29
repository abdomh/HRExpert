﻿CREATE TABLE [dbo].[Departments]
(
	[Id] bigint NOT NULL PRIMARY KEY IDENTITY(1,1),
	[OrganizationId] bigint NOT NULL,
	[Code1C] uniqueidentifier,
	[ParentId] bigint,
	[Name] nvarchar(256),
	[Delete] bit not null default(0),
	CONSTRAINT FK_Departments_Organization FOREIGN KEY (OrganizationId) References Organizations(Id),
	CONSTRAINT FK_Departments_Parent FOREIGN Key (ParentId) REferences Departments(Id)

)
