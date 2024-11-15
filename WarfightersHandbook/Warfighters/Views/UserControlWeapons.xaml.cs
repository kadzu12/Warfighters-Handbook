using System.Windows;
using System.Windows.Controls;
using Warfighters.Models;

namespace Warfighters.Views
{
    /// <summary>
    /// Логика взаимодействия для UserControlWeapons.xaml
    /// </summary>
    public partial class UserControlWeapons : UserControl
    {
        Weapon weapon_view = new Weapon();
        public UserControlWeapons(Weapon weapon)
        {
            InitializeComponent();

            DataContext = weapon;
            weapon_view = weapon;
        }

        private void viewBut_Click(object sender, RoutedEventArgs e)
        {
            var page = new WeaponInfo(weapon_view);
            MainWindow.frame.Navigate(page);
        }
    }
}
