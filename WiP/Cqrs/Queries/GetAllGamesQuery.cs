using MediatR;
using WiP.Core.Response.Game;

namespace WiP.Cqrs.Queries
{
    public class GetAllGamesQuery : IRequest<List<GameResponse>>
    {
    }
}
