/*
 * Craft System
 * Una Roberts
 * Application created in PROG 305 Programming 2
 * With code demos from instructor
 * Spring 2026
 */


using System.Web;
using Microsoft.VisualBasic;

namespace CraftingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {

            GameEngine engine = new GameEngine();
            engine.setUp(); 


        }
    }
}

/* to do 
 *
 *Figure out how to get the 1/6 to display 
 *add items to the inventory and display them along with money and name 
 * finish "Create a method that will determine if user input is a number."
 * 
 * 
 * 
 * 
 * later to do:
 * write conversion method 
 * Conversion:
 * 48 teaspoons = 1 cup
 * 16 tablespoons = 1 cup
 * 3 teaspoons = 1 tablespoon
 * A teaspoon of dry leaves typically weighs about 0.1 ounces.
 * */


