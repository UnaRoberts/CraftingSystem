using System;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace CraftingSystem
{
    public static class Display
    {
        public static void Print(string message)
        {

            Console.WriteLine(message); 
        }

        public static string UserInput()
        {
            return Console.ReadLine();
        }

        public static void DetermineInput(string userInput) //needs to be filled out 
        {

           
            if (int.TryParse(userInput, out _))
            {
                Console.WriteLine("Input is numeric.");
            }
            else
            {
                Console.WriteLine("Input is not numeric.");
            }
            Console.ReadLine();

            //above code from: https://www.webdevtutor.net/blog/c-sharp-validate-input-is-numeric
        }

        //make one mthod to search a list 
        //one to search an array 
        //and then  just try to one search a string 


        public static bool CheckPlayerInventoryItem(Person player, string ingredientName, double ingredientAmount)
        {
            //has to run throguh list to check if it has a certain position or type in it - since inventory is a list, can check for string 

            foreach (Item item in player.Inventory)
            {
                if (item.ItemName == ingredientName && item.ItemQuantity == ingredientAmount)
            {
                    //Print("Yay");
                    return true; // Item found in inventory
                    
                }
               
            }
            //Print("Boo");
            return false;
           


        }



        public static class MeasurementConverter
        {
            // Conversion constants
            private const double TeaspoonsPerTablespoon = 3.0;
            private const double TeaspoonsPerCup = 48.0;
            private const double TablespoonsPerCup = 16.0;

            // Dry leaf weight: 1 teaspoon ≈ 0.1 oz
            private const double OuncesPerTeaspoonDryLeaves = 0.1;

            // -----------------------------
            //  Base conversions (to tsp)
            // -----------------------------
            public static double CupsToTeaspoons(double cups)
                => cups * TeaspoonsPerCup;

            public static double TablespoonsToTeaspoons(double tbsp)
                => tbsp * TeaspoonsPerTablespoon;

            public static double TeaspoonsToCups(double tsp)
                => tsp / TeaspoonsPerCup;

            public static double TeaspoonsToTablespoons(double tsp)
                => tsp / TeaspoonsPerTablespoon;

            // -----------------------------
            //  Dry leaf weight conversion
            // -----------------------------
            public static double TeaspoonsToOuncesDry(double tsp)
                => tsp * OuncesPerTeaspoonDryLeaves;

            public static double OuncesDryToTeaspoons(double ounces)
                => ounces / OuncesPerTeaspoonDryLeaves;

            // -----------------------------
            //  Generic helper (optional)
            // -----------------------------
            public static double Convert(double amount, string fromUnit, string toUnit)
            {
                // Normalize unit strings
                fromUnit = fromUnit.ToLower();
                toUnit = toUnit.ToLower();

                // Step 1: convert from source → teaspoons
                double teaspoons = fromUnit switch
                {
                    "tsp" or "teaspoon" or "teaspoons" => amount,
                    "tbsp" or "tablespoon" or "tablespoons" => TablespoonsToTeaspoons(amount),
                    "cup" or "cups" => CupsToTeaspoons(amount),
                    "oz" or "ounce" or "ounces" => OuncesDryToTeaspoons(amount),
                    _ => throw new ArgumentException($"Unknown unit: {fromUnit}")
                };

                // Step 2: convert teaspoons → target
                return toUnit switch
                {
                    "tsp" or "teaspoon" or "teaspoons" => teaspoons,
                    "tbsp" or "tablespoon" or "tablespoons" => TeaspoonsToTablespoons(teaspoons),
                    "cup" or "cups" => TeaspoonsToCups(teaspoons),
                    "oz" or "ounce" or "ounces" => TeaspoonsToOuncesDry(teaspoons),
                    _ => throw new ArgumentException($"Unknown unit: {toUnit}")
                };
            }
        }


        /*
         example usage:
         
         double tsp = MeasurementConverter.CupsToTeaspoons(1);  
// 48

double cups = MeasurementConverter.TeaspoonsToCups(12);
// 0.25

double oz = MeasurementConverter.TeaspoonsToOuncesDry(5);
// 0.5 ounces

double result = MeasurementConverter.Convert(2, "tbsp", "tsp");
// 6
*/
        //used CoPilot, proper credits in Program file


        public static void ChangeAmountByName(List<Item> list, string itemName, double amount)
        {
            foreach (Item item in list)
            {
                if (item.ItemName == itemName)
                {
                    item.ItemQuantity += amount;
                    return; 
                }
            }

        }

        public static void AddItem()
        { }



        public static void AppTitle(string message)
        { Console.Title = message; }

        #region number conversions
        public static float ConvertStringToFloat(string s)
        {
            if (float.TryParse(s, out float result))
            {
                return result;
            }

            return 0;
        }
        public static int ConvertStringToInteger(string input)
        {
            if (int.TryParse(input, out int number))
            {
                return number;
            }
            return 0;
        }
        public static double ConvertStringToDouble(string input)
        {
            if (double.TryParse(input, out double number))
            {
                return number;
            }
            return 0;
        }

//from in class demo - Janell Baxter 

        #endregion 












        /*
         potential future additions 
         ConvertStringToInteger(string input): int
ConvertStringToDouble(string input): double
ConvertStringToFloat(string input): float
        */


    }
}
