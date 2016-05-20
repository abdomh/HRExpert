CREATE VIEW [dbo].[vwDepartmentAccessLinks]
	AS 
	SELECT dep.*,pers.UserId as AccessUserId,acc.PersonId as AccessPersonId,acc.RoleId as AccessRoleId FROM Departments dep
		LEFT JOIN DepartmentLinks dlinks on dep.Id=dlinks.RightId
		INNER JOIN AccessLinks acc on dlinks.LeftId=acc.DepartmentId
		INNER JOIN Persons pers on acc.PersonId=pers.Id

