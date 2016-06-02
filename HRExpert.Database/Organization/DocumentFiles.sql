CREATE TABLE [dbo].[DocumentFiles]
(
	[Id] uniqueidentifier not null primary key default(newid()),
	[DocumentGuid] uniqueidentifier not null,
	[FileType] int not null,
	[FileName] nvarchar(512),
	CONSTRAINT FK_DocumentFiles_Document Foreign Key (DocumentGuid) References Documents(Id)
)
