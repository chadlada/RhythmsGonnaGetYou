using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RhythmsGonnaGetYou
{
    class Program
    {
                // ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ Menu Option Methods etc. ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

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

            var selectingBand = true;
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
            Console.WriteLine("\nPress ENTER to quit to menu: ");
            var quitToMenu = Console.ReadLine();
            Console.Clear();
        }

        static void LetBandGo()
        {

        }
        static void ReSignBand()
        {

        }
        static void ViewAllBands()
        {

        }
        static void ViewAllAlbumsFromBand()
        {

        }
        static void ViewAllAlbumsByReleaseDate()
        {

        }
        static void ViewAllBandsSigned()
        {

        }
        static void ViewAllBandsNotSigned()
        {

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
            var isThisGoodInput = int.TryParse(userInput, out inputAsInteger);

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
            Console.WriteLine("\n\n");
            Console.WriteLine("********************************************************\n");
            Console.WriteLine("          Welcome to Rhythm Records\n\n");
            Console.WriteLine("********************-Menu-******************************\n");

            Console.WriteLine("Please choose one of the following options\n");
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
            Console.WriteLine($" There are {songCount} songs in database!");



            var keepGoing = true;
            var counter = 0;

            while (keepGoing)
            {
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
                        // Add a song to album 
                        break;
                    case "4":
                        //Let a band go
                        break;
                    case "5":
                        // Resign a band
                        break;
                    case "6":
                        // View all bands
                        break;
                    case "7":
                        // View all albums by a band
                        break;
                    case "8":
                        // View all albums by release date
                        break;
                    case "9":
                        // View all bands that are signed
                        break;
                    case "10":
                        // View all bands that are NOT signed
                        break;
                    case "Q":
                        keepGoing = false;
                        break;

                    default:
                        Console.Clear();
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
