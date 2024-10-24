namespace CopsAndRobbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Test");
            //List<People> peoples = new List<People>();
            //peoples.Add (new Citizen("Oscar", 1, 1 , 1 ,1));
            //peoples.Add(new Citizen("Emil", 1, 1, 1, 1));
            //peoples.Add(new Citizen("Johan", 1, 1, 1, 1));
            //peoples.Add(new Citizen("Emil 2", 1, 1, 1, 1));

            //foreach (People people in peoples)
            //{
            //    Console.WriteLine(people.Name + " ");
            //    foreach (Goods goods in people.Goods)
            //    {
            //        Console.Write(goods.ItemName + " ");
            //    }
            //}
            //Console.ReadLine();
            Console.CursorVisible = false;
            City City = new City(12, 12, 12, 25, 100);
            City.DisplayLocation();

            
            
            while (true)
            {

                for (int i = 0; i < City.Peoples.Count; i++)
                {
                    Render.Movement(i, City);
                    City.DisplayPeople(i);

                }

                Thread.Sleep(200);            
            }
        }
    }
}
