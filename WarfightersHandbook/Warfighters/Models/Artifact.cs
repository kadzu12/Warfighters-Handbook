namespace Warfighters.Models;

public partial class Artifact
{
    public int IdArtifact { get; set; }

    public string Category { get; set; } = null!;

    public virtual ICollection<Stat> IdStats { get; set; } = new List<Stat>();
    public Artifact()
    {
        RecommendedStats = new HashSet<RecommendedStat>();
    }

    public virtual ICollection<RecommendedStat> RecommendedStats { get; set; }
}
