namespace Warfighters.Models;

public partial class Stat
{
    public int IdStat { get; set; }

    public string NameStat { get; set; } = null!;

    public decimal StartNumber { get; set; }

    public decimal MaxNumber { get; set; }

    public string TypeStat { get; set; } = null!;

    public virtual ICollection<RecommendedStat> RecommendedStats { get; set; } = new List<RecommendedStat>();

    public virtual ICollection<Artifact> IdArtifacts { get; set; } = new List<Artifact>();
}
