CREATE VIEW [dbo].[vwDocumentAccess]
	AS SELECT doc.Id as DocumentGuid, ac.AccessUserId, ac.AccessPersonId, ac.AccessRoleId FROM Documents doc
	 inner join vwPersonsAccessLinks ac on doc.PersonId=ac.Id