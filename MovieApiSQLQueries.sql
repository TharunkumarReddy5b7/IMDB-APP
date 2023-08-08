CREATE DATABASE IMDB2;

USE IMDB2;

CREATE SCHEMA Foundation


CREATE TABLE Foundation.Actors
(
Id Int Identity(1,1) Primary Key Not Null,
Name Varchar(max) Not Null,
Gender Varchar(max) Not Null,
DOB DateTime,
Bio Varchar(max) Not Null
);

INSERT INTO Foundation.Actors (Name,Gender,DOB,Bio) VALUES('NTR','Male','28/may/1992','Great Actor');
INSERT INTO Foundation.Actors (Name,Gender,DOB,Bio) VALUES('RAM','Male','18/APR/1978','Adventure Actor');

SELECT * from Foundation.Actors;

CREATE TABLE Foundation.Producers
(
Id Int Identity(1,1) Primary Key Not Null,
Name Varchar(max) Not Null,
Gender Varchar(max) Not Null,
DOB DateTime,
Bio Varchar(max) Not Null
);

INSERT INTO Foundation.Producers (Name,Gender,DOB,Bio) VALUES('Shobu','Male','29/jan/1981','Star Producer');
INSERT INTO Foundation.Producers (Name,Gender,DOB,Bio) VALUES('Kalyan','Male','12/APR/1979','Great Producer');

SELECT * FROM Foundation.Producers;

CREATE TABLE Foundation.Movies
(
   Id int identity(1,1) Primary Key Not Null,
   Name varchar(max) Not Null,
   YearOfRelease int,
   Plot varchar(1000) Not Null,
   Poster varchar(max) Not Null,
   ProducerId int Foreign Key References Foundation.Producers(Id)
)



CREATE TABLE Foundation.Genres
(
   Id Int identity(1,1) Primary Key Not Null,
   Name Varchar(max) Not Null
);

INSERT INTO Foundation.Genres (Name) values('Comedy');
INSERT INTO Foundation.Genres (Name) values('Emotion');
INSERT INTO Foundation.Genres (Name) values('Action');


SELECT * FROM Foundation.Genres;

CREATE TABLE Foundation.Reviews
(
  
  Id Int Identity(1,1) Primary Key Not Null,
  MovieId Int Foreign Key References Foundation.Movies(Id) Not Null,
  Message Varchar(max)
);

CREATE TABLE Foundation.MovieActors
(
  MovieId Int Foreign Key References Foundation.Movies(Id) Not Null,
  ActorId Int Foreign Key References Foundation.Actors(Id) Not Null
);



CREATE TABLE Foundation.MovieGenres
(
  MovieId Int Foreign Key References Foundation.Movies(Id) Not Null,
  GenreId Int Foreign Key References Foundation.Genres(Id) Not Null
);

/* STORED PROCEDURES */

/*  SP to insert a movie */

CREATE PROCEDURE Foundation.spInsertMovie
(
@Name varchar(100),
@Year int,
@Plot varchar(max),
@Poster varchar(max),
@ProducerId int,
@ActorIds varchar(max),
@GenreIds varchar(max)
)
AS
BEGIN
  
   DECLARE @MovieId int;
   INSERT INTO Foundation.Movies (Name,YearOfRelease,Plot,Poster,ProducerId) 
   values (@Name,@Year,@Plot,@Poster,@ProducerId);
   SET @MovieId=SCOPE_IDENTITY();

   INSERT INTO Foundation.MovieActors(MovieId,ActorId)
   SELECT @MovieId, value FROM STRING_SPLIT(@ActorIds, ',');

   INSERT INTO Foundation.MovieGenres(MovieId,GenreId)
   SELECT @MovieId, value FROM STRING_SPLIT(@GenreIds, ',');
   
END



Foundation.spInsertMovie
@Name='Kick',
@Year=2017,
@Plot='story Movie',
@Poster='httpsurl',
@ProducerId=1,
@ActorIdS='1,2',
@GenreIds='2,3'

CREATE PROCEDURE Foundation.spUpdateMovie
(
@Name varchar(100),
@Year int,
@Plot varchar(max),
@Poster varchar(max),
@ProducerId int,
@ActorIds varchar(max),
@GenreIds varchar(max),
@MovieId int
)
AS
BEGIN
   
   DELETE FROM Foundation.MovieActors where MovieId=@MovieId;
   DELETE FROM Foundation.MovieGenres where MovieId=@MovieId;
   UPDATE FOUNDATION.Movies 
   SET
       Name=@Name,
	   Plot=@Plot,
	   YearOfRelease=@Year,
	   ProducerId=@ProducerId,
	   Poster=@Poster
   WHERE Id=@MovieId;

   

   INSERT INTO Foundation.MovieActors(MovieId,ActorId)
   SELECT @MovieId, value FROM STRING_SPLIT(@ActorIds, ',');

   INSERT INTO Foundation.MovieGenres(MovieId,GenreId)
   SELECT @MovieId, value FROM STRING_SPLIT(@GenreIds, ',');
   
END


