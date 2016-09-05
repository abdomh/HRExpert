CREATE TABLE [dbo].[Objects]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1,1),
	ClassId int,
    ViewName nvarchar(1024),
    Url nvarchar(max),
	CONSTRAINT FK_Objects_Class Foreign key (ClassId) References Classes(Id)
)
