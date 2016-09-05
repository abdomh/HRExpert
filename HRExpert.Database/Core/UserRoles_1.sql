CREATE TABLE [dbo].[UserRoles]
(
	UserId int not null,
	RoleId int not null,
	COnstraint FK_UserRoles_User Foreign key (UserId) References Users(Id),
	COnstraint FK_UserRoles_Roles Foreign key (ROleId) References Roles(Id)
)
