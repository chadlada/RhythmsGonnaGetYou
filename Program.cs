using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RhythmsGonnaGetYou
{
    class Program
    {
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
            Console.WriteLine("[1] Add a new band");
            Console.WriteLine("[2] View All bands");
            Console.WriteLine("[3] Add a song to an album");
            Console.WriteLine("[4] Let a band go");
            Console.WriteLine("[5] Resign a band");
            Console.WriteLine("[6] View all albums from a band");
            Console.WriteLine("[7] View all albums by release date");
            Console.WriteLine("[8] View all bands that are signed");
            Console.WriteLine("[9] View all bands that are not signed");
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

            while (keepGoing)
            {
                var menuSelection = ShowMenu();
                switch (menuSelection)
                {
                    case "1":
                        AddBand();
                        break;
                    case "2":
                        // View all bands method
                        break;
                    case "3":
                        // Add a song to album method
                        break;
                    case "4":
                        //Let a band go
                        break;
                    case "5":
                        // Resign a band
                        break;
                    case "6":
                        // View all albums from a band
                        break;
                    case "7":
                        // View all albums by release date
                        break;
                    case "8":
                        // View all bands that are signed
                        break;
                    case "9":
                        // View all bands that are not signed
                        break;
                    case "Q":
                        keepGoing = false;
                        break;
                }

            }

        }
    }
}
