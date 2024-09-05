using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Endpoint;

[Route("cocktail-mixer")]
public class CocktailController: Controller
{
    private IMediator Mediator { get; set; }
    private Serilog.ILogger Logger { get; set; }

    public CocktailController(IMediator mediator, Serilog.ILogger logger)
    {
        Mediator = mediator;
        Logger = logger;
    }
    
    [HttpGet]
    [Route("random-cocktail")]
    public IActionResult Fetch([FromBody] RandomCocktailRequest request)
    {
        SafeLog(request);

        return new JsonResult(Mediator.Send(request).Result);
    }
    
    private void SafeLog(object request)
    {
        try
        {
            Logger.Debug("Executing {requestType} with body of {requestBody}.", request.GetType().Name, JsonConvert.SerializeObject(request));
        }
        catch (Exception ex)
        {
            Logger.Error(ex, "Unable to log request.");
        }
    }
}