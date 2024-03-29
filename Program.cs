﻿using System;
using System.Drawing;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Pastel;

namespace RhythmsGonnaGetYou
{
    class Program
    {
        // ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Menu Option Methods etc. ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
        static void Greeting()
        {
            Console.WriteLine("   ######  #     # #     # ####### #     # #     # ");
            Console.WriteLine("   #     # #     #  #   #     #    #     # ##   ## ");
            Console.WriteLine("   #     # #     #   # #      #    #     # # # # # ");
            Console.WriteLine("   ######  #######    #       #    ####### #  #  # ");
            Console.WriteLine("   #   #   #     #    #       #    #     # #     # ");
            Console.WriteLine("   #    #  #     #    #       #    #     # #     # ");
            Console.WriteLine("   #     # #     #    #       #    #     # #     # ");
            Console.WriteLine("   ################################################");
        }





        static void AddBand()
        {
            Console.Clear();
            var context = new RhythmsContext();
            Band newBand = new Band();

            Console.Write("\nType the name of new band then hit ENTER: ");
            newBand.Name = Console.ReadLine();
            Console.Write("\nType the new bands country of origin then hit ENTER: ");
            newBand.CountryOfOrigin = Console.ReadLine();
            Console.Write("\nType the new bands number of members then hit ENTER: ");
            newBand.NumberOfMembers = int.Parse(Console.ReadLine());
            Console.Write("\nType the new bands website then hit ENTER: ");
            newBand.Website = Console.ReadLine();
            Console.Write("\nType the new bands style/genre then hit ENTER: ");
            newBand.Style = Console.ReadLine();
            Console.Write("\nIf the band is signed, type 'true' then press ENTER\nor\nIf the band isn't signed, type false then press ENTER: ");
            var isSignedInput = Console.ReadLine().ToLower();
            newBand.IsSigned = bool.Parse(isSignedInput);
            Console.Write("\nType the Primary contacts name then hit ENTER: ");
            newBand.ContactName = Console.ReadLine();
            Console.Write("\nType the Primary contacts phone number then hit ENTER: ");
            newBand.ContactPhoneNumber = Console.ReadLine();

            context.Bands.Add(newBand);
            context.SaveChanges();

            Console.WriteLine($"\n {newBand.Name} Added to database\n\n");
            Console.WriteLine("\nPress ENTER to quit and return to main menu: ");
            Console.ReadLine();
            Console.Clear();
        }

        static void AddAlbum()
        {
            Console.Clear();
            var context = new RhythmsContext();
            Album newAlbum = new Album();

            Console.Write("Type the title of the new album, then press ENTER: ");
            newAlbum.Title = Console.ReadLine();

            Console.Write("\nIf the album is explicit, type 'true' then hit ENTER\nor\nIf the album is NOT explicit, type 'false' then hit ENTER: ");
            var isExplicitInput = Console.ReadLine().ToLower();
            newAlbum.IsExplicit = bool.Parse(isExplicitInput);

            Console.Write("\nType the release date of new album in the following format (2000-06-15) then press ENTER: ");
            var newAlbumReleaseDate = Console.ReadLine();
            newAlbum.ReleaseDate = DateTime.Parse(newAlbumReleaseDate);

            bool selectingBand = true;
            var bandForAlbum = new Band();
            while (selectingBand)
            {
                Console.WriteLine("Select a band to assign the album to, then press ENTER: ");
                var bandSelection = Console.ReadLine();
                if (context.Bands.FirstOrDefault(band => band.Name == bandSelection) != null)
                {
                    bandForAlbum = context.Bands.FirstOrDefault(band => band.Name == bandSelection);
                    selectingBand = false;
                }
                else
                {
                    Console.WriteLine("\nThere is no band by that name in database");
                    Console.WriteLine("\nPlease Try Again");
                }
            }
            Console.WriteLine($"\n{newAlbum.Title} assigned to {bandForAlbum.Name}");
            newAlbum.BandId = bandForAlbum.Id;
            context.Albums.Add(newAlbum);
            context.SaveChanges();
            Console.WriteLine("\nAdded to database\n\n");
            Console.WriteLine("\nPress ENTER to quit and return to main menu: ");
            var quitToMenu = Console.ReadLine();
            Console.Clear();
        }

