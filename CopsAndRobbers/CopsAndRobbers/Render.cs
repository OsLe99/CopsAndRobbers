using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopsAndRobbers
{
    internal class Render
    {
        public static void NewsFeed(Location location, int position)
        {
            if(location.NewNews == true)
            {
                for (int i = 0; i < (location.News.Count() < 5 ? location.News.Count() : 5); i++)
                {
                    Console.SetCursorPosition(0, (position + i));
                    Console.WriteLine($"{location.News.Count() - 1 - i}. {location.News.ElementAt(location.News.Count() - i - 1)}");

                }
                location.NewNews = false;
                //Thread.Sleep(200);
            }
        }

        public static void DisplayPeople(People person)
        {
            Console.SetCursorPosition(person.PosX, person.PosY);
            if (person is Citizen)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("C");
            }
            else if (person is Robber)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("R");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("P");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void DisplayLocation(Location location) // Draws city border
        {
            for (int col = location.StartPosY; col <= (location.StartPosY + location.Height); col++)
            {
                Console.SetCursorPosition(location.StartPosX, col);
                for (int row = location.StartPosX; row <= (location.StartPosX + location.Width); row++)
                {

                    if (col == location.StartPosY || col == (location.StartPosY + location.Height) || row == location.StartPosX || row == (location.StartPosX + location.Width))
                    {
                        Console.Write("X");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }

            for (int col = 22; col <= (22 + 10); col++)
            {
                Console.SetCursorPosition(0, col);
                for (int row = 0; row <= (20); row++)
                {

                    if (col == 22 || col == (22 + 10) || row == 0 || row == 20)
                    {
                        Console.Write("X");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }

        }

        public static void DisplayStatus(City city, int position)
        {
            int jailed = 0;
            foreach (var robber in city.Peoples)
            {
                if (robber is Robber)
                {
                    if ((robber as Robber).PrisonTime > 0)
                    {
                        jailed--;
                    }
                }
            }
            Console.SetCursorPosition(0, position);

            Console.WriteLine($"Av {city.AmmountOfCitizen} medborgare är {city.AmmountOfCitizen} medborgare kvar.\n" +
                $"Av {city.AmmountOfCops} poliser är {city.AmmountOfCops} poliser kvar.\n" + 
                $"Av {city.AmmountOfThiefs} tjuvar är {city.AmmountOfThiefs + jailed} kvar.");
        }
    }
}
