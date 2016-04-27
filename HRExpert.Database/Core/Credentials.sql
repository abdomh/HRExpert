CREATE TABLE [dbo].[Credentials]
(	
	[Value] nvarchar(256) NOT NULL,
	[UserId] bigint NOT NULL,
	[Secret] nvarchar(256) NOT NULL,
	[CredentialTypeId] bigint NOT NULL,
	CONSTRAINT PK_Credentials PRIMARY KEY(UserId,CredentialTypeId),
	CONSTRAINT FK_Credentials_Users FOREIGN KEY (UserId) REFERENCES Users(Id),
	CONSTRAINT FK_Credentials_Types FOREIGN KEY (CredentialTypeId) REFERENCES CredentialTypes(Id)
	 
)
