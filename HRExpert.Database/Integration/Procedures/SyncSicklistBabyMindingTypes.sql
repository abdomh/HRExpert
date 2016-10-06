CREATE PROCEDURE [dbo].[SyncSicklistBabyMindingTypes]
AS
	INSERT INTO SicklistBabyMindingTypes
	(Name,Code)
	select st1c.Name,cast(st1c.id as nvarchar) from SicklistBabyMindingTypes_1c st1c
	left join SicklistBabyMindingTypes st on st.Code = cast(st1c.id as nvarchar)
	where st.Id is null
RETURN 0
