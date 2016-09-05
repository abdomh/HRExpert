CREATE TABLE [dbo].[CachedForms]
(
	CultureId int,
	FormId int,
	Code nvarchar(32),
	Name nvarchar(256),
	CachedFields nvarchar(max),
	Constraint FK_CachedForms_Culture Foreign key(CultureId) References Cultures(Id),
	Constraint FK_CachedForms_Form Foreign key (FormId) References Forms(Id)
)
