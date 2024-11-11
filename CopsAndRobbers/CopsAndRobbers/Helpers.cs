using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CopsAndRobbers
{
    internal class Helpers
    {
        public static string GetName()
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
            return names[Random.Shared.Next(0, names.Length)];
        }
    }
}
