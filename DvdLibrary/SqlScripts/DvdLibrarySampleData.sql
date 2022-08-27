USE DVDLibrary
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ResetDvdSampleData')
DROP PROCEDURE ResetDvdSampleData
GO

CREATE PROCEDURE ResetDvdSampleData AS
BEGIN
	DELETE FROM Dvds;

	DBCC CHECKIDENT ('Dvds', RESEED, 1)

	SET IDENTITY_INSERT Dvds ON;

	INSERT INTO Dvds (DvdId, Title, ReleaseYear, Director, Rating, Notes)
	VALUES (1, 'The Land Before Time', 1988, 'Don Bluth', 'G', 'During the age of the dinosaurs, a massive famine forces several herds of dinosaurs to seek an oasis known as the Great Valley.'),
	(2, 'Hook', 1991, 'Steven Spielberg', 'PG', 'When Captain James Hook kidnaps his children, an adult Peter Pan must return to Neverland and reclaim his youthful spirit in order to challenge his old enemy.'),
	(3, 'Happy Gilmore', 1996, 'Dennis Dugan', 'PG-13', 'A rejected hockey player puts his skills to the golf course to save his grandmothers house.'),
	(4, 'Donnie Darko', 2001, 'Richard Kelly', 'R', 'After narrowly escaping a bizarre accident, a troubled teenager is plagued by visions of a man in a large rabbit suit who manipulates him to commit a series of crimes.')

	SET IDENTITY_INSERT Dvds OFF;
END