CREATE PROCEDURE [dbo].[SyncPersons]
AS
	INSERT INTO Persons
		(Name, PositionId, DepartmentId, PostCount, AcceptDate, DismissalDate, Email,Code1C)
	SELECT p1c.Name,p.Id,d.Id,p1c.PostCount, ISNULL(p1c.AcceptDate,GETDATE()), p1c.DismissalDate, p1c.Email, p1c.Id  FROM Persons_1C p1c
		INNER JOIN Departments d on p1c.Department=d.Code1C
		INNER JOIN Positions p on p1c.Position=p.Code1C
		LEFT JOIN Persons pers on p1c.Id = pers.Code1C
	where pers.Id is null

	UPDATE pers
	SET 
		pers.Name = p1c.Name,
		pers.DepartmentId = d.Id,
		pers.PositionId = p.Id,
		pers.Email = p1c.Email,
		pers.AcceptDate = ISNULL(p1c.AcceptDate,GETDATE()),
		pers.DismissalDate = p1c.DismissalDate,
		pers.PostCount = p1c.PostCount
	FROM Persons_1C p1c
		INNER JOIN Departments d on p1c.Department=d.Code1C
		INNER JOIN Positions p on p1c.Position=p.Code1C
		INNER JOIN Persons pers on p1c.Id = pers.Code1C
	
	DELETE FROM [Credentials]
	WHERE UserId in (SELECT UserId FROM Persons where DismissalDate is not null)

	declare @personName nvarchar(256), @personEmail nvarchar(256), @personId int, @personUserId int;

	DECLARE personcursor CURSOR FOR 
		SELECT  Id,Name,Email
		FROM Persons
		WHERE UserId is null and Email is not null and LEN(LTRIM(RTRIM(Email)))>0 and DismissalDate is null
	open personcursor
	fetch next from personcursor into @personId, @personName, @personEmail
	WHILE @@FETCH_STATUS = 0  
	begin
	 exec CreateNewUser	  @personId,@personName,@personEmail
	fetch next from personcursor into @personId, @personName, @personEmail
	end
	close personcursor
	deallocate personcursor
	
	
	INSERT INTO UserRoles
	(UserId,RoleId)
	SELECT u.Id,r.Id FROM Users u
	INNER JOIN Persons p on u.id=p.UserId
	INNER JOIN Positions pos on p.PositionId = pos.Id
	INNER JOIN Roles r on r.Code = 'Manager' and pos.Rank=1
	LEFT JOIN UserRoles ur on u.Id = ur.UserId and ur.RoleId = r.Id
    where ur.UserId is null

	INSERT INTO UserRoles
	(UserId,RoleId)
	SELECT u.Id,r.Id FROM Users u
	INNER JOIN Persons p on u.id=p.UserId
	INNER JOIN Positions pos on p.PositionId = pos.Id
	INNER JOIN Roles r on r.Code = 'SubManager' and pos.Rank=2
	LEFT JOIN UserRoles ur on u.Id = ur.UserId and ur.RoleId = r.Id
    where ur.UserId is null

	INSERT INTO UserRoles
	(UserId,RoleId)
	SELECT u.Id,r.Id FROM Users u
	INNER JOIN Roles r on r.Code = 'Employee'
	LEFT JOIN UserRoles ur on u.Id = ur.UserId and ur.RoleId = r.Id
    where ur.UserId is null

	DELETE FROM UserRoles 
	where RoleId = (SELECT top 1 Id from Roles where Code = 'Manager') 
		and not exists 
		(Select * From Users u 				
				inner join Persons p on p.UserId=u.Id
				inner join Positions pos on p.PositionId = pos.Id
				where pos.Rank=1 and u.Id = UserId)
	
	DELETE FROM UserRoles 
	where RoleId = (SELECT top 1 Id from Roles where Code = 'SubManager') 
		and not exists 
		(Select * From Users u 				
				inner join Persons p on p.UserId=u.Id
				inner join Positions pos on p.PositionId = pos.Id
				where pos.Rank=2 and u.Id = UserId)
	DELETE FROM AccessLinks where IsManual=0

	INSERT INTO AccessLinks
	(DepartmentId,PersonId,RoleId)
	SELECT pers.DepartmentId,pers.Id, r.Id FROM Persons pers
	INNER JOIN Users u on pers.UserId = u.Id
	INNER JOIN UserRoles ur on u.Id=ur.UserId
	INNER JOIN Roles r on ur.RoleId =r.Id and (r.Code = 'Manager')

	INSERT INTO AccessLinks
	(DepartmentId,PersonId,RoleId)
	SELECT pers.DepartmentId,pers.Id, r.Id FROM Persons pers
	INNER JOIN Users u on pers.UserId = u.Id
	INNER JOIN UserRoles ur on u.Id=ur.UserId
	INNER JOIN Roles r on ur.RoleId =r.Id and (r.Code = 'SubManager')
	INSERT INTO AccessLinks
	(DepartmentId,TargetPersonId,PersonId,RoleId)
	SELECT pers.DepartmentId, pers.Id,pers.Id, r.Id FROM Persons pers
	INNER JOIN Users u on pers.UserId = u.Id
	INNER JOIN UserRoles ur on u.Id=ur.UserId
	INNER JOIN Roles r on ur.RoleId =r.Id and (r.Code = 'Employee')

RETURN 0
