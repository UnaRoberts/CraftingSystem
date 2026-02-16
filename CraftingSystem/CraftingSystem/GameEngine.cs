using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;//needed for using outer files
using System.Linq;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static CraftingSystem.Display;


namespace CraftingSystem
{
    class GameEngine
    {
        public string GameEngineName { get; set; }
        public Person Player = new Person(); 
        public List<Recipe> Recipes = new List<Recipe>();






        //List<Recipe>[] listOfRecipes = new List<Recipe>[2];
        public GameEngine()
        {
        }
//        public void title()
//        {
//            string title = "";
//            string[] titleLine = File.ReadAllLines("../../../data/title.txt");
//            try
//            {

//                title = File.ReadAllText("../../../data/title.txt")//../ indicates a level you went out, can also use an absolute path which is tellgn you every name,con = if on a PC, then its not possible to transport it 
//;
//            }

//            catch (Exception ex)
//            {
//                Print("Instructions not available");
//                return;
//            }


//            Print(titleLine[0]);
//            Print(titleLine[1]);
//        }
        private List<Recipe> LoadRecipes() //list will have a bunch of instances of recipe 
        {
            string fileName = "../../../data/recipes.xml";

            List<Recipe> Recipes = new List<Recipe>();
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            XmlNode root = doc.DocumentElement;
            XmlNodeList recipeList = root.SelectNodes("/recipes/recipe");
            XmlNodeList ingredientsList;

            foreach (XmlElement recipe in recipeList)
            {
                Recipe recipeToAdd = new Recipe();
                recipeToAdd.RecipeName = recipe.GetAttribute("RecipeName");
               // recipeToAdd.Description = recipe.GetAttribute("description");

                ///need to try parse below based on what the type is 
                string OutputAmount = recipe.GetAttribute("OutputAmount");
                //if (int.TryParse(yieldAmount, out float amount))
                //{ recipeToAdd.OutputAmount = amount; }

                recipeToAdd.AmountType = recipe.GetAttribute("AmountType");
                string RecipePrice = recipe.GetAttribute("RecipePrice");
                if (int.TryParse(RecipePrice, out int value))
                { recipeToAdd.RecipePrice = value; }

                ingredientsList = recipe.ChildNodes; //for ingredients

                foreach (XmlElement i in ingredientsList)
                {
                    string ItemName = i.GetAttribute("ItemName");
                    string ItemQuantityString = i.GetAttribute("ItemQuantity");
                    double ItemQuantity = 0;
                    if (double.TryParse(ItemQuantityString, out double e))
                    { ItemQuantity = e; }
                    
                    string AmountType = i.GetAttribute("AmountType");
                   
                    
                    
                    string tempItemPrice = i.GetAttribute("ItemPrice");
                    double ItemPrice = 0;
                    if (double.TryParse(tempItemPrice, out double ingValue))
                    { ItemPrice = ingValue; }

                    recipeToAdd.Ingredients.Add(new Item(ItemName, ItemQuantity, AmountType, ItemPrice));
                }
                Recipes.Add(recipeToAdd);
            }
            return Recipes;

        }//from In class lecture




        public void setUp()
        {           
            Recipes = LoadRecipes();
            AppTitle("Crafting System");
            Player.GetPersonName();
            Player.LoadInventory();
            Player.playerInfo();
            Menu();
        }

        public void ShowRecipes()
        {
            int number = 1;

            Print("Available Recipes:");

            foreach (var recipe in Recipes)
            {
                Print($"{number}.) {recipe.RecipeName}");
                number++;
            }
        }
        public void Menu() 

        {
            Print("What would you like to do?");
            Console.WriteLine("1.) View recipes \n2.) Craft item \n3.) View Credits \n4.) Exit"); 
            string MenuPick = Display.UserInput();
            Console.Clear();

            if (MenuPick == "1")
            {
                ShowRecipes();
                Print("Which recipe details would you like to view?");
                pickRecipe();
            }

            else if (MenuPick == "2")
            {
                
                    CraftItem();
                //Print("This action is under construction");//NEEDS WORK 

            }

            else if (MenuPick == "3")
            {
                
                displayCredits();
            }

            else if (MenuPick == "4")
            { }

            else
            {   Print("Invalid input, please enter a number from the menu.");
                Menu();
            } 
        }
      


        public void pickRecipe()
        {
            string recipePick = UserInput();
            if (int.TryParse(recipePick, out int index))
            {
                index -= 1;
                ShowRecipeDetails(index);
                Print("Press enter to return to Menu");
                UserInput();
                Console.Clear();
                Menu();
            }

            else
            {
                Print("Invalid input, please enter a number.");
            }
        }



        public void ShowRecipeDetails(int recipeIndex)
        {
            Console.Clear(); 
            if (recipeIndex < 0 || recipeIndex >= Recipes.Count)
            {
                Print("Invalid recipe number.");
                return;
            }

            Recipe recipe = Recipes[recipeIndex];

            Print($"{recipe.RecipeName}");
            Print("");
            foreach (var ingredient in recipe.Ingredients)
            {
                Print($"-{ingredient.ItemQuantity} {ingredient.AmountType} of {ingredient.ItemName}  (${ingredient.ItemPrice})");
            }

        }


