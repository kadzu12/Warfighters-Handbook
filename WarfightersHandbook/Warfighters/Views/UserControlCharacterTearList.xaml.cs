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

namespace Warfighters.Views
{
    /// <summary>
    /// Логика взаимодействия для UserControlCharacterTearList.xaml
    /// </summary>
    public partial class UserControlCharacterTearList : UserControl
    {
        Character character_build = new Character();
        public UserControlCharacterTearList(Character character)
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
