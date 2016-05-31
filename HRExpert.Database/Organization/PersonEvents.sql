CREATE TABLE [dbo].[PersonEvents]
(
	[DocumentGuid] uniqueidentifier PRIMARY KEY,
	[BeginDate] datetime,
	[EndDate] datetime,
	CONSTRAINT FK_PersonEvents_Documents Foreign Key (DocumentGuid) References Documents(Id)
)
