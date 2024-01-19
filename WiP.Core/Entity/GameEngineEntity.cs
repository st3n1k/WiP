namespace WiP.Core.Entity
{
    public class GameEngineEntity : BaseEntity
    {
        public string? Version { get; set; }
        public int? EngineId { get; set; }
        public EngineEntity? Engine { get; set; }
    }
}
