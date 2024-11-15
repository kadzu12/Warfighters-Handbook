namespace Warfighters.Models
{
    public class CharacterStat
    {
        public int IdCharacter { get; set; }
        public int IdStat { get; set; }

        public virtual Character Character { get; set; }
        public virtual Stat Stat { get; set; }
    }
}
