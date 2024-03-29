﻿CREATE TABLE [dbo].[AccessLinks]
(
	[PersonId] bigint not null,
	[DepartmentId] bigint,
	[TargetPersonId] bigint,
	[RoleId] bigint not null,
	Constraint FK_AccessLinks_TargetPerson Foreign key (TargetPersonId) references Persons(Id),
	Constraint FK_AccessLinks_Role foreign key (RoleId) References Roles(Id),
	Constraint PK_AccessLinks Primary key (PersonId,DepartmentId, RoleId),
	Constraint FK_AccessLinks_Persons Foreign Key (PersonId) References Persons(Id),
	Constraint FK_AccessLinks_Departments Foreign Key (DepartmentId) References Departments(Id)
)
