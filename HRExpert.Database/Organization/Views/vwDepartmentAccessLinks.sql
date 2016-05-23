CREATE VIEW [dbo].[vwDepartmentAccessLinks]
	AS 
	SELECT dep.*,pers.UserId as AccessUserId,acc.personId as AccessPersonId,acc.RoleId as AccessRoleId FROM Departments dep
		INNER JOIN GetDepartmentsAccess(null) acc on dep.Id=acc.departmentId
		inner JOIN Persons pers on pers.Id=acc.personId


