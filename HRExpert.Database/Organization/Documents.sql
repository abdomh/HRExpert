CREATE TABLE [dbo].[Documents]
(
	[Id] uniqueidentifier NOT NULL default(newid()) PRIMARY KEY,
	[CreatorId] bigint not null,
	[Code1C] uniqueidentifier,
	[SendTo1C] datetime,
	[CreateDate] datetime not null default (GetDate()),	
	[DeleteDate] datetime,
	[PersonId] bigint not null,
	[DocumentId] bigint not null default(0),
	[DocumentTypeId] bigint not null,
	[DocumentStatusId] bigint,
	CONSTRAINT FK_Documents_DocumentStatus Foreign key (DocumentStatusId) References Statuses(Id),
	CONSTRAINT FK_Documents_DocumentTypes FOREIGN KEY (DocumentTypeId) References DocumentTypes(Id),
	CONSTRAINT FK_Documents_Person Foreign Key (PersonId) References Persons(Id),
	Constraint FK_Documents_Creator Foreign key (CreatorId) References Persons(Id)
)
