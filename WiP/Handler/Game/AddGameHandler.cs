using MediatR;
using WiP.Core.Entity;
using WiP.Core.Interfaces;
using WiP.Core.Response;
using WiP.Cqrs.Commands.Game;

namespace WiP.Handler.Game
{
    public class AddGameHandler : IRequestHandler<AddGameCommand, CreateResponse>
    {
        private IUnitOfWork _unitOfWork;
        public AddGameHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<CreateResponse> Handle(AddGameCommand request, CancellationToken cancellationToken)
        {

            var entity = new GameEntity();

            entity.Title = request.Name;

            _unitOfWork.Repository<GameEntity>()!.Add(entity);

            await _unitOfWork.Complete();

            return new CreateResponse() { Id = entity.Id };
        }
    }
}
