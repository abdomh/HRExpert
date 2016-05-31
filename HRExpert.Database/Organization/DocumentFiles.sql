CREATE TABLE [dbo].[DocumentFiles]
(
	[DocumentGuid] uniqueidentifier not null,
	[FileType] int not null,
	[FileName] nvarchar(512),
	CONSTRAINT PK_DocumentFiles Primary key (DocumentGuid, FileType)
)
