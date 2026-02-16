using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static CraftingSystem.Display;

namespace CraftingSystem
{
    //person can buy materials and sell things to get more money
     public class Person
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


        
       


        //alternatively you can overload by having another constructor and then passing i is optiona; 
        public Person() {
           
            //Inventory.Add(new Item("Chamomile Tea", 48, "tablespoons", 0));


            //Inventory.Add(new Item("Ashwagandha (Withania somnifera, extract)", 1 / 6, "", 0));
            //Inventory.Add( new Item("Dried Lavender(Lavandula angustifolia, dried)", 1 / 6, "", 0));
            //Inventory.Add(new Item("Lemon Balm(Melissa officinalis, dried)", 1 / 6, "", 0));
           



        }


        //need methods to add and remove items - not recipes - so add when you craft them and remove when you sell them 

        //listname.Count -- to see how long a list is 

        static string playerName;
        
        public void LoadInventory()

        {
           
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../data/inventory.xml");

            XmlNode root = doc.DocumentElement;
             XmlNodeList ingredientNodes = root.SelectNodes("ingredient");

            foreach (XmlNode ing in ingredientNodes)

            {
                string itemName = ing.Attributes["ItemName"].Value;
                string itemQuantityString = ing.Attributes["ItemQuantity"].Value;
                string amountType = ing.Attributes["AmountType"].Value;
                string itemPriceString = ing.Attributes["ItemPrice"].Value;

                Inventory.Add(new Item(itemName, double.Parse(itemQuantityString), amountType, double.Parse(itemPriceString)));

            }
        }




        public void GetPersonName() 
        
        {
            string instructions = "";
            string[] instructionLine = File.ReadAllLines("../../../data/instructions.txt");
            try
            {

                instructions = File.ReadAllText("../../../data/instructions.txt")//../ indicates a level you went out, can also use an absolute path which is tellgn you every name,con = if on a PC, then its not possible to transport it 
;
            }

            catch (Exception ex)
            {
                Print("Instructions not available");
                return;
            }

            
            Print(instructionLine[0]);
            Print(instructionLine[1]);
            playerName = UserInput();

            Print("Welcome " + playerName + "!");
            Print(instructionLine[2]);
            UserInput();
            Console.Clear();   
            
        }

        public void playerInfo()
        {
            Print($"--- {playerName} - {Currency.ToString("c")} ---\nInventory:{GetInventory()}");
            Print("");
        }

        public string GetInventory()
        {
            string output = "";
            foreach (Item item in Inventory)
            {
                output += $"\n-{item.ItemQuantity} {item.AmountType} of {item.ItemName}";
            }

            return output;
        }

       
        public string Information() => $"--- {playerName} - {Currency.ToString("c")} ---"; //expression body method does the same as playerInfor
      

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

    }
}
