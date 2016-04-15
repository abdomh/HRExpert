CREATE TABLE [dbo].[StaffEstablishedPostPerson]
(
	[StaffEstablishedPostId] bigint not null,
	[PersonId] bigint not null,
	[PostCount] decimal (18,2) not null default(0),
	CONSTRAINT PK_StaffEstablishedPostPerson PRIMARY KEY (StaffEstablishedPostId,PersonId)
)
