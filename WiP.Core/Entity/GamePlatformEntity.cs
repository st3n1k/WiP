namespace WiP.Core.Entity
{
    public class GamePlatformEntity : BaseEntity
    {
        public int? GameId { get; set; }
        public GameEntity? Game { get; set; }
        public int? PlatformId { get; set; }
        public PlatformEntity? Platform { get; set; }
    }
}
