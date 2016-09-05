CREATE TABLE [dbo].[Properties]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1,1),
	ObjectId int,
    MemberId int,
    HtmlId int,
	CONSTRAINT FK_Properties_Object Foreign key(ObjectId) References Objects(Id),
	CONSTRAINT FK_Properties_Member Foreign Key (MemberId) References Members(Id),
	Constraint FK_Properties_Dictionary Foreign Key(HtmlId) References Dictionaries(Id)
)
