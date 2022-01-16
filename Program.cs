using System;
using System.Linq;

namespace RhythmsGonnaGetYou
{
    class Program
    {
        static string Menu()
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

        static void Main(string[] args)
        {
            var context = new RhythmsContext();
            var bandCount = context.Bands.Count();

            var keepGoing = true;

            while (keepGoing)
            {
                var menuSelection = Menu();
                switch (menuSelection)
                {
                    case "1":
                        // Add new band method
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
