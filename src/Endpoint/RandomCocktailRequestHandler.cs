using Core;
using MediatR;
using Newtonsoft.Json;
using Serilog;

namespace Endpoint;

public class RandomCocktailRequestHandler: IRequestHandler<RandomCocktailRequest, RandomCocktailResponse>
{
    private ILogger Logger { get; set; }
    private ICocktailClient CocktailClient { get; set; }
    private ITranslate Translator { get; set; }
    public RandomCocktailRequestHandler(ICocktailClient cocktailClient, ITranslate translator, ILogger logger)
    {
        CocktailClient = cocktailClient;
        Translator = translator;
        Logger = logger;
    }
    public Task<RandomCocktailResponse> Handle(RandomCocktailRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var randomCocktail = CocktailClient.GetRandomCocktail();
            Logger.Information("Request processed successfully. Response received was: {response}", JsonConvert.SerializeObject(randomCocktail));
            
            var mapper = new ReceipeMapper();
            var jsonResponse = new RandomCocktailResponseFactory().Create();
            
            if (request.Language == Language.English)
            {
                mapper.Map(randomCocktail, Language.English, jsonResponse);
                
                return Task.FromResult(jsonResponse);
            }
            
            var translatedReceipe = Translator.TranslateRecipe(randomCocktail);
            mapper.Map(translatedReceipe, Language.Sith, jsonResponse);
            
            return Task.FromResult(jsonResponse);
        }
        catch(Exception ex)
        {
            Logger.Error(ex, "Some error occurred processing request {request}", JsonConvert.SerializeObject(request));
            return Task.FromResult(new RandomCocktailResponse());
        }
    }
}