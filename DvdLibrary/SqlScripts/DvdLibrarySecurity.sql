USE master
GO

IF EXISTS(SELECT * FROM master.sys.server_principals
	WHERE name = 'DvdLibraryApp')
DROP LOGIN DvdLibraryApp
GO

CREATE LOGIN DvdLibraryApp WITH PASSWORD='testing123'
GO

USE DVDLibrary
GO

IF EXISTS(SELECT * FROM sys.database_principals
	WHERE name = 'DvdLibraryAppUser')
DROP USER DvdLibraryAppUser
GO

CREATE USER DvdLibraryAppUser FOR LOGIN DvdLibraryApp
GO

GRANT EXECUTE ON CreateDvd TO DvdLibraryAppUser
GRANT EXECUTE ON DeleteDvd TO DvdLibraryAppUser
GRANT EXECUTE ON UpdateDvd TO DvdLibraryAppUser
GRANT EXECUTE ON GetAllDvds TO DvdLibraryAppUser
GRANT EXECUTE ON GetDvdById TO DvdLibraryAppUser
GRANT EXECUTE ON GetDvdsByTitle TO DvdLibraryAppUser
GRANT EXECUTE ON GetDvdsByReleaseYear TO DvdLibraryAppUser
GRANT EXECUTE ON GetDvdsByDirector TO DvdLibraryAppUser
GRANT EXECUTE ON GetDvdsByRating TO DvdLibraryAppUser
GRANT EXECUTE ON ResetDvdSampleData TO DvdLibraryAppUser
GO

GRANT SELECT ON Dvds to DvdLibraryAppUser
GRANT INSERT ON Dvds to DvdLibraryAppUser
GRANT UPDATE ON Dvds to DvdLibraryAppUser
GRANT DELETE ON Dvds to DvdLibraryAppUser
GO