CREATE TABLE [dbo].[ManagerDepartmentLinks]
(
	[PersonId] bigint not null,
	[DepartmentId] bigint not null,
	Constraint PK_ManagerDepartmentLinks Primary key (PersonId,DepartmentId),
	Constraint FK_ManagerDepartmentLinks_Persons Foreign Key (PersonId) References Persons(Id),
	Constraint FK_ManagerDepartmentLinks_Departments Foreign Key (DepartmentId) References Departments(Id)
)
