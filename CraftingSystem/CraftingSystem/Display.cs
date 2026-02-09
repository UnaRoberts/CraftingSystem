using System;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Linq;
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


        public static bool SearchText(string text, string searchTerm)
        {
            if (text.Contains(searchTerm))
            {
                return true;
            }
            return false;
        }

        //from class reading "Search String"


       

        


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
