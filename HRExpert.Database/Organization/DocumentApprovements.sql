CREATE TABLE [dbo].[DocumentApprovements]
(
	[DocumentGuid] uniqueidentifier not null,
	[ApprovePosition] int not null,
	[PersonId] bigint not null,
	[DateAccept] datetime,
	CONSTRAINT PK_DocumentApprovements Primary key (DocumentGuid,ApprovePosition),
	CONSTRAINT FK_DocumentApprovements_Document Foreign key (DocumentGuid) References Documents(Id)
	
)
