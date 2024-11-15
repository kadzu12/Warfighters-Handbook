using System.Collections.ObjectModel;
using System.Windows.Controls;
using Warfighters.Models;
using Warfighters.Models.Data;

namespace Warfighters.Views
{

    public partial class SetInfo : Page
    {
        public SetArtifact SetArtifact { get; set; }
        public ObservableCollection<Character> Characters { get; set; }
        public SetInfo(SetArtifact set)
        {
            InitializeComponent();

            SetArtifact = set;
            DataContext = this;
            using (HoyoverseContext db = new HoyoverseContext())
            {
                var characters = db.Characters
                    .Where(c => c.IdSignatureSetArtifact == set.IdSet || c.IdSets.Contains(set))
                    .ToList();
                Characters = new ObservableCollection<Character>(characters);
            }
            if (Characters.Count != 0)
            {
                foreach (var character in Characters)
                {
                    itemsLV.Items.Add(new UserControleImage(character));
                }
                tbText.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                tbText.Visibility = System.Windows.Visibility.Visible;
                itemsLV.Visibility = System.Windows.Visibility.Collapsed;
            }
        }
    }
}
