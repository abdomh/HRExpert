CREATE PROCEDURE [dbo].[SyncStaffEstablishedPost]
AS
	INSERT INTO StaffEstablishedPosts
		(DepartmentId,PositionId,PostCount)
	SELECT d.Id,p.Id,sep1c.PostCount FROM StaffEstablishedPost_1C sep1c
		INNER JOIN Departments d on sep1c.Department=d.Code1C
		INNER JOIN Positions p on sep1c.Position=p.Code1C
		LEFT JOIN StaffEstablishedPosts sep on sep.DepartmentId=d.Id and sep.PositionId=p.Id
	where sep.DepartmentId is null
	
	INSERT INTO StaffEstablishedPosts
		(DepartmentId,PositionId,PostCount)
	SELECT d.Id,p.Id,0 FROM Persons_1C p1c
		INNER JOIN Departments d on p1c.Department=d.Code1C
		INNER JOIN Positions p on p1c.Position=p.Code1C
		LEFT JOIN StaffEstablishedPosts sep on sep.DepartmentId=d.Id and sep.PositionId=p.Id
	where sep.DepartmentId is null
		GROUP BY d.Id,p.Id

	UPDATE sep
	SET 
		sep.PostCount= sep1c.PostCount
	FROM StaffEstablishedPost_1C sep1c
		INNER JOIN Departments d on sep1c.Department=d.Code1C
		INNER JOIN Positions p on sep1c.Position=p.Code1C
		INNER JOIN StaffEstablishedPosts sep on sep.DepartmentId=d.Id and sep.PositionId=p.Id
	where sep.PostCount!= sep1c.PostCount
RETURN 0
