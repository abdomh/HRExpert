CREATE PROCEDURE [dbo].[SyncSicklistPaymentRestrictTypes]

AS
	INSERT INTO SicklistPaymentRestrictTypes
	(Name,Code)
	select st1c.Name,cast(st1c.id as nvarchar) from SicklistPaymentRestrictTypes_1c st1c
	left join SicklistPaymentRestrictTypes st on st.Code = cast(st1c.id as nvarchar)
	where st.Id is null
RETURN 0
