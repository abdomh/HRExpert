CREATE TABLE [dbo].[Menus]
(
	[Id] bigint NOT NULL PRIMARY KEY Identity(1,1),
	[Name] nvarchar(256) NOT NULL,
	[Code] nvarchar(32),
	[Delete] bit not null default(0),
	[Link] nvarchar(256) NOT NULL, 
	[ParentId] bigint,
	CONSTRAINT FK_Menu_Parent FOREIGN KEY (ParentId) REFERENCES Menus(Id)
)
