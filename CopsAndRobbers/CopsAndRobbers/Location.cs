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
            Prison = new List<int> { (Height + 12), 20, 1, (Height + 2) };
            AmmountOfCitizen = ammountOfCitizen;
            AmmountOfCops = ammountOfCops;
            AmmountOfThiefs = ammountOfThiefs;
            CreatePeople(Peoples, ammountOfCitizen, ammountOfThiefs, ammountOfCops);
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
            
            if (CityGrid.TryGetValue((people.PosX, people.PosY), out List<int> indexList))
            {
                for (int i = 0; i < indexList.Count(); i++)
                {
                    people.Interaction(Peoples[indexList[i]], this);
                    NewNews = true;
                }
                
                if(indexList.Count() > 0) people.SetDirection(this);
                indexList.Add(people.Id);
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

            for (int i = 0; i < ammountOfCitizen; i++)
            {
                peoples.Add(new Citizen($"{Helpers.GetName()}", peoples.Count(), this));
            }
            for (int i = 0; i < ammountOfTheifs; i++)
            {
                peoples.Add(new Robber($"{Helpers.GetName()}", peoples.Count(), this));
            }
            for (int i = 0; i < ammountOfCops; i++)
            {
                peoples.Add(new Cop($"{Helpers.GetName()}", peoples.Count(), this));
            }
        }
    }
}
