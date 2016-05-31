CREATE VIEW [dbo].[vwDocumentAccessLinks]
	AS SELECT doc.*, ac.AccessUserId, ac.AccessPersonId, ac.AccessRoleId FROM Documents doc
	 inner join vwPersonsAccessLinks ac on doc.PersonId=ac.Id