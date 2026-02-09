using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static CraftingSystem.Display;


namespace CraftingSystem
{
    class GameEngine
    {
        public string GameEngineName { get; set; }
        public Person Player = new Person(); 
        public List<Recipe> Recipes = new List<Recipe>();


        List<Recipe>[] listOfRecipes = new List<Recipe>[2];
        public GameEngine()
        {
        }

        public void setUp()
        {
            //ApplicationTitle
            
            AppTitle("Crafting System");
            //Player.Items();
            Player.GetPersonName();
            //Player.trade();
            AddRecipes();
            Menu();
        }

        public void AddRecipes() //Used CoPilot to make an array of lists
        {
            for (int i = 0; i < listOfRecipes.Length; i++)
            {
                listOfRecipes[i] = new List<Recipe>();
            }

            listOfRecipes[0].Add(new Recipe("Chamomile Tea", 1, "cup", 1,
                    new List<Item>()
                    {   new Item( "Water", 48 , "", 0.0015 ), //one cup .0015 dollars per cup 
                        new Item( "Chamomile",1/3 ,"", 0.0875  ),  //1 tsp ch 7 dollars for 8 ounes - .0875 for a tsp    
                    }
                     )
                );

            var chamomileTea = listOfRecipes[0].FirstOrDefault(r => r.RecipeName == "Chamomile Tea");


            listOfRecipes[1].Add(new Recipe("Sleeping Potion", 1, "cup", 1,
                     new List<Item>()
                     {  new Item("Chamomile Tea", 48,"", 0, chamomileTea),
                        new Item( "Ashwagandha (Withania somnifera, extract)",1/6,"", 0 ),  //1/2 tsp Ashwagandha//$14.95 for 2 ounces //one tsp = 0.7475 (divide in half for half a tsp)
                        new Item( "Dried Lavender(Lavandula angustifolia, dried)",1/6,"", 0 ), ////$3.25 per ounce//one tsp = $032.5 (divide in half for half a tsp)
                        new Item( "Lemon Balm(Melissa officinalis, dried)",1/6,"", 0 ), ////$34.95 for 4 oz(8.7375 per ounce) //one tsp = $0.87375 (divide in half for half a tsp)
                     }
                      )
                 );
            var sleepingPotion = listOfRecipes[1].FirstOrDefault(r => r.RecipeName == "Sleeping Potion");
        }

        public void Menu() //change this method to be a loop using break - recursion example and let the last one just fall through to exit 

        {
            Print("What would you like to do?");
            Console.WriteLine("1.) View recipes \n2.) Craft item \n3.) View Credits \n4.) Exit"); //show inventory 
            string MenuPick = Display.UserInput();
            Console.Clear();

            if (MenuPick == "1")
            {
                ShowRecipes();
                Print("Which recipe details would you like to view?");
                PickRecipe();

                //experimenting using this to remov e sutff 

                


            }

            else if (MenuPick == "2")
            {
                Print("This action is under construction");
            }

            else if (MenuPick == "3")
            {
                
                displayCredits();
            }

            else if (MenuPick == "4")
            {
                Environment.Exit(0);

                //instead just stop the loop and it will fall through and end 
            }

            //make final else (catch all, return to menu)
        }
      
        public void ShowRecipes()
        {
            int number = 1; 

            Print("Available Recipes:");
            Print($"{number}.) {listOfRecipes[0][0].RecipeName}");         
            number++;
            Print($"{number}.) {listOfRecipes[1][0].RecipeName}");
            number++;

        }

        public void ShowRecipeDetails(int listIndex, int recipePick) 
        {
            Console.Clear();
            Print($"Recipe Details:");
            Print($" {listOfRecipes[listIndex][recipePick]}");
        }


        public void Select() //  //from class reading "Search String"
        {
            Console.WriteLine("Enter your choice: Chamomile Tea or Sleeping Tea");
            string input = Console.ReadLine();

            if (SearchText(input.ToLower(), "ch"))
            {
                Console.WriteLine("Chamomile Tea was chosen");
            }
            else if (SearchText(input.ToLower(), "sle"))
            {
                Console.WriteLine("Sleeping Tea was chosen");
            }
            //else if (SearchText(input.ToLower(), "thu"))
            //{
            //    Console.WriteLine("Thursday was chosen");
            //}
            else
            {
                Console.WriteLine("Please enter one of the choices. Press any key to continue...");
                Console.ReadKey();
                Select();
            }
        }



