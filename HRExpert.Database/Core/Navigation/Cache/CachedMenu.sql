CREATE TABLE [dbo].[CachedMenus]
(
	CultureId int,
	MenuId int,
	Code nvarchar(32),
	CachedMenuItems nvarchar(max),
	Constraint FK_CachedMenu_Culture Foreign key (CultureId) References Cultures(Id),
	Constraint FK_CachedMenu_Menu Foreign Key(MenuId)References Menus(Id)
)
