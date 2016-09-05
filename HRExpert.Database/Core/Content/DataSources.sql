CREATE TABLE [dbo].[DataSources]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1,1),
	ClassId int,
	Code nvarchar(32),
	CSharpClassName nvarchar(1024),
	Parameters nvarchar(max),
	Constraint FK_DataSources_Class Foreign Key (ClassId) REferences Classes(Id)
)
