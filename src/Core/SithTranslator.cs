namespace Core;

using System;
using System.Collections.Generic;

public class SithTranslator : ITranslate
{
    private Dictionary<string, string> sithTranslations = new()
    {
        { "Grape Soda", "Kra'shosh" },
        { "Tequila", "Kyntor-Shâs" },
        { "Stir together and serve over ice.", "Urai jata drâtsu nash ur agmen’ sîri." },
        { "Strawberry Daiquiri", "Jah'ra'nok Daiquiri" },
        { "Ordinary Drink", "Kash'nor Drink" },
        { "Cocktail glass", "Vash'ta'kor" },
        {
            "Pour all ingredients into shaker with ice cubes. Shake well. Strain in chilled cocktail glass.",
            "Rish'nor ka'ra vash'ta sur shak'nak ur ice shari. Korr’nash vash. Strain na’ va shaka vash'ta'kor."
        },
        { "Apricot punch", "Dru'kor Punch" },
        { "Punch / Party Drink", "Punch / Kash'nor Drink" },
        { "Punch bowl", "Dru'kor va" },
        {
            "Pour all ingredients into a large punch bowl. Add ice and 4 oranges that are peeled and divided.",
            "Rish'nor ka'ra vash'ta sur Dru'kor va. Add shari ur 4 nar'mur na’ shâk and divided."
        },
        { "Apricot brandy", "Dru'kor Kall" },   // Dru'kor = Apricot, Kall = Brandy
        { "Triple sec", "Tre'thik Sec" },       // Tre'thik = Triple
        { "Lime", "Kra'mor" },                  // Kra'mor = Lime
        { "Red wine", "Sith'korr Vin" },        // Sith'korr = Red, Vin = Wine
        { "Sugar", "Nash'tar" },                // Nash'tar = Sugar
        { "Orange juice", "Nar'mur Jus" },      // Nar'mur = Orange, Jus = Juice
        { "Lemon juice", "Lem'sha Jus" },       // Lem'sha = Lemon
        { "Cloves", "Khor'kash" },              // Khor'kash = Cloves
        { "Cinnamon", "Sith'tan" }              // Sith'tan = Cinnamon
    };

    public DrinkDto TranslateRecipe(DrinkDto recipe)
    {
        DrinkDto translatedRecipe = new DrinkDto
        {
            StrDrink = TranslateToSith(recipe.StrDrink),
            StrCategory = TranslateToSith(recipe.StrCategory),
            StrAlcoholic = TranslateToSith(recipe.StrAlcoholic),
            StrGlass = TranslateToSith(recipe.StrGlass),
            StrInstructions = TranslateToSith(recipe.StrInstructions),
            StrIngredient1 = TranslateToSith(recipe.StrIngredient1),
            StrIngredient2 = TranslateToSith(recipe.StrIngredient2),
            StrIngredient3 = TranslateToSith(recipe.StrIngredient3),
            StrIngredient4 = TranslateToSith(recipe.StrIngredient4),
            StrIngredient5 = TranslateToSith(recipe.StrIngredient5)
        };

        return translatedRecipe;
    }
    
    private string TranslateToSith(string input)
    {
        return sithTranslations.ContainsKey(input) ? sithTranslations[input] : GenerateRandomSithWord(input.Length);
    }

    private string GenerateRandomSithWord(int length)
    {
        var random = new Random();
        const string chars = " abcdefghijklmnopqrstuvwxyz'âî-";
        var randomLength = random.Next(3, 15);
        var randomString = new char[randomLength];

        for (var i = 0; i < randomLength; i++)
        {
            randomString[i] = chars[random.Next(chars.Length)];
        }

        return new string(randomString);
    }
}