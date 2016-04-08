CREATE TABLE [dbo].[PermissionTypes]
(
	[Id] bigint NOT NULL PRIMARY KEY identity(1,1),
	[Name] nvarchar(256),
	[Code] nvarchar(32),
	[Delete] bit not null default(0),
	[ModuleId] bigint not null,
	Constraint FK_PermissionTypes_Modules Foreign Key (ModuleId) References Modules(Id)
)
