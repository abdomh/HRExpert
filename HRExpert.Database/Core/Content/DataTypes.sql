CREATE TABLE [dbo].[DataTypes]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1,1),
	JavaScriptEditorClassName nvarchar(1024),
	Name nvarchar(256),
    Position int
)
