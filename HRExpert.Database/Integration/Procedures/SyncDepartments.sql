CREATE PROCEDURE [dbo].[SyncDepartments]

AS
	INSERT INTO Departments
		(Name,OrganizationId,Code1C)
	SELECT d1c.Name,1,d1c.Id FROM Department_1C d1c
		LEFT JOIN Departments d on d1c.Id = d.Code1C
    where d.Id is null

	UPDATE d
		set Name = d1c.Name,
		ParentId = parent.Id
	FROM Department_1C d1c
		INNER JOIN Departments d on d1c.Id = d.Code1C
		LEFT JOIN Departments parent on d1c.Parent = parent.Code1C

RETURN 0
