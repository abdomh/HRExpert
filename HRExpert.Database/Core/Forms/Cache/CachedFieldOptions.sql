CREATE TABLE [dbo].[CachedFieldOptions]
(
	FieldOptionId int,
	Value nvarchar(max),
	Position int,
	Constraint FK_CachedFieldOptions_FieldOption Foreign key(FieldOptionId) References FieldOptions(Id)
)
