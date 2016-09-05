CREATE TABLE [dbo].[MenuItems]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1,1),
	MenuId int,
	MenuItemId int,
	NameId int,
	Url nvarchar(1024),
	Position int,
	Constraint FK_MenuItems_Menu Foreign Key (MenuId) References Menus(Id),
	Constraint FK_MenuItems_MenuItems Foreign Key(MenuItemId) References MenuItems(Id),
	Constraint FK_MenuItems_Name Foreign Key(NameId) References Dictionaries(Id)
)
