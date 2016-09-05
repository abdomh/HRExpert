CREATE TABLE [dbo].[Classes]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1,1),
	ClassId int,
    Name nvarchar(256),
    PluralizedName nvarchar(256),
    IsAbstract bit,
    IsStandalone bit,
    DefaultViewName nvarchar(1024),
	CONSTRAINT FK_Class_Parent Foreign key (ClassId) References Classes(Id)
)
