CREATE VIEW [dbo].[vwOrganizationAccessLinks]
	AS SELECT DISTINCT org.*, da.AccessUserId, da.AccessPersonId, da.AccessRoleId FROM vwDepartmentAccessLinks da
	INNER JOIN Organizations org on org.Id=da.OrganizationId