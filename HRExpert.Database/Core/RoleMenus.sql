CREATE TABLE [dbo].[RoleMenus]
(
	RoleId bigint not null,
	MenuId bigint not null,
	CONSTRAINT FK_RoleMenus_Roles FOREIGN KEY (RoleId) REFERENCES Roles(Id),
	CONSTRAINT FK_RoleMenus_Menus FOREIGN KEY (MenuId) REFERENCES Menus(Id),
	CONSTRAINT PK_RoleMenus PRIMARY KEY (RoleId,MenuId)
)
