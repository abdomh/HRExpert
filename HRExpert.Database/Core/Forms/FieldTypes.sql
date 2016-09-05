CREATE TABLE [dbo].[FieldTypes]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1,1),
	Name nvarchar(256),
	Code nvarchar(32),
	Position int
)
