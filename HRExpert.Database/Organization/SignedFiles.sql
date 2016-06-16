CREATE TABLE [dbo].[SignedFiles]
(
	[Id] uniqueidentifier not null Primary key default(newid()),
	[FileId] uniqueidentifier NOT NULL,
	[CreateDate] DateTime not null Default(GetDate()),
	[DeleteAfterDownload] bit not null default(1),
	CONSTRAINT FK_SignedFiles_DocumentFiles Foreign key (FileId) References DocumentFiles(Id)
)
