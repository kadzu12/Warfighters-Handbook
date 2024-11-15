namespace Warfighters.Models;

public partial class Constellation
{
    public int IdConstellation { get; set; }

    public int IdCharacter { get; set; }

    public string NameConstellation { get; set; } = null!;

    public int ConstellationLevel { get; set; }

    public string DescriptionConstellation { get; set; } = null!;

    public virtual Character IdCharacterNavigation { get; set; } = null!;
}
