using MediatR;
using WiP.Core.Entity;
using WiP.Core.Interfaces;
using WiP.Core.Response.Game;
using WiP.Cqrs.Queries;

namespace WiP.Handler.Game
{
    public class GetAllGamesHandler : IRequestHandler<GetAllGamesQuery, List<GameResponse>>
    {
        private IUnitOfWork _unitOfWork;
        public GetAllGamesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<GameResponse>> Handle(GetAllGamesQuery request, CancellationToken cancellationToken)
        {
            var dbData = await _unitOfWork.Repository<GameEntity>()!.ListAllAsync();

            var response = dbData.Select(x => new GameResponse() { Name = x.Title }).ToList();

            return response;
        }
    }
}
