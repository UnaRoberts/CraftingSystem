using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CraftingSystem
{
    public class Recipe
    {
        public string RecipeName;
        public int OutputAmount;
        public int RecipePrice;
        public List<Item> Ingredients = new List<Item>() { }; //list of items (called ingredients)

        public Recipe(string name, int outputAmount, int price, List<Item> ingredients)
       {
            RecipeName = name;
            OutputAmount = outputAmount;
            RecipePrice = price;
            Ingredients = ingredients;
        }


        public Recipe()
        {
        }


        public override string ToString()
        {
            string ingredientList = string.Join(", ", Ingredients);

            return $"{RecipeName}\nMakes: {OutputAmount} \nPrice: {RecipePrice} \nIngredients: {ingredientList})";

        }

    }
}