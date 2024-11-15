namespace CopsAndRobbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            
            // Instansierat subklass okbjektet city
            City city = new City(20, 10, 5, 20, 100, 0, 0);

            // Ritar upp det visuella i konsollen från objekten
            Render.DisplayLocation(city);
            Render.DisplayStatus(city);
            city.InitCityGrid();

            while (true)
            {
                // Går igenom alla element i city.Peoples lista
                foreach (People people in city.Peoples)
                {
                    // Kallar på metoder för att köra program
                    people.Move(city);
                    Render.DisplayPeople(people);
                    city.UpdateCityGrid(people);
                    Render.NewsFeed(city, (city.Prison[0] + 6));
                }
                Thread.Sleep(50);
            }
        }
    }
}
