CREATE TABLE [dbo].[Persons]
(
	[Id] int NOT NULL PRIMARY KEY IDENTITY(1,1),
	[UserId] int,
	[Code1C] uniqueidentifier,
	[Name] nvarchar(256),
	[Email] nvarchar(256),
	[AcceptDate] DateTime not null default(getdate()),
	[DismissalDate] DateTime,
	[DepartmentId] int ,
	[PositionId] int,
	[PostCount] decimal(18,2),
	CONSTRAINT FK_Person_StaffEstablishedPost FOREIGN KEY (DepartmentId,PositionId) References StaffEstablishedPosts(DepartmentId,PositionId),
	CONSTRAINT FK_Person_User FOREIGN KEY (UserId) References Users(Id)
)
