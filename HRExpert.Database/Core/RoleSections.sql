CREATE TABLE [dbo].[RoleSections]
(
	[RoleId] bigint not null,
	[SectionId] bigint not null,
	Constraint PK_RoleSections Primary Key (RoleId,SectionId),
	Constraint FK_RoleSections_Role Foreign Key (RoleId) References Roles(Id),
	Constraint FK_RoleSections_Section Foreign Key (SectionId) References Sections(Id)
)
