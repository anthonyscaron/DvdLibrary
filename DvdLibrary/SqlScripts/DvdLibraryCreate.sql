USE master
GO

IF EXISTS(SELECT * FROM sys.databases WHERE NAME='DVDLibrary')
DROP DATABASE DVDLibrary
GO

CREATE DATABASE DVDLibrary
GO

USE DVDLibrary
GO

IF EXISTS(SELECT * FROM sys.tables WHERE Name='Dvds')
	DROP TABLE Dvds
GO

CREATE TABLE Dvds (
	DvdId int identity(1,1) primary key not null,
	Rating varchar(5) not null,
	Title varchar(50) not null,
	ReleaseYear int not null,
	Director varchar(50) not null,
	Notes varchar(500) null
)
GO