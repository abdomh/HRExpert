CREATE TABLE [dbo].[Peoples]
(
	[Id] bigint NOT NULL PRIMARY KEY IDENTITY(1,1),
	[UserId] bigint NOT NULL,
	[ObjectId] uniqueidentifier NOT NULL,
	CONSTRAINT FK_Peoples_Objects FOREIGN KEY([ObjectId]) REFERENCES BaseObjects(Id),
	CONSTRAINT FK_Peoples_Users FOREIGN KEY(UserId) REFERENCES Users(Id)

)
