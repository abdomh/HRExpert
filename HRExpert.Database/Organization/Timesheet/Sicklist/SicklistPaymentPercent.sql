CREATE TABLE [dbo].[SicklistPaymentPercent]
(
	[Id] bigint NOT NULL PRIMARY KEY identity(1,1),
	[Value] decimal(18,2) not null default(0)
)
