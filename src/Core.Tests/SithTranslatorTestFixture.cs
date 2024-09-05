using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace Core.Tests;

public class SithTranslatorTestFixture
{
    private string BaseUrl { get; set; }
    private ITestOutputHelper TestOutputHelper { get; set; }
    
    public SithTranslatorTestFixture(ITestOutputHelper testOutputHelper)
    {
        TestOutputHelper = testOutputHelper;
        BaseUrl = "https://www.thecocktaildb.com/api/json/v1/1/random.php";
    }
    
    [Fact]
    public void TranslateRecipe()
    {
        // Arrange
        var client = new CocktailClient(BaseUrl);
        
        //Act
        var recipe = client.GetRandomCocktail();
        var translateRecipe = new SithTranslator().TranslateRecipe(recipe);
        
        // Assert 
        var settings = new JsonSerializerSettings()
        {
            DateFormatString = "dd/MM/yyyy hh:mm:ss",
            Formatting = Formatting.Indented
        };
        TestOutputHelper.WriteLine("Random drink : {0}", JsonConvert.SerializeObject(translateRecipe, settings));
    }
}