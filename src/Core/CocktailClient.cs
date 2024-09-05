using Newtonsoft.Json;

namespace Core;

public class CocktailClient : ICocktailClient
{
    private string BaseUrl { get; set; }
    
    public CocktailClient(string baseUrl)
    {
        BaseUrl = baseUrl;
    }
    
    public DrinkDto GetRandomCocktail()
    {
        using var client = new HttpClient();
        var response = client.GetAsync(BaseUrl).GetAwaiter().GetResult();
    
        if (response.IsSuccessStatusCode)
        {
            var jsonString = response.Content.ReadAsStringAsync().Result;
            var cocktailResponse = JsonConvert.DeserializeObject<CocktailResponseDto>(jsonString);
            var drink = cocktailResponse?.Drinks.FirstOrDefault();
            
            return drink;
        }
    
        return null;
    }
}