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
	(CredentialTypeId,Secret,UserId,Value)
	Values
	(1,'1',1,'baranov@ruscount.ru'),
	(2,'1',1,'admin'),
	(1,'1',2,'info@ruscount.ru'),
	(2,'1',2,'tester')
	--Роли
	INSERT INTO Roles
	(Name)
	VALUES
	(N'Администратор'),
	(N'Тестировщик')
	--Модули
	INSERT INTO Sections
	(Name)
	Values
	(N'Администрирование'),
	(N'Базовые права')
	--Права доступа
	INSERT INTO PermissionTypes
	(Name, SectionId)
	VALUES
	(N'Делать всё',1),
	(N'Просмотр',2),
	(N'Редактирование',2),
	(N'Удаление',2)
	
	--Права доступа по ролям
	INSERT INTO RolePermissionTypes
	(RoleId,PermissionTypeId)
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
	--Типы сущностей
	INSERT INTO EntityTypes
	(Name)
	VALUES
	(N'Организация'),
	(N'Подразделение'),
	(N'Сотрудник'),
	(N'Штатная единица'),
	(N'Документ')
	--Статусы
	INSERT INTO Statuses
	(Name)
	Values
	(N'Черновик'),
	(N'Завершено'),
	(N'Отменено')
	--Типы документов
	INSERT INTO DocumentTypes
	(Name)
	VALUES
	(N'Командировка'),
	(N'Авансовый отчёт'),
	(N'Удержание'),
	(N'Больничный'),
	(N'Отпуск'),
	(N'Отпуск по уходу за ребенком')
RETURN 0
