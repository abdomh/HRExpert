CREATE VIEW [dbo].[vwStaffEstablishedPostWithAccessLinks]
	AS 
	SELECT sep.*,da.AccessUserId, da.AccessPersonId, da.AccessRoleId FROM StaffEstablishedPosts sep
		INNER JOIN vwDepartmentAccessLinks da ON sep.DepartmentId=da.Id