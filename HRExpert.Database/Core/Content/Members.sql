CREATE TABLE [dbo].[Members]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1,1),
	ClassId int,
    TabId int,
	Code nvarchar(32),
	Name nvarchar(256),
	Position int,
    PropertyDataTypeId int,
    IsPropertyLocalizable bit,
    IsPropertyVisibleInList bit,
    RelationClassId int,
    IsRelationSingleParent bit,
	CONSTRAINT FK_Member_Class Foreign key (ClassId) References Classes(Id),
	Constraint FK_Member_Tab Foreign Key (TabId) References Tabs(Id),
	Constraint FK_Member_DataType Foreign Key (PropertyDataTypeId) References DataTypes(Id),
	CONSTRAINT FK_Member_RelationClass Foreign Key (RelationClassId) References Classes(Id)
)
