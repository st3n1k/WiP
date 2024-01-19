namespace WiP.Core.Entity
{
    public class GameDeveloperEntity : BaseEntity
    {
        public int? GameId { get; set; }
        public GameEntity? Game { get; set; }
        public int? DeveloperId { get; set; }
        public DeveloperEntity? Developer { get; set; }
    }
}
