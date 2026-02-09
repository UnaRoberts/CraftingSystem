using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static CraftingSystem.Display;


namespace CraftingSystem
{
    public class Item
    {
        public string ItemName { get; set; }
        public int ItemQuantity { get; set; }
        public double ItemPrice { get; set; }
        public Recipe SubRecipe { get; set; }
        public string AmountType = "cup(s)"; //defaults to this but can be changed 

        public Item(string name, int quanitiy, string amountType, double price, Recipe subRecipe = null)
        {
            ItemName = name; 
            ItemQuantity = quanitiy;
            ItemPrice = price;
            AmountType = amountType;
            SubRecipe = subRecipe;
        }

        public Item()
        {
         
        }

        public override string ToString() //Used CoPilot 
        {
            return $"\n-{ItemQuantity} x{ItemName} (${ItemPrice})";
        }

    }
}