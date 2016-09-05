CREATE TABLE [dbo].[Cultures]
(
	Id int Primary key identity(1,1),
Name nvarchar(256) not null,
Code nvarchar(32) not null,
IsNeutral bit
)
