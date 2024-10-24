using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopsAndRobbers
{
    internal class Location
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public List<string> News { get; set; }
        public List<Robber> Prisoners { get; set; }
        public List<People> Peoples { get; set; }
        
        public int?[,] CityGrid { get; set; }

        public Location(int height, int width)
        {
            Height = height;
            Width = width;
            CityGrid = new int?[width, height];
            Peoples = new List<People>();
            //DisplayLocation();
        }

        public void DisplayPeople(int currentPerson)
        {
            //for (int i = 0; i < Peoples.Count; i++)
            //{
                Console.SetCursorPosition(Peoples[currentPerson].PosX, Peoples[currentPerson].PosY);
                if (Peoples[currentPerson] is Citizen)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("C");
                }
                else if (Peoples[currentPerson] is Robber)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("R");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("P");
                }
                Console.ForegroundColor= ConsoleColor.White;
           // }
        }
        //public void Movement(int currentPerson)
        //{
        //    Random rnd = new Random();

        //    if (Peoples[currentPerson].PosX + Peoples[currentPerson].DirX == 0 || Peoples[currentPerson].PosX + Peoples[currentPerson].DirX == Width ||
        //        Peoples[currentPerson].PosY + Peoples[currentPerson].DirY == 0 || Peoples[currentPerson].PosY + Peoples[currentPerson].DirY == Height ||
        //        (Peoples[currentPerson].DirX == 0 && Peoples[currentPerson].DirY == 0))
        //    {
        //        Peoples[currentPerson].DirX = rnd.Next(-1, 2);
        //        Peoples[currentPerson].DirY = rnd.Next(-1, 2);
        //    }
        //    else
        //    {
        //        Console.SetCursorPosition(Peoples[currentPerson].PosX, Peoples[currentPerson].PosY);
        //        Console.Write(" ");
        //        CityGrid[Peoples[currentPerson].PosX, Peoples[currentPerson].PosY] = null;
        //        Peoples[currentPerson].PosY += Peoples[currentPerson].DirY;
        //        Peoples[currentPerson].PosX += Peoples[currentPerson].DirX;
        //        CityGrid[Peoples[currentPerson].PosX, Peoples[currentPerson].PosY] = currentPerson;
        //    }

        //}

        public void Interaction()
        {

        }

        

        public void DisplayLocation() // Draws city border
        {
            
            for (int col = 0; col <= Height; col++)
            {
                for (int row = 0; row <= Width; row++)
                {

                    if (col == 0 || col == Height || row == 0 || row == Width)
                    {
                        Console.Write("░");
                    }
                    else
                    {
                        Console.Write(" ");
                    }


                }
                Console.WriteLine();
            }
        }
       
    }
    class City: Location
    {
        public int AmmountOfCitizen { get; }
        public int AmmountOfTheifs { get; }
        public int AmmountOfCops { get; }
        public City(int ammountOfCitizen, int ammountOfTheifs, int ammountOfCops, int height, int width) : base(height, width)
        {
            CreatePeople(Peoples, ammountOfCitizen, ammountOfTheifs, ammountOfCops);
            // InitCityGrid();
        }
        private void InitCityGrid()
        {
            for (int i = 0; i < Peoples.Count; i++)
            {
                CityGrid[Peoples[i].PosX, Peoples[i].PosY] = i;
            }
        }
        private void CreatePeople(List<People> peoples, int ammountOfCitizen, int ammountOfTheifs, int ammountOfCops)
        {
            Random rnd = new Random();

            for (int i = 0; i < ammountOfCitizen; i++)
            {
                peoples.Add(new Citizen($"Medbergoare{i}", rnd.Next(1, Width), rnd.Next(1, Height), rnd.Next(-1, 2), rnd.Next(-1, 2)));
            }
            for (int i = 0; i < ammountOfTheifs; i++)
            {
                peoples.Add(new Robber($"Tjuv{i}", rnd.Next(1, Width), rnd.Next(1, Height), rnd.Next(-1, 2), rnd.Next(-1, 2)));
            }
            for (int i = 0; i < ammountOfCops; i++)
            {
                peoples.Add(new Cop($"Polis{i}", rnd.Next(1, Width), rnd.Next(1, Height), rnd.Next(-1, 2), rnd.Next(-1, 2)));
            }
        }

    }
    class Prison: Location
    {
        public Prison(int height, int width) : base (width, height)
        {
            
        }
    }
}
