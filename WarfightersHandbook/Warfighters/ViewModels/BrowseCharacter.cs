using DevExpress.Mvvm;
using System.ComponentModel;
using Warfighters.Models;
using Warfighters.Services;
using Warfighters.Views;

namespace Warfighters.ViewModels
{
    public class BrowseCharacter : BindableBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private List<Character> characters = CharacterServices.GetCharacters();
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

        private string search;
        public string Search
        {
            get { return search; }
            set
            {
                search = value;
                NotifyPropertyChanged(nameof(Search));
                FilterCharacters();
            }
        }

        private void FilterCharacters()
        {
            if (string.IsNullOrEmpty(Search)) { Characters = CharacterServices.GetCharacters(); }
            else
            {
                Characters = CharacterServices.GetCharacters().Where(c => c.NameCharacter.ToLower().Contains(Search.ToLower())).ToList();
            }
        }

        public BrowseCharacter()
        {
            Characters = CharacterServices.GetCharacters();
        }
    }
}
