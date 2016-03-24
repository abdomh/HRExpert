CREATE TABLE [dbo].[Photos]
(
	[Id] bigint NOT NULL PRIMARY KEY IDENTITY(1,1),
	[UserId] bigint NOT NULL,
	[FileName] nvarchar(max) NOT NULL,
	CONSTRAINT FK_Photos_Users FOREIGN KEY (UserId) REFERENCES Users(id)
)
