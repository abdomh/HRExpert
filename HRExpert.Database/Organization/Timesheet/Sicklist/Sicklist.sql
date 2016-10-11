﻿CREATE TABLE [dbo].[Sicklist]
(
	[Id] int not null primary key identity(1,1),
	[DocumentGuid] uniqueidentifier not null,	
	[SicklistTypeId] int not null,
	[SicklistPaymentRestrictTypeId] int,
	[SicklistPaymentPercentId] int,
	[SicklistBabyMindingTypeId] int,
	[SicklistNumber] nvarchar(256),
	[PaymentBeginDate] DateTime,
	[PaymentDecreaseDate] DateTime,
	[isPreviousPaymentCounted] bit not null default(0),
	[isAddToFullPayment] bit not null default(0),
	[isUseBefore] bit not null default(0),
	[ExperienceYears] int,
	[ExperienceMonth] int,
	[StatusId] int,
	[IsContinued] bit not null default(0),
	[DaysCount] int not null default(0),
	Constraint FK_Sicklist_Type Foreign key (SicklistTypeId) References SicklistTypes(Id),
	Constraint FK_Sicklist_PaymentRestrictType Foreign key (SicklistPaymentRestrictTypeId) References SicklistPaymentRestrictTypes(Id),
	Constraint FK_Sicklist_PaymentPercent Foreign key (SicklistPaymentPercentId) References SicklistPaymentPercent(Id),
	Constraint FK_Sicklist_BabyMindingType Foreign key (SicklistBabyMindingTypeId) References SicklistBabyMindingTypes(Id),
	Constraint FK_Sicklist_Documents Foreign key (DocumentGuid) References Documents(Id)
)
