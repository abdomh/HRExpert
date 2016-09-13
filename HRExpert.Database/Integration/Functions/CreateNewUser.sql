CREATE Procedure [dbo].[CreateNewUser]
(
	@personId int,
	@username nvarchar(256),
	@email nvarchar(256)
)
AS
BEGIN
	Declare @newUser table (Id int)
	Declare @newUserId int
	Declare @pass nvarchar(8)
	Declare @createdate bigint
	select @pass= 'C4-CA-42-38-A0-B9-23-82-0D-CC-50-9A-6F-75-84-9B';
    Set @createdate = DATEDIFF(second, '1970-01-01', GETDATE());

	INSERT INTO Users
	(Name, Created)
	output inserted.Id into @newUser
	Values
	(@username,
	@createdate)
	select @newUserId=id from @newUser
	INSERT INTO Credentials
	(CredentialTypeId,Identifier,UserId,Secret)
	Values
	(1,@email,@newUserId,@pass)
	update Persons set UserId = @newUserId where id = @personId	
END
