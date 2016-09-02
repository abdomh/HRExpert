CREATE TABLE [dbo].[RolePermissions]
(
	RoleId int NOT NULL,
	PermissionId int NOT NULL,
	CONSTRAINT FK_RolePermissionTypes_Roles FOREIGN KEY (RoleId) REFERENCES Roles(Id),
	CONSTRAINT FK_RolePermissionTypes_Permissions FOREIGN KEY (PermissionId) REFERENCES Permissions(Id),
	CONSTRAINT PK_RolePermissionTypes PRIMARY KEY (RoleId,PermissionId)
)
