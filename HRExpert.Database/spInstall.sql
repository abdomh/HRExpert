CREATE PROCEDURE [dbo].[spInstall]
AS
	---Добавление юзера
	INSERT INTO Users
	(Name,Created)
	VALUES
	(N'Администратор', DATEDIFF(second, '1970-01-01', GETDATE())),
	(N'Тестировщик',DATEDIFF(second, '1970-01-01', GETDATE()))
	--Добавление типов учетных данных
	INSERT INTO CredentialTypes
	(Name,Code)
	VALUES 
	('Email','Email')
	--Добавление учетных данных
	INSERT INTO Credentials
	(CredentialTypeId,Secret,UserId,Identifier)
	Values
	(1,'C4-CA-42-38-A0-B9-23-82-0D-CC-50-9A-6F-75-84-9B',1,'admin')
	--Роли
	INSERT INTO Roles
	(Name,Code)
	VALUES
	(N'Administrator',N'Administrator')
	
	--Права доступа
	INSERT INTO Permissions
	(Name,Code)
	VALUES
	(N'Делать всё','1'),
	(N'Просмотр','2'),
	(N'Редактирование','3'),
	(N'Удаление','4')
	
	--Права доступа по ролям
	INSERT INTO RolePermissions
	(RoleId,PermissionId)
	VALUES
	(1,1),
	(2,2)
	--Роли пользователей
	INSERT INTO UserRoles
	(RoleId,UserId)
	VALUES
	(1,1)
	--Организации
	INSERT INTO Organizations
	(Name)
	VALUES
	(N'Экспресс Волга'),
	(N'Совкомбанк'),
	(N'Русконсалт')
	
	--Статусы
	INSERT INTO Statuses
	(Name)
	Values
	(N'Черновик'),
	(N'Документ оформлен'),
	(N'Выгружен в 1С'),
	(N'Отменено')
	Insert into Dictionaries
	(Id)
	Values(1)
	INSERT INTO Cultures
	(Code,Name)
	Values
	('en','English')
	

RETURN 0
