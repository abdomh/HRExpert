CREATE TABLE [dbo].[RolePermissions]
(
	RoleId bigint NOT NULL,
	PermissionId bigint NOT NULL,
	CONSTRAINT FK_RolePermissions_Roles FOREIGN KEY (RoleId) REFERENCES Roles(Id),
	CONSTRAINT FK_RolePermissions_Permissions FOREIGN KEY (PermissionId) REFERENCES Permissions(Id),
	CONSTRAINT PK_RolePermissions PRIMARY KEY (RoleId,PermissionId)
)
