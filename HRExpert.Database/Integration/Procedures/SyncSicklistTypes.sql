CREATE PROCEDURE [dbo].[SyncSicklistTypes]
AS
	INSERT INTO SicklistTypes
	(Name,Code)
	select st1c.Name,cast(st1c.id as nvarchar) from SicklistTypes_1c st1c
	left join SicklistTypes st on st.Code = cast(st1c.id as nvarchar)
	where st.Id is null
RETURN 0
