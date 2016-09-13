CREATE PROCEDURE [dbo].[SyncPositions]
AS
	INSERT INTO Positions
		(Code1C,Name,Rank)
	SELECT p1c.Id,p1c.Name, ISNULL( p1c.Rank,0)
	FROM Position_1C p1c
		left join Positions p on p1c.Id = p.Code1C
	where p.id is null

	UPDATE p
		SET p.Name = p1c.Name,
		p.Rank = ISNULL( p1c.Rank,0)
	FROM
		Positions p INNER JOIN Position_1C p1c on p.Code1C=p1c.Id
	where p.Name!=p1c.Name or p.Rank!=p1c.Rank
RETURN 0
