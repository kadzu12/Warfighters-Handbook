using DevExpress.Mvvm;
using System.ComponentModel;
using Warfighters.Models;
using Warfighters.Services;
using Warfighters.Views;

namespace Warfighters.ViewModels
{
    public class BrowseTierList : BindableBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private List<Character> characters = CharacterServices.GetTolViewedCharacters();
        public List<Character> Characters
        {
            get { return characters; }
            set
            {
                characters = value;
                NotifyPropertyChanged(nameof(Characters));
                NotifyPropertyChanged(nameof(UserControleImages));
            }
        }

        public List<UserControleImage> UserControleImages
        {
            get { return Characters.Select(c => new UserControleImage(c)).ToList(); }
        }

        public BrowseTierList()
        {
            Characters = CharacterServices.GetTolViewedCharacters();
        }
    }
}
