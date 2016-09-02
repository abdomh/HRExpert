CREATE TABLE [dbo].[Users]
(
	[Id] int PRIMARY KEY IDENTITY(1,1),	
	[Name] nvarchar(256),
	[Created] bigint
)
