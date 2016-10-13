CREATE VIEW [dbo].[vwAllDepartmentsByPersonOrganization]
	AS SELECT d.*,po.AccessPersonId, po.AccessUserId  FROM Departments d
	inner join
	(
	SELECT distinct dep.OrganizationId as OrganizationId, al.PersonId as AccessPersonId,p.UserId as AccessUserId FROM AccessLinks al
	INNER JOIN Departments dep on al.DepartmentId = dep.Id
	INNER JOIN Persons p on al.PersonId = p.Id
	) po ON d.OrganizationId=po.OrganizationId

