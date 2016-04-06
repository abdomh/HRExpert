CREATE TABLE [dbo].[ObjectLinks]
(
	[ParentId] uniqueidentifier NOT NULL,
	[ChildId] uniqueidentifier NOT NULL,
	CONSTRAINT FK_ObjectLinks_Parent FOREIGN KEY (ParentId) REFERENCES BaseObjects(Id),
	CONSTRAINT FK_ObjectLinks_Child FOREIGN KEY (ChildId) REFERENCES BaseObjects(Id),
	CONSTRAINT PK_ObjectLinks PRIMARY KEY (ParentId,ChildId) 
)
