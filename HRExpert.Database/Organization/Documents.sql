CREATE TABLE [dbo].[Documents]
(
	[DocumentId] bigint NOT NULL,
	[DocumentTypeId] bigint NOT NULL,
	[CreatorId] bigint not null,
	[CreateDate] DateTime not null default(GETDATE()),	
	[EditDate] DateTime not null default(GETDATE()),
	[DeleteDate] DateTime,
	[Code1C] uniqueidentifier,
	[Status] bigint not null default(1),
	CONSTRAINT PK_Documents PRIMARY KEY (DocumentId,DocumentTypeId),
	CONSTRAINT FK_Documents_DocumentType FOREIGN KEY (DocumentTypeId) References DocumentTypes(Id),
	CONSTRAINT FK_Documents_Creator FOREIGN KEY (CreatorId) References Persons(Id)
)
