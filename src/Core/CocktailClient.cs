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
    
    public string TranslateOrGenerateRandom(string text)
    {
        try
        {
            // Call translation API here, e.g., Google Translate, or your custom logic
            // Fallback: Generate random strings in case of error
            return GenerateRandomString(text);
        }
        catch (Exception)
        {
            return GenerateRandomString(text);
        }
    }

    public string GenerateRandomString(string text)
    {
        Random random = new Random();
        string[] words = text.Split(' ');
        return string.Join(" ", words.Select(_ => RandomString(random.Next(3, 15))));
    }

    private string RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[new Random().Next(s.Length)]).ToArray());
    }
}