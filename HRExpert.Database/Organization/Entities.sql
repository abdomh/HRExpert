CREATE TABLE [dbo].[Entities]
(
	[EntityId] bigint NOT NULL,
	[EntityTypeId] bigint not null,
	[CreateDate] DateTime not null default(getDate()),
	[DeleteDate] DateTime ,
	CONSTRAINT PK_Entities PRIMARY KEY (EntityId, EntityTypeId)
)
