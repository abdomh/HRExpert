CREATE TABLE [dbo].[Users]
(
	[Id] bigint primary key identity(1,1),
	[ObjectId] uniqueidentifier,
	[Password] nvarchar(100) not null,
	[Email] nvarchar(50),
	[SecondEmail] nvarchar(50),
	CONSTRAINT FK_Users_Objects FOREIGN KEY([ObjectId]) REFERENCES BaseObjects(Id)
)
