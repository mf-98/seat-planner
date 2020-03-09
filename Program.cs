
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatPlanner
{
    class Program
    {

        const int NUM_TABLES = 6;
        const int NUM_SEATS_PER_TABLE = 4;
        const int NUM_SEATS = NUM_TABLES * NUM_SEATS_PER_TABLE;
        const int FIELD_WIDTH = 20;
        const int MaxLength = 20;

        static void Main(string[] args)
        {
            string[] names = new string[NUM_SEATS];
            bool[] SeatIsOccupied = new bool[NUM_SEATS];
            string userChoice = "";

            InitalizeSeats(names, SeatIsOccupied);
            bool myBool = false;

            do
            {

                try
                {

                    Console.WriteLine("Welcome to the seating plan");
                    Console.WriteLine("Press " + 1 + " to add a guest and " + 2 + " to remove a guest ");
                    int MenuChoice = int.Parse(Console.ReadLine());

                    switch (MenuChoice)
                    {
                        case 1:

                            userChoice = " ";
                            SeedNames(names, SeatIsOccupied);
                            DisplaySeatingChart(names, SeatIsOccupied);
                           
                            Console.WriteLine("Would you like to stay? Enter stay if you want to repeat");
                            userChoice = Console.ReadLine();

                            if (userChoice != "stay")
                            {
                                Console.WriteLine("Goodbye!");
                                myBool = false;
                            }

                            else if (userChoice == "stay")
                            {
                                myBool = true;
                            }
                            break;

                        case 2:

                            userChoice = " "; 
                            RemoveGuest(names, SeatIsOccupied);
                            DisplaySeatingChart(names, SeatIsOccupied);

                            Console.WriteLine("Would you like to stay or go? Enter stay if you want to repeat");
                            userChoice = Console.ReadLine();
                            if (userChoice != "stay")
                            {
                                Console.WriteLine("Goodbye!");
                                myBool = false;
                            }

                            else if (userChoice == "stay")
                            {
                                myBool = true;
                            }
                            break;

                        default:
                            myBool = true;
                            Console.WriteLine("Oops that doesn't seem right. Please try again.");
                            break;
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("Something went wrong. Please try again");
                    myBool = true;
                }

            } while (userChoice == "stay" || myBool);
        }

        static void SeedNames(string[] names, bool[] SeatIsOccupied)
        {
            bool keepGoing = false;
            string guestName = "";

            do
            {
                try
                {
                    Console.WriteLine("Enter a guest name");
                    guestName = Console.ReadLine();
                    keepGoing = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Something went wrong: " + ex.Message);
                    keepGoing = true;
                }

                if (guestName.Trim().Length == 0)
                {
                    Console.WriteLine("You didn't write anything. Please try again.");
                    keepGoing = true;
                }

            } while (keepGoing);

            if (guestName.Length > MaxLength)
                guestName = guestName.Substring(0, MaxLength);

            do
            {
                try
                {

                    DisplayEmptySeatingChart(names, SeatIsOccupied);
                    Console.WriteLine("Enter a guest seat number");
                    int guestseat = int.Parse(Console.ReadLine());

                    if (SeatIsOccupied[guestseat])
                    {
                        Console.WriteLine("SORRY, THIS SEAT IS ALREADY TAKEN!!!");
                        keepGoing = false;
                    }

                    else
                    {
                        names[guestseat] = guestName;
                        SeatIsOccupied[guestseat] = true;
                        Console.WriteLine("Ok!!!!! we have filled that seat with " + guestName);
                        keepGoing = false;
                    }

                }
                catch (FormatException)
                {
                    Console.WriteLine("Oops you typed something wrong. Please try again: ");
                    keepGoing = true;
                }

                catch (OverflowException)
                {
                    Console.WriteLine("Oops you typed something wrong. Please try again: ");
                    keepGoing = true;
                }

                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Oops you typed something wrong. Please try again: ");
                    keepGoing = true;
                }

                catch (Exception)
                {
                    Console.WriteLine("Something went wrong. Please try again: ");
                    keepGoing = true;
                }

            } while (keepGoing);
        }

        static void RemoveGuest(string[] names, bool[] SeatIsOccupied)
        {

            bool keepGoing = false;

            do
            {
                try
                {
                    Console.WriteLine("Remove a guest from the seating chart? Press " + 1 + " to remove by guestseat, " + 2 + " to remove by guestname");
                    int RemoveMenuChoice = int.Parse(Console.ReadLine());

                    if (RemoveMenuChoice > 2 || RemoveMenuChoice < 1)
                    {
                        Console.WriteLine("Something went wrong. Please choose 1 or 2");
                        keepGoing = true;
                    }

                    switch (RemoveMenuChoice)
                    {
                        case 1:

                            DisplayEmptySeatingChart(names, SeatIsOccupied);
                            Console.WriteLine("Enter guest seat number you wish to remove: ");
                            int guestSeatRemove = int.Parse(Console.ReadLine());
                            names[guestSeatRemove] = string.Empty;
                            SeatIsOccupied[guestSeatRemove] = false;
                            Console.WriteLine("THE GUEST HAS BEEN REMOVED!!!!!!");
                            keepGoing = false;
                            break;

                        case 2:

                            DisplayEmptySeatingChart(names, SeatIsOccupied);
                            Console.WriteLine("Enter the name of the guest you wish to remove: ");
                            string GuestNameRemove = Console.ReadLine();
                            for (int i = 0; i < names.Length; i++)
                            {
                                if (names[i] == GuestNameRemove)
                                {
                                    names[i] = string.Empty;
                                    SeatIsOccupied[i] = false;
                                    Console.WriteLine("THE GUEST HAS BEEN REMOVED!!!!!!");
                                    keepGoing = false;
          
                                }

                            }
                            break;     
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("Something went wrong. Please try again");
                    keepGoing = true;
                }

            } while (keepGoing);

        }


        private static void InitalizeSeats(string[] names, bool[] SeatIsOccupied)
        {
            names[0] = string.Empty;
            SeatIsOccupied[0] = false;

            names[1] = "Anastasia";
            SeatIsOccupied[1] = true;

            names[2] = string.Empty;
            SeatIsOccupied[2] = false;

            names[3] = string.Empty;
            SeatIsOccupied[3] = false;

            names[4] = "Buttercup Mother";
            SeatIsOccupied[4] = true;

            names[5] = "Westley Father";
            SeatIsOccupied[5] = true;

            names[6] = string.Empty; ;
            SeatIsOccupied[6] = false;

            names[7] = string.Empty; ;
            SeatIsOccupied[7] = false;

            names[8] = "Princess";
            SeatIsOccupied[8] = true;

            names[9] = string.Empty; ;
            SeatIsOccupied[9] = false;

            names[10] = string.Empty; ;
            SeatIsOccupied[10] = false;

            names[11] = "Queen";
            SeatIsOccupied[11] = true;

            names[12] = string.Empty; ;
            SeatIsOccupied[12] = false;

            names[13] = string.Empty; ;
            SeatIsOccupied[13] = false;

            names[14] = "King";
            SeatIsOccupied[14] = true;

            names[15] = string.Empty; ;
            SeatIsOccupied[15] = false;

            names[16] = string.Empty; ;
            SeatIsOccupied[16] = false;

            names[17] = string.Empty; 
            SeatIsOccupied[17] = false;

            names[18] = string.Empty;
            SeatIsOccupied[18] = false;

            names[19] = string.Empty; ;
            SeatIsOccupied[19] = false;

            names[20] = string.Empty; ;
            SeatIsOccupied[20] = false;

            names[21] = string.Empty;
            SeatIsOccupied[21] = false;

            names[22] = "Butterfly";
            SeatIsOccupied[22] = true;

            names[23] = string.Empty;
            SeatIsOccupied[23] = false;
        }


        static void DisplaySeatingChart(string[] names, bool[] SeatIsOccupied)
        {
            Console.WriteLine("**********************************************************************************************");
            for (int i = 0; i < NUM_TABLES; i++)
            {
                for (int j = 0; j < NUM_SEATS_PER_TABLE; j++)
                {
                    int index = i * NUM_SEATS_PER_TABLE + j;

                    Console.Write(String.Format("* {0,-20} ", names[index]));

                }
                Console.WriteLine(" *");
            }
            Console.WriteLine("**********************************************************************************************");

        }


        static void DisplayEmptySeatingChart(string[] names, bool[] SeatIsOccupied)
        {

            Console.WriteLine("**********************************************************************************************");

            for (int i = 0; i < NUM_TABLES; i++)
            {

                for (int j = 0; j < NUM_SEATS_PER_TABLE; j++)
                {

                    int index = i * NUM_SEATS_PER_TABLE + j;

                    if (SeatIsOccupied[index] == false)
                    {

                        Console.Write(String.Format("* {0,-20} ", "Seat " + index));
                    }

                    else
                    {

                        Console.Write(String.Format("* {0,-20} ", "TAKEN Seat " + index));
                    }

                }

                Console.WriteLine(" *");

            }

            Console.WriteLine("**********************************************************************************************");

        }

    }
}
