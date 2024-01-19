namespace WiP.Core.Entity
{
    public class GenreEntity : BaseEntity
    {
        public string? Title { get; set; }
        public List<GameGenreEntity>? GameGenres { get; set; }
    }
}
