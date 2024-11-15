namespace Warfighters.Models
{
    public class ArtifactStats
    {
        public int IdArtifact { get; set; }
        public int IdStat { get; set; }

        public virtual Artifact Artifact { get; set; }
        public virtual Stat Stat { get; set; }
    }
}
