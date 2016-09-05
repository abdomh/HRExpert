CREATE TABLE [dbo].[CachedProperties]
(
	PropertyId int,
	MemberCode nvarchar(32),
	Html nvarchar(max),
	CONSTRAINT FK_CachedProperties_Property Foreign Key (PropertyId) References Properties(Id)
)
