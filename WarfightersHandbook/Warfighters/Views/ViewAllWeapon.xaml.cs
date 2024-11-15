using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Warfighters.Models;
using Warfighters.Services;
using Warfighters.ViewModels;

namespace Warfighters.Views
{
    /// <summary>
    /// Логика взаимодействия для ViewAllWeapon.xaml
    /// </summary>
    public partial class ViewAllWeapon : Page
    {
        public ViewAllWeapon()
        {
            InitializeComponent();

            DataContext = new BrowseWeapon();
        }

        private void charactersBT_Click(object sender, RoutedEventArgs e)
        {
            ViewAllBuilds viewAllBuilds = new ViewAllBuilds();
            this.NavigationService.Navigate(viewAllBuilds);
        }

        private void weaponsBT_Click(object sender, RoutedEventArgs e)
        {

        }

        private void artefactsBT_Click(object sender, RoutedEventArgs e)
        {
            ViewAllArtefact viewAllArtefact = new ViewAllArtefact();
            this.NavigationService.Navigate(viewAllArtefact);
        }
    }
}
