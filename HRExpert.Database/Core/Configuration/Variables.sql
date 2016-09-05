CREATE TABLE [dbo].[Variables]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1,1),
	Name nvarchar(256) not null,
	Code nvarchar(32) not null,
	Position int,
	Value nvarchar(1024),
	SectionId int not null,
	Constraint FK_Variables_Sections Foreign key (SectionId) References Sections(Id)
)
