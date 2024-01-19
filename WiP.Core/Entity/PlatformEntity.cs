

namespace WiP.Core.Entity
{
    public class PlatformEntity : BaseEntity
    {
        public string? Title { get; set; }
        public DateTime? Release { get; set; }
        public List<GamePlatformEntity>? GamePlatforms { get; set; }
    }
}
