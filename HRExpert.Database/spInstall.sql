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
	(N'Администратор',N'Administrator'),
	(N'Руководитель',N'Manager'),
	(N'Зам.Руководителя',N'SubManager'),
	(N'Сотрудник',N'Employee'),
	(N'Кадровик',N'PersonnelManager')
	
	--Права доступа
	INSERT INTO Permissions
	(Name,Code)
	Values
	(N'Редактирование заявки на этапе сотрудника',N'Request.Edit.Employee'),
	(N'Редактирование заявки на этапе руководителя',N'Request.Edit.Manager'),
	(N'Редактирование заявки на этапе кадровика',N'Request.Edit.PersonnelManager')

	INSERT INTO RolePermissions
	(RoleId,PermissionId)
	SELECT r.Id,p.Id FROM Roles r
	inner join Permissions p on p.Code like  '%.'+r.Code+'%'

	
	--Роли пользователей
	INSERT INTO UserRoles
	(RoleId,UserId)
	VALUES
	(1,1)
	
	Insert into Dictionaries
	(Id)
	Values(1)
	INSERT INTO Cultures
	(Code,Name)
	Values
	('en','English')
	
	--END OF CORE
	--ORGANIZATION BEGIN
	--Организации
	INSERT INTO Organizations
	(Name)
	VALUES
	(N'Экспресс Волга'),
	(N'Совкомбанк'),
	(N'Русконсалт')
	
	--Статусы
	INSERT INTO Statuses
	(Name, Code)
	Values
	(N'Черновик',N'Temp'),
	(N'Документ оформлен',N'Ready'),
	(N'Выгружен в 1С',N'Uploaded'),
	(N'Отменено',N'Cancelled')

	INSERT INTO DocumentTypes
	(Name,Code)
	Values
	(N'Больничный лист',N'Sicklist'),
	(N'Отпуск',N'Vacation'),
	(N'Неявка',N'Absence')

	INSERT INTO TimesheetStatuses
	(Name,ShortName)
	Values
	(N'Я',N'Явка'),
	(N'Б',N'Временная нетрудоспособность с назначением пособия согласно законодательству'),
	(N'Т',N'Временная нетрудоспособность без назнач. пособия в случаях, предусм. законодательством'),
	(N'ВЧ',N'Вечерние часы'),
	(N'Н',N'Ночные часы'),
	(N'В',N'Выходные и нерабочие дни'),
	(N'К',N'Командировка'),
	(N'ОТ',N'Отпуск'),
	(N'ОЗ',N'Отпуск без сохранения заработной платы в случаях, предусмотренных законодательством'),
	(N'ДО',N'Отпуск без сохранения заработной платы, предоставляемый сотр. по разреш. работодателя'),
	(N'Р',N'Отпуск по беременности и родам (отпуск в связи с усыновлением новорожд. ребенка)'),
	(N'ОЖ',N'Отпуск по уходу за ребенком до достижения им возраста трех лет'),
	(N'РВ',N'Продолжительность работы в выходные и нерабочие, праздничные дни'),
	(N'С',N'Продолжительность сверхурочной работы'),
	(N'ПР',N'Прогулы (отсутствие на рабочем месте без уваж. причин в теч. времени, уст. законодательством)'),
	(N'НН',N'Неявки по невыясненным причинам'),
	(N'ВП',N'Простои по вине сотрудника'),
	(N'РП',N'Время простоя по вине работодателя')

	INSERT INTO SicklistPaymentPercent
	(Name,Value)
	Values
	('60',60),
	('80',80),
	('100',100)

RETURN 0
