CREATE FUNCTION [dbo].[GetDepartmentsAccess]
(
	@personId int
)
RETURNS @returntable TABLE
(
	PersonId int,
    DepartmentId int,
	RoleId int
)
AS
BEGIN
	DECLARE @persid int, @roleid int,@departmentid int
	DECLARE access_cursor CURSOR FOR
	SELECT acc.PersonId, acc.DepartmentId, acc.RoleId FROM AccessLinks acc
	WHERE @personId is null or acc.PersonId=@personId

	OPEN access_cursor;

	-- Perform the first fetch.
	FETCH NEXT FROM access_cursor INTO @persid,@departmentid,@roleid;

	-- Check @@FETCH_STATUS to see if there are any more rows to fetch.
	WHILE @@FETCH_STATUS = 0
	BEGIN
		insert @returntable
		SELECT @persid,childs.Id,@roleid FROM GetDepartmentChilds(@departmentid) childs
		union SELECT @persid, @departmentid,@roleid
	   -- This is executed as long as the previous fetch succeeds.
	   FETCH NEXT FROM access_cursor INTO @persid,@departmentid,@roleid;
	END

	CLOSE access_cursor;
	DEALLOCATE access_cursor;	

	RETURN
END
