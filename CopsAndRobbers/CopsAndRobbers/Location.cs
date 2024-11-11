using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopsAndRobbers
{
    internal class Location
    {
        public int StartPosX { get; set; }
        public int StartPosY { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public List<string> News { get; set; }
        public bool NewNews { get; set; }
        public List<int> Prison { get; set; }
        public List<People> Peoples { get; set; }
        
        public Dictionary<(int, int), List<int>> CityGrid { get; set; }

        public Location(int height, int width, int startPosX, int startPosY)
        {
            Height = height;
            Width = width;
            StartPosX = startPosX;
            StartPosY = startPosY;
            CityGrid = new Dictionary<(int, int), List<int>>();
            Peoples = new List<People>();
        }
       
    }
    class City: Location
    {
        public int AmmountOfCitizen { get; set; }
        public int AmmountOfThiefs { get; set; }
        public int AmmountOfCops { get; set; }
        
        
        public City(int ammountOfCitizen, int ammountOfThiefs, int ammountOfCops, int height, int width, int startPosX, int startPosY) : base(height, width, startPosX, startPosY)
        {
            News = new List<string>();
            Prison = new List<int> { 32, 20, 1, 22 };
            AmmountOfCitizen = ammountOfCitizen;
            AmmountOfCops = ammountOfCops;
            AmmountOfThiefs = ammountOfThiefs;
            CreatePeople(Peoples, ammountOfCitizen, ammountOfThiefs, ammountOfCops);
            // InitCityGrid();

        }
        public void InitCityGrid()
        {
            for (int i = 0; i < Peoples.Count(); i++)
            {
                if (CityGrid.TryGetValue((Peoples[i].PosX, Peoples[i].PosY), out List<int> indexList))  //Bryta ut till egen metod... Fixat
                {

                    indexList.Add(Peoples[i].Id);

                }
                else
                {
                    CityGrid.Add((Peoples[i].PosX, Peoples[i].PosY), new List<int> { Peoples.IndexOf(Peoples[i]) });
                }
                Render.DisplayPeople(Peoples[i]);
            }
        }

        public void UpdateCityGrid(People people)
        {
            
            if (CityGrid.TryGetValue((people.PosX, people.PosY), out List<int> indexList))  //Bryta ut till egen metod... Fixat
            {
                for (int i = 0; i < indexList.Count(); i++)
                {
                    people.Interaction(Peoples[indexList[i]], this); // Skapa interaction
                    NewNews = true;
                }
                
                if(indexList.Count() > 0) people.SetDirection(this);
                indexList.Add(people.Id);
                // CityGrid[(people.PosX, people.PosY)].Add(people.Id);

                //CityGrid.Add(people.PosX, people.PosY), 

            }
            else
            {
                CityGrid.Add((people.PosX, people.PosY), new List<int> { people.Id });
            }
            if (people.MaxY > this.Height)
            {
                people.Interaction(people, this);
            }
        }

        public void CreatePeople(List<People> peoples, int ammountOfCitizen, int ammountOfTheifs, int ammountOfCops)
        {
            string[] names = new string[]
            {
                "Alice", "Arvid", "Axel", "Beatrice", "Benjamin", "Björn", "Camilla", "Carl", "Caroline", "David",
                "Daniel", "Diana", "Elin", "Elias", "Emma", "Emil", "Eva", "Filip", "Fredrik", "Gabriel",
                "Hanna", "Henrik", "Ida", "Isak", "Jacob", "Johanna", "Johan", "Julia", "Karin", "Kasper",
                "Klara", "Kristina", "Leo", "Lina", "Linus", "Louise", "Lucas", "Ludvig", "Maja", "Malin",
                "Marcus", "Maria", "Martin", "Matilda", "Max", "Mia", "Mikael", "Moa", "Nina", "Noah",
                "Olle", "Oscar", "Patrik", "Peter", "Rebecka", "Robin", "Ronja", "Samuel", "Sandra", "Sebastian",
                "Simon", "Sofia", "Sofie", "Stina", "Susanna", "Theodor", "Therese", "Thomas", "Tina", "Tommy",
                "Ulrika", "Viktor", "Wilma", "Ylva", "Alexander", "Amanda", "Anders", "Anna", "Anton", "Astrid",
                "Birgitta", "Bo", "Carina", "Christoffer", "Ella", "Erik", "Frida", "Gustav", "Helen", "Håkan",
                "Jan", "Jessica", "Jonas", "Lars", "Malte", "Monica", "Nils", "Per", "Rickard", "Stefan"
            };

            for (int i = 0; i < ammountOfCitizen; i++)
            {
                peoples.Add(new Citizen($"{names[Random.Shared.Next(0, 100)]}", peoples.Count(), this));
            }
            for (int i = 0; i < ammountOfTheifs; i++)
            {
                peoples.Add(new Robber($"{names[Random.Shared.Next(0, 100)]}", peoples.Count(), this));
            }
            for (int i = 0; i < ammountOfCops; i++)
            {
                peoples.Add(new Cop($"{names[Random.Shared.Next(0, 100)]}", peoples.Count(), this));
            }
        }

    }
    class Prison: Location
    {
        public Prison(int height, int width, int startPosX, int startPosY) : base (height, width, startPosX, startPosY)
        {
            
        }
    }
}
