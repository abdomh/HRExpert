CREATE TABLE [dbo].[Timesheet]
(
	[DocumentGuid] uniqueidentifier not null Primary key,
	[StatusId] int not null,
	[IsStaffEstablishedPostTemporaryFree] bit not null default(0),
	CONSTRAINT FK_Timesheet_Status Foreign key (StatusId) References TimesheetStatuses(Id),
	CONSTRAINT FK_Timesheet_Events foreign key (DocumentGuid) References PersonEvents(DocumentGuid)
)
