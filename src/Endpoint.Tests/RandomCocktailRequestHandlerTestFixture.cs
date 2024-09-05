using Core;
using Serilog;
using Serilog.Events;
using Xunit;

namespace Endpoint.Tests;

public class RandomCocktailRequestHandlerTestFixture
{
    private ILogger Logger { get; set; }
    private CocktailClient CocktailClient { get; set; }

    public RandomCocktailRequestHandlerTestFixture()
    {
        Logger = ConfigureLogger();
        CocktailClient = new CocktailClient("https://www.thecocktaildb.com/api/json/v1/1/random.php");
    }

    private static ILogger ConfigureLogger()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Is(LogEventLevel.Debug)
            .WriteTo.Console()
            .CreateLogger();

        return Log.Logger;
    }

    [Fact]
    public void HandlerTestFixture()
    {
        var testSubject = new RandomCocktailRequestHandler(
            CocktailClient,
            new SithTranslator(),
            Logger
        );
        var json = testSubject.Handle(new RandomCocktailRequest { Language = Language.English }, CancellationToken.None);
    }
}