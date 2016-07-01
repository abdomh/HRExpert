CREATE TABLE [dbo].[DocumentApprovements]
(
	[DocumentGuid] uniqueidentifier not null,
	[ApprovePosition] int not null,
	[PersonId] bigint not null,
	[RealPersonId] bigint not null,
	[IsAccept] bit not null default(0),
	[DateAccept] datetime,

	CONSTRAINT PK_DocumentApprovements Primary key (DocumentGuid,ApprovePosition),
	CONSTRAINT FK_DocumentApprovements_Document Foreign key (DocumentGuid) References Documents(Id),
	Constraint FK_DocumentApprovements_Person Foreign key (PersonId) References Persons(Id),
	Constraint FK_DocumentApprovements_RealPerson Foreign key (RealPersonId) References Persons(Id)
)
