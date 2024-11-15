using System.Windows;
using System.Windows.Controls;
using Warfighters.Models;

namespace Warfighters.Views
{
    /// <summary>
    /// Логика взаимодействия для UserControleImage.xaml
    /// </summary>
    public partial class UserControleImage : UserControl
    {
        Character character_build = new Character();
        public UserControleImage(Character character)
        {
            InitializeComponent();

            character_build = character;
            DataContext = character;
        }

        private void viewBut_Click(object sender, RoutedEventArgs e)
        {
            var page = new CharacterInfo(character_build);
            MainWindow.frame.Navigate(page);
        }
    }
}
