CREATE TABLE [dbo].[SicklistPaymentRestrictTypes]
(
	[Id] bigint NOT NULL PRIMARY KEY identity(1,1),
	[Name] nvarchar(256) not null,
	[Code] nvarchar(32),
	[Value] decimal(18,2)
)
