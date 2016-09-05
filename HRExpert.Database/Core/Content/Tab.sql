CREATE TABLE [dbo].[Tabs]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1,1),
	ClassId int,
    Name nvarchar(256),
    Position int,
	CONSTRAINT FK_Tab_Class Foreign key (ClassId) References Classes(Id)
)
