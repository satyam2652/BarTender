using MediatR;

namespace Endpoint;

public class RandomCocktailRequest: IRequest<RandomCocktailResponse>
{
    public Language Language { get; set; }
}

public enum Language
{
    English = 1,
    Sith = 2
}