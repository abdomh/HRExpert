CREATE TABLE [dbo].[Credentials]
(
	[Id] bigint NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Value] nvarchar(256) NOT NULL,
	[UserId] bigint NOT NULL,
	[Secret] nvarchar(256) NOT NULL,
	[CredentialTypeId] bigint NOT NULL,
	CONSTRAINT FK_Credentials_Users FOREIGN KEY (UserId) REFERENCES Users(Id),
	CONSTRAINT FK_Credentials_Types FOREIGN KEY (CredentialTypeId) REFERENCES CredentialTypes(Id)
	 
)
