CREATE TABLE [dbo].[Menus]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1,1)	,
	NameId int,
	Code nvarchar(32),
	Constraint FK_Menus_Name Foreign Key (NameId) References Dictionaries(Id)

)
