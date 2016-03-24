CREATE TABLE [dbo].[BaseObjects]
(
	[Id] uniqueidentifier PRIMARY KEY NOT NULL DEFAULT(NEWID()),
	[GUID1C] uniqueidentifier,
	[ClassId] bigint ,
	[Name] nvarchar(256) NOT NULL DEFAULT(''),
	[Description] text,
	[Version] int NOT NULL DEFAULT(1),
	[CreateDate] DateTime NOT NULL DEFAULT(GETDATE()),	
	[DeleteDate] DateTime,
	CONSTRAINT FK_BaseObjects_Classes FOREIGN KEY (ClassId) REFERENCES BaseClasses(Id)
)
