using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Media.Imaging;

namespace Warfighters.Models;

public partial class Weapon
{

    public int IdWeapon { get; set; }

    public string ImageWeapon { get; set; } = null!;
    [NotMapped]
    public BitmapImage DisplayedImage
    {
        get
        {
            var uri = new Uri($"pack://application:,,,/ResourcesWeapons/{ImageWeapon}");
            return new BitmapImage(uri);
        }
    }

    public string NameWeapon { get; set; } = null!;

    public string TypeWeapon { get; set; } = null!;

    public int RarityWeapon { get; set; }

    public int BasicAttack { get; set; }

    public string AdditionalStat { get; set; } = null!;

    public string PassiveEffect { get; set; } = null!;

    public virtual ICollection<Character> Characters { get; set; } = new List<Character>();

    public virtual ICollection<Character> IdCharacters { get; set; } = new List<Character>();
}