        public void PickRecipe()
        {

            Select();
            //string recipePick = Display.UserInput();

            //if (recipePick == "1")
            //{
            //    ShowRecipeDetails(0, 0);           
            //}

            //else if (recipePick == "2")
            //{
            //    ShowRecipeDetails(1, 0);
            //}

            //else if (recipePick == "3")
            //{
            //    ShowRecipeDetails(2, 0);

            //}

        }

        public void displayCredits()
        {

            Print("---Credits---");
            Print("Demos by Janell Baxter");
            Print("Used CoPilot");
            Print($"Open Source code:" +
                "\n- https://www.webdevtutor.net/blog/c-sharp-validate-input-is-numeric");
        }
    }
}




/*
 from in class:


//show recipes (in engine)
public string ShowAllRecipes()
{
     string output = "Available Recipes:\n";
     int number = 1;
 
     foreach (Recipe recipe in Recipes)
     {
         output += $"   {number}. {recipe.Information()}\n";
         number++;
     }
     return output;
}




-----------------------------------

 //recipe menu in engine
public void RecipeMenu()
 
{
     ShowAllRecipes();
     Print("Enter the number of the recipe you would like to view:");
     string choice = GetInput();
     int num = ConvertStringToInteger(choice);
     if (num >= 1 && num < Recipes.Count)
     {
         //great - we got a good number
         Print(Recipes[num - 1].Information());
     }
     else
 
     {
         //print message saying enter right range as number
         //recursive RecipeMenu()
     }
}
 
 
 
 */
































//things I'm not using currently - possibly useful later
/*
 *  ////shows whole recipe and ALL recipes
            //int number = 1;
            //foreach (var list in listOfRecipes)
            //{
            //    //number thing here 
            //    Display.Print($"{number}.)");


            //    Console.WriteLine(string.Join($", ", list));
            //    //Console.WriteLine(string.Join(", ", list));
            //    Console.WriteLine("");
            //    number++;

            //}


 * */




//ARCHIVED VERSION of recipes system - started using a list, now switched to an array

/*public void AddRecipes()
        {
                var chamomileTea = new Recipe ( "Chamomile Tea", 1, 1,
                    new List<Item>()
                    {   new Item( "Water", 48 , 0.0015 ), //one cup .0015 dollars per cup 
                        new Item( "Chamomile",1/3 , 0.0875 ),  //1 tsp ch 7 dollars for 8 ounes - .0875 for a tsp    
                    }
                     );
            Recipes.Add(chamomileTea);


            var sleepingPotion = new Recipe("Sleeping Potion", 1, 1,
                     new List<Item>()
                     {  new Item("Chamomile Tea", 48, 0, chamomileTea), 
                        new Item( "Ashwagandha (Withania somnifera, extract)",1/6, 0 ),  //1/2 tsp Ashwagandha//$14.95 for 2 ounces //one tsp = 0.7475 (divide in half for half a tsp)
                        new Item( "Dried Lavender(Lavandula angustifolia, dried)",1/6, 0 ), ////$3.25 per ounce//one tsp = $032.5 (divide in half for half a tsp)
                        new Item( "Lemon Balm(Melissa officinalis, dried)",1/6, 0 ), ////$34.95 for 4 oz(8.7375 per ounce) //one tsp = $0.87375 (divide in half for half a tsp)
                     }
                     );
            Recipes.Add(sleepingPotion);
        }



 public void ShowRecipeDetails() //this needs to show all details and the ingredients , needs to acept input 
        {
            Console.Clear();
            Display.Print($"Recipe Details:");

          



            {
                foreach (Recipe recipe in Recipes)
                {

                    Display.Print($"{recipe.RecipeName}");
                    
                    int number = 1;
                    foreach (Item ingredient in recipe.Ingredients)
                    {
                        Display.Print($"{number}. {ingredient.ItemName}, {ingredient.ItemQuantity}, {ingredient.ItemPrice} ");

                        number++;
                    }
                    Display.Print($"");
                }
            }
        }

*/