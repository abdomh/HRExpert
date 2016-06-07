CREATE VIEW [dbo].[vwDepartmentAccessLinks]
	AS 
	SELECT dep.*,pers.UserId as AccessUserId,acc.PersonId as AccessPersonId,acc.RoleId as AccessRoleId FROM Departments dep
		INNER JOIN GetDepartmentsAccess(null) acc on dep.Id=acc.DepartmentId
		inner JOIN Persons pers on pers.Id=acc.personId


