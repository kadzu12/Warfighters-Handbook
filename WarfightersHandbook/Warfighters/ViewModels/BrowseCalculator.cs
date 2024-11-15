using DevExpress.Mvvm;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Warfighters.Models;
using Warfighters.Pages;
using Warfighters.Services;
using Warfighters.Views;

namespace Warfighters.ViewModels
{
    public class BrowseCalculator : BindableBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //Список персонажей, кому подходит данный артефакт
        private List<Character> _suitableCharacters = new List<Character>();
        public List<Character> SuitableCharacters
        {
            get { return _suitableCharacters; }
            set
            {
                _suitableCharacters = value;
                NotifyPropertyChanged(nameof(SuitableCharacters));
                NotifyPropertyChanged(nameof(SuitableCharactersImages));
            }
        }
        public List<UserControleImage> SuitableCharactersImages
        {
            get { return SuitableCharacters.Select(c=> new UserControleImage(c)).ToList(); }
        }
        //Расчет
        private RelayCommand calculateWnd;
        public RelayCommand CalculateWnd
        {
            get
            {
                return calculateWnd ?? new RelayCommand(obj =>
                {
                    CalculateWndMethod();
                });
            }
        }
        public void CalculateWndMethod()
        {
            if (Calculator.calculator.cbSet.SelectedIndex != -1 && Calculator.calculator.cbPiece.SelectedIndex != -1 && Calculator.calculator.cbMainStat.SelectedIndex != -1)
            {
                TextBox[] textBoxes = [Calculator.calculator.tbHPPercent, Calculator.calculator.tbATKPercent, Calculator.calculator.tbDEFPercent, Calculator.calculator.tbEM, Calculator.calculator.tbRecharge, Calculator.calculator.tbCritRate, Calculator.calculator.tbCritDMG];
                SuitableCharacters = CalculatorServices.Calculate(Calculator.calculator.cbSet.SelectedItem.ToString(), Calculator.calculator.cbPiece.SelectedItem.ToString(), Calculator.calculator.cbMainStat.SelectedItem.ToString(), textBoxes, Calculator.calculator.tbHPPercent.Text, Calculator.calculator.tbATKPercent.Text, Calculator.calculator.tbDEFPercent.Text, Calculator.calculator.tbEM.Text, Calculator.calculator.tbRecharge.Text, Calculator.calculator.tbCritRate.Text, Calculator.calculator.tbCritDMG.Text);
                SetOriginalSuitableCharacters(SuitableCharacters);
                Calculator.calculator.tbText.Visibility = Visibility.Visible;
            }
            else { MessageBox.Show("Не все значения выбраны."); }
        }
        //Очистка
        private RelayCommand cancelWnd;
        public RelayCommand CancelWnd
        {
            get
            {
                return cancelWnd ?? new RelayCommand(obj =>
                {
                    CanselWndMethod();
                });
            }
        }
        public void CanselWndMethod()
        {
            Calculator.calculator.cbPiece.SelectedIndex = -1;
            Calculator.calculator.cbMainStat.ItemsSource = ArtifactServices.GetMainStatsName();
            Calculator.calculator.cbMainStat.SelectedIndex = -1;
            Calculator.calculator.cbSet.SelectedIndex = -1;

            Calculator.calculator.tbATKPercent.Text = string.Empty;
            Calculator.calculator.tbHPPercent.Text = string.Empty;
            Calculator.calculator.tbDEFPercent.Text = string.Empty;
            Calculator.calculator.tbRecharge.Text = string.Empty;
            Calculator.calculator.tbEM.Text = string.Empty;
            Calculator.calculator.tbCritDMG.Text = string.Empty;
            Calculator.calculator.tbCritRate.Text = string.Empty;

            Calculator.calculator.tbText.Visibility = Visibility.Collapsed;
            SuitableCharacters.Clear();
        }
        //Поиск
        private List<Character> _originalSuitableCharacters = new List<Character>();
        public void SetOriginalSuitableCharacters(List<Character> characters)
        {
            _originalSuitableCharacters = characters;
        }
        private string _search;
        public string Search
        {
            get { return _search; }
            set
            {
                _search = value;
                NotifyPropertyChanged(nameof(Search));
                FilterCharacters();
            }
        }
        public void FilterCharacters()
        {
            if (string.IsNullOrEmpty(Search))
            {
                SuitableCharacters = _originalSuitableCharacters;
            }
            else
            {
                SuitableCharacters = _originalSuitableCharacters
                    .Where(c => c.NameCharacter.ToLower().Contains(Search.ToLower()))
                    .ToList();
            }
        }
    }
}
