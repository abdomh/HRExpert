CREATE PROCEDURE [dbo].[SyncAll]
AS
	exec SyncPositions
	
	exec SyncDepartments
	
	exec SyncStaffEstablishedPost
	
	exec SyncPersons
RETURN 0
