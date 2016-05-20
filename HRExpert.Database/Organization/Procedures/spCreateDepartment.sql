CREATE PROCEDURE [dbo].[spCreateDepartment]
	@Name nvarchar(256),
	@Organization bigint,
	@Code1C uniqueidentifier,
	@Parent uniqueidentifier
AS
	Declare @ParentId bigint, @CurrentId bigint

	SELECT @CurrentId = Id FROM Departments WHERE Code1C=@Code1C;
	SELECT @ParentId = Id FROM Departments WHERE Code1C=@Parent;
	IF @CurrentId is null
	begin
		INSERT INTO Departments
		(Name,OrganizationId,Code1C)
		VALUES
		(@Name,@Organization,@Code1C)
		SELECT @CurrentId = Id FROM Departments WHERE Code1C=@Code1C;
	end
	INSERT INTO DepartmentLinks
	(LeftId,RightId,Distance)
	SELECT dl.LeftId,@CurrentId,dl.Distance+1 FROM DepartmentLinks dl
	WHERE dl.RightId=@ParentId
	UNION
	SELECT @CurrentId,@CurrentId,0