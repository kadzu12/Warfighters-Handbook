using System.Windows;
using System.Windows.Controls;
using Warfighters.Models;

namespace Warfighters.Views
{
    /// <summary>
    /// Логика взаимодействия для UserControlArtefact.xaml
    /// </summary>
    public partial class UserControlArtefact : UserControl
    {
        SetArtifact set = new SetArtifact();
        public UserControlArtefact(SetArtifact setArtefact)
        {
            InitializeComponent();

            DataContext = setArtefact;
            set = setArtefact;
        }

        private void viewBut_Click(object sender, RoutedEventArgs e)
        {
            var page = new SetInfo(set);
            MainWindow.frame.Navigate(page);
        }
    }
}
