CREATE TABLE [dbo].[Persons]
(
	[Id] bigint NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Code1C] uniqueidentifier,
	[Name] nvarchar(256),
	[AcceptDate] DateTime not null default(getdate()),
	[DismissalDate] DateTime,
	[DepartmentId] bigint not null,
	[PositionId] bigint not null,
	[PostCount] decimal(18,2),
	CONSTRAINT FK_Person_StaffEstablishedPost FOREIGN KEY (DepartmentId,PositionId) References StaffEstablishedPosts(DepartmentId,PositionId)
)
