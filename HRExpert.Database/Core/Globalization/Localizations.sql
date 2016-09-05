CREATE TABLE [dbo].[Localizations]
(
	Id int Primary key identity(1,1),
Value nvarchar(256),
DictionaryId int,
CultureId int,
Constraint FK_Localizations_Dictionaries Foreign key (DictionaryId) References Dictionaries(Id),
Constraint FK_Localizations_Cultures Foreign key (CultureId) References Cultures(Id)
)
