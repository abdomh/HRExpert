CREATE PROCEDURE [dbo].[spInstall]
AS
	---Добавление юзера
	INSERT INTO Users
	(Name)
	VALUES
	(N'Администратор'),
	(N'Тестировщик')
	--Добавление типов учетных данных
	INSERT INTO CredentialTypes
	(Name)
	VALUES 
	('Email'),
	('Login'),
	('Phone')
	--Добавление учетных данных
	INSERT INTO Credentials
	(CredentialTypeId,Secret,UserId,Identifier)
	Values
	(2,'1',1,'admin')
	--Роли
	INSERT INTO Roles
	(Name)
	VALUES
	(N'Администратор'),
	(N'Тестировщик')
	
	--Права доступа
	INSERT INTO Permissions
	(Name)
	VALUES
	(N'Делать всё'),
	(N'Просмотр'),
	(N'Редактирование'),
	(N'Удаление')
	
	--Права доступа по ролям
	INSERT INTO RolePermissions
	(RoleId,PermissionId)
	VALUES
	(1,1),
	(2,2)
	--Роли пользователей
	INSERT INTO RoleUsers
	(RoleId,UserId)
	VALUES
	(1,1),
	(2,2)
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
	
RETURN 0
