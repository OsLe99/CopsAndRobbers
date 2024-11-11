namespace CopsAndRobbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            
            // Instansierat subklass okbjekten city
            City city = new City(20, 10, 5, 20, 80, 0, 0);

            //Ritar upp de visuella i konsollen från objekten
            Render.DisplayLocation(city);
            Render.DisplayStatus(city, 34);
            city.InitCityGrid();

            while (true)
            {
                //Går igenom alla element i city.Peoples lista
                foreach (People people in city.Peoples)
                {
                    //Kommer kommentar
                    people.Move(city);
                    Render.DisplayPeople(people);
                    city.UpdateCityGrid(people);
                    Render.NewsFeed(city, 38);
                }
                Thread.Sleep(100);
            }
        }
    }
}
