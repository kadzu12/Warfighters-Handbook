using System.Windows;
using System.Windows.Controls;
using Warfighters.Pages;
using Warfighters.Views;

namespace Warfighters
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Frame frame;

        public MainWindow()
        {
            InitializeComponent();

            content_frame.NavigationService.Navigate(new ViewAllBuilds(), Visibility.Visible);
            frame = content_frame;
        }

        private void ratingBT_Click(object sender, RoutedEventArgs e)
        {
            content_frame.NavigationService.Navigate(new Rating(), Visibility.Visible);
        }

        private void calculatorBT_Click(object sender, RoutedEventArgs e)
        {
            content_frame.NavigationService.Navigate(new Calculator(), Visibility.Visible);
        }

        private void buildBT_Click(object sender, RoutedEventArgs e)
        {
            content_frame.NavigationService.Navigate(new ViewAllBuilds(), Visibility.Visible);
        }
    }
}