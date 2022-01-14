-- 1st) Createdb RecordDatabase
-- 2nd) pgcli RecordDatabase
-- 3rd) Create Table > Albums (Include BandId (foreign) column)
-- 5th) Create Table > Bands
-- 4th) Create Table > Songs (Include BandId (foreign) column)

-- Albums Table
Create Table "Albums" (
"Id" SERIAL PRIMARY KEY,
"Title" TEXT,
"IsExplicit" BOOLEAN,
"ReleaseDate" DATE
);

-- alter Albums table to ADD BandId column
alter table "Albums" 
add column "BandId" 
Int Null References "Bands" ("Id");

-- Bands Table
Create Table "Bands" (
"Id" SERIAL PRIMARY KEY,
"Name" TEXT,
"CountryOfOrigin" TEXT,
"NumberOfMembers" INTEGER,
"Website" TEXT,
"Style" TEXT,
"IsSigned" BOOLEAN,
"ContactName" TEXT,
"ContactPhoneNumber" TEXT);


-- Songs Table
Create Table "Songs" (
"Id" SERIAL PRIMARY KEY,
"TrackNumber" Int,
"Title" TEXT,
"Duration" TEXT
);

-- alter Songs table to ADD AlbumID column
alter table "Songs" 
add column "AlbumId" 
Int Null References "Albums" ("Id");

-- Add a new band  
Insert Into "Bands" ("Name", "CountryOfOrigin", "NumberOfMembers", "Website", "Style", "IsSigned","ContactName", "ContactPhoneNumber")
Values ('The Beatles', 'England', 4, 'wwww.thebeatles.com', 'rock', 'true', 'Brian Epstein', '727-413-6789');



-- View all the bands
Select * From "Bands";

-- Add an album for a band
Insert Into "Albums" ("Title", "IsExplicit", "ReleaseDate")
Values ('Sgt Peppers Lonely Hearts Club Band', 'false', '1967-05-26');

-- Add a song to an album
Insert Into "Songs" ("TrackNumber", "Title", "duration")
Values (4,'Lucy In The Sky With Diamonds', '4:00');

-- Add extra bands, albums, songs, for examples
Insert Into "Bands" ("Name", "CountryOfOrigin", "NumberOfMembers", "Website", "Style", "IsSigned","ContactName", "ContactPhoneNumber")
Values ('Dave Matthews Band', 'US', 8, 'wwww.dmb.com', 'rock', 'true', 'John Walsh', '417-687-1372');
Insert Into "Bands" ("Name", "CountryOfOrigin", "NumberOfMembers", "Website", "Style", "IsSigned","ContactName", "ContactPhoneNumber")
Values ('The Rolling Stones', 'England', 5, 'wwww.therollingstones.com', 'rock', 'true', 'Davic Chatham', '317-456-6879');
Insert Into "Bands" ("Name", "CountryOfOrigin", "NumberOfMembers", "Website", "Style", "IsSigned","ContactName", "ContactPhoneNumber")
Values ('The Doors', 'US', 4, 'wwww.thebeatles.com', 'rock', 'true', 'James McDonald', '287-698-5786');
Insert Into "Bands" ("Name", "CountryOfOrigin", "NumberOfMembers", "Website", "Style", "IsSigned","ContactName", "ContactPhoneNumber")
Values ('Led Zeppelin', 'England', 4, 'wwww.LedZeppelin.com', 'rock', 'true', 'Bryan Cruze', '312-687-2342');
Insert Into "Bands" ("Name", "CountryOfOrigin", "NumberOfMembers", "Website", "Style", "IsSigned","ContactName", "ContactPhoneNumber")
Values ('Cream', 'England', 4, 'wwww.cream.com', 'rock', 'true', 'Donald Irving', '476-243-6978');

Insert Into "Songs" ("TrackNumber", "Title", "duration")
Values (3,'Crash Into Me', '5:28');
Insert Into "Songs" ("TrackNumber", "Title", "duration")
Values (5,'Beast of Burden', '3:38');
Insert Into "Songs" ("TrackNumber", "Title", "duration")
Values (7,'Light My Fire', '3:12');
Insert Into "Songs" ("TrackNumber", "Title", "duration")
Values (1,'Babe Im Gonna Leave You', '5:58');
Insert Into "Songs" ("TrackNumber", "Title", "duration")
Values (4,'Sunshine Of My Love', '3:33');

Insert Into "Albums" ("Title", "IsExplicit", "ReleaseDate")
Values ('Crash', 'false', '1996-08-13');
Insert Into "Albums" ("Title", "IsExplicit", "ReleaseDate")
Values ('Aftermath', 'false', '1968-08-14');
Insert Into "Albums" ("Title", "IsExplicit", "ReleaseDate")
Values ('Close The Door', 'true', '1969-02-12');
Insert Into "Albums" ("Title", "IsExplicit", "ReleaseDate")
Values ('Grafitti', 'false', '1969-04-09');
Insert Into "Albums" ("Title", "IsExplicit", "ReleaseDate")
Values ('Creamy', 'false', '1966-05-26');



UPDATE "Albums" SET "BandId" = 1 WHERE "Id" IN (1);
UPDATE "Albums" SET "BandId" = 2 WHERE "Id" IN (2);
UPDATE "Albums" SET "BandId" = 3 WHERE "Id" IN (3);
UPDATE "Albums" SET "BandId" = 4 WHERE "Id" IN (4);
UPDATE "Albums" SET "BandId" = 5 WHERE "Id" IN (5);
UPDATE "Albums" SET "BandId" = 6 WHERE "Id" IN (6);

UPDATE "Songs" SET "AlbumId" = 2 WHERE "Id" IN (2);
UPDATE "Songs" SET "AlbumId" = 3 WHERE "Id" IN (3);
UPDATE "Songs" SET "AlbumId" = 4 WHERE "Id" IN (4);
UPDATE "Songs" SET "AlbumId" = 5 WHERE "Id" IN (5);
UPDATE "Songs" SET "AlbumId" = 6 WHERE "Id" IN (6);
-- Isn't allowing update to this last Song
-- insert or update on table "Songs" violates foreign key constraint "Songs_AlbumId_fkey"
UPDATE "Songs" SET "AlbumId" = 7 WHERE "Id" IN (7);

-- Let a band go (update isSigned to false)
-- Resign a band (update isSigned to true)
-- Prompt for a band name and view all their albums
-- View all albums ordered by ReleaseDate
-- View all bands that are signed
-- View all bands that are not signed
-- Quit the program

    -- * Album
    --     * Id
    --     * Title
    --     * IsExplicit
    --     * ReleaseDate
    -- * Band
    --     * Id
    --     * Name
    --     * CountryOfOrigin
    --     * NumberOfMembers
    --     * Website
    --     * Style
    --     * IsSigned
    --     * ContactName
    --     * ContactPhoneNumber
    -- * Song
    --     * Id
    --     * Track Number
    --     * Title
    --     * Duration



        -- INSERT INTO "Bands" ("Name", "CountryOfOrigin", "NumberOfMembers", "Website", "Style", "IsSigned", "ContactName", "ContactPhoneNumber") VALUES ('Elton John', 'United States', 1, 'eltonjohn.com', 'Rock', Yes, 'Ricky Martin', 800-321-9000);