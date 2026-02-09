using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static CraftingSystem.Display;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CraftingSystem
{
    //person can buy materials and sell things to get more money
    class Person
    {

        private string PersonName { get; set; }
        private double Currency;
        private int AmountItems;
        public List<Item> Inventory = new List<Item>(); //list to hold item instances

        public Person(string name, double currency, int amountItems, List<Item> inventory) //constructor - makes an instance of this class, can pass in aprameters and use it in the code block, passing in a parameter means you have to include that to make an instance
        {
            PersonName = name;
            Currency = currency;
            AmountItems = amountItems;
            Inventory = inventory;
        }


        Item chamomile = new Item("Chamomile Tea", 48, "tablespoons", 0);
        Item ashwagandha = new Item("Ashwagandha (Withania somnifera, extract)", 1 / 6, "", 0);
        Item lavender = new Item("Dried Lavender(Lavandula angustifolia, dried)", 1 / 6, "", 0);
        Item lemonBalm = new Item("Lemon Balm(Melissa officinalis, dried)", 1 / 6, "", 0);

        //In a constructor for the Person class (Player and Trader NPC) add 3 items to the inventory list. These are temporary and will be removed soon.



        //alternatively you can overload by having another constructor and then passing i is optiona; 
        public Person()
        {
            
            Add(new Item("Chamomile Tea", 48, "tablespoons", 0));
            Add(new Item("Ashwagandha (Withania somnifera, extract)", 1 / 6, "", 0));
            Add(new Item("Dried Lavender(Lavandula angustifolia, dried)", 1 / 6, "", 0));
            Add(new Item("Lemon Balm(Melissa officinalis, dried)", 1 / 6, "", 0));
            //need more here
            //convert everything to cups using code 

        }
        
        

        //need methods to add and remove items - not recipes - so add when you craft them and remove when you sell them 

        //listname.Count -- to see how long a list is 

        static string playerName;
        public void GetPersonName()

        {
            Print("Enter Player Name...");
            playerName = UserInput();
            DetermineInput(playerName);

            Console.Clear();
            playerInfo();

            Print("");
        }

        //public void playerInfo()
        //{
        //   Print($"--- {playerName} - {Currency.ToString("c")} ---");
        //}

        public void playerInfo()
        {
            Print($"--- {playerName} - {Currency.ToString("c")} - {GetInventory()} ---");
        }

        private string GetInventory()
        {
            string output = "";
            foreach (Item item in Inventory)
            {
                output += $"{item.ItemName}\n";
            }

            return output;
        }


        public string Information() => $"--- {playerName} - {Currency.ToString("c")} ---"; //expression body method does the same as playerInfor
        public void Input()//was meant to be used for the funtion deterining if the input was a number
        {


        }

        static bool IsNumber(string s)
        {
            foreach (char c in s)
            {
                if (!char.IsDigit(c))
                { return false; }
            }
            return true;
        }




        public string GetCurrency()
        {

            return Currency.ToString("c");

        } //shows how to print in a money way 



        public void Add(Item item)//CopPilot
        {
            Inventory.Add(item);
        }

        public void Remove(Item item) //try using a search method in hre to search item and then remove 
        {
            Inventory.Remove(item);
        }
        //use the remove method with a search inside, if the search returns true then remove that item
        public void trade() //written but I do not think it is working 
        {

            SearchText("chamomile", "chamomile");
            Remove(chamomile);

            playerInfo();
        }

    }
}
