using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CraftingSystem
{
    //person can buy materials and sell things to get more money
     class Person
    {
        private string PersonName { get; set; } 
        private double Currency;
        private int AmountItems;
        public List<Item> Inventory = new List<Item>(); //list to hold item instances

        public Person(string name, double currency) //constructor - makes an instance of this class, can pass in aprameters and use it in the code block, passing in a parameter means you have to include that to make an instance
        {
            PersonName = name;
            Currency = currency;
        }

        //alternatively you can overload by having another constructor and then passing i is optiona; 
        public Person() { }

        public void GetPersonName() 
        
        {
            Display.Print("Enter Player Name...");
            string playerName = Display.UserInput();
            //Display.DetermineInput(playerName);



            //from here to 
            string userInput = playerName;
            if (IsNumber(userInput))
            {
                Console.WriteLine("Integer");
            }
            else
            {
                Console.WriteLine("String");
            }
            Console.ReadLine();
            //to here needs to be refactored to be a method in Display 


            Console.Clear();
            //Console.Clear();
            Display.Print($"--- {playerName} - {Currency.ToString("c")} ---");
            Display.Print("");
            //Display.Print($"{playerName} all measures are in tablespoons");
        }



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

    }
}
