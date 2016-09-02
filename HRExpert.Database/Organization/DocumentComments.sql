CREATE TABLE [dbo].[DocumentComments]
(
	[Id] uniqueidentifier Primary key not null default( newid()),
	[CreateDate] datetime not null default(getdate()),
	[DocumentGuid] uniqueidentifier not null,
	[Message] nvarchar(max),
	[Author] int not null,
	Constraint FK_DocumentComments_Document Foreign key (DocumentGuid) References Documents(Id),
	Constraint FK_DocumentComments_Author foreign key (Author) References Persons(Id)
)
