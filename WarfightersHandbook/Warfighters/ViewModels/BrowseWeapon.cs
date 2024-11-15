using DevExpress.Mvvm;
using System.ComponentModel;
using Warfighters.Models;
using Warfighters.Services;
using Warfighters.Views;

namespace Warfighters.ViewModels
{
    class BrowseWeapon : BindableBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private List<Weapon> weapons = WeaponServices.GetWeapon();
        public List<Weapon> Weapons
        {
            get { return weapons; }
            set
            {
                weapons = value;
                NotifyPropertyChanged(nameof(Weapons));
                NotifyPropertyChanged(nameof(UserControlWeapons));
            }
        }
        public List<UserControlWeapons> UserControlWeapons
        {
            get { return Weapons.Select(w => new UserControlWeapons(w)).ToList(); }
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
            if (string.IsNullOrEmpty(Search)) { Weapons = WeaponServices.GetWeapon(); }
            else
            {
                Weapons = WeaponServices.GetWeapon().Where(w => w.NameWeapon.ToLower().Contains(Search.ToLower())).ToList();
            }
        }
        public BrowseWeapon()
        {
            Weapons = WeaponServices.GetWeapon();
        }
    }
}
