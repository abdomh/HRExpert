CREATE TABLE [dbo].[Events]
(
	[EntityId] bigint not null,
	[EntityTypeId] bigint not null,
	[DocumentId] bigint not null,
	[DocumentTypeId] bigint not null,
	[Begin] DateTime not null default(GetDate()),
	[End] DateTime ,
	CONSTRAINT PK_Events PRIMARY KEY (EntityId, EntityTypeId, DocumentId,DocumentTypeId),
	Constraint FK_Events_Entities FOREIGN KEY (EntityId, EntityTypeId) REFERENCES Entities(EntityId,EntityTypeId),
	Constraint FK_Events_Documents FOREIGN KEY (DocumentId,DocumentTypeId) REFERENCES Documents(DocumentId, DocumentTypeId)
)