        public void CraftItem()
        {
            Print("Which recipe would you like to craft?");
            ShowRecipes();
           
            string ItemPick = Display.UserInput();
          
            if (ItemPick == "1")
            {          
                CheckPlayerInventoryItem(Player, "Water", 1);
                CheckPlayerInventoryItem(Player, "Chamomile", 1);
                if (CheckPlayerInventoryItem(Player, "Water", 1) && CheckPlayerInventoryItem(Player, "Chamomile", 1))
                {
                    Console.Clear();
                    ChangeAmountByName(Player.Inventory, "Water", -1);
                    ChangeAmountByName(Player.Inventory, "Chamomile", -1);
                    ChangeAmountByName(Player.Inventory, "Chamomile Tea", +1);
                    Print("You have crafted 1 Chamomile Tea!");
                    Player.playerInfo();
                    Print("Press enter to return to Menu");
                    UserInput();
                    Console.Clear();
                    Menu();
                }
                else
                {
                    Print("You do not have all the ingredients to craft a Sleeping Potion.");
                }
            }

            else if (   ItemPick == "2")
            {
                CheckPlayerInventoryItem(Player, "Chamomile Tea", 1);
                CheckPlayerInventoryItem(Player, "Ashwagandha", 0.5);
                CheckPlayerInventoryItem(Player, "Dried Lavender", 0.5);
                CheckPlayerInventoryItem(Player, "Lemon Balm", 0.5);
                if (CheckPlayerInventoryItem(Player, "Chamomile Tea", 1) && CheckPlayerInventoryItem(Player, "Ashwagandha", 0.5) && CheckPlayerInventoryItem(Player, "Dried Lavender", 0.5) && CheckPlayerInventoryItem(Player, "Lemon Balm", 0.5))
                {
                    Console.Clear();
                    ChangeAmountByName(Player.Inventory, "Chamomile Tea", -1);
                    ChangeAmountByName(Player.Inventory, "Ashwagandha", -0.5);
                    ChangeAmountByName(Player.Inventory, "Dried Lavender", -0.5);
                    ChangeAmountByName(Player.Inventory, "Lemon Balm", -0.5);
                    ChangeAmountByName(Player.Inventory, "Sleepy Tea", +1);
                    Print("You have crafted 1 Sleeping Potion!");
                    
                    Player.playerInfo();
                    Print("Press enter to return to Menu");
                    UserInput();
                    Console.Clear();
                    Menu();
                }
                else
                {
                    Print("You do not have all the ingredients to craft a Sleeping Potion.");
                }
            }
            else
            {
               
            }         
        }


        public void AddItemToInventory()
        {
            
            //method to add items to inventory when you craft them 

            //subtract ingerdients 
            //add new instance of ingredient 

        }
        public void displayCredits()
        {

            Print("---Credits---");
            Print("Demos by Janell Baxter");
            Print("Used CoPilot");
            Print($"Open Source code:" +
                "\n- https://www.webdevtutor.net/blog/c-sharp-validate-input-is-numeric");
            Print("Press enter to return to Menu");
            UserInput();
            Console.Clear();
            Menu();
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




method for adding recipes to the list


        //public void AddRecipes() //Used CoPilot to make an array of lists
        //{
        //    for (int i = 0; i < listOfRecipes.Length; i++)
        //    {
        //        listOfRecipes[i] = new List<Recipe>();
        //    }

        //    listOfRecipes[0].Add(new Recipe("Chamomile Tea", 1, "cup", 1,
        //            new List<Item>()
        //            {   new Item( "Water", 48 , "", 0.0015 ), //one cup .0015 dollars per cup 
        //                new Item( "Chamomile",1/3 ,"", 0.0875  ),  //1 tsp ch 7 dollars for 8 ounes - .0875 for a tsp    
        //            }
        //             )
        //        );

        //    var chamomileTea = listOfRecipes[0].FirstOrDefault(r => r.RecipeName == "Chamomile Tea");


        //    listOfRecipes[1].Add(new Recipe("Sleeping Potion", 1, "cup", 1,
        //             new List<Item>()
        //             {  new Item("Chamomile Tea", 48,"", 0, chamomileTea),
        //                new Item( "Ashwagandha (Withania somnifera, extract)",1/6,"", 0 ),  //1/2 tsp Ashwagandha//$14.95 for 2 ounces //one tsp = 0.7475 (divide in half for half a tsp)
        //                new Item( "Dried Lavender(Lavandula angustifolia, dried)",1/6,"", 0 ), ////$3.25 per ounce//one tsp = $032.5 (divide in half for half a tsp)
        //                new Item( "Lemon Balm(Melissa officinalis, dried)",1/6,"", 0 ), ////$34.95 for 4 oz(8.7375 per ounce) //one tsp = $0.87375 (divide in half for half a tsp)
        //             }
        //              )
        //         );
        //    var sleepingPotion = listOfRecipes[1].FirstOrDefault(r => r.RecipeName == "Sleeping Potion");
        //}









        public void PickRecipe()
        {
            string recipePick = Display.UserInput();

            if (recipePick == "1")
            {
                ShowRecipeDetails(0, 0);           
            }

            else if (recipePick == "2")
            {
                ShowRecipeDetails(1, 0);
            }

            else if (recipePick == "3")
            {
                ShowRecipeDetails(2, 0);

            }

        }





  public void ShowRecipeDetails(int listIndex, int recipePick) 
        {
            Console.Clear();
            Print($"Recipe Details:");

            foreach (var recipe in Recipes)
            {
                Print($"Recipe: {recipe.RecipeName}");

                foreach (var ingredient in recipe.Ingredients)
                {
                    Print($"-{ingredient.ItemQuantity} {ingredient.AmountType} {ingredient.ItemName}  (${ingredient.ItemPrice})");
                }
            }
        }



*/