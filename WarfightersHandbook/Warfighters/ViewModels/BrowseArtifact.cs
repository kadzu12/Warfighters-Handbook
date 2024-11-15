using DevExpress.Mvvm;
using System.ComponentModel;
using Warfighters.Models;
using Warfighters.Services;
using Warfighters.Views;

namespace Warfighters.ViewModels
{
    class BrowseArtifact : BindableBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private List<SetArtifact> setArtifacts = ArtifactServices.GetSetArtifact();
        public List<SetArtifact> SetArtifacts
        {
            get { return setArtifacts; }
            set
            {
                setArtifacts = value;
                NotifyPropertyChanged(nameof(SetArtifact));
                NotifyPropertyChanged(nameof(UserControlArtefacts));
            }
        }
        public List<UserControlArtefact> UserControlArtefacts
        {
            get { return SetArtifacts.Select(s => new UserControlArtefact(s)).ToList(); }
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
            if (string.IsNullOrEmpty(Search)) { SetArtifacts = ArtifactServices.GetSetArtifact(); }
            else
            {
                SetArtifacts = ArtifactServices.GetSetArtifact().Where(s => s.NameSet.ToLower().Contains(Search.ToLower())).ToList();
            }
        }
        public BrowseArtifact()
        {
            SetArtifacts = ArtifactServices.GetSetArtifact();
        }
    }
}
