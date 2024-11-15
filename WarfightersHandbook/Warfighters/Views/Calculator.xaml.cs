using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Warfighters.Models;
using Warfighters.Services;
using Warfighters.ViewModels;

namespace Warfighters.Pages
{
    /// <summary>
    /// Логика взаимодействия для Calculator.xaml
    /// </summary>
    public partial class Calculator : Page
    {
        public static Calculator calculator;
        public Calculator()
        {
            InitializeComponent();

            calculator = this;
            DataContext = new BrowseCalculator();

            cbPiece.ItemsSource = ArtifactServices.GetArtifactsName();
            cbMainStat.ItemsSource = ArtifactServices.GetMainStatsName();
            cbSet.ItemsSource = ArtifactServices.GetSetsName();
        }

        private void cbPiece_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectPiece = cbPiece.SelectedItem as string;
            int pieceId = ArtifactServices.GetArtifactIDByName(selectPiece);
            if (pieceId != -1)
            {
                List<string> mainStats = ArtifactServices.GetMainStatsByArtifactId(pieceId);
                cbMainStat.ItemsSource = mainStats;
            }
        }

        private void tbATKPercent_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            CalculatorServices.KeyControl(e, tbATKPercent, 35.00);
        }

        private void tbHPPercent_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            CalculatorServices.KeyControl(e, tbHPPercent, 35.00);
        }

        private void tbDEFPercent_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            CalculatorServices.KeyControl(e, tbDEFPercent, 43.70);
        }

        private void tbRecharge_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            CalculatorServices.KeyControl(e, tbRecharge, 38.90);
        }

        private void tbEM_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            CalculatorServices.KeyControl(e, tbEM, 140.00);
        }

        private void tbCritDMG_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            CalculatorServices.KeyControl(e, tbCritDMG, 46.60);
        }

        private void tbCritRate_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            CalculatorServices.KeyControl(e, tbCritRate, 23.30);
        }
    }
}
