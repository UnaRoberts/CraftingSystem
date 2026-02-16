/*
 * Craft System
 * Una Roberts
 * Application created in PROG 305 Programming 2
 * With code demos from instructor, Open Source and CoPilot
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

           // could just do new GameEngine().setUp()
        }
    }
}

/* to do 
 *
 *
 *
 *For future edits:
 *make an instance of a trader
 * make a trade method
 * make a method to add money 
 *use the conversion method soemwhere
 *add items from the recipes instead of adding amounts to already exsiting items (see the inventory xml)
 *export players progress to a xml so they can make progress each tiem they play
 *
 * */




/*Credits for CoPilot:
 * 
 * What I asked: could you build a method for within a utility class that converts measurements using these conversions: * 48 teaspoons = 1 cup
- 16 tablespoons = 1 cup
- 3 teaspoons = 1 tablespoon
- A teaspoon of dry leaves typically weighs about 0.1 ounces.


What it responded: 
A Clean, Reusable MeasurementConverter Utility
Here’s a polished version that gives you:
- Conversions between teaspoons ↔ tablespoons ↔ cups
- Conversion from teaspoons → ounces (dry leaves) using your rule
- A single internal “base unit” (teaspoons) so everything stays consistent
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



💡 Why this design works beautifully
✔ Everything converts through a single base unit
Teaspoons are the “anchor,” so you never get weird rounding errors from chaining conversions.
✔ You get both simple methods and a generic Convert()
Use whichever fits your workflow.
✔ Easy to extend
If you later add grams, milliliters, or potion‑specific units, you just add one more constant and two small methods.



 * 
 * 
 * */


