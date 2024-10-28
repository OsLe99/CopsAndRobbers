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
        public List<People> Prisoners { get; set; }
        public List<People> Peoples { get; set; }
        
        public int?[,] CityGrid { get; set; }

        public Location(int height, int width)
        {
            Height = height;
            Width = width;
            CityGrid = new int?[width, height];
            Peoples = new List<People>();
            Prisoners = new List<People>();
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

        public void Interaction(int currentPerson)
        {
            foreach (var people in Peoples)
            {
                if ((people.PosX == Peoples[currentPerson].PosX && people.PosY == Peoples[currentPerson].PosY) && people != Peoples[currentPerson])
                {
                    if (Peoples[currentPerson] is Citizen && people is Robber)
                    {
                        people.Goods.Add(Peoples[currentPerson].Goods.Last());
                        Peoples[currentPerson].Goods.Remove(Peoples[currentPerson].Goods.Last());
                    }
                    else if (Peoples[currentPerson] is Robber && people is Citizen)
                    {
                        Peoples[currentPerson].Goods.Add(people.Goods.Last());
                        people.Goods.Remove(people.Goods.Last());
                    }
                    else if (Peoples[currentPerson] is Cop && people is Robber && people.Goods.Count() > 0)
                    {
                        people.Goods.AddRange(Peoples[currentPerson].Goods);
                        Peoples[currentPerson].Goods.RemoveRange(0, Peoples[currentPerson].Goods.Count());

                        Prisoners.Add(people);
                        Peoples.Remove(people);
                    }
                    else if (Peoples[currentPerson] is Robber && people is Cop && Peoples[currentPerson].Goods.Count() > 0)
                    {
                        Peoples[currentPerson].Goods.AddRange(people.Goods);
                        people.Goods.RemoveRange(0, people.Goods.Count());

                        Prisoners.Add(Peoples[currentPerson]);
                        Peoples.Remove(Peoples[currentPerson]);
                    }
                    else
                    {
                        //News.Add($"{Peoples[currentPerson]} hälsar på {people}");
                    }
                }
            }
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