        static void AddSongToAlbum()
        {
            Console.Clear();
            var context = new RhythmsContext();
            Song newSong = new Song();

            Console.Write("Type the title of the new song, then press ENTER: ");
            newSong.Title = Console.ReadLine();
            Console.Write("Type the track number of new song, then press ENTER: ");
            var newSongTrackNumber = Console.ReadLine();
            newSong.TrackNumber = int.Parse(newSongTrackNumber);
            Console.Write("Type the duration of the new song, (Format: 00:02:45), then press ENTER: ");
            // var newSongDuration = Console.ReadLine();
            newSong.duration = Console.ReadLine();

            var selectingAlbum = true;
            var albumForSong = new Album();
            while (selectingAlbum)
            {
                Console.Write("\nSelect an album to add new song to, then press ENTER: ");
                var albumSelection = Console.ReadLine();
                if (context.Albums.FirstOrDefault(album => album.Title == albumSelection) != null)
                {
                    albumForSong = context.Albums.FirstOrDefault(album => album.Title == albumSelection);
                    selectingAlbum = false;
                }
                else
                {
                    Console.WriteLine("\nThere is no album by that name in database");
                    Console.WriteLine("\nPlease Try Again");
                }
            }
            Console.WriteLine($"\n{newSong.Title} assigned to {albumForSong.Title}");
            newSong.AlbumId = albumForSong.Id;
            context.Songs.Add(newSong);
            context.SaveChanges();
            Console.WriteLine("\nAdded to database\n\n");
            Console.WriteLine("Press ENTER to quit and return to main menu.\n");
            var quitToMenu = Console.ReadLine();
            Console.Clear();

        }

        static void LetBandGo()
        {
            Console.Clear();
            var context = new RhythmsContext();
            var selectingBand = true;
            var selectedBandToLetGo = new Band();

            while (selectingBand)
            {
                Console.Write("Select a band to let go. Type name, then press ENTER: ");
                var bandSelection = Console.ReadLine();
                if (context.Bands.FirstOrDefault(band => band.Name == bandSelection) != null)
                {
                    selectedBandToLetGo = context.Bands.FirstOrDefault(band => band.Name == bandSelection);
                    selectingBand = false;
                }
                else
                {
                    Console.WriteLine("\nThere is no band by that name in database");
                    Console.WriteLine("\nPlease Try Again");
                }
            }
            selectedBandToLetGo.IsSigned = false;
            Console.WriteLine("\nBand no longer signed to label");
            context.SaveChanges();
            Console.WriteLine("\nChanges saved to database");
            Console.WriteLine("\nPress ENTER to quit and return to main menu: ");
            var quitToMenu = Console.ReadLine();
            Console.Clear();
        }


        static void ReSignBand()
        {
            Console.Clear();
            var context = new RhythmsContext();
            var selectingBand = true;
            var selectedBandToReSign = new Band();

            while (selectingBand)
            {
                Console.Write("Select a band to sign. Type name, then press ENTER: ");
                var bandSelection = Console.ReadLine();
                if (context.Bands.FirstOrDefault(band => band.Name == bandSelection) != null)
                {
                    selectedBandToReSign = context.Bands.FirstOrDefault(band => band.Name == bandSelection);
                    selectingBand = false;
                }
                else
                {
                    Console.WriteLine("\nThere is no band by that name in database");
                    Console.WriteLine("\nPlease Try Again");
                }
            }
            selectedBandToReSign.IsSigned = true;
            Console.WriteLine("\nBand added to label");
            context.SaveChanges();
            Console.WriteLine("\nChanges saved to database");
            Console.WriteLine("\nPress ENTER to quit and return to main menu: ");
            var quitToMenu = Console.ReadLine();
            Console.Clear();
        }

        static void ViewAllBands()
        {
            Console.Clear();
            var context = new RhythmsContext();
            Console.WriteLine("\nViewing all bands:");

            foreach (var band in context.Bands)
            {
                Console.WriteLine($"{band.Name} ");
            }
            var bandCount = context.Bands.Count();
            Console.WriteLine($"\n\n#######--There are {bandCount} bands in database!--#######");
            Console.WriteLine("\nPress ENTER to quit and return to main menu: ");

            Console.ReadLine();
            Console.Clear();
        }

        static void ViewAllAlbumsFromBand()
        {
            Console.Clear();
            var context = new RhythmsContext();
            Console.WriteLine("\nViewing albums from specified band\n");

            var whatband = PromptForString("What band would you like to see albums from?");
            var albumsFromBand = context.Bands.FirstOrDefault(band => band.Name == whatband);
            var albumName = context.Albums.Include(album => album.Band).Where(album => album.Band == albumsFromBand);

            Console.WriteLine($"\n\nAlbums by {whatband}: ");
            foreach (var album in albumName)
            {
                Console.WriteLine(album.Title);
            }
            Console.WriteLine("\nPress ENTER to quit and return to main menu: ");
            Console.ReadLine();
            Console.Clear();
        }



