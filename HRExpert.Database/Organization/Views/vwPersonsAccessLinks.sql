CREATE VIEW [dbo].[vwPersonsAccessLinks]
	AS SELECT pers.*,da.AccessUserId,da.AccessPersonId,da.AccessRoleId FROM Persons pers
	inner join vwDepartmentAccessLinks da on pers.DepartmentId=da.Id
