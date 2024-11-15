namespace Warfighters.Models
{
    public partial class CharacterSet
    {
        public int IdCharacter { get; set; }
        public int IdSet { get; set; }

        public virtual Character Character { get; set; }
        public virtual SetArtifact Set { get; set; }
    }
}
