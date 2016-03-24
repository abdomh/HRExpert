CREATE TABLE [dbo].[DataSourcePermissions]
(
	DataSourceId bigint NOT NULL,
	PermissionId bigint NOT NULL,
	CONSTRAINT FK_DataSourcePermissions_DataSources FOREIGN KEY (DataSourceId) REFERENCES DataSources(Id),
	CONSTRAINT FK_DataSourcePermissions_Permissions FOREIGN KEY (PermissionId) REFERENCES Permissions(Id),
	CONSTRAINT PK_DataSourcePermissions PRIMARY KEY (DataSourceId,PermissionId)
)
