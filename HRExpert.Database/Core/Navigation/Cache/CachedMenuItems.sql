CREATE TABLE [dbo].[CachedMenuItems]
(
	MenuItemId int,
	Name nvarchar(256),
	Url nvarchar(1024),
	Position int,
	CachedMenuItems nvarchar(max),
	Constraint FK_CachedMenuItems_MenuItem Foreign key(MenuItemId) References MenuItems(Id)
)
