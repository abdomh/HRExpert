CREATE TABLE [dbo].[CachedFields]
(
	FieldId int,
	FieldTypeCode nvarchar(32),
	Name nvarchar(256),
	Position int,
	CachedFieldOptions nvarchar(max),
	Constraint FK_CachedField_Field Foreign Key(FieldId) References Fields(Id)
)
