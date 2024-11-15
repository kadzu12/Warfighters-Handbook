using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Media.Imaging;

namespace Warfighters.Models;

public partial class Character
{
    public Character()
    {
        RecommendedStats = new HashSet<RecommendedStat>();
        Constellations = new HashSet<Constellation>();
        Talents = new HashSet<Talent>();
        IdSets = new HashSet<SetArtifact>();
        IdWeapons = new HashSet<Weapon>();
    }

    public int IdCharacter { get; set; }

    public string ImageCharacter { get; set; } = null!;
    [NotMapped]
    public BitmapImage DisplayedImage
    {
        get
        {
            var uri = new Uri($"pack://application:,,,/ResourcesCharacters/{ImageCharacter}");
            return new BitmapImage(uri);
        }
    }

    public string NameCharacter { get; set; } = null!;

    public string EyeGod { get; set; } = null!;

    public string Region { get; set; } = null!;

    public string TypeWeapon { get; set; } = null!;

    public int Rariry { get; set; }

    public int IdSignatureWepons { get; set; }

    public int IdSignatureSetArtifact { get; set; }

    public int CountViews { get; set; }

    public string? MainDps { get; set; }

    public string? SubDps { get; set; }

    public string? Support { get; set; }

    public virtual ICollection<RecommendedStat> RecommendedStats { get; set; }
    public virtual ICollection<Constellation> Constellations { get; set; }
    public virtual Weapon IdSignatureWeponsNavigation { get; set; } = null!;
    [ForeignKey("IdSignatureSetArtifact")]
    public virtual SetArtifact IdSignaturSetNavigation { get; set; } = null!;
    public virtual ICollection<Talent> Talents { get; set; }
    public virtual ICollection<SetArtifact> IdSets { get; set; }
    public virtual ICollection<Weapon> IdWeapons { get; set; }
}
