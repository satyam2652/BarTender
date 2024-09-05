using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace Core.Tests;

public class CocktailClientTestFixture
{
    private string BaseUrl { get; set; }
    private ITestOutputHelper TestOutputHelper { get; set; }
    
    public CocktailClientTestFixture(ITestOutputHelper testOutputHelper)
    {
        TestOutputHelper = testOutputHelper;
        BaseUrl = "https://www.thecocktaildb.com/api/json/v1/1/random.php";
    }

    [Fact]
    public void GetRandomCocktail()
    {
        // Arrange
        var client = new CocktailClient(BaseUrl);
        
        //Act
        var response = client.GetRandomCocktail();
        
        // Assert 
        var settings = new JsonSerializerSettings()
        {
            DateFormatString = "dd/MM/yyyy hh:mm:ss",
            Formatting = Formatting.Indented
        };
        TestOutputHelper.WriteLine("Random drink : {0}", JsonConvert.SerializeObject(response, settings));
    }

}