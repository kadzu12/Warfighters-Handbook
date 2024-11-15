using System.Windows.Media.Imaging;
using Warfighters.Models;

namespace Warfighters.ViewModels
{
    public class SetViewModel
    {
        public SetArtifact SetArtifact { get; }
        public BitmapImage DisplayedImage
        {
            get
            {
                var uri = new Uri($"pack://application:,,,/ResourcesArtifacts/{SetArtifact.ImageSet}");
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = uri;
                bitmap.EndInit();
                return bitmap;
            }
        }

        public string Name => SetArtifact.NameSet;

        public string? Dungeon => SetArtifact.Dungeon;

        public string IncompleteStatBonus => SetArtifact.IncompleteStatBonus;

        public string? FullStatBonus => SetArtifact.FullStatBonus;
        public SetViewModel(SetArtifact setArtifact)
        {
            SetArtifact = setArtifact;
        }
    }
}
