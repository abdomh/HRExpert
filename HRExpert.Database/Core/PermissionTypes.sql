CREATE TABLE [dbo].[PermissionTypes]
(
	[Id] bigint NOT NULL PRIMARY KEY identity(1,1),
	[Name] nvarchar(256),
	[Delete] bit not null default(0),
	[SectionId] bigint not null,
	Constraint FK_PermissionTypes_Sections Foreign Key (SectionId) References Sections(Id)
)
