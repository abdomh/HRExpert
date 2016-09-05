CREATE TABLE [dbo].[FieldOptions]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1,1),
	FieldId int,
	ValueId int,
	Position int,
	Constraint FK_FieldOptions_Field Foreign Key (FieldId) References Fields(Id),
	Constraint FK_FieldOptions_Values Foreign Key (ValueId) References Dictionaries(Id)
)
