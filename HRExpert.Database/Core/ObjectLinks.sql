CREATE TABLE [dbo].[ObjectLinks]
(
	[ParentId] uniqueidentifier NOT NULL,
	[ChildId] uniqueidentifier NOT NULL,
	[LinkTypeId] bigint NOT NULL,
	CONSTRAINT FK_ObjectLinks_Parent FOREIGN KEY (ParentId) REFERENCES BaseObjects(Id),
	CONSTRAINT FK_ObjectLinks_Child FOREIGN KEY (ChildId) REFERENCES BaseObjects(Id),
	CONSTRAINT FK_ObjectLinks_Types FOREIGN KEY (LinkTypeId) REFERENCES LinkTypes(Id),
	CONSTRAINT PK_ObjectLinks PRIMARY KEY (ParentId,ChildId,LinkTypeId) 
)
