USE DVDLibrary
GO

/* GetAllDvds */
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetAllDvds')
	DROP PROCEDURE GetAllDvds
GO

CREATE PROCEDURE GetAllDvds AS
BEGIN
	SELECT DvdId, Title, ReleaseYear, Director, Rating, Notes
	FROM Dvds d
END
GO

/* GetDvdById */
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetDvdById')
	DROP PROCEDURE GetDvdById
GO

CREATE PROCEDURE GetDvdById (
	@DvdId int
)
AS
BEGIN
	SELECT DvdId, Title, ReleaseYear, Director, Rating, Notes
	FROM Dvds d
	WHERE DvdId = @DvdId
END
GO

/* GetDvdByTitle */
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetDvdsByTitle')
	DROP PROCEDURE GetDvdsByTitle
GO

CREATE PROCEDURE GetDvdsByTitle (
	@Title varchar(50)
)
AS
BEGIN
	SELECT DvdId, Title, ReleaseYear, Director, Rating, Notes
	FROM Dvds d
	WHERE Title LIKE @Title + '%'
	ORDER BY Title DESC
END
GO

/* GetDvdByReleaseYear */
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetDvdsByReleaseYear')
	DROP PROCEDURE GetDvdsByReleaseYear
GO

CREATE PROCEDURE GetDvdsByReleaseYear (
	@ReleaseYear int
)
AS
BEGIN
	SELECT DvdId, Title, ReleaseYear, Director, Rating, Notes
	FROM Dvds d
	WHERE CAST(ReleaseYear AS varchar(5)) LIKE CAST(@ReleaseYear AS varchar(5)) + '%'
	ORDER BY ReleaseYear, Title
END
GO

/* GetDvdByDirector */
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetDvdsByDirector')
	DROP PROCEDURE GetDvdsByDirector
GO

CREATE PROCEDURE GetDvdsByDirector (
	@Director varchar(50)
)
AS
BEGIN
	SELECT DvdId, Title, ReleaseYear, Director, Rating, Notes
	FROM Dvds d
	WHERE Director LIKE @Director + '%'
	ORDER BY Director, Title
END
GO

/* GetDvdByRating */
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetDvdsByRating')
	DROP PROCEDURE GetDvdsByRating
GO

CREATE PROCEDURE GetDvdsByRating (
	@Rating varchar(5)
)
AS
BEGIN
	SELECT DvdId, Title, ReleaseYear, Director, Rating, Notes
	FROM Dvds d
	WHERE Rating LIKE @Rating + '%'
	ORDER BY Rating, Title
END
GO

/* CreateDvd */
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CreateDvd')
	DROP PROCEDURE CreateDvd
GO

CREATE PROCEDURE CreateDvd (
	@DvdId int output,
	@Rating varchar(5),
	@Title varchar(50),
	@ReleaseYear int,
	@Director varchar(50),
	@Notes varchar(500)
) AS
BEGIN
	INSERT INTO Dvds (Title, ReleaseYear, Director, Rating, Notes)
	VALUES (@Title, @ReleaseYear, @Director, @Rating, @Notes)

	SET @DvdId = SCOPE_IDENTITY();
END
GO

/* UpdateDvd */
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'UpdateDvd')
	DROP PROCEDURE UpdateDvd
GO

CREATE PROCEDURE UpdateDvd (
	@DvdId int,
	@Rating varchar(5),
	@Title varchar(50),
	@ReleaseYear int,
	@Director varchar(50),
	@Notes varchar(500)
) AS
BEGIN
	UPDATE Dvds SET
		Rating = @Rating,
		Title = @Title,
		ReleaseYear = @ReleaseYear,
		Director = @Director,
		Notes = @Notes
	WHERE DvdId = @DvdId
END
GO

/* DeleteDvd */
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DeleteDvd')
	DROP PROCEDURE DeleteDvd
GO

CREATE PROCEDURE DeleteDvd (
	@DvdId int
) AS
BEGIN
	BEGIN TRANSACTION

	DELETE FROM Dvds WHERE DvdId = @DvdId

	COMMIT TRANSACTION
END
GO