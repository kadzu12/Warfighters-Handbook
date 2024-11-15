using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Media.Imaging;

namespace Warfighters.Models;

public partial class SetArtifact
{
    public int IdSet { get; set; }

    public string ImageSet { get; set; } = null!;
    [NotMapped]
    public BitmapImage DisplayedImage
    {
        get
        {
            var uri = new Uri($"pack://application:,,,/ResourcesArtifacts/{ImageSet}");
            return new BitmapImage(uri);
        }
    }

    public string NameSet { get; set; } = null!;

    public string? Dungeon { get; set; }

    public string IncompleteStatBonus { get; set; } = null!;

    public string? FullStatBonus { get; set; }
    public virtual ICollection<Character> Characters { get; set; } = new List<Character>();
    public virtual ICollection<Character> IdCharacters { get; set; } = new List<Character>();
}
