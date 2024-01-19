namespace WiP.Core.Entity
{
    public class DeveloperEntity : BaseEntity
    {
        public string? Title { get; set; }
        public List<GameDeveloperEntity>? GameDevelopers { get; set; }

    }
}
