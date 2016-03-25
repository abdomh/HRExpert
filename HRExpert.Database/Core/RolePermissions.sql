CREATE TABLE [dbo].[RolePermissionTypes]
(
	RoleId bigint NOT NULL,
	PermissionTypeId bigint NOT NULL,
	CONSTRAINT FK_RolePermissionTypes_Roles FOREIGN KEY (RoleId) REFERENCES Roles(Id),
	CONSTRAINT FK_RolePermissionTypes_Permissions FOREIGN KEY (PermissionTypeId) REFERENCES PermissionTypes(Id),
	CONSTRAINT PK_RolePermissionTypes PRIMARY KEY (RoleId,PermissionTypeId)
)
