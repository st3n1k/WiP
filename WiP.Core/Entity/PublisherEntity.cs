namespace WiP.Core.Entity
{
    public class PublisherEntity : BaseEntity
    {
        public string? Title { get; set; }
        public List<GamePublisherEntity>? GamePublishers { get; set; }
    }
}
