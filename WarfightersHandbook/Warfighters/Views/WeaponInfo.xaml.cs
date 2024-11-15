using System.Collections.ObjectModel;
using System.Windows.Controls;
using Warfighters.Models;
using Warfighters.Models.Data;

namespace Warfighters.Views
{
    /// <summary>
    /// Логика взаимодействия для WeaponInfo.xaml
    /// </summary>
    public partial class WeaponInfo : Page
    {
        public Weapon Weapon { get; set; }
        public ObservableCollection<Character> Characters { get; set; }
        public WeaponInfo(Weapon weapon)
        {
            InitializeComponent();

            Weapon = weapon;
            DataContext = this;
            using (HoyoverseContext db = new HoyoverseContext())
            {
                var characters = db.Characters
                    .Where(c => c.IdSignatureWepons == weapon.IdWeapon || c.IdWeapons.Contains(weapon))
                    .ToList();
                Characters = new ObservableCollection<Character>(characters);
            }
            if (Characters.Count != 0)
            {
                foreach (var character in Characters)
                {
                    itemsLV.Items.Add(new UserControleImage(character));
                }
                tbText.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                tbText.Visibility = System.Windows.Visibility.Visible;
                itemsLV.Visibility = System.Windows.Visibility.Collapsed;
            }
        }
    }
}
