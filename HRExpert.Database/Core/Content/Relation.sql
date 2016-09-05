CREATE TABLE [dbo].[Relation]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1,1),
	MemberId int,
	PrimaryId int,
	ForeignId int,
	Constraint FK_Relation_Member Foreign Key (MemberId) References Members(Id),
	Constraint FK_Relation_Primary Foreign Key (PrimaryId) References Objects(Id),
	Constraint FK_Relation_Foreign Foreign Key (ForeignId) References Objects(Id)
)
