namespace Warfighters.Models
{
    public partial class CharacterWeapon
    {
        public int IdCharacter { get; set; }
        public int IdWeapon { get; set; }

        public virtual Character Character { get; set; }
        public virtual Weapon Weapon { get; set; }
    }
}
