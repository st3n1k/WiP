using MediatR;
using WiP.Core.Response;

namespace WiP.Cqrs.Commands.Game
{
    public class AddGameCommand : IRequest<CreateResponse>
    {
        public string? Name { get; set; }
        public DateTime? Release { get; set; }
        public decimal? Metascore { get; set; }
        public string? Cover { get; set; }
        public string? Description { get; set; }
        public int? GameEngineId { get; set; }
        public int? SeriesId { get; set; }
        public int[]? GamePlatforms { get; set; }
        public int[]? GameGenres { get; set; }
        public int[]? GameDevelopers { get; set; }
        public int[]? GamePublishers { get; set; }
    }
}
