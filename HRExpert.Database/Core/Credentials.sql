CREATE TABLE [dbo].[Credentials]
(	
	[Id] int not null Primary Key identity(1,1),
	[Identifier] nvarchar(256) NOT NULL,
	[UserId] int NOT NULL,
	[Secret] nvarchar(256) NOT NULL,
	[CredentialTypeId] int NOT NULL,
	CONSTRAINT FK_Credentials_Users FOREIGN KEY (UserId) REFERENCES Users(Id),
	CONSTRAINT FK_Credentials_Types FOREIGN KEY (CredentialTypeId) REFERENCES CredentialTypes(Id)
	 
)
