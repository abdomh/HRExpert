CREATE FUNCTION [dbo].[GetDepartmentChilds]
(
	@departmentid bigint
)
RETURNS @returntable TABLE
(
	Id bigint,
	Name nvarchar(256),
	Distance int
)
AS
BEGIN
	with tree (nm, id, level)
		as (	select top 1 Name, Id,0
				from Departments
				where ParentId = @departmentid
			union all
				select Name, Departments.Id, tree.level+1
				from Departments
				inner join tree on tree.id = Departments.ParentId 
		)
	INSERT @returntable
	select id, nm ,level
	from tree 

	RETURN
END
