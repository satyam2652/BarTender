namespace Endpoint;

public class RandomCocktailResponseFactory
{
    public RandomCocktailResponse Create()
    {
        var response = new RandomCocktailResponse()
        {
            Ingredients = new List<Ingredient>()
        };
        return response;
    }
}