namespace Endpoint;

public class RandomCocktailResponse
{
    public string Language { get; set; } 
    public string Title { get; set; } 
    public string Instructions { get; set; }
    public string Image { get; set; }       
    public List<Ingredient> Ingredients { get; set; }

    public RandomCocktailResponse()
    {
        Ingredients = new List<Ingredient>();
    }
}

public class Ingredient
{
    public string Name { get; set; }    
    public string Measure { get; set; } 
    public string Image { get; set; }   
}