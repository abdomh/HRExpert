CREATE VIEW [dbo].[vwPersonsAccessLinks]
	AS
		SELECT pers.*,da.AccessUserId,da.AccessPersonId,da.AccessRoleId FROM Persons pers
		inner join vwDepartmentAccessLinks da on pers.DepartmentId=da.Id
		UNION
		SELECT pers.*, accpers.UserId as AccessUserId, accpers.Id as AccessPersonId, acc.RoleId as AccessRoleId FROM Persons pers
		inner join AccessLinks acc on pers.Id = acc.TargetPersonId
		inner join Persons accpers on acc.PersonId=accpers.Id
