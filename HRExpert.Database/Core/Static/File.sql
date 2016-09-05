CREATE TABLE [dbo].[Files]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1,1),
	Name nvarchar(256),
	Size bigint
)
