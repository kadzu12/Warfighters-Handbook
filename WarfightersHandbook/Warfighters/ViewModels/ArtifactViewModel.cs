using Warfighters.Models;

namespace Warfighters.ViewModels
{
    public class ArtifactViewModel
    {
        public int IdArtifact { get; }
        public string Category { get; }

        public ArtifactViewModel(Artifact artifact)
        {
            IdArtifact = artifact.IdArtifact;
            Category = artifact.Category;
        }
    }
}
