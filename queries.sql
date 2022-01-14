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