CREATE TABLE [dbo].[Departments]
(
	[Id] int NOT NULL PRIMARY KEY IDENTITY(1,1),
	[OrganizationId] int NOT NULL,
	[Code1C] uniqueidentifier,
	[ParentId] int,
	[Name] nvarchar(256),
	[Delete] bit not null default(0),
	CONSTRAINT FK_Departments_Organization FOREIGN KEY (OrganizationId) References Organizations(Id),
	CONSTRAINT FK_Departments_Parent FOREIGN Key (ParentId) REferences Departments(Id)

)
