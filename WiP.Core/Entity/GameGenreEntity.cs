namespace WiP.Core.Entity
{
    public class GameGenreEntity : BaseEntity
    {
        public int? GameId { get; set; }
        public GameEntity? Game { get; set; }
        public int? GenreId { get; set; }
        public GenreEntity? Genre { get; set; }
    }
}
