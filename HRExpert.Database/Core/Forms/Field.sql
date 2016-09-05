CREATE TABLE [dbo].[Fields]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1,1),
	FormId int,
	FieldTypeId int,
	NameId int,
	Position int,
	Constraint FK_Fields_Form Foreign Key (FormId) References Forms(Id),
	Constraint FK_Fields_FieldType Foreign Key(FieldTypeId) References FieldTypes(Id),
	Constraint FK_Fields_Name Foreign Key (NameId) References Dictionaries(Id)

)
