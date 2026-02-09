using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using static CraftingSystem.Display;


namespace CraftingSystem
{
    public class Recipe
    {
        public string RecipeName;
        public int OutputAmount;
        public string AmountType; //measurement of the thing
        public int RecipePrice;
        public List<Item> Ingredients = new List<Item>() { }; //list of items (called ingredients)

        public Recipe(string name, int outputAmount, string amountType, int price, List<Item> ingredients)
       {
            RecipeName = name;
            OutputAmount = outputAmount;
            AmountType = amountType;
            RecipePrice = price;
            Ingredients = ingredients;
        }


        public Recipe()
        {
        }


        public override string ToString() //Used CoPilot 
        {
            string ingredientList = string.Join(", ", Ingredients);

            return $"{RecipeName}\nMakes: {OutputAmount} {AmountType}\nPrice: {RecipePrice} \nIngredients: {ingredientList})";

        }

    }
}