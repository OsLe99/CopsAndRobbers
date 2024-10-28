using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopsAndRobbers
{
    internal class People
    {
        public string Name { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int DirX { get; set; }
        public int DirY { get; set; }
        public List<Goods> Goods { get; set; }

        public People(string name, int posX, int posY, int dirX, int dirY)
        {
            Goods = new List<Goods>();
            Name = name; 
            PosX = posX;
            PosY = posY; 
            DirX = dirX; 
            DirY = dirY; 
        }
    }

    class Citizen : People
    {
        public Citizen(string name, int posX, int posY, int dirX, int dirY) : base(name, posX, posY, dirX, dirY)   
        {
            CreateGoods(Goods);
        }

        private void CreateGoods(List<Goods> goods)
        {
            goods.Add(new Goods("keys"));
            goods.Add(new Goods("phone"));
            goods.Add(new Goods("dosh"));
            goods.Add(new Goods("watch"));
        }
    }
    class Robber : People
    {
        public Robber(string name, int posX, int posY, int dirX, int dirY) : base(name, posX, posY, dirX, dirY)
        {

        }
    }

    class Cop : People
    {
        public Cop(string name, int posX, int posY, int dirX, int dirY) : base(name, posX, posY, dirX, dirY)
        {

        }
    }

}
