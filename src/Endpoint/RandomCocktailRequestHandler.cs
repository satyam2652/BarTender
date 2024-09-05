using Core;
using MediatR;
using Newtonsoft.Json;
using Serilog;

namespace Endpoint;

public class RandomCocktailRequestHandler: IRequestHandler<RandomCocktailRequest, RandomCocktailResponse>
{
    private ILogger Logger { get; set; }
    private ICocktailClient CocktailClient { get; set; }
    
    public RandomCocktailRequestHandler(ICocktailClient cocktailClient, ILogger logger)
    {
        CocktailClient = cocktailClient;
        Logger = logger;
    }
    public Task<RandomCocktailResponse> Handle(RandomCocktailRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var randomCocktail = CocktailClient.GetRandomCocktail();
            Logger.Information("Request processed successfully. Response received was: {response}", JsonConvert.SerializeObject(randomCocktail));
            return Task.FromResult(new RandomCocktailResponse());

        }
        catch(Exception ex)
        {
            Logger.Error(ex, "Some error occurred processing request {request}", JsonConvert.SerializeObject(request));
            return Task.FromResult(new RandomCocktailResponse());
        }
    }
}