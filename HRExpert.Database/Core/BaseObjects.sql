CREATE TABLE [dbo].[BaseObjects]
(
	[Id] uniqueidentifier primary key not null default(NEWID()),
	[GUID1C] uniqueidentifier,
	[ClassId] bigint ,
	[Name] nvarchar(100) not null default(''),
	[Description] text,
	[Version] int not null default(1),
	[CreateDate] DateTime not null default(GETDATE()),	
	[DeleteDate] DateTime,
	[CreatorId] bigint,
	CONSTRAINT FK_Object_Creator FOREIGN KEY (CreatorId) References Users(Id),
	CONSTRAINT FK_Object_Class FOREIGN KEY (ClassId) References BaseClasses(Id)
)
