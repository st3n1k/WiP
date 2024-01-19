namespace WiP.Core.Entity
{
    public class GamePublisherEntity : BaseEntity
    {
        public int? GameId { get; set; }
        public GameEntity? Game { get; set; }
        public int? PublisherId { get; set; }
        public PublisherEntity? Publisher { get; set; }
    }
}
