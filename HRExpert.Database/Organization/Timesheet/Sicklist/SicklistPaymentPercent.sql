CREATE TABLE [dbo].[SicklistPaymentPercent]
(
	[Id] int NOT NULL PRIMARY KEY identity(1,1),
	[Value] decimal(18,2) not null default(0),
	[Code] nvarchar(256),
	[Name] nvarchar(256)
)
