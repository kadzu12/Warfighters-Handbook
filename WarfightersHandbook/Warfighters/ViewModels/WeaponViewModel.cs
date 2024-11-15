using System.Windows.Media.Imaging;
using Warfighters.Models;

namespace Warfighters.ViewModels
{
    public class WeaponViewModel
    {
        public Weapon Weapon { get; }
        public BitmapImage DisplayedImage
        {
            get
            {
                var uri = new Uri($"pack://application:,,,/ResourcesWeapons/{Weapon.ImageWeapon}");
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = uri;
                bitmap.EndInit();
                return bitmap;
            }
        }

        public string Name => Weapon.NameWeapon;

        public string Type => Weapon.TypeWeapon;

        public int Rarity => Weapon.RarityWeapon;

        public int BasicAttack => Weapon.BasicAttack;

        public string AdditionalStat => Weapon.AdditionalStat;

        public string PassiveEffect => Weapon.PassiveEffect;

        public WeaponViewModel(Weapon weapon)
        {
            Weapon = weapon;
        }
    }
}
