CREATE TABLE [dbo].[SicklistPaymentRestrictTypes]
(
	[Id] bigint NOT NULL PRIMARY KEY identity(1,1),
	[Name] nvarchar(256) not null,
	[Value] decimal(18,2)
)