        static void ViewAllAlbumsByReleaseDate()
        {
            Console.Clear();
            var context = new RhythmsContext();
            Console.WriteLine("\nViewing all albums by release date: ");
            var albumsByReleaseDate = context.Albums.OrderBy(album => album.ReleaseDate);
            foreach (var album in albumsByReleaseDate)
            {
                Console.WriteLine($"{album.Title} was released on {album.ReleaseDate.ToString("MM/dd/yyyy")}");
            }
            Console.WriteLine("\nPress ENTER to quit and return to main menu: ");
            Console.ReadLine();
            Console.Clear();
        }

        static void ViewAllBandsSigned()
        {
            Console.Clear();
            var context = new RhythmsContext();

            var signedBands = context.Bands.Where(band => band.IsSigned == true);
            foreach (var band in signedBands)
            {
                Console.WriteLine($"{band.Name}");
            }
            Console.WriteLine("\nPress ENTER to quit and return to main menu: ");
            Console.ReadLine();
            Console.Clear();
        }


        static void ViewAllBandsNotSigned()
        {
            Console.Clear();
            var context = new RhythmsContext();

            var signedBands = context.Bands.Where(band => band.IsSigned == false);
            foreach (var band in signedBands)
            {
                Console.WriteLine($"{band.Name}");
            }
            Console.WriteLine("\nPress ENTER to quit and return to main menu: ");
            Console.ReadLine();
            Console.Clear();
        }

        // ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Menu Option Methods etc. ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^



        static string PromptForString(string prompt)
        {
            Console.WriteLine(prompt);
            var userInput = Console.ReadLine();
            return userInput;
        }

        static int PromptForInteger(string prompt)
        {
            var userInput = PromptForString(prompt);

            int inputAsInteger;
            bool isThisGoodInput = int.TryParse(userInput, out inputAsInteger);

            if (isThisGoodInput)
            {
                return inputAsInteger;
            }
            else
            {
                Console.WriteLine("That isn't an integer. You get a 0");
                return 0;
            }
        }



        static string ShowMenu()
        {
            // Console.WriteLine("\n");
            Console.WriteLine("   ************************************************\n");
            Console.WriteLine($"{"            WELCOME TO RHYTHM RECORDS".Pastel(Color.FromArgb(165, 229, 250))}\n");

            // Console.WriteLine("             Welcome to Rhythm Records\n\n");
            Console.WriteLine("   ********************-Menu-**********************\n");

            Console.WriteLine("      Please choose one of the following options\n");
            Console.WriteLine("\n***********-ADD-***********");
            Console.WriteLine("[1] Add a new band");
            Console.WriteLine("[2] Add an album for a band");
            Console.WriteLine("[3] Add a song to an album");
            Console.WriteLine("\n******-SIGNED STATUS-******");
            Console.WriteLine("[4] Let a band go");
            Console.WriteLine("[5] Resign a band");
            Console.WriteLine("\n*************-VIEW-***************");
            Console.WriteLine("[6] View All bands");
            Console.WriteLine("[7] View all albums from a band");
            Console.WriteLine("[8] View all albums by release date");
            Console.WriteLine("[9] View all bands that are signed");
            Console.WriteLine("[10] View all bands that are not signed\n");
            Console.WriteLine("[Q] Quit program");

            var choice = Console.ReadLine().ToUpper();
            return choice;

        }


        // ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Methods etc. ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^


        static void Main(string[] args)
        {


            var context = new RhythmsContext();

            var bandCount = context.Bands.Count();
            Console.WriteLine($" There are {bandCount} bands in database!");
            var albumCount = context.Albums.Count();
            Console.WriteLine($" There are {albumCount} albums in database!");
            var songCount = context.Songs.Count();
            Console.WriteLine($" There are {songCount} songs in database!\n\n");


            var keepGoing = true;
            var counter = 0;

            while (keepGoing)
            {
                Greeting();
                var menuSelection = ShowMenu();
                switch (menuSelection)
                {
                    case "1":
                        AddBand();
                        break;
                    case "2":
                        AddAlbum();
                        break;
                    case "3":
                        AddSongToAlbum();
                        break;
                    case "4":
                        LetBandGo();
                        break;
                    case "5":
                        ReSignBand();
                        break;
                    case "6":
                        ViewAllBands();
                        break;
                    case "7":
                        ViewAllAlbumsFromBand();
                        break;
                    case "8":
                        ViewAllAlbumsByReleaseDate();
                        break;
                    case "9":
                        ViewAllBandsSigned();
                        break;
                    case "10":
                        ViewAllBandsNotSigned();
                        break;
                    case "Q":
                        keepGoing = false;
                        break;

                    default:
                        Console.Clear();
                        // counter = counter + 1;
                        counter += 1;
                        if (counter > 3)
                        {
                            Console.WriteLine("Exceeded Attempts..Closing App\n");
                            keepGoing = false;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Select an option, then hit ENTER\n");
                        }
                        break;
                }
            }
        }
    }
}