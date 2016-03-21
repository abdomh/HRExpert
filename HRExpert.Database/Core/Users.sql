CREATE TABLE [dbo].[Users]
(
	[Id] bigint primary key identity(1,1),
	[GUID] uniqueidentifier,
	[Password] nvarchar(100) not null,
	[Email] nvarchar(50),
	[SecondEmail] nvarchar(50),
	CONSTRAINT FK_Users_Objects FOREIGN KEY([GUID]) REFERENCES BaseObjects(Id)
)
