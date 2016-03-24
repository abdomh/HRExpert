CREATE TABLE [dbo].[RoleUsers]
(
	[UserId] bigint not null,
	[RoleId] bigint not null,
	Constraint FK_RoleUsers_User Foreign key (UserId) References Users(Id),
	Constraint FK_RoleUsers_Role Foreign key (RoleId) References Roles(Id),
	Constraint PK_RoleUsers Primary key (UserId,RoleId) 
)
