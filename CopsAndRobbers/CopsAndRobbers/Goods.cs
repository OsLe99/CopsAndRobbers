using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopsAndRobbers
{
    internal class Goods
    {
        public string ItemName { get; set; }
        public int OriginalOwnerId { get; }
        public Goods(string itemName, int originalOwnerId)
        {
            ItemName = itemName;
            OriginalOwnerId = originalOwnerId;
        }
    }
}
