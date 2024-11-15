namespace Warfighters.Models;

public partial class Talent
{
    public int IdTalent { get; set; }

    public int IdCharacter { get; set; }

    public string CategoryTalent { get; set; } = null!;

    public string NameTalent { get; set; } = null!;

    public string DescriptionTalent { get; set; } = null!;

    public int PriorityImprovement { get; set; }

    public virtual Character IdCharacterNavigation { get; set; } = null!;
}

