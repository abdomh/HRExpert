CREATE TABLE [dbo].[Sections]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1,1),
	Name nvarchar(256) not null,
	Code nvarchar(32) not null
)
