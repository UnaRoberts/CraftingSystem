using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CraftingSystem
{
    public class Item
    {
        public string ItemName { get; set; }
        public int ItemQuantity { get; set; }
        public double ItemPrice { get; set; }
        public Recipe SubRecipe { get; set; }


        public Item(string name, int quanitiy, double price, Recipe subRecipe = null)
        {
            ItemName = name; 
            ItemQuantity = quanitiy;
            ItemPrice = price;
            SubRecipe = subRecipe;
        }

        public Item()
        {
         
        }

        public override string ToString()
        {
            return $"\n-{ItemQuantity} x{ItemName} (${ItemPrice})";
        }

    }
}