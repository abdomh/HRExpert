CREATE TABLE [dbo].[Forms]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1,1),
	Code nvarchar(32),
	NameId int,
	Email nvarchar(256),
	Constraint FK_Forms_Name Foreign Key (NameId) References Dictionaries(Id)
)
