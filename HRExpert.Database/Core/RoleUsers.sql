﻿CREATE TABLE [dbo].[RoleUsers]
(
	[UserId] bigint NOT NULL,
	[RoleId] bigint NOT NULL,
	CONSTRAINT FK_RoleUsers_Users FOREIGN KEY (UserId) REFERENCES Users(Id),
	CONSTRAINT FK_RoleUsers_Roles FOREIGN KEY (RoleId) REFERENCES Roles(Id),
	CONSTRAINT PK_RoleUsers PRIMARY KEY (UserId,RoleId) 
)
