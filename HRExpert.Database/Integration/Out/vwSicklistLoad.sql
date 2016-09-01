CREATE VIEW [dbo].[vwSicklistLoad]
	AS SELECT 
           s.Id,
		   doc.CreateDate,
           pe.BeginDate,
           pe.EndDate,
           s.DaysCount,
           s.PaymentBeginDate,
           s.ExperienceYears,
           s.ExperienceMonth,
           1 AS ExperienceIn1C,
           s.PaymentDecreaseDate,
           s.IsPreviousPaymentCounted,
           0 as Is2010Calculate, 
           s.IsAddToFullPayment,
           ts.StatusId,
           s.SicklistNumber,
           s.IsContinued,
           pers.Id AS UserCode,
           pers.Name AS UserName,
           st.Code AS SicklistTypeCode,
           bm.Name AS SicklistBabyMindingTypeCode, 
           pp.Value as SicklistPercent,
           pr.Code AS SicklistPaymentRestrictTypeCode
   
    FROM   
	Documents doc inner join 
	Sicklist s on doc.id = s.DocumentGuid LEFT OUTER JOIN	
	PersonEvents pe on pe.DocumentGuid=doc.id left join
    Persons pers ON doc.PersonId = pers.Id LEFT OUTER JOIN
    Persons AS creator ON Doc.CreatorId = creator.Id LEFT OUTER JOIN
    SicklistTypes st ON S.SicklistTypeId = st.Id LEFT OUTER JOIN
    SicklistBabyMindingTypes bm ON S.SicklistBabyMindingTypeId = bm.Id LEFT OUTER JOIN
    SicklistPaymentPercent pp ON S.SicklistPaymentPercentId = pp.Id LEFT OUTER JOIN
    SicklistPaymentRestrictTypes pr ON S.SicklistPaymentRestrictTypeId = pr.Id LEFT JOIN
    Timesheet ts on ts.DocumentGuid = doc.Id
    WHERE        
         doc.DocumentStatusId=2
