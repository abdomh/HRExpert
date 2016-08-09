CREATE TABLE [dbo].[PermissionTypes]
(
	[Id] bigint NOT NULL PRIMARY KEY identity(1,1),
	[Name] nvarchar(256),
	[Code] nvarchar(256),
	[SectionId] bigint not null default(1),
	[Delete] bit not null default(0),
	CONSTRAINT FK_PermissionTypes_Section FOREIGN KEY (SectionId) References Sections(Id)
)
