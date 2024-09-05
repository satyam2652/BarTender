using Core;

namespace Endpoint;

public class ReceipeMapper
{
    public void Map(DrinkDto receipe, Language language, RandomCocktailResponse mapTo)
    {
        mapTo.Language = language.ToString();
        mapTo.Title = receipe.StrDrink;
        mapTo.Instructions = receipe.StrInstructions;
        mapTo.Image = receipe.StrDrinkThumb;
        
        MapLanguage(language, mapTo);
        MapIngredientsAndMeasurements(receipe, mapTo);
    }

    private static void MapLanguage(Language language, RandomCocktailResponse mapTo)
    {
        mapTo.Language = language switch
        {
            Language.English => Language.English.ToString(),
            Language.Sith => Language.Sith.ToString(),
            _ => mapTo.Language
        };
    }

    private static void MapIngredientsAndMeasurements(DrinkDto receipe, RandomCocktailResponse mapTo)
    {
        MapIngredient(receipe.StrIngredient1, receipe.StrMeasure1, mapTo.Ingredients);
        MapIngredient(receipe.StrIngredient2, receipe.StrMeasure2, mapTo.Ingredients);
        MapIngredient(receipe.StrIngredient3, receipe.StrMeasure3, mapTo.Ingredients);
        MapIngredient(receipe.StrIngredient4, receipe.StrMeasure4, mapTo.Ingredients);
        MapIngredient(receipe.StrIngredient5, receipe.StrMeasure5, mapTo.Ingredients);
        MapIngredient(receipe.StrIngredient6, receipe.StrMeasure6, mapTo.Ingredients);
        MapIngredient(receipe.StrIngredient7, receipe.StrMeasure7, mapTo.Ingredients);
        MapIngredient(receipe.StrIngredient8, receipe.StrMeasure8, mapTo.Ingredients);
        MapIngredient(receipe.StrIngredient9, receipe.StrMeasure9, mapTo.Ingredients);
        MapIngredient(receipe.StrIngredient10, receipe.StrMeasure10, mapTo.Ingredients);
        MapIngredient(receipe.StrIngredient11, receipe.StrMeasure11, mapTo.Ingredients);
        MapIngredient(receipe.StrIngredient12, receipe.StrMeasure12, mapTo.Ingredients);
        MapIngredient(receipe.StrIngredient13, receipe.StrMeasure13, mapTo.Ingredients);
        MapIngredient(receipe.StrIngredient14, receipe.StrMeasure14, mapTo.Ingredients);
        MapIngredient(receipe.StrIngredient15, receipe.StrMeasure15, mapTo.Ingredients);
    }

    private static void MapIngredient(string strIngredient, string strMeasure, List<Ingredient> ingredients)
    {
        if (!string.IsNullOrEmpty(strIngredient))
        {
            ingredients.Add(new Ingredient
            {
                Name = strIngredient,
                Measure = strMeasure,
                Image = $"https://www.thecocktaildb.com/images/ingredients/{strIngredient}-Medium.png"
            });
        }
    }
}