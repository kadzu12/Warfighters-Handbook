using System.Windows.Media.Imaging;
using Warfighters.Models;

namespace Warfighters.ViewModels
{
    public class CharacterViewModel
    {
        public Character Character { get; }

        public BitmapImage DisplayedImage
        {
            get
            {
                var uri = new Uri($"pack://application:,,,/ResourcesCharacters/{Character.ImageCharacter}");
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = uri;
                bitmap.EndInit();
                return bitmap;
            }
        }

        public string Name => Character.NameCharacter;
        public string EyeGod => Character.EyeGod;
        public string Region => Character.Region;
        public string Type => Character.TypeWeapon;
        public int Rarity => Character.Rariry;
        public int IdSignatureW => Character.IdSignatureWepons;
        public int IdSignatureSets => Character.IdSignatureSetArtifact;
        public int CountViews => Character.CountViews;
        public string MainDps => Character.MainDps;
        public string SubDps => Character.SubDps;
        public string Support => Character.Support;

        public CharacterViewModel(Character character)
        {
            Character = character;
        }
    }
}
