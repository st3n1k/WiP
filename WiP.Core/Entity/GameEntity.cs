namespace WiP.Core.Entity
{
    public class GameEntity : BaseEntity
    {
        public string? Title { get; set; }
        public DateTime? Release { get; set; }
        public decimal? Metascore { get; set; }
        public byte[]? Cover { get; set; }
        public string? CoverUrl { get; set; }
        public string? Description { get; set; }
        public int? GameEngineId { get; set; }
        public GameEngineEntity? GameEngine { get; set; }
        public int? SeriesId { get; set; }
        public SeriesEntity? Series { get; set; }
        public List<GamePlatformEntity>? GamePlatforms { get; set; }
        public List<GameGenreEntity>? GameGenres { get; set; }
        public List<GameDeveloperEntity>? GameDevelopers { get; set; }
        public List<GamePublisherEntity>? GamePublishers { get; set; }
    }
}
