using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public enum ItemsToUse
    {
        Fertilizer,
        Moth,
        Rabbit
    }

    public class Item
    {
        public string theItemName;
        public int theItemAmount;
        
        public Item() { }

        public Item(string theName, int theAmount)
        {
            theItemName = theName;
            theItemAmount = theAmount;
        }
    }
}
