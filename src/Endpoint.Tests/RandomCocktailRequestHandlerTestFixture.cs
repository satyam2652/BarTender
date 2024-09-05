using Core;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Xunit;

namespace Endpoint.Tests;

public class RandomCocktailRequestHandlerTestFixture
{
    private ILogger Logger { get; set; }

    public RandomCocktailRequestHandlerTestFixture()
    {
        Logger = ConfigureLogger();
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
            new CocktailClient("https://www.thecocktaildb.com/api/json/v1/1/random.php"),
            Logger
        );
        testSubject.Handle(new RandomCocktailRequest { Language = Language.English }, CancellationToken.None);
    }
}