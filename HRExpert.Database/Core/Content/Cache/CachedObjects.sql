CREATE TABLE [dbo].[CachedObjects]
(
	CultureId int,
	ObjectId int,
	ClassId int,
	ViewName nvarchar(max),
	Url nvarchar(max),
	CachedProperties nvarchar(max),
	CachedDataSources nvarchar(max),
	Constraint FK_CachedObjects_Culter Foreign Key (CultureId) References Cultures(Id),
	Constraint FK_CachedObjects_Object Foreign Key (ObjectId) References Objects(Id),
	Constraint FK_CachedObjects_Class Foreign Key (ClassId) References Classes(Id)

)
