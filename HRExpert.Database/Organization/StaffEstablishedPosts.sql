CREATE TABLE [dbo].[StaffEstablishedPosts]
(
	[PostCount] decimal (18,2) NOT NULL default(0),
	[DepartmentId] int NOT NULL,
	[PositionId] int not null,	
	CONSTRAINT FK_StaffEstablishedPosts_Departments FOREIGN KEY (DepartmentId) References Departments(Id),
	CONSTRAINT FK_StaffEstablishedPosts_Positions Foreign Key ( PositionId) References Positions(Id),
	CONSTRAINT PK_StaffEstablishedPosts PRIMARY KEY (DepartmentId, PositionId)
)
