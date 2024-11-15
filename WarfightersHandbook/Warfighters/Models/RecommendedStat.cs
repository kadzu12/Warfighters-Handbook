namespace Warfighters.Models;

public partial class RecommendedStat
{
    public int IdCharacter { get; set; }
    public int IdArtifact { get; set; }
    public int IdStat { get; set; }

    public virtual Character IdCharacterNavigation { get; set; } = null!;
    public virtual Artifact IdArtifactNavigation { get; set; } = null!;
    public virtual Stat IdStatNavigation { get; set; } = null!;
}
