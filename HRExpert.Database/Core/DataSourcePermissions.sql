CREATE TABLE [dbo].[DataSourcePermissionTypes]
(
	DataSourceId bigint NOT NULL,
	PermissionTypeId bigint NOT NULL,
	CONSTRAINT FK_DataSourcePermissionTypes_DataSources FOREIGN KEY (DataSourceId) REFERENCES DataSources(Id),
	CONSTRAINT FK_DataSourcePermissionTypes_Permissions FOREIGN KEY (PermissionTypeId) REFERENCES PermissionTypes(Id),
	CONSTRAINT PK_DataSourcePermissionTypes PRIMARY KEY (DataSourceId,PermissionTypeId)
)
